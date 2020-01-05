

namespace Inflexion2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Vocabulary of string contants to use like arguments in the application from console or appsetings in config file module
    /// </summary>
    public static class Arguments
    {
        /// <summary>
        /// Argument command to indicate the selected Database by the name of the conecction.
        /// </summary>
        /// <remarks> The connection string list is usally in xml file for configuration</remarks>
        public const string DbConnect = @"\db=";

        /// <summary>
        /// Argument command to enforce the use of any appsetting over the options in the database. 
        /// </summary>
        public const string AppSetting = @"\as;";

        /// <summary>
        /// Argument command to get help about arguments. 
        /// </summary>
        public const string HelpShort = @"\?";

        /// <summary>
        /// Argument command to get help about arguments. 
        /// </summary>
        public const string Help = @"\help";

        /// <summary>
        /// Argument command to get help about arguments. 
        /// </summary>
        public const string Admin = @"\admin";
    }
}
