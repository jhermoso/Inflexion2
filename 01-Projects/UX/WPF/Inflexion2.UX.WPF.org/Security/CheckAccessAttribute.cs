using System;

namespace Inflexion2.UX.WPF.Security
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