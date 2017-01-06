// -- FILE ------------------------------------------------------------------
// name       : FormSettings.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	public class FormSettings : ApplicationSettings
	{

		// ----------------------------------------------------------------------
		public FormSettings( Form form ) :
			this( form, form.GetType().Name )
		{
		} // FormSettings

		// ----------------------------------------------------------------------
		public FormSettings( Form form, string settingsKey ) :
			base( settingsKey )
		{
			if ( form == null )
			{
				throw new ArgumentNullException( "form" );
			}

			this.form = form;
			UseLocation = true;
			UseSize = true;
			UseWindowState = true;
			SaveOnClose = true;

			// settings 
			topSetting = CreateSetting( "Window.Top", "Top" );
			leftSetting = CreateSetting( "Window.Left", "Left" );
			widthSetting = CreateSetting( "Window.Width", "Width" );
			heightSetting = CreateSetting( "Window.Height", "Height" );
			stateSetting = CreateSetting( "Window.WindowState", "WindowState" );

			// subscribe to parent form's events
			this.form.Load += FormLoad;
			this.form.Closing += FormClosing;
		} // FormSettings

		// ----------------------------------------------------------------------
		public Form Form
		{
			get { return form; }
		} // Form

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
		public DialogResult? SaveCondition
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
		public bool SaveOnClose { get; set; }

		// ----------------------------------------------------------------------
		public override void Save()
		{
			if ( saveCondition.HasValue && saveCondition.Value != form.DialogResult )
			{
				return;
			}
			base.Save();
		} // Save

		// ----------------------------------------------------------------------
		private void FormLoad( object sender, EventArgs e )
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
			if ( UseWindowState )
			{
				Settings.Add( stateSetting );
			}

			Load();
		} // FormLoad

		// ----------------------------------------------------------------------
		private void FormClosing( object sender, CancelEventArgs e )
		{
			if ( !SaveOnClose )
			{
				return;
			}
			Save();
		} // FormClosing

		// ----------------------------------------------------------------------
		private PropertySetting CreateSetting( string name, string propertyName )
		{
			PropertySetting propertySetting = new PropertySetting( name, form, propertyName );
			propertySetting.ValueSaving += ValueSaving;
			return propertySetting;
		} // CreateSetting

		// ----------------------------------------------------------------------
		private void ValueSaving( object sender, SettingValueCancelEventArgs e )
		{
			if ( AllowMinimized == false && form.WindowState == FormWindowState.Minimized )
			{
				e.Cancel = true;
			}
		} // ValueSaving

		// ----------------------------------------------------------------------
		// members
		private readonly Form form;
		private readonly PropertySetting topSetting;
		private readonly PropertySetting leftSetting;
		private readonly PropertySetting widthSetting;
		private readonly PropertySetting heightSetting;
		private readonly PropertySetting stateSetting;
		private DialogResult? saveCondition;
	} // class FormSettings

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
