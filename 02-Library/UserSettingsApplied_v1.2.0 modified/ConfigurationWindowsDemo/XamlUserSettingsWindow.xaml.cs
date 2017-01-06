// -- FILE ------------------------------------------------------------------
// name       : XamlUserSettingsWindow.cs
// created    : Jani Giannoudis - 2008.04.30
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Itenso.Solutions.Community.ConfigurationWindowsDemo
{

	// ------------------------------------------------------------------------
	public partial class XamlUserSettingsWindow : INotifyPropertyChanged
	{

		// ----------------------------------------------------------------------
		public event PropertyChangedEventHandler PropertyChanged;

		// ----------------------------------------------------------------------
		public static readonly DependencyProperty UserBackgroundProperty = DependencyProperty.Register(
			"UserBackground",
			typeof( Brush ),
			typeof( XamlUserSettingsWindow ),
			null );

		// ----------------------------------------------------------------------
		public static readonly DependencyProperty UserBackgroundRedProperty = DependencyProperty.Register(
			"UserBackgroundRed",
			typeof( byte ),
			typeof( XamlUserSettingsWindow ),
			new PropertyMetadata( UserBackgroundChanged ) );

		// ----------------------------------------------------------------------
		public static readonly DependencyProperty UserBackgroundGreenProperty = DependencyProperty.Register(
			"UserBackgroundGreen",
			typeof( byte ),
			typeof( XamlUserSettingsWindow ),
			new PropertyMetadata( UserBackgroundChanged ) );

		// ----------------------------------------------------------------------
		public static readonly DependencyProperty UserBackgroundBlueProperty = DependencyProperty.Register(
			"UserBackgroundBlue",
			typeof( byte ),
			typeof( XamlUserSettingsWindow ),
			new PropertyMetadata( UserBackgroundChanged ) );

		// ----------------------------------------------------------------------
		public XamlUserSettingsWindow()
		{
			InitializeComponent();
		} // XamlUserSettingsWindow

		// ----------------------------------------------------------------------
		public ObservableCollection<Customer> Customers
		{
			get { return customers ?? ( customers = LoadCustomers() ); }
		} // Customers

		// ----------------------------------------------------------------------
		public Brush UserBackground
		{
			get { return (Brush)GetValue( UserBackgroundProperty ); }
			set { SetValue( UserBackgroundProperty, value ); }
		} // UserBackground

		// ----------------------------------------------------------------------
		public byte UserBackgroundRed
		{
			get { return (byte)GetValue( UserBackgroundRedProperty ); }
			set { SetValue( UserBackgroundRedProperty, value ); }
		} // UserBackgroundRed

		// ----------------------------------------------------------------------
		public byte UserBackgroundGreen
		{
			get { return (byte)GetValue( UserBackgroundGreenProperty ); }
			set { SetValue( UserBackgroundGreenProperty, value ); }
		} // UserBackgroundGreen

		// ----------------------------------------------------------------------
		public byte UserBackgroundBlue
		{
			get { return (byte)GetValue( UserBackgroundBlueProperty ); }
			set { SetValue( UserBackgroundBlueProperty, value ); }
		} // UserBackgroundBlue

		// ----------------------------------------------------------------------
		protected void NotifyPropertyChanged( string propertyName )
		{
			PropertyChangedEventHandler propertyChanged = PropertyChanged;
			if ( propertyChanged != null )
			{
				propertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
			}
		} // NotifyPropertyChanged

		// ----------------------------------------------------------------------
		private static ObservableCollection<Customer> LoadCustomers()
		{
			ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

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
		private void UpdateUserBackground()
		{
			Color color = new Color();
			color.R = UserBackgroundRed;
			color.G = UserBackgroundGreen;
			color.B = UserBackgroundBlue;
			UserBackground = new SolidColorBrush( color );
		} // UpdateUserBackground

		// ----------------------------------------------------------------------
		private static void UserBackgroundChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			XamlUserSettingsWindow window = d as XamlUserSettingsWindow;
			if ( window == null )
			{
				return;
			}

			window.UpdateUserBackground();
		} // UserBackgroundChanged

		// ----------------------------------------------------------------------
		// members
		private ObservableCollection<Customer> customers;

	} // class XamlUserSettingsWindow

} // namespace Itenso.Solutions.Community.ConfigurationWindowsDemo
// -- EOF -------------------------------------------------------------------
