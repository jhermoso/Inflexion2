// -- FILE ------------------------------------------------------------------
// name       : WindowSettings.cs
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
	public class WindowSettings : ApplicationSettings
	{

		// ----------------------------------------------------------------------
		public static readonly DependencyProperty SettingsProperty =
			DependencyProperty.RegisterAttached(
				"Settings",
				typeof( string ),
				typeof( WindowSettings ),
				new FrameworkPropertyMetadata( OnWindowSettingsChanged ) );

		// ----------------------------------------------------------------------
		public static readonly DependencyProperty CollectedSettingProperty =
			DependencyProperty.RegisterAttached(
				"CollectedSetting",
				typeof( DependencyProperty ),
				typeof( WindowSettings ),
				new FrameworkPropertyMetadata( OnCollectedSettingChanged ) );

		// ----------------------------------------------------------------------
		public static readonly DependencyProperty ExcludeElementProperty = DependencyProperty.RegisterAttached(
			"ExcludeElement",
			typeof( bool ),
			typeof( WindowSettings ) );

		// ----------------------------------------------------------------------
		public WindowSettings( Window window ) :
			this( window, window.GetType().Name )
		{
		} // WindowSettings

		// ----------------------------------------------------------------------
		public WindowSettings( Window window, string settingsKey ) :
			base( settingsKey )
		{
			if ( window == null )
			{
				throw new ArgumentNullException( "window" );
			}

			this.window = window;
			UseLocation = true;
			UseSize = true;
			UseWindowState = true;
			SaveOnClose = true;

			// settings 
			topSetting = CreateSetting( "Window.Top", Window.TopProperty );
			leftSetting = CreateSetting( "Window.Left", Window.LeftProperty );
			widthSetting = CreateSetting( "Window.Width", FrameworkElement.WidthProperty );
			heightSetting = CreateSetting( "Window.Height", FrameworkElement.HeightProperty );
			stateSetting = CreateSetting( "Window.WindowState", Window.WindowStateProperty );

			// subscribe to parent window's events
			this.window.SourceInitialized += WindowSourceInitialized;
			this.window.Initialized += WindowInitialized;
			this.window.Loaded += WindowLoaded;
			this.window.Closing += WindowClosing;
		} // WindowSettings

		// ----------------------------------------------------------------------
		public Window Window
		{
			get { return window; }
		} // Window

		// ----------------------------------------------------------------------
		public ISetting TopSetting
		{
			get { return topSetting; }
		} // TopSetting

		// ----------------------------------------------------------------------
		public ISetting LeftSetting
		{
			get { return leftSetting; }
		} // LeftSetting

		// ----------------------------------------------------------------------
		public ISetting WidthSetting
		{
			get { return widthSetting; }
		} // WidthSetting

		// ----------------------------------------------------------------------
		public ISetting HeightSetting
		{
			get { return heightSetting; }
		} // HeightSetting

		// ----------------------------------------------------------------------
		public ISetting StateSetting
		{
			get { return stateSetting; }
		} // StateSetting

		// ----------------------------------------------------------------------
		public bool? SaveCondition
		{
			get { return saveCondition; }
			set { saveCondition = value; }
		} // SaveCondition

		// ----------------------------------------------------------------------
		public bool UseLocation { get; set; }

		// ----------------------------------------------------------------------
		public bool UseSize { get; set; }

		// ----------------------------------------------------------------------
		public bool UseWindowState { get; set; }

		// ----------------------------------------------------------------------
		public bool AllowMinimized { get; set; }

		// ----------------------------------------------------------------------
		public bool SaveOnClose
		{
			get { return saveOnClose; }
			set { saveOnClose = value; }
		} // SaveOnClose

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
		public static DependencyProperty GetCollectedSetting( DependencyObject dependencyObject )
		{
			return dependencyObject.GetValue( SettingsProperty ) as DependencyProperty;
		} // GetCollectedSetting

		// ----------------------------------------------------------------------
		public static void SetCollectedSetting( DependencyObject dependencyObject, DependencyProperty dependencyProperty )
		{
			dependencyObject.SetValue( SettingsProperty, dependencyProperty );
		} // SetCollectedSetting

		// ----------------------------------------------------------------------
		public static bool GetExcludeElement( DependencyObject obj )
		{
			return (bool)obj.GetValue( ExcludeElementProperty );
		} // GetExcludeElement

		// ----------------------------------------------------------------------
		public static void SetExcludeElement( DependencyObject obj, bool exclude )
		{
			obj.SetValue( ExcludeElementProperty, exclude );
		} // SetExcludeElement

		// ----------------------------------------------------------------------
		public override void Save()
		{
			if ( saveCondition.HasValue && saveCondition != window.DialogResult )
			{
				return;
			}
			base.Save();
		} // Save

		// ----------------------------------------------------------------------
		protected override void OnCollectingSetting( SettingCollectorCancelEventArgs e )
		{
			FrameworkElement frameworkElement = e.Element as FrameworkElement;
			if ( frameworkElement == null )
			{
				e.Cancel = true;
				return;
			}

			// exclusion
			object exclude = frameworkElement.ReadLocalValue( ExcludeElementProperty );
			if ( exclude != null && exclude is bool && (bool)exclude )
			{
				e.Cancel = true;
				return;
			}

			base.OnCollectingSetting( e );
		} // OnCollectSettings

		// ----------------------------------------------------------------------
		void WindowSourceInitialized( object sender, EventArgs e )
		{
			// By settings the window state here, it allows the window to be
			// maximized to the correct screen in a multi-monitor environment.
			if ( UseWindowState )
			{
				Settings.Add( stateSetting );
			}
		} // WindowSourceInitialized

		// ----------------------------------------------------------------------
		private void WindowInitialized( object sender, EventArgs e )
		{
			if ( UseLocation )
			{
				Settings.Add( topSetting );
				Settings.Add( leftSetting );
			}
			if ( UseSize )
			{
				Settings.Add( widthSetting );
				Settings.Add( heightSetting );
			}
			Load();
		} // WindowInitialized

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
		private DependencyPropertySetting CreateSetting( string name, DependencyProperty dependencyProperty )
		{
			DependencyPropertySetting propertySetting = new DependencyPropertySetting( name, window, dependencyProperty );
			propertySetting.ValueSaving += ValueSaving;
			return propertySetting;
		} // CreateSetting

		// ----------------------------------------------------------------------
		private void ValueSaving( object sender, SettingValueCancelEventArgs e )
		{
			if ( AllowMinimized == false && window.WindowState == WindowState.Minimized )
			{
				e.Cancel = true;
			}
		} // ValueSaving

		// ----------------------------------------------------------------------
		private static void OnWindowSettingsChanged( DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e )
		{
			Window window = dependencyObject as Window;
			if ( window == null )
			{
				Debug.WriteLine( "WindowSettings: invalid window" );
				return;
			}

			if ( window.GetValue( DependencyPropertySetting.ApplicationSettingsProperty ) != null )
			{
				return; // window contains already an application setting
			}

			string settingsKey = e.NewValue as string;
			if ( string.IsNullOrEmpty( settingsKey ) )
			{
				Debug.WriteLine( "WindowSettings: missing window settings key" );
				return;
			}

			// create and attach the application settings to the window
			WindowSettings windowSettings = new WindowSettings( window, settingsKey );
			window.SetValue( DependencyPropertySetting.ApplicationSettingsProperty, windowSettings );
		} // OnWindowSettingsChanged

		// ----------------------------------------------------------------------
		private static void OnCollectedSettingChanged( DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e )
		{
			FrameworkElement frameworkElement = dependencyObject as FrameworkElement;
			if ( frameworkElement == null )
			{
				Debug.WriteLine( "WindowSettings: invalid framework element" );
				return;
			}

			DependencyProperty dependencyProperty = e.NewValue as DependencyProperty;
			if ( dependencyProperty == null )
			{
				Debug.WriteLine( "WindowSettings: missing dependency property" );
				return;
			}

			// search the window settings
			WindowSettings windowSettings =
					frameworkElement.ReadLocalValue( DependencyPropertySetting.ApplicationSettingsProperty ) as WindowSettings;
			if ( windowSettings == null )
			{
				Debug.WriteLine( "WindowSettings: missing window settings in element " + frameworkElement );
				return;
			}

			DependencyPropertySettingCollector collector =
				new DependencyPropertySettingCollector( frameworkElement, dependencyProperty );
			windowSettings.SettingCollectors.Add( collector );
		} // OnCollectedSettingChanged

		// ----------------------------------------------------------------------
		// members
		private readonly Window window;
		private readonly DependencyPropertySetting topSetting;
		private readonly DependencyPropertySetting leftSetting;
		private readonly DependencyPropertySetting widthSetting;
		private readonly DependencyPropertySetting heightSetting;
		private readonly DependencyPropertySetting stateSetting;
		private bool? saveCondition;
		private bool saveOnClose;

	} // class WindowSettings

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
