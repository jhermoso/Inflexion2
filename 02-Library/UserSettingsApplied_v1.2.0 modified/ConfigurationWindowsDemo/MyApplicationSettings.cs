// -- FILE ------------------------------------------------------------------
// name       : MyApplicationSettings.cs
// created    : Jani Giannoudis - 2008.04.28
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System.Windows;
using Itenso.Configuration;
using Itenso.Common;

namespace Itenso.Solutions.Community.ConfigurationWindowsDemo
{

	// ------------------------------------------------------------------------
	public class MyApplicationSettings : WindowsApplicationSettings
	{

		// ----------------------------------------------------------------------
		public MyApplicationSettings( Application application ) :
			base( application, typeof( MyApplicationSettings ) )
		{
			Settings.Add( new PropertySetting( this, "HostName" ) );
		} // MyApplicationSettings

		// ----------------------------------------------------------------------
		public string HostName { get; set; }

	} // class MyApplicationSettings

} // namespace Itenso.Solutions.Community.ConfigurationWindowsDemo
// -- EOF -------------------------------------------------------------------
