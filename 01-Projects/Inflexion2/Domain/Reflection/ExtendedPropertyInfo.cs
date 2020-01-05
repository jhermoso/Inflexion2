

namespace Inflexion2.Domain.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class ExtendedPropertyInfo 
    {
        /// <summary>
        /// Original property info
        /// </summary>
        public PropertyInfo PI { get; private set; }

        public string OwnerClassName { get; private set; }
        public string PropertyName { get; private set; }

        public string WholeName
        {
            get
            {
                return String.Format("{0}.{1}",this.OwnerClassName, this.PropertyName);
            }
        }

        public bool IsSystemType { get; private set; }
        public bool IsChildren { get; private set; }
        public bool IsParent { get; private set; }

        public ExtendedPropertyInfo(PropertyInfo p, string className , string propertyName, bool isSystem, bool isChildren, bool isParent)
        {
            this.PI = p;
            this.OwnerClassName = className;
            this.PropertyName = propertyName;
            this.IsSystemType = isSystem;
            this.IsChildren = isChildren;
            this.IsParent = isParent;
        }
    }
}
