

namespace Inflexion2.Domain.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Reflection;

    public class ReflectionTools
    {
        /// <summary>
        /// Gets the list of all public properties including parents and children from a root aggregate type
        /// </summary>
        /// <param name="rootType"> the type to study</param>
        /// <param name="allowedAggregates">the list of classes names to include in the study parents and childrens</param>
        /// <param name="excludedProperties">List of properties that are not included </param>
        /// <returns></returns>
        public static  List<ExtendedPropertyInfo> GetRecursivePublicPropertiesFromClass( Type rootType, string[] allowedAggregates, string[] excludedProperties ,LinkedList<Type> visitedTypes = null)
        {
            List<ExtendedPropertyInfo> result = new List<ExtendedPropertyInfo>();

            PropertyInfo[] properties;
            properties = rootType.GetProperties();

            if (visitedTypes == null)
            {
                visitedTypes = new LinkedList<Type>();
                visitedTypes.AddFirst(rootType);
            }
            else
            {
                //if (visitedTypes.Contains(rootType))
                //{
                //    return result;
                //}
                //else
                //{
                    visitedTypes.AddLast(rootType);
                //}
            }

            var allowedProperties = properties.Where(c => allowedAggregates.Contains(c.DeclaringType.Name) && c.IsAllowed(rootType, excludedProperties));
            var standarProperties = allowedProperties.Where(c => c.PropertyType.Namespace.Equals("System"));
            var genericProperties = allowedProperties.Where(c => !(c.PropertyType.Namespace.Equals("System")));
            // for net4.5
            //var childrenProperties = genericProperties.Where(c => c.PropertyType.IsGenericType && c.PropertyType.GenericTypeArguments.Any() && allowedAggregates.Contains(c.PropertyType.GenericTypeArguments[0].Name));
            var childrenProperties = genericProperties.Where(c => c.PropertyType.IsGenericType && c.PropertyType.IsGenericTypeDefinition /*&& allowedAggregates.Contains(c.PropertyType.GenericTypeArguments[0].Name)*/);

            var parentProperties = genericProperties.Where(c => !(c.PropertyType.IsGenericType) && allowedAggregates.Contains(c.PropertyType.Name));

            foreach (PropertyInfo property in parentProperties)
            {
                if (visitedTypes.Contains(property.PropertyType))
                {
                    var allowedInnerProperties = properties.Where(c => allowedAggregates.Contains(c.DeclaringType.Name) && c.IsAllowed(rootType, excludedProperties));
                    var standarInnerProperties = allowedInnerProperties.Where(c => c.PropertyType.Namespace.Equals("System"));
                    var genericInnerProperties = allowedInnerProperties.Where(c => !(c.PropertyType.Namespace.Equals("System")));
                    // for net4.5
                    //var childrenInnerProperties = genericInnerProperties.Where(c => c.PropertyType.IsGenericType && c.PropertyType.GenericTypeArguments.Any() && allowedAggregates.Contains(c.PropertyType.GenericTypeArguments[0].Name));
                    var childrenInnerProperties = genericInnerProperties.Where(c => c.PropertyType.IsGenericType && c.PropertyType.IsGenericTypeDefinition   /* && allowedAggregates.Contains(c.PropertyType.GenericTypeArguments[0].Name)*/);
                    var parentInnerProperties = genericInnerProperties.Where(c => !(c.PropertyType.IsGenericType) && allowedAggregates.Contains(c.PropertyType.Name));

                    //is possible to repeat category parents (leaves in a tree) but not complex parents (nodes in graphs)
                    if (childrenInnerProperties.Any() || parentInnerProperties.Any() /*|| visitedTypes.First() == property.PropertyType*/)
                    {
                        continue;
                    }

                }

                var newProperties = GetRecursivePublicPropertiesFromClass(property.PropertyType, allowedAggregates, excludedProperties, visitedTypes);
                foreach (var parentProperty in newProperties)
                {
                    result.Add(new ExtendedPropertyInfo(property, parentProperty.OwnerClassName, parentProperty.PropertyName, false, false, true));
                }   
            }

            foreach (PropertyInfo property in standarProperties)
            {
                result.Add(new ExtendedPropertyInfo(property, rootType.Name, property.Name, true, false, false));
            }

            foreach (PropertyInfo property in childrenProperties)
            {
                if (visitedTypes.Contains(property.PropertyType))
                {
                    continue;
                }

                var temp = property.PropertyType.GetProperties();
                var innerTypes = property.PropertyType.GetProperties().Where(c => allowedAggregates.Contains(c.PropertyType.Name)).Select(c => c.PropertyType);//Last().GetType();
                foreach (var innerType in innerTypes)
                {
                    var newProperties = GetRecursivePublicPropertiesFromClass(innerType, allowedAggregates, excludedProperties, visitedTypes);
                    foreach (var childProperty in newProperties)
                    {
                        result.Add(new ExtendedPropertyInfo(property, childProperty.OwnerClassName, childProperty.PropertyName, false, true, false));
                    }
                }
            }

            return result;
        }
    }
}
