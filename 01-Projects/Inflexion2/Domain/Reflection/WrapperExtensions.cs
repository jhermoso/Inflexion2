

namespace Inflexion2.Domain.Reflection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public static class WrapperExtensions
    {
        //public static WrapperPropertyDescriptor PropertyDescriptor(this PropertyInfo propertyInfo, string newName = null)
        //{
        //    var temp = TypeDescriptor.GetProperties(propertyInfo.DeclaringType)[propertyInfo.Name];
        //    return (WrapperPropertyDescriptor)temp;
        //}

        public static IEnumerable Cast(this IEnumerable self, Type innerType)
        {
            var methodInfo = typeof (Enumerable).GetMethod("Cast");
            var genericMethod = methodInfo.MakeGenericMethod(innerType);
            return genericMethod.Invoke(null, new [] {self}) as IEnumerable;
        }

        /// <summary>
        /// check if object implemnts ienumerable interface by reflection
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool ImplementsIEnumerable(this object content)
        {
            return content.GetType()
                           .GetInterfaces()
                           .Any(t => t == typeof(IEnumerable<>));
        }

        /// <summary>
        /// indicates if a property of a class type is in the array of excluded properties or not.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="row"></param>
        /// <param name="classType"></param>
        /// <param name="excludedProperties"></param>
        /// <returns></returns>
        public static bool IsAllowed(this PropertyInfo property, object row, Type classType, string[] excludedProperties)
        {
            PropertyInfo propertyInfo = row.GetType().GetProperty(property.Name);
            string tkey = string.Format("{0}.{1}", classType.Name, propertyInfo.Name);
            bool result = !excludedProperties.Contains(tkey);
            return result;
        }

        public static bool IsAllowed(this PropertyInfo property, Type classType, string[] excludedProperties)
        {
            PropertyInfo propertyInfo = classType.GetProperty(property.Name);
            string tkey = string.Format("{0}.{1}", classType.Name, propertyInfo.Name);
            bool result = !excludedProperties.Contains(tkey);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="row"></param>
        /// <param name="allowedAggregates"></param>
        /// <returns></returns>
        public static bool IsEnumerableGeneric(this PropertyInfo property, object row, string[] allowedAggregates)
        {
            var innerproperties = property.PropertyType.GetProperties();
            var innerProperty = property.PropertyType.GetProperties().Where(c => allowedAggregates.Contains(c.PropertyType.Name)).First();
            var innerContent = row.GetType().GetProperty(property.Name).GetValue(row, null);
            bool result = innerContent.ImplementsIEnumerable();
      
            return result;
        }


    }
}
