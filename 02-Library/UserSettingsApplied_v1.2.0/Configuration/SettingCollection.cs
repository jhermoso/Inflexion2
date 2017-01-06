// -- FILE ------------------------------------------------------------------
// name       : SettingCollection.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.Collections;
using System.Reflection;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	public sealed class SettingCollection : IEnumerable
	{

		// ----------------------------------------------------------------------
		public SettingCollection( ApplicationSettings applicationSettings )
		{
			if ( applicationSettings == null )
			{
				throw new ArgumentNullException( "applicationSettings" );
			}

			this.applicationSettings = applicationSettings;
		} // SettingCollection

		// ----------------------------------------------------------------------
		public ApplicationSettings ApplicationSettings
		{
			get { return applicationSettings; }
		} // ApplicationSettings

		// ----------------------------------------------------------------------
		public int Count
		{
			get { return settings.Count; }
		} // Count

		// ----------------------------------------------------------------------
		public bool HasChanges
		{
			get 
			{
				foreach ( ISetting setting in settings )
				{
					if ( setting.HasChanged )
					{
						return true;
					}
				}
				return false;
			}
		} // HasChanges

		// ----------------------------------------------------------------------
		public IEnumerator GetEnumerator()
		{
			return settings.GetEnumerator();
		} // GetEnumerator

		// ----------------------------------------------------------------------
		public bool Contains( ISetting setting )
		{
			if ( setting == null )
			{
				throw new ArgumentNullException( "setting" );
			}
			return settings.Contains( setting );
		} // Contains

		// ----------------------------------------------------------------------
		public void Add( ISetting setting )
		{
			if ( setting == null )
			{
				throw new ArgumentNullException( "setting" );
			}
			setting.ApplicationSettings = applicationSettings;
			settings.Add( setting );
		} // Add

		// ----------------------------------------------------------------------
		public void AddAll( object obj )
		{
			if ( obj == null )
			{
				throw new ArgumentNullException( "obj" );
			}

			// field settings
			FieldInfo[] fieldInfos = obj.GetType().GetFields(
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
			foreach ( FieldInfo fieldInfo in fieldInfos )
			{
				FieldSettingAttribute[] settingAttributes = (FieldSettingAttribute[])fieldInfo.GetCustomAttributes( typeof( FieldSettingAttribute ), true );
				if ( settingAttributes.Length <= 0 )
				{
					continue;
				}

				FieldSettingAttribute settingAttribute = settingAttributes[ 0 ];
				string settingName = settingAttribute.Name;
				if ( string.IsNullOrEmpty( settingName ) )
				{
					settingName = fieldInfo.Name;
				}
				object defaultValue = settingAttribute.DefaultValue;
				FieldSetting fieldSetting = new FieldSetting(
					settingName, obj, fieldInfo.Name, defaultValue );
				Add( fieldSetting );
			}

			// property settings
			PropertyInfo[] propertyInfos = obj.GetType().GetProperties(
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
			foreach ( PropertyInfo propertyInfo in propertyInfos )
			{
				PropertySettingAttribute[] settingAttributes = (PropertySettingAttribute[])propertyInfo.GetCustomAttributes( typeof( PropertySettingAttribute ), true );
				if ( settingAttributes.Length <= 0 )
				{
					continue;
				}

				PropertySettingAttribute settingAttribute = settingAttributes[ 0 ];
				string settingName = settingAttribute.Name;
				if ( string.IsNullOrEmpty( settingName ) )
				{
					settingName = propertyInfo.Name;
				}
				object defaultValue = settingAttribute.DefaultValue;
				PropertySetting propertySetting = new PropertySetting(
					settingName, obj, propertyInfo.Name, defaultValue );
				Add( propertySetting );
			}
		} // AddAll

		// ----------------------------------------------------------------------
		public void Remove( ISetting setting )
		{
			if ( setting == null )
			{
				throw new ArgumentNullException( "setting" );
			}
			settings.Remove( setting );
		} // Remove

		// ----------------------------------------------------------------------
		public void Clear()
		{
			settings.Clear();
		} // Clear

		// ----------------------------------------------------------------------
		// members
		private readonly ArrayList settings = new ArrayList();
		private readonly ApplicationSettings applicationSettings;

	} // class SettingCollection

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
