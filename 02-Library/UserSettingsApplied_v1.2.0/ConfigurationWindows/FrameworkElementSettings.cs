// -- FILE ------------------------------------------------------------------
// name       : FrameworkElementSettings.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Windows;
using System.ComponentModel;
using System.Diagnostics;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	public class FrameworkElementSettings : ApplicationSettings
	{

		// ----------------------------------------------------------------------
		public static readonly DependencyProperty SettingsProperty =
			DependencyProperty.RegisterAttached(
				"Settings",
				typeof( string ),
				typeof( FrameworkElementSettings ),
				new FrameworkPropertyMetadata( OnFrameworkElementSettingsChanged ) );

		// ----------------------------------------------------------------------
		public static readonly DependencyProperty CollectedSettingProperty =
			DependencyProperty.RegisterAttached(
				"CollectedSetting",
				typeof( DependencyProperty ),
				typeof( FrameworkElementSettings ),
				new FrameworkPropertyMetadata( OnCollectedSettingChanged ) );

		// ----------------------------------------------------------------------
		public static readonly DependencyProperty ExcludeElementProperty = DependencyProperty.RegisterAttached(
			"ExcludeElement",
			typeof( bool ),
			typeof( FrameworkElementSettings ) );

		// ----------------------------------------------------------------------
		public FrameworkElementSettings( FrameworkElement frameworkElement ) :
			this( frameworkElement, frameworkElement.GetType().Name )
		{
		} // FrameworkElementSettings

		// ----------------------------------------------------------------------
		public FrameworkElementSettings( FrameworkElement frameworkElement, string settingsKey ) :
			base( settingsKey )
		{
			if ( frameworkElement == null )
			{
				throw new ArgumentNullException( "frameworkElement" );
			}

			this.frameworkElement = frameworkElement;
			this.frameworkElement.Initialized += FrameworkElementInitialized;
		} // FrameworkElementSettings

		// ----------------------------------------------------------------------
		public FrameworkElement FrameworkElement
		{
			get { return frameworkElement; }
		} // FrameworkElement

		// ----------------------------------------------------------------------
		public bool SaveOnClose
		{
			get { return saveOnClose; }
			set { saveOnClose = value; }
		} // SaveOnClose

		// ----------------------------------------------------------------------
		private Window ParentWindow
		{
			get
			{
				DependencyObject control = frameworkElement;
				while ( control != null )
				{
					if ( control is Window )
					{
						return control as Window;
					}

					control = LogicalTreeHelper.GetParent( control );
				}

				return null;
			}
		} // ParentWindow

		// ----------------------------------------------------------------------
		public static string GetSettings( DependencyObject dependencyObject )
		{
			return dependencyObject.GetValue( SettingsProperty ) as string;
		} // SetSettings

		// ----------------------------------------------------------------------
		public static void SetSettings( DependencyObject dependencyObject, string settingsKey )
		{
			dependencyObject.SetValue( SettingsProperty, settingsKey );
		} // SetSettings

		// ----------------------------------------------------------------------
		private void FrameworkElementInitialized( object sender, EventArgs e )
		{
			Window window = ParentWindow;
			if ( window == null )
			{
				throw new InvalidOperationException();
			}

			// subscribe to the parent window events
			window.Loaded += WindowLoaded;
			window.Closing += WindowClosing;
		} // FrameworkElementSettings

		// ----------------------------------------------------------------------
		private void WindowLoaded( object sender, RoutedEventArgs e )
		{
			Load();
		} // WindowLoaded

		// ----------------------------------------------------------------------
		private void WindowClosing( object sender, CancelEventArgs e )
		{
			if ( saveOnClose == false )
			{
				return;
			}
			Save();
		} // WindowClosing

		// ----------------------------------------------------------------------
		private static void OnFrameworkElementSettingsChanged( DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e )
		{
			FrameworkElement frameworkElement = dependencyObject as FrameworkElement;
			if ( frameworkElement == null )
			{
				Debug.WriteLine( "FrameworkElementSettings: invalid framework element" );
				return;
			}

			if ( frameworkElement.GetValue( DependencyPropertySetting.ApplicationSettingsProperty ) != null )
			{
				return; // framework-element contains already an application setting
			}

			string settingsKey = e.NewValue as string;
			if ( string.IsNullOrEmpty( settingsKey ) )
			{
				Debug.WriteLine( "FrameworkElementSettings: missing framework element settings key" );
				return;
			}

			// create and attach the application settings to the framework-element
			FrameworkElementSettings frameworkElementSettings = new FrameworkElementSettings( frameworkElement, settingsKey );
			frameworkElement.SetValue( DependencyPropertySetting.ApplicationSettingsProperty, frameworkElementSettings );
		} // OnFrameworkElementSettingsChanged

		// ----------------------------------------------------------------------
		private static void OnCollectedSettingChanged( DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e )
		{
			FrameworkElement frameworkElement = dependencyObject as FrameworkElement;
			if ( frameworkElement == null )
			{
				Debug.WriteLine( "FrameworkElementSettings: invalid framework element" );
				return;
			}

			DependencyProperty dependencyProperty = e.NewValue as DependencyProperty;
			if ( dependencyProperty == null )
			{
				Debug.WriteLine( "FrameworkElementSettings: missing dependency property" );
				return;
			}

			// search the framework element settings
			FrameworkElementSettings frameworkElementSettings =
					frameworkElement.ReadLocalValue( DependencyPropertySetting.ApplicationSettingsProperty ) as FrameworkElementSettings;
			if ( frameworkElementSettings == null )
			{
				Debug.WriteLine( "FrameworkElementSettings: missing framework element settings in element " + frameworkElement );
				return;
			}

			DependencyPropertySettingCollector collector =
				new DependencyPropertySettingCollector( frameworkElement, dependencyProperty );
			frameworkElementSettings.SettingCollectors.Add( collector );
		} // OnCollectedSettingChanged

		// ----------------------------------------------------------------------
		// members
		private readonly FrameworkElement frameworkElement;
		private bool saveOnClose = true;

	} // class FrameworkElementSettings

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
