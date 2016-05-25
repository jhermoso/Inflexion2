using System;

namespace Inflexion.Framework.UX.Windows.Security
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class CheckAccessAttribute : Attribute
    {
        public CheckAccessAttribute() : this(string.Empty)
        {
        }

        public CheckAccessAttribute(string permissionName)
        {
            this.PermissionName = permissionName;
        }

        public string PermissionName { get; set; }
    }
}