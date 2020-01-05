

namespace Needel.Common.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// coomon funcionalities to read and setup application settings from
    /// diferent sources. app.config web.config, database or xml files
    /// </summary>
    public partial class SetupNeedelAppSettings : Inflexion2.Infrastructure.ApplicationSettings
    {
        #region constructors

        /// <summary>
        /// create instance of SetupNeedelAppSettings to read, and provide appsetings values to Needel's module.
        /// </summary>
        public SetupNeedelAppSettings(string[] args = null) :base()
        {
            SetLogger(this.GetType());
            this.Logger.Debug(string.Format(CultureInfo.InvariantCulture, "Created SetupNeedelAppSettings"));
            this.userKey = "kbGtg5euTZPUtafUw"; // encripting key for user
            this.passwordKey = "t7SB5gftqkkdTgLdH"; // encripting key for password
            ReadBasicPropertiesFromConfig(args);
            LoadDatabaseProperties();
        }
        #endregion
    }
}
