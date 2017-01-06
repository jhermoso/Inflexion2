// -- FILE ------------------------------------------------------------------
// name       : SettingCollectorCancelEventArgs.cs
// created    : Jani Giannoudis - 2008.05.11
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.ComponentModel;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	public delegate void SettingCollectorCancelEventHandler( object sender, SettingCollectorCancelEventArgs e );

	// ------------------------------------------------------------------------
	public class SettingCollectorCancelEventArgs : CancelEventArgs
	{

		// ----------------------------------------------------------------------
		public SettingCollectorCancelEventArgs( object element ) :
			this( element, false )
		{
		} // SettingCollectorCancelEventArgs

		// ----------------------------------------------------------------------
		public SettingCollectorCancelEventArgs( object element, bool cancel ) :
			base( cancel )
		{
			if ( element == null )
			{
				throw new ArgumentNullException( "element" );
			}

			this.element = element;
		} // SettingCollectorCancelEventArgs

		// ----------------------------------------------------------------------
		public object Element
		{
			get { return element; }
		} // Element

		// ----------------------------------------------------------------------
		// members
		private readonly object element;

	} // class SettingCollectorCancelEventArgs

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
