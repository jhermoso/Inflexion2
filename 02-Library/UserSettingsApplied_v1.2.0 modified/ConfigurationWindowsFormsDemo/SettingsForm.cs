// -- FILE ------------------------------------------------------------------
// name       : SettingsForm.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Itenso.Configuration;

namespace Itenso.Solutions.Community.ConfigurationWindowsFormsDemo
{

	// ------------------------------------------------------------------------
	enum CustomAlignment
	{
		Left,
		Center,
		Right,
	} // enum CustomAlignment

	// ------------------------------------------------------------------------
	public partial class SettingsForm : Form
	{

		// ----------------------------------------------------------------------
		public SettingsForm()
		{
			InitializeComponent();
			SetupListItems( 50 );

			// create settings group
			formSettings = new FormSettings( this );
			formSettings.SaveOnClose = false; // disable auto-save

			// add settings to group
			formSettings.Settings.Add(
				new PropertySetting( "Panel.SplitterPosition", panelSplitter, "SplitPosition", 100 ) );
			formSettings.Settings.Add(
				new PropertySetting( "CustomAlignment", this, "Alignment", CustomAlignment.Left ) );
			formSettings.Settings.Add(
				new FieldSetting( "FormColor", this, "formColor", formColor ) );
			formSettings.Settings.Add(
				new FieldSetting( "FormFont", this, "formFont", formFont ) );

			InitControls();
		} // SettingsForm

		// ----------------------------------------------------------------------
		public string HostName
		{
			get { return hostEdit.Text; }
			set { hostEdit.Text = value; }
		} // HostName

		// ----------------------------------------------------------------------
		internal CustomAlignment Alignment
		{
			get
			{
				if ( alignmentLeftOption.Checked )
				{
					return CustomAlignment.Left;
				}
				if ( alignmentCenterOption.Checked )
				{
					return CustomAlignment.Center;
				}
				return alignmentRightOption.Checked ? CustomAlignment.Right : CustomAlignment.Left;
			}
			set
			{
				switch ( value )
				{
					case CustomAlignment.Left:
						alignmentLeftOption.Checked = true;
						break;
					case CustomAlignment.Center:
						alignmentCenterOption.Checked = true;
						break;
					case CustomAlignment.Right:
						alignmentRightOption.Checked = true;
						break;
				}
			}
		} // Alignment

		// ----------------------------------------------------------------------
		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			UpdateControls();
		} // OnLoad

		// ----------------------------------------------------------------------
		private void SetupListItems( int count )
		{
			itemsList.BeginUpdate();
			for ( int i = 0; i < count; i++ )
			{
				itemsList.Items.Add( "Item " + ( i + 1 ) );
			}
			itemsList.SelectedIndex = 0;
			itemsList.EndUpdate();
		} // SetupListItems

		// ----------------------------------------------------------------------
		private void InitControls()
		{
			userConfigNameLabel.Text = ApplicationSettings.UserConfigurationFilePath;
			formToolTip.SetToolTip( userConfigNameLabel, ApplicationSettings.UserConfigurationFilePath );
			UpdateControls();
		} // InitControls

		// ----------------------------------------------------------------------
		private void UpdateControls()
		{
			windowLocationLabel.Text = string.Concat(
				Left.ToString( CultureInfo.InvariantCulture ), ", ", Top.ToString( CultureInfo.InvariantCulture ) );
			windowSizeLabel.Text = string.Concat(
				Width.ToString( CultureInfo.InvariantCulture ), " x ", Height.ToString( CultureInfo.InvariantCulture ) );
			windowStateLabel.Text = WindowState.ToString();

			selectedItemLabel.Text = itemsList.SelectedItem != null ? itemsList.SelectedItem.ToString() : "-";
			spltterPositionText.Text = panelSplitter.SplitPosition.ToString( CultureInfo.InvariantCulture );

			colorText.Text = formColor.ToString();
			colorText.BackColor = formColor;
			formToolTip.SetToolTip( colorText, formColor.ToString() );

			fontText.Text = formFont.ToString();
			fontText.Font = formFont;
			formToolTip.SetToolTip( fontText, formFont.ToString() );
		} // UpdateControls

		// ----------------------------------------------------------------------
		protected override void OnLocationChanged( EventArgs e )
		{
			base.OnLocationChanged( e );
			UpdateControls();
		} // OnLocationChanged

		// ----------------------------------------------------------------------
		protected override void OnSizeChanged( EventArgs e )
		{
			base.OnSizeChanged( e );
			UpdateControls();
		} // OnSizeChanged

		// ----------------------------------------------------------------------
		private void ItemChanged( object sender, EventArgs e )
		{
			UpdateControls();
		} // ItemChanged

		// ----------------------------------------------------------------------
		private void SplitterMoving( object sender, SplitterEventArgs e )
		{
			UpdateControls();
		} // SplitterMoving

		// ----------------------------------------------------------------------
		private void ChangeColor( object sender, EventArgs e )
		{
			colorSetupDialog.Color = formColor;
			if ( colorSetupDialog.ShowDialog() != DialogResult.OK )
			{
				return;
			}

			formColor = colorSetupDialog.Color;
			UpdateControls();
		} // ChangeColor

		// ----------------------------------------------------------------------
		private void ChangeFont( object sender, EventArgs e )
		{
			fontSetupDialog.Font = formFont;
			if ( fontSetupDialog.ShowDialog() != DialogResult.OK )
			{
				return;
			}

			formFont = fontSetupDialog.Font;
			UpdateControls();
		} // ChangeFont

		// ----------------------------------------------------------------------
		private void ResetSettings( object sender, EventArgs e )
		{
			formSettings.Reset();
			UpdateControls();
		} // ResetSettings

		// ----------------------------------------------------------------------
		private void ReloadSettings( object sender, EventArgs e )
		{
			formSettings.Reload();
			UpdateControls();
		} // ReloadSettings

		// ----------------------------------------------------------------------
		private void SaveSettings( object sender, EventArgs e )
		{
			formSettings.Save();
			UpdateControls();
		} // SaveSettings

		// ----------------------------------------------------------------------
		private void OpenUserConfig( object sender, EventArgs e )
		{
			string fileName = userConfigNameLabel.Text;
			if ( !File.Exists( fileName ) )
			{
				MessageBox.Show( "File not available:\n\n" + fileName, Text );
				return;
			}
			Process.Start( fileName );
		} // OpenUserConfig

		// ----------------------------------------------------------------------
		private void CollectedSettings( object sender, EventArgs e )
		{
			new CollectedSettingsForm().ShowDialog();
		} // CollectedSettings

		// ----------------------------------------------------------------------
		private void GridViewSettings( object sender, EventArgs e )
		{
			new DataGridViewSettingsForm().ShowDialog();
		} // GridViewSettings

		// ----------------------------------------------------------------------
		private void Close( object sender, EventArgs e )
		{
			if ( saveOnCloseOption.Checked )
			{
				formSettings.Save();
			}
			Close();
		} // Close

		// ----------------------------------------------------------------------
		// members
		private readonly FormSettings formSettings;
		private Color formColor = Color.FromArgb( 200, 255, 200 );
		private Font formFont = new Font( FontFamily.GenericMonospace, 8 );

	} // class SettingsForm

} // namespace Itenso.Solutions.Community.ConfigurationWindowsFormsDemo
// -- EOF -------------------------------------------------------------------
