// -- FILE ------------------------------------------------------------------
// name       : SettingListBox.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System.Windows.Forms;
using Itenso.Configuration;

namespace Itenso.Solutions.Community.ConfigurationWindowsFormsDemo
{

	// ------------------------------------------------------------------------
	public class SettingListBox : ListBox
	{

		// ----------------------------------------------------------------------
		public SettingListBox()
		{
			if ( DesignMode )
			{
				return;
			}
			ControlSettings controlSettings = new ControlSettings( this );
			controlSettings.Settings.Add( new PropertySetting( this, "SelectedIndex" ) );
		} // SettingListBox

	} // class SettingListBox

} // namespace Itenso.Solutions.Community.ConfigurationWindowsFormsDemo
// -- EOF -------------------------------------------------------------------
