// -- FILE ------------------------------------------------------------------
// name       : SettingCollectorCollection.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.Collections;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	public sealed class SettingCollectorCollection : IEnumerable
	{

		// ----------------------------------------------------------------------
		public event SettingCollectorCancelEventHandler CollectingSetting;

		// ----------------------------------------------------------------------
		public SettingCollectorCollection( ApplicationSettings applicationSettings )
		{
			if ( applicationSettings == null )
			{
				throw new ArgumentNullException( "applicationSettings" );
			}

			this.applicationSettings = applicationSettings;
		} // SettingCollectorCollection

		// ----------------------------------------------------------------------
		public ApplicationSettings ApplicationSettings
		{
			get { return applicationSettings; }
		} // ApplicationSettings

		// ----------------------------------------------------------------------
		public int Count
		{
			get { return settingCollectors.Count; }
		} // Count

		// ----------------------------------------------------------------------
		public IEnumerator GetEnumerator()
		{
			return settingCollectors.GetEnumerator();
		} // GetEnumerator

		// ----------------------------------------------------------------------
		public void Add( ISettingCollector setting )
		{
			if ( setting == null )
			{
				throw new ArgumentNullException( "setting" );
			}
			setting.ApplicationSettings = applicationSettings;
			setting.CollectingSetting += SettingCollectingSetting;
			settingCollectors.Add( setting );
		} // Add

		// ----------------------------------------------------------------------
		public void Remove( ISettingCollector setting )
		{
			if ( setting == null )
			{
				throw new ArgumentNullException( "setting" );
			}
			setting.CollectingSetting -= SettingCollectingSetting;
			settingCollectors.Remove( setting );
		} // Remove

		// ----------------------------------------------------------------------
		public void Clear()
		{
			foreach ( ISettingCollector settingCollector in settingCollectors )
			{
				Remove( settingCollector );
			}
		} // Clear

		// ----------------------------------------------------------------------
		public void Collect()
		{
			foreach ( ISettingCollector settingCollector in settingCollectors )
			{
				settingCollector.Collect();
			}
		} // Collect

		// ----------------------------------------------------------------------
		private void SettingCollectingSetting( object sender, SettingCollectorCancelEventArgs e )
		{
			if ( CollectingSetting != null )
			{
				CollectingSetting( this, e );
			}
		} // SettingCollectingSetting

		// ----------------------------------------------------------------------
		// members
		private readonly ArrayList settingCollectors = new ArrayList();
		private readonly ApplicationSettings applicationSettings;

	} // class SettingCollectorCollection

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
