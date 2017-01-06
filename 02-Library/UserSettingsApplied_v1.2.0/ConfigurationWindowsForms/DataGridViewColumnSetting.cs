// -- FILE ------------------------------------------------------------------
// name       : DataGridViewColumnSetting.cs
// created    : Jani Giannoudis - 2008.05.09
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.Windows.Forms;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	[Serializable]
	internal class DataGridViewColumnSetting
	{

		// ----------------------------------------------------------------------
		public DataGridViewColumnSetting( DataGridViewColumn dataGridViewColumn )
		{
			if ( dataGridViewColumn == null )
			{
				throw new ArgumentNullException( "dataGridViewColumn" );
			}

			DisplayIndex = dataGridViewColumn.DisplayIndex;
			Width = dataGridViewColumn.Width;
			Name = dataGridViewColumn.Name;
			Visible = dataGridViewColumn.Visible;
		} // DataGridViewColumnSetting

		// ----------------------------------------------------------------------
		public int DisplayIndex { get; set; }

		// ----------------------------------------------------------------------
		public int Width { get; set; }

		// ----------------------------------------------------------------------
		public string Name { get; set; }

		// ----------------------------------------------------------------------
		public bool Visible { get; set; }

		// ----------------------------------------------------------------------
		public override bool Equals( object obj )
		{
			if ( obj == this )
			{
				return true;
			}

			DataGridViewColumnSetting compare = obj as DataGridViewColumnSetting;
			if ( compare == null )
			{
				return false;
			}

			return
				string.Equals( Name, compare.Name ) &&
				int.Equals( DisplayIndex, compare.DisplayIndex ) &&
				int.Equals( Width, compare.Width ) &&
				bool.Equals( Visible, compare.Visible );
		} // Equals

		// ----------------------------------------------------------------------
		public override int GetHashCode()
		{
			int hash = GetType().GetHashCode();
			hash = AddHashCode( hash, Name );
			hash = AddHashCode( hash, DisplayIndex );
			hash = AddHashCode( hash, Width );
			hash = AddHashCode( hash, Visible );
			return hash;
		} // GetHashCode

		// ----------------------------------------------------------------------
		private static int AddHashCode( int hash, object obj )
		{
			int combinedHash = obj != null ? obj.GetHashCode() : 0;
			if ( hash != 0 )
			{
				combinedHash += hash * 31;
			}
			return combinedHash;
		} // AddHashCode

	} // class DataGridViewColumnSetting

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
