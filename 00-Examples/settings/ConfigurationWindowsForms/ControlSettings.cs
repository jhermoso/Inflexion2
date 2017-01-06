// -- FILE ------------------------------------------------------------------
// name       : ControlSettings.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	public class ControlSettings : ApplicationSettings
	{

		// ----------------------------------------------------------------------
		public ControlSettings( Control control ) :
			this( control, control.GetType().Name )
		{
		} // ControlSettings

		// ----------------------------------------------------------------------
		public ControlSettings( Control control, string settingsKey ) :
			base( settingsKey )
		{
			if ( control == null )
			{
				throw new ArgumentNullException( "control" );
			}

			this.control = control;
			this.control.HandleCreated += ControlHandleCreated;
			this.control.HandleDestroyed += ControlHandleDestroyed;
			SaveOnClose = true;
		} // ControlSettings

		// ----------------------------------------------------------------------
		public Control Control
		{
			get { return control; }
		} // Control

		// ----------------------------------------------------------------------
		public bool SaveOnClose { get; set; }

		// ----------------------------------------------------------------------
		private void OnFormLoad( object sender, EventArgs e )
		{
			Load();
		} // OnFormLoad

		// ----------------------------------------------------------------------
		private void OnFormClosing( object sender, CancelEventArgs e )
		{
			if ( SaveOnClose == false )
			{
				return;
			}
			Save();
		} // OnFormClosing

		// ----------------------------------------------------------------------
		private void ControlHandleCreated( object sender, EventArgs e )
		{
			Form form = control.FindForm();
			if ( form == null )
			{
				Debug.WriteLine( "ControlSettings: missing control form" );
				return;
			}

			form.Load += OnFormLoad;
			form.Closing += OnFormClosing;
		} // ControlHandleCreated

		// ----------------------------------------------------------------------
		private void ControlHandleDestroyed( object sender, EventArgs e )
		{
			Form form = control.FindForm();
			if ( form == null )
			{
				Debug.WriteLine( "ControlSettings: missing control form" );
				return;
			}

			form.Load -= OnFormLoad;
			form.Closing -= OnFormClosing;
		} // ControlHandleDestroyed

		// ----------------------------------------------------------------------
		// members
		private readonly Control control;

	} // class ControlSettings

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
