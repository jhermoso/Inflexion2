

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
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdentifier"></typeparam>
    public class EntityReflection<TEntity, TIdentifier> 
    where TEntity :class, IEntity<TIdentifier>, IEquatable<TEntity>
    where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static PropertyInfo[] GetEntityProperties()
        {
            PropertyInfo[] properties;
            properties = typeof(TEntity).GetProperties().Where(c => c.MemberType == MemberTypes.Property).ToArray();
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
            properties = typeof(TEntity).GetProperties().Where(c => c.PropertyType.ImplementsIEnumerable() && c.PropertyType != typeof(String)).ToArray();
            return properties;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static PropertyInfo[] GetParentProperties()
        {
            PropertyInfo[] properties;
            properties = typeof(TEntity).GetProperties().Where(c => !c.PropertyType.ImplementsIEnumerable() && (c.ImplementsIEntity() || c.ImplementsIValueObject())).ToArray();
            return properties;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public static class EntityReflectionExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool ImplementsIEntity(this object content)
        {
            return content.GetType()
                           .GetInterfaces()
                           .Any(t => t == typeof(IDomainEntity));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool ImplementsIValueObject(this object content)
        {
            return content.GetType()
                           .GetInterfaces()
                           .Any(t => t == typeof(IValueObject));
        }
    }
}
