

namespace DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Remoting;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Wrapper record is a record where all the properties are wrapped 
    /// </summary>
    public class WrapperRecord : DynamicObject, ICustomTypeDescriptor/*, INotifyPropertyChanged*/
    {
        internal Dictionary<string, WrapperProperty> columns = new Dictionary<string, WrapperProperty>();
        internal ExtendedPropertyInfo[] internalProperties;

        private WrapperRecord()
        { }
        public WrapperRecord(ExtendedPropertyInfo[] internalProperties)
        {
            this.internalProperties = internalProperties;

            foreach (var property in this.internalProperties)
            {
                string tkey = property.WholeName;
                this.columns.Add(tkey, new WrapperProperty());
            }
        }  

        // indexer by dynamic properties
        public dynamic this[string key]
        {
            get
            {
                WrapperProperty wrapperValue;
                columns.TryGetValue(key, out wrapperValue);
                if (wrapperValue.PropertyValue != null)
                    return wrapperValue.PropertyValue;

                return string.Empty;
            }

            set
            {
                if (value != null )
                {
                    if (value.GetType() == typeof(WrapperProperty))
                    {
                        columns[key] = value;
                    }

                    else
                    {
                        columns[key].PropertyValue = value;
                    }
                }
            }
        }

        #region INotifyPropertyChanged implementation
        //public event PropertyChangedEventHandler PropertyChanged;

        ///// <summary>
        ///// https://www.danrigby.com/2015/09/12/inotifypropertychanged-the-net-4-6-way/
        ///// </summary>
        ///// <param name="propertyName"></param>
        //protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="field"></param>
        ///// <param name="value"></param>
        ///// <param name="propertyName"></param>
        ///// <returns></returns>
        //protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        //{
        //    if (EqualityComparer<T>.Default.Equals(field, value))
        //        return false;
        //    field = value;
        //    //OnPropertyChanged(propertyName);
        //    return true;
        //}
        #endregion
        internal WrapperRecord Copy()
        {
            WrapperRecord newWrapperRecord = new WrapperRecord(this.internalProperties);
            foreach (var wrapper in this.columns)
            {
                newWrapperRecord[wrapper.Key] = wrapper.Value;
            }

            return newWrapperRecord;
        }

        internal WrapperRecord CopyAfterType(Type limit)
        {
            WrapperRecord newWrapperRecord = new WrapperRecord(this.internalProperties);
            bool empty = true; 
            foreach (var wrapper in this.columns)
            {
                if (wrapper.Key.StartsWith(limit.Name))   
                    empty = false;                

                if (empty)
                    newWrapperRecord[wrapper.Key] = new WrapperProperty();
                else
                    newWrapperRecord[wrapper.Key] = wrapper.Value;
            }

            return newWrapperRecord;
        }


        internal WrapperRecord CopyExceptRepeated(WrapperRecord lastRecord)
        {
            WrapperRecord newWRecord = new WrapperRecord(this.internalProperties);
            foreach (var wrapper in this.columns)
            {
                var lastType = lastRecord.columns[wrapper.Key].GetInternalType();
                var lastId = lastRecord.columns[wrapper.Key].GetId();
                var lastName = lastRecord.columns[wrapper.Key].GetPropertyName();
                var lastValue = lastRecord.columns[wrapper.Key];

                var newType = this.columns[wrapper.Key].GetInternalType();
                var newId = this.columns[wrapper.Key].GetId();
                var newName = this.columns[wrapper.Key].GetPropertyName();
                var newValue = this.columns[wrapper.Key];

                if (lastType == newType && lastId == newId && lastName == newName && lastValue == newValue) 
                {
                    newWRecord[wrapper.Key] = new WrapperProperty();
                }
                else
                {
                    newWRecord[wrapper.Key] = wrapper.Value;
                }
                
            }

            return newWRecord;
        }

        #region ICustomTypeDescriptor implementation
        public AttributeCollection GetAttributes()
        {
            return null;
        }

        public string GetClassName()
        {
            return "WrapperRecord";
        }

        public string GetComponentName()
        {
            return null;
        }

        public TypeConverter GetConverter()
        {
            return null;
        }

        public EventDescriptor GetDefaultEvent()
        {
            return null;
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        public object GetEditor(Type editorBaseType)
        {
            return null;
        }

        public EventDescriptorCollection GetEvents()
        {
            return null;
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return null;
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return new PropertyDescriptorCollection(this.columns.Keys.Select(key => new WrapperPropertyDescriptor(key)).ToArray());
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return null;
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
           
            return null;
        }
        #endregion

        #region override of DynamicObject methods to drive the set and get 


        public override IEnumerable<string> GetDynamicMemberNames()
        {
            //return base.GetDynamicMemberNames();
            return this.columns.Keys;
        }

        /// <summary>
        /// Overrides the TryGetMember method of the DynamicObject class. 
        /// The TryGetMember method is called when a member of a 
        /// dynamic class is requested and no arguments are specified. 
        /// </summary>
        /// <param name="binder">The binder argument contains information about the referenced 
        /// member, and the result argument references the result returned 
        /// for the specified member.</param>
        /// <param name="result">The TryGetMember method returns a 
        /// Boolean value that returns true if the requested member exists; 
        /// otherwise it returns false.</param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            //return base.TryGetMember(binder, out result);

            if ( this.columns.Keys.Contains(binder.Name))
            {
                result = this.columns[binder.Name].PropertyValue;
                return true;
            }

            result = null;
            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            //return base.TrySetMember(binder, value);
            if (this.columns.Keys.Contains(binder.Name) )
            {
                this.columns[binder.Name].PropertyValue = value;
                return true;
            }

            return false;
        }

        #endregion
    }
}
