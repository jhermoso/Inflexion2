// -- FILE ------------------------------------------------------------------
// name       : MyApplicationSettings.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using Itenso.Configuration;

namespace Itenso.Solutions.Community.ConfigurationWindowsFormsDemo
{

	// ------------------------------------------------------------------------
	public class MyApplicationSettings : ApplicationSettings
	{

		// ----------------------------------------------------------------------
		public MyApplicationSettings() :
			base( typeof( MyApplicationSettings ) )
		{
			Settings.Add( new PropertySetting( this, "HostName" ) );
		} // MyApplicationSettings

		// ----------------------------------------------------------------------
		public string HostName { get; set; }

	} // class MyApplicationSettings

} // namespace Itenso.Solutions.Community.ConfigurationWindowsFormsDemo
// -- EOF -------------------------------------------------------------------
