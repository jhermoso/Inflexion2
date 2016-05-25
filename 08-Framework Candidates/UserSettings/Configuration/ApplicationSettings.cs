// -- FILE ------------------------------------------------------------------
// name       : ApplicationSettings.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------


namespace I3TV.Framework.UserInterface.Wpf.Utilities.Configuration
{
    using System.Configuration;


    // ------------------------------------------------------------------------
    public class ApplicationSettings : ApplicationSettingsBase
    {

        // ----------------------------------------------------------------------
        public event SettingValueCancelEventHandler SettingSaving;
        public event SettingValueCancelEventHandler SettingLoading;
        public event SettingCollectorCancelEventHandler CollectingSetting;

        // ----------------------------------------------------------------------
        public const string UpgradeSettingsKey = "UpgradeSettings";

        // ----------------------------------------------------------------------
        public ApplicationSettings(object obj) :
            this(obj.GetType().Name, obj)
        {
        } // ApplicationSettings

        // ----------------------------------------------------------------------
        public ApplicationSettings(string settingsKey) :
            this(settingsKey, null)
        {
        } // ApplicationSettings

        // ----------------------------------------------------------------------
        public ApplicationSettings(string settingsKey, object obj) :
            base(settingsKey)
        {
            this.settings = new SettingCollection(this);

            // provider
            this.defaultProvider = new LocalFileSettingsProvider();
            this.defaultProvider.Initialize("LocalFileSettingsProvider", null);
            this.Providers.Add(this.defaultProvider);

            // upgrade
            this.upgradeSettings = new ValueSetting(UpgradeSettingsKey, typeof(bool), true);
            this.UseAutoUpgrade = true;

            if (obj != null)
            {
                this.Settings.AddAll(obj);
            }
        } // ApplicationSettings

        // ----------------------------------------------------------------------
        public SettingsProvider DefaultProvider
        {
            get { return this.defaultProvider; }
        } // DefaultProvider

        // ----------------------------------------------------------------------
        public SettingCollection Settings
        {
            get { return this.settings; }
        } // Settings

        // ----------------------------------------------------------------------
        public SettingCollectorCollection SettingCollectors
        {
            get
            {
                if (this.settingCollectors == null)
                {
                    this.settingCollectors = new SettingCollectorCollection(this);
                    this.settingCollectors.CollectingSetting += this.SettingCollectorsCollectingSetting;
                }
                return this.settingCollectors;
            }
        } // SettingCollectors

        // ----------------------------------------------------------------------
        public bool UseAutoUpgrade
        {
            get { return this.settings.Contains(this.upgradeSettings); }
            // ReSharper disable ValueParameterNotUsed
            set
            // ReSharper restore ValueParameterNotUsed
            {
                if (this.UseAutoUpgrade)
                {
                    return;
                }
                this.settings.Add(this.upgradeSettings);
            }
        } // UseAutoUpgrade

        // ----------------------------------------------------------------------
        public static string UserConfigurationFilePath
        {
            get
            {
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                return config.FilePath;
            }
        } // UserConfigurationFilePath

        // ----------------------------------------------------------------------
        public void Load()
        {
            Load(true);
        } // Load

        // ----------------------------------------------------------------------
        public virtual void Load(bool upgrade)
        {
            this.CollectSettings();
            this.LoadSettings();
            if (!upgrade)
            {
                return;
            }

            if ((bool)this.upgradeSettings.Value)
            {
                Upgrade();
                this.upgradeSettings.Value = false;
            }
            this.LoadSettings();
        } // Load

        // ----------------------------------------------------------------------
        public new virtual void Reload()
        {
            base.Reload();
            this.LoadSettings();
        } // Reload

        // ----------------------------------------------------------------------
        public new virtual void Reset()
        {
            base.Reset();
            this.LoadSettings();
        } // Reload

        // ----------------------------------------------------------------------
        public override void Save()
        {
            this.SaveSettings();
            base.Save();
        } // Save

        // ----------------------------------------------------------------------
        private void CollectSettings()
        {
            if (this.settingCollectors == null)
            {
                return; // no colectors present
            }
            this.settingCollectors.Collect();
        } // CollectSettings

        // ----------------------------------------------------------------------
        private void LoadSettings()
        {
            foreach (ISetting userSetting in this.settings)
            {
                if (this.SettingLoading != null)
                {
                    userSetting.ValueLoading += this.UserSettingLoading;
                }
                userSetting.Load();
                if (this.SettingLoading != null)
                {
                    userSetting.ValueLoading -= this.UserSettingLoading;
                }
            }
        } // LoadSettings

        // ----------------------------------------------------------------------
        private void SaveSettings()
        {
            foreach (ISetting userSetting in this.settings)
            {
                if (this.SettingSaving != null)
                {
                    userSetting.ValueSaving += this.UserSettingSaving;
                }
                userSetting.Save();
                if (this.SettingSaving != null)
                {
                    userSetting.ValueSaving -= this.UserSettingSaving;
                }
            }
        } // SaveSettings

        // ----------------------------------------------------------------------
        protected virtual void OnCollectingSetting(SettingCollectorCancelEventArgs e)
        {
            if (this.CollectingSetting != null)
            {
                this.CollectingSetting(this, e);
            }
        } // OnCollectingSetting

        // ----------------------------------------------------------------------
        private void UserSettingSaving(object sender, SettingValueCancelEventArgs e)
        {
            if (this.SettingSaving != null)
            {
                this.SettingSaving(sender, e);
            }
        } // UserSettingSaving

        // ----------------------------------------------------------------------
        private void UserSettingLoading(object sender, SettingValueCancelEventArgs e)
        {
            if (this.SettingLoading != null)
            {
                this.SettingLoading(sender, e);
            }
        } // UserSettingLoading

        // ----------------------------------------------------------------------
        private void SettingCollectorsCollectingSetting(object sender, SettingCollectorCancelEventArgs e)
        {
            this.OnCollectingSetting(e);
        } // SettingCollectorsCollectingSetting

        // ----------------------------------------------------------------------
        // members
        private readonly LocalFileSettingsProvider defaultProvider = new LocalFileSettingsProvider();
        private readonly SettingCollection settings;
        private SettingCollectorCollection settingCollectors;
        private readonly ValueSetting upgradeSettings;

    } // class ApplicationSettings

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
