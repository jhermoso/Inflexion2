// -- FILE ------------------------------------------------------------------
// name       : SettingsForm.cs
// created    : Jani Giannoudis - 2008.05.09
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------

using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Itenso.Configuration;

namespace Itenso.Solutions.Community.ConfigurationWindowsFormsDemo
{

	// ------------------------------------------------------------------------
	public partial class DataGridViewSettingsForm : Form
	{

		// ----------------------------------------------------------------------
		public DataGridViewSettingsForm()
		{
			InitializeComponent();
			formSettings = new FormSettings( this );
			formSettings.SaveOnClose = false; // disable auto-save
			formSettings.Settings.Add( new DataGridViewSetting( customersDataGridView ) );

			customersDataGridView.DataSource = LoadCustomers();
		} // DataGridViewSettingsForm

		// ----------------------------------------------------------------------
		private static List<Customer> LoadCustomers()
		{
			List<Customer> customers = new List<Customer>();

			for ( int i = 0; i < 100; i++ )
			{
				string userId = ( i + 1 ).ToString( CultureInfo.InvariantCulture );
				Customer customer = new Customer(
					"FisrtName" + userId,
					"LastName" + userId,
					"Street" + userId,
					"City" + userId,
					"ZipCode" + userId );

				customers.Add( customer );
			}

			return customers;
		} // LoadCustomers

		// ----------------------------------------------------------------------
		protected override void OnClosing( CancelEventArgs e )
		{
			base.OnClosing( e );

			if ( DialogResult == DialogResult.Cancel )
			{
				return; // is canceling
			}

			if ( !formSettings.Settings.HasChanges )
			{
				return; // nothing to do
			}

			StringBuilder sb = new StringBuilder();
			foreach ( ISetting setting in formSettings.Settings )
			{
				if ( !setting.HasChanged )
				{
					continue;
				}

				sb.Append( " - " );
				sb.Append( setting.ToString() );
				sb.Append( "\n" );
			}

			DialogResult result = MessageBox.Show( "Save changes?\n\n" + sb, Text, MessageBoxButtons.YesNoCancel );
			switch ( result )
			{
				case DialogResult.Yes:
					formSettings.Save();
					break;
				case DialogResult.No:
					break;
				case DialogResult.Cancel:
					e.Cancel = true;
					break;
			}
		} // OnClosing

		// ----------------------------------------------------------------------
		// members
		private readonly FormSettings formSettings;

	} // class SettingsForm

} // namespace Itenso.Solutions.Community.ConfigurationWindowsFormsDemo
// -- EOF -------------------------------------------------------------------
