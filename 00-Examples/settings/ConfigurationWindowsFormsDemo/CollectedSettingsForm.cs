// -- FILE ------------------------------------------------------------------
// name       : SettingsForm.cs
// created    : Jani Giannoudis - 2008.05.11
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System.Windows.Forms;
using Itenso.Configuration;

namespace Itenso.Solutions.Community.ConfigurationWindowsFormsDemo
{

	// ------------------------------------------------------------------------
	public partial class CollectedSettingsForm : Form
	{

		// ----------------------------------------------------------------------
		public CollectedSettingsForm()
		{
			InitializeComponent();

			formSettings = new FormSettings( this );
			formSettings.CollectingSetting += FormSettingsCollectingSetting;

			formSettings.SettingCollectors.Add( new PropertySettingCollector( this, typeof( Splitter ), "SplitPosition" ) );
			formSettings.SettingCollectors.Add( new PropertySettingCollector( this, typeof( TextBox ), "Text" ) );
			formSettings.SettingCollectors.Add( new PropertySettingCollector( this, typeof( DateTimePicker ), "Value" ) );
			formSettings.SettingCollectors.Add( new PropertySettingCollector( this, typeof( CheckBox ), "Checked" ) );
			formSettings.SettingCollectors.Add( new PropertySettingCollector( this, typeof( ComboBox ), "SelectedIndex" ) );
		} // CollectedSettingsForm

		// ----------------------------------------------------------------------
		private void FormSettingsCollectingSetting( object sender, SettingCollectorCancelEventArgs e )
		{
			if ( e.Element == optionLevel3 )
			{
				e.Cancel = true;
			}
		} // FormSettingsCollectingSetting

		// ----------------------------------------------------------------------
		// members
		private readonly FormSettings formSettings;


	} // class SettingsForm

} // namespace Itenso.Solutions.Community.ConfigurationWindowsFormsDemo
// -- EOF -------------------------------------------------------------------
