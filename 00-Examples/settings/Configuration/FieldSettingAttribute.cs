// -- FILE ------------------------------------------------------------------
// name       : FieldSettingAttribute.cs
// created    : Jani Giannoudis - 2009.01.14
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	[AttributeUsage( AttributeTargets.Field, AllowMultiple = false )]
	public class FieldSettingAttribute : Attribute
	{

		// ----------------------------------------------------------------------
		public string Name { get; set; }

		// ----------------------------------------------------------------------
		public object DefaultValue { get; set; }

	} // class FieldSettingAttribute

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
