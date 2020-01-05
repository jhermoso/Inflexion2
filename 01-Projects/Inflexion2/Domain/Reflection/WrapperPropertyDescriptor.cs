

namespace DB
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// https://jopinblog.wordpress.com/2007/05/12/dynamic-propertydescriptors-with-anonymous-methods/
    /// </summary>
    public class WrapperPropertyDescriptor : PropertyDescriptor
    {
        public delegate object DynamicGetValue(object component);
        public delegate void DynamicSetValue(object component, object newValue);

        protected Type _componentType;
        protected Type _propertyType;
        protected DynamicGetValue _getDelegate;
        protected DynamicSetValue _setDelegate;

        /// <summary>
        /// for read only dynamic properties
        /// </summary>
        /// <param name="name"></param>
        public WrapperPropertyDescriptor(string name) 
            : base(name, null)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="componentType"></param>
        /// <param name="name"></param>
        /// <param name="propertyType"></param>
        /// <param name="getDelegate"></param>
        /// <param name="setDelegate"></param>
        public WrapperPropertyDescriptor(Type componentType, string name, Type propertyType, DynamicGetValue getDelegate, DynamicSetValue setDelegate)
            : base(name, null)
        {
            _componentType = componentType;
            _propertyType = propertyType;
            _getDelegate = getDelegate;
            _setDelegate = setDelegate;
        }

        public override object GetValue(object component)
        {
            if (_getDelegate == null)
                return ((WrapperRecord)component)[Name];
            else
                return _getDelegate(component);
        }
        public override void SetValue(object component, object value)
        {
            
            if (_setDelegate == null)
                ((WrapperRecord)component)[Name] = value;
            else
                _setDelegate(component, value);
        }
        public override void ResetValue(object component)
        {
            if (_setDelegate == null)
                ((WrapperRecord)component)[Name] = null;
            else
                SetValue(component, null);
        }
        public override bool CanResetValue(object component)
        {
            if (_setDelegate == null)
                return false;
            else
                return true;
        }
        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
        public override Type PropertyType
        {
            get
            {
                if (_propertyType == null)
                    return typeof(Object);
                else
                    return _propertyType;
            }
        }
        public override bool IsReadOnly
        {
            get { return false; /*_setDelegate == null;*/ }
        }
        public override Type ComponentType
        {
            get
            {
                if (_componentType == null)
                    return typeof(WrapperRecord);
                else
                    return _componentType;
            }
        }
    }
}
