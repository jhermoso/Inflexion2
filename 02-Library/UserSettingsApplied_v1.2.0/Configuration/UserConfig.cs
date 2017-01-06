// -- FILE ------------------------------------------------------------------
// name       : UserConfig.cs
// created    : Jani Giannoudis - 2008.05.16
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	public class UserConfig
	{

		// ----------------------------------------------------------------------
		public UserConfig( System.Configuration.Configuration configuration )
		{
			if ( configuration == null )
			{
				throw new ArgumentNullException( "configuration" );
			}

			this.configuration = configuration;
		} // UserConfig

		// ----------------------------------------------------------------------
		public System.Configuration.Configuration Configuration
		{
			get { return configuration; }
		} // Configuration

		// ----------------------------------------------------------------------
		public string FilePath
		{
			get { return configuration.FilePath; }
		} // FilePath

		// ----------------------------------------------------------------------
		public string FileName
		{
			get { return new FileInfo( configuration.FilePath ).Name; }
		} // FileName

		// ----------------------------------------------------------------------
		public List<ClientSettingsSection> Sections
		{
			get
			{
				List<ClientSettingsSection> sections = new List<ClientSettingsSection>();

				foreach ( ConfigurationSectionGroup sectionGroup in configuration.SectionGroups )
				{
					UserSettingsGroup userSettingsGroup = sectionGroup as UserSettingsGroup;
					if ( userSettingsGroup == null )
					{
						continue;
					}

					foreach ( ConfigurationSection section in userSettingsGroup.Sections )
					{
						ClientSettingsSection clientSettingsSection = section as ClientSettingsSection;
						if ( clientSettingsSection == null )
						{
							continue;
						}

						sections.Add( clientSettingsSection );
					}
				}

				return sections;
			}
		} // Sections

		// ----------------------------------------------------------------------
		private UserSettingsGroup UserSettingsGroup
		{
			get
			{
				foreach ( ConfigurationSectionGroup sectionGroup in configuration.SectionGroups )
				{
					UserSettingsGroup userSettingsGroup = sectionGroup as UserSettingsGroup;
					if ( userSettingsGroup != null )
					{
						return userSettingsGroup;
					}
				}
				return null;
			}
		} // UserSettingsGroup

		// ----------------------------------------------------------------------
		public void RemoveAllSections()
		{
			UserSettingsGroup userSettingsGroup = UserSettingsGroup;
			if ( userSettingsGroup == null )
			{
				return;
			}
			configuration.SectionGroups.Remove( userSettingsGroup.SectionGroupName );
		} // RemoveAllSections

		// ----------------------------------------------------------------------
		public void RemoveSection( string name )
		{
			if ( string.IsNullOrEmpty( name ) )
			{
				throw new ArgumentNullException( "name" );
			}

			UserSettingsGroup userSettingsGroup = UserSettingsGroup;
			if ( userSettingsGroup == null )
			{
				return;
			}

			ConfigurationSection section = userSettingsGroup.Sections[ name ];
			if ( section == null )
			{
				throw new InvalidOperationException( "invalid section " + name );
			}
			userSettingsGroup.Sections.Remove( name );
		} // RemoveSection

		// ----------------------------------------------------------------------
		public bool HasSameSettings( UserConfig compareUserConfig )
		{
			if ( compareUserConfig == null )
			{
				throw new ArgumentNullException( "compareUserConfig" );
			}

			if ( configuration.SectionGroups.Count != compareUserConfig.configuration.SectionGroups.Count )
			{
				return false;
			}

			foreach ( ConfigurationSectionGroup compareSectionGroup in compareUserConfig.configuration.SectionGroups )
			{
				UserSettingsGroup compareUserSettingsGroup = compareSectionGroup as UserSettingsGroup;
				if ( compareUserSettingsGroup == null )
				{
					continue;
				}

				UserSettingsGroup userSettingsGroup = configuration.SectionGroups[ compareSectionGroup.Name ] as UserSettingsGroup;
				if ( userSettingsGroup == null || userSettingsGroup.Sections.Count != compareSectionGroup.Sections.Count )
				{
					return false;
				}

				foreach ( ConfigurationSection compareSection in compareSectionGroup.Sections )
				{
					ClientSettingsSection compareClientSettingsSection = compareSection as ClientSettingsSection;
					if ( compareClientSettingsSection == null )
					{
						continue;
					}

					ClientSettingsSection clientSettingsSection = userSettingsGroup.Sections[ compareSection.SectionInformation.Name ] as ClientSettingsSection;
					if ( clientSettingsSection == null || clientSettingsSection.Settings.Count != compareClientSettingsSection.Settings.Count )
					{
						return false;
					}

					foreach ( SettingElement compateSettingElement in compareClientSettingsSection.Settings )
					{
						SettingElement settingElement = clientSettingsSection.Settings.Get( compateSettingElement.Name );
						if ( settingElement == null || !settingElement.Value.ValueXml.InnerXml.Equals( compateSettingElement.Value.ValueXml.InnerXml ) )
						{
							return false;
						}
					}
				}
			}

			return true;
		} // HasSameSettings

		// ----------------------------------------------------------------------
		public void Save()
		{
			configuration.Save();
		} // Save

		// ----------------------------------------------------------------------
		public void SaveAs( string fileName )
		{
			configuration.SaveAs( fileName );
		} // SaveAs

		// ----------------------------------------------------------------------
		public void Import( UserConfig importUserConfig, bool overwriteSettings )
		{
			if ( importUserConfig == null )
			{
				throw new ArgumentNullException( "importUserConfig" );
			}

			foreach ( ConfigurationSectionGroup importSectionGroup in importUserConfig.configuration.SectionGroups )
			{
				UserSettingsGroup importUserSettingsGroup = importSectionGroup as UserSettingsGroup;
				if ( importUserSettingsGroup == null )
				{
					continue;
				}

				UserSettingsGroup userSettingsGroup = configuration.SectionGroups[ importSectionGroup.Name ] as UserSettingsGroup;
				if ( userSettingsGroup == null )
				{
					userSettingsGroup = new UserSettingsGroup();
					configuration.SectionGroups.Add( importSectionGroup.Name, userSettingsGroup );
				}

				foreach ( ConfigurationSection importSection in importSectionGroup.Sections )
				{
					ClientSettingsSection importClientSettingsSection = importSection as ClientSettingsSection;
					if ( importClientSettingsSection == null )
					{
						continue;
					}

					ClientSettingsSection clientSettingsSection = userSettingsGroup.Sections[ importSection.SectionInformation.Name ] as ClientSettingsSection;
					if ( clientSettingsSection == null )
					{
						clientSettingsSection = new ClientSettingsSection();
						userSettingsGroup.Sections.Add( importSection.SectionInformation.Name, clientSettingsSection );
					}

					foreach ( SettingElement importSettingElement in importClientSettingsSection.Settings )
					{
						bool newSetting = false;

						SettingElement settingElement = clientSettingsSection.Settings.Get( importSettingElement.Name );
						if ( settingElement == null )
						{
							newSetting = true;
							settingElement = new SettingElement();
							settingElement.Name = importSettingElement.Name;
							settingElement.SerializeAs = importSettingElement.SerializeAs;
							clientSettingsSection.Settings.Add( settingElement );
						}

						if ( !newSetting && !overwriteSettings )
						{
							continue;
						}

						SettingValueElement settingValueElement = new SettingValueElement();
						settingValueElement.ValueXml = importSettingElement.Value.ValueXml;
						settingElement.SerializeAs = importSettingElement.SerializeAs;
						settingElement.Value = settingValueElement;
						clientSettingsSection.Settings.Add( settingElement );
					}
				}
			}
		} // Import

		// ----------------------------------------------------------------------
		public static UserConfig FromOpenExe()
		{
			System.Configuration.Configuration configuration =
				ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.PerUserRoamingAndLocal );
			return new UserConfig( configuration );
		} // UserSettings

		// ----------------------------------------------------------------------
		public static UserConfig FromFile( string path )
		{
			ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap();
			exeConfigurationFileMap.ExeConfigFilename = path;
			System.Configuration.Configuration configuration =
				ConfigurationManager.OpenMappedExeConfiguration( exeConfigurationFileMap, ConfigurationUserLevel.None );
			return new UserConfig( configuration );
		} // FromFile

		// ----------------------------------------------------------------------
		// members
		private readonly System.Configuration.Configuration configuration;

	} // class UserConfig

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
