// -- FILE ------------------------------------------------------------------
// name       : ValueSettingBase.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.Configuration;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	public abstract class ValueSettingBase : Setting
	{

		// ----------------------------------------------------------------------
		protected ValueSettingBase( string name ) :
			this( name, null )
		{
		} // ValueSettingBase

		// ----------------------------------------------------------------------
		protected ValueSettingBase( string name, object defaultValue )
		{
			if ( string.IsNullOrEmpty( name ) )
			{
				throw new ArgumentNullException( "name" );
			}

			this.name = name;
			DefaultValue = defaultValue;
			SerializeAs = SettingsSerializeAs.String;
		} // ValueSettingBase

		// ----------------------------------------------------------------------
		public string Name
		{
			get { return name; }
		} // Name

		// ----------------------------------------------------------------------
		public object DefaultValue { get; set; }

		// ----------------------------------------------------------------------
		public SettingsSerializeAs SerializeAs { get; set; }

		// ----------------------------------------------------------------------
		public bool LoadUndefinedValue { get; set; }

		// ----------------------------------------------------------------------
		public bool SaveUndefinedValue { get; set; }

		// ----------------------------------------------------------------------
		public bool HasValue
		{
			get { return Value != null; }
		} // HasValue

		// ----------------------------------------------------------------------
		public override bool HasChanged
		{
			get
			{
				object originalValue = OriginalValue;
				object value = Value;

				if ( originalValue == value )
				{
					return false;
				}

				return originalValue == null || !originalValue.Equals( value );
			}
		} // HasChanged

		// ----------------------------------------------------------------------
		public abstract object OriginalValue
		{
			get;
		} // OriginalValue

		// ----------------------------------------------------------------------
		public abstract object Value
		{
			get;
			set;
		} // Value

		// ----------------------------------------------------------------------
		public override string ToString()
		{
			return string.Concat( name, "=", Value );
		} // ToString

		// ----------------------------------------------------------------------
		// members
		private readonly string name;

	} // class ValueSettingBase

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
