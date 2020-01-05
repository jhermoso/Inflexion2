

namespace DB
{
    using System;
    using System.Collections.Generic;

    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Dynamic;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using CustomExtensions;
    using System.Collections;
    using Business;

    /// <summary>
    /// 
    /// </summary>
    public class WrapperRecordList: List<WrapperRecord>,  ITypedList/*, INotifyPropertyChanged*/
    {
        #region fields
        private ExtendedPropertyInfo[] internalProperties;
        //private List<WrapperRecord> wrapperFields;
        private WrapperPropertyDescriptor[] propertiesDescriptions;
        #endregion

        public List<string> Columns { get; private set; }

        #region Constructors
        public WrapperRecordList()
        {
            this.Columns = new List<string>();
        }

        public WrapperRecordList(List<ExtendedPropertyInfo> properties)
            :this()
        {
            this.internalProperties = properties.ToArray();
            foreach (var property in this.internalProperties)
            {
                string tkey = property.WholeName;
                Columns.Add(tkey);
            }
        }

        public List<WrapperRecord> GetRecursiveContent(Object content, string[] allowedAggregates, string[] excludedProperties, WrapperRecord currentRecord = null, bool repeatValues = true, bool startingNewRecord = true)
        {
            if (currentRecord == null)
            {
                currentRecord = new WrapperRecord(this.internalProperties);
            }

            List<WrapperRecord> result = new List<WrapperRecord>();
            bool IsAddedInInnerClass = false;
            Type contentType = content.GetType(); // gets the type of the parameter
            WrapperRecord record;
            WrapperProperty wraper;
            PropertyInfo propertyInfo;

            if (content.ImplementsIEnumerable())  // check if the content is a list or simple object
            {
                Type classType = content.GetType().GenericTypeArguments[0]; // get the underppined type of the collection
                var classProperties = classType.GetProperties();

                var listedContent = (((IList)content).Cast(classType)); // cast the object to an ienumerable version to iterate over it.

                //start iteration over collection to wrapp all properties
                string tkey;
                foreach (var row in listedContent) // iterate over all the content
                {
                    if (repeatValues || startingNewRecord)
                    {
                        record = currentRecord.Copy();
                    }
                    else
                    {
                        record = new WrapperRecord(this.internalProperties);
                    }

                    startingNewRecord = false; // the header is already copied.
                    var IdPropertyValue = (int)row.GetType().GetProperty("Oid").GetValue(row);

                    var allowedProperties = classProperties.Where(c => allowedAggregates.Contains(c.DeclaringType.Name) && c.IsAllowed(classType, excludedProperties));
                    var standarProperties = allowedProperties.Where(c => c.PropertyType.Namespace.Equals("System"));
                    var genericProperties = allowedProperties.Where(c => !(c.PropertyType.Namespace.Equals("System")));
                    var childrenProperties = genericProperties.Where(c => c.PropertyType.IsGenericType && c.PropertyType.GenericTypeArguments.Any() && allowedAggregates.Contains(c.PropertyType.GenericTypeArguments[0].Name));
                    var parentProperties = genericProperties.Where(c => !(c.PropertyType.IsGenericType) && allowedAggregates.Contains(c.PropertyType.Name));

                    foreach (var property in parentProperties) 
                    {
                        Type innerClassType = property.PropertyType;
                        var innerContent = row.GetType().GetProperty(property.Name).GetValue(row);
                        var innerIdPropertyValue = (int)innerClassType.GetProperty("Oid").GetValue(innerContent); // if is a parent has an oid

                        var innerAllowedProperties = innerClassType.GetProperties().Where(c => allowedAggregates.Contains(c.DeclaringType.Name) && c.IsAllowed( innerClassType, excludedProperties));
                        var innerStandarProperties = innerAllowedProperties.Where(c => c.PropertyType.Namespace.Equals("System"));
                        var innerGenericProperties = innerAllowedProperties.Where(c => !(c.PropertyType.Namespace.Equals("System")));
                        //var innerChildrenProperties = innerGenericProperties.Where(c => c.PropertyType.IsGenericType && c.PropertyType.GenericTypeArguments.Any() && allowedAggregates.Contains(c.PropertyType.GenericTypeArguments[0].Name));
                        var innerParentProperties = innerGenericProperties.Where(c => !(c.PropertyType.IsGenericType) && allowedAggregates.Contains(c.PropertyType.Name));

                        foreach (var innerProperty in innerParentProperties)
                        {
                            var innerParentContent = innerContent.GetType().GetProperty(innerProperty.Name).GetValue(innerContent);

                            var newcolumns = GetRecursiveContent(innerParentContent, allowedAggregates, excludedProperties, record, repeatValues);
                            result.AddRange(newcolumns);
                            IsAddedInInnerClass = true;
                            startingNewRecord = false;
                        }

                        foreach (var innerProperty in innerStandarProperties)
                        {
                            var innerPropertyInfo = innerClassType.GetProperty(innerProperty.Name);
                            tkey = string.Format("{0}.{1}", innerClassType.Name, innerProperty.Name);
                            var propertycontent = innerPropertyInfo.GetValue(innerContent);
                            wraper = new WrapperProperty(innerClassType, innerIdPropertyValue, innerPropertyInfo.Name, propertycontent);
                            record[tkey] = wraper;
                        }
                    }

                    foreach (var property in standarProperties)
                    {
                        propertyInfo = property;//row.GetType().GetProperty(property.PropertyName);
                        tkey = string.Format("{0}.{1}", classType.Name, propertyInfo.Name);

                        wraper = new WrapperProperty(classType, IdPropertyValue, propertyInfo.Name, propertyInfo.GetValue(row));
                        record[tkey] = wraper;
                    }

                    foreach (var property in childrenProperties)
                    {
                        var innerContent = row.GetType().GetProperty(property.Name).GetValue(row);
                        var newcolumns = GetRecursiveContent(innerContent, allowedAggregates, excludedProperties, record, repeatValues);
                        result.AddRange(newcolumns);
                        IsAddedInInnerClass = true;
                        startingNewRecord = false;
                    }

                    if (IsAddedInInnerClass)
                    {
                        IsAddedInInnerClass = false;
                    }
                    else
                    {
                        result.Add(record);
                    }

                    startingNewRecord = false;
                }
            }
            else
            {


            }

            return result;
        }

        #endregion

        #region ITypedList implementation

        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (listAccessors == null || listAccessors.Length == 0)
            {
                this.propertiesDescriptions = new WrapperPropertyDescriptor[this.Columns.Count];

                for (int i = 0; i < this.Columns.Count; i++)
                {

                    propertiesDescriptions[i] = new WrapperPropertyDescriptor(this.Columns[i]);
                }

                return new PropertyDescriptorCollection(propertiesDescriptions);
            }
            throw new NotImplementedException("Relations not implemented");
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "TabularView";
        }
        #endregion

     

    }
}
