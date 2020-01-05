

namespace Inflexion2.Domain.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Reflection;
    using Reflection;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TValueObject"></typeparam>
    public class ValueObjectReflection<TValueObject> 
    where TValueObject : ValueObject<TValueObject>, IValueObject, /*IComparable<TValueObject>,*/ IEquatable<TValueObject>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static PropertyInfo[] GetValueObjectProperties()
        {
            PropertyInfo[] properties;
            properties = typeof(TValueObject).GetProperties().Where(c => c.MemberType == MemberTypes.Property).ToArray();
            var selectedProperties = properties.Where(c => c.PropertyType.FullName.StartsWith("System") && c.PropertyType.FullName.Split('.').Count() == 2).ToArray();
            var selectedProperties1 = properties.Where(c => !(c.PropertyType.FullName.StartsWith("System") && c.PropertyType.FullName.Split('.').Count() == 2)).ToArray();
            var selectedProperties2 = selectedProperties.Where(c => c.PropertyType.IsClass).ToArray();

            return selectedProperties1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static PropertyInfo[] GetChildrenProperties()
        {
            PropertyInfo[] properties;
            properties = typeof(TValueObject).GetProperties().Where(c => c.PropertyType.ImplementsIEnumerable()).ToArray();
            return properties;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static PropertyInfo[] GetParentProperties()
        {
            PropertyInfo[] properties;
            properties = typeof(TValueObject).GetProperties().Where(c => !c.PropertyType.ImplementsIEnumerable() && (c.ImplementsIEntity() || c.ImplementsIValueObject())).ToArray();
            return properties;
        }
    }
}
