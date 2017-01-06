// -- FILE ------------------------------------------------------------------
// name       : ValueSetting.cs
// created    : Jani Giannoudis - 2008.04.25
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	public class ValueSetting : ValueSettingBase
	{

		// ----------------------------------------------------------------------
		public ValueSetting( string name, Type valueType ) :
			this( name, valueType, null, null )
		{
		} // ValueSetting

		// ----------------------------------------------------------------------
		public ValueSetting( string name, Type valueType, object value ) :
			this( name, valueType, value, null )
		{
		} // ValueSetting

		// ----------------------------------------------------------------------
		public ValueSetting( string name, Type valueType, object value, object defaultValue ) :
			base( name, defaultValue )
		{
			if ( valueType == null )
			{
				throw new ArgumentNullException( "valueType" );
			}
			if ( defaultValue != null && defaultValue.GetType() != valueType )
			{
				throw new ArgumentException( "defaultValue" );
			}

			this.valueType = valueType;
			ChangeValue( value );
		} // ValueSetting

		// ----------------------------------------------------------------------
		public override object OriginalValue
		{
			get { return LoadValue( Name, valueType, SerializeAs, DefaultValue ); }
		} // OriginalValue

		// ----------------------------------------------------------------------
		public override object Value
		{
			get { return value; }
			set { ChangeValue( value ); }
		} // Value

		// ----------------------------------------------------------------------
		public override void Load()
		{
			try
			{
				object originalValue = OriginalValue;
				if ( originalValue == null && LoadUndefinedValue == false )
				{
					return;
				}
				Value = originalValue;
			}
			catch
			{
				if ( ThrowOnErrorLoading )
				{
					throw;
				}
			}
		} // Load

		// ----------------------------------------------------------------------
		public override void Save()
		{
			try
			{
				object toSaveValue = Value;
				if ( toSaveValue == null && SaveUndefinedValue == false )
				{
					return;
				}
				SaveValue( Name, valueType, SerializeAs, toSaveValue, DefaultValue );
			}
			catch
			{
				if ( ThrowOnErrorSaving )
				{
					throw;
				}
			}
		} // Save

		// ----------------------------------------------------------------------
		private void ChangeValue( object newValue )
		{
			if ( newValue != null && newValue.GetType() != valueType )
			{
				throw new ArgumentException( "newValue" );
			}
			value = newValue;
		} // ChangeValue

		// ----------------------------------------------------------------------
		// members
		private readonly Type valueType;
		private object value;

	} // class ValueSetting

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
