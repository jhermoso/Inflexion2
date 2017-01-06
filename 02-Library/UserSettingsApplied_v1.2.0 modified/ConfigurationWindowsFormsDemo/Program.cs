// -- FILE ------------------------------------------------------------------
// name       : Program.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.Windows.Forms;

namespace Itenso.Solutions.Community.ConfigurationWindowsFormsDemo
{

	// ------------------------------------------------------------------------
	public class Program
	{

		// ----------------------------------------------------------------------
		[STAThread]
		static void Main()
		{
			appSettings.Load();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );

			SettingsForm settingsForm = new SettingsForm();
			settingsForm.FormClosed += SettingsFormClosed;
			settingsForm.HostName = appSettings.HostName;
			Application.Run( settingsForm );

			appSettings.Save();
		} // Main

		// ----------------------------------------------------------------------
		static void SettingsFormClosed( object sender, FormClosedEventArgs e )
		{
			appSettings.HostName = ((SettingsForm)sender).HostName;
		} // SettingsFormClosed

		// ----------------------------------------------------------------------
		// members
		private static readonly MyApplicationSettings appSettings = new MyApplicationSettings();

	} // class Program

} // namespace Itenso.Solutions.Community.ConfigurationWindowsFormsDemo
// -- EOF -------------------------------------------------------------------
