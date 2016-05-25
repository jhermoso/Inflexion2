namespace Inflexion.Framework.UX.Windows.Security
{
    /// <summary>
    /// The provider for authorization level base on security name. 
    /// </summary>
    public interface IAccessLevelProvider
    {
        /// <summary>
        /// Gets the auth level base on permission name (string).
        /// </summary>
        /// <param name="securityName">Name of the security.</param>
        /// <returns></returns>
        AccessLevel GetAccessLevel(string permissionName);
    }
}