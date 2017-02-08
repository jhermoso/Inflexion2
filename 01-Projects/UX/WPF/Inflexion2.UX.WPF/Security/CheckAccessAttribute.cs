namespace Inflexion2.UX.WPF.Security
{
    using System;

    /// <summary>
    /// using System;
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class CheckAccessAttribute : Attribute
    {
        /// <summary>
        /// using System;
        /// </summary>
        public CheckAccessAttribute() : this(string.Empty)
        {
        }

        /// <summary>
        /// using System;
        /// </summary>
        /// <param name="permissionName"></param>
        public CheckAccessAttribute(string permissionName)
        {
            this.PermissionName = permissionName;
        }

        /// <summary>
        /// using System;
        /// </summary>
        public string PermissionName { get; set; }
    }
}