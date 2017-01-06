// -- FILE ------------------------------------------------------------------
// name       : PropertySettingCollector.cs
// created    : Jani Giannoudis - 2008.05.09
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	public class PropertySettingCollector : SettingCollector
	{
		
		// ----------------------------------------------------------------------
		public PropertySettingCollector( Control owner, Type elementType, string propertyName )
		{
			if ( owner == null )
			{
				throw new ArgumentNullException( "owner" );
			}
			if ( elementType == null )
			{
				throw new ArgumentNullException( "elementType" );
			}
			if ( string.IsNullOrEmpty( propertyName ) )
			{
				throw new ArgumentNullException( "propertyName" );
			}

			this.owner = owner;
			this.elementType = elementType;
			this.propertyName = propertyName;
		} // PropertySettingCollector

		// ----------------------------------------------------------------------
		public Control Owner
		{
			get { return owner; }
		} // Owner

		// ----------------------------------------------------------------------
		public Type ElementType
		{
			get { return elementType; }
		} // ElementType

		// ----------------------------------------------------------------------
		public string PropertyName
		{
			get { return propertyName; }
		} // PropertyName

		// ----------------------------------------------------------------------
		public override void Collect()
		{
			Collect( owner.Controls, true );
		} // Collect

		// ----------------------------------------------------------------------
		private void Collect( Control.ControlCollection children, bool recursive )
		{
			foreach ( Control control in children )
			{
				bool add = control.GetType().IsAssignableFrom( elementType );

				string controlId = null;
				if ( add )
				{
					controlId = GetControlId( control );
					if ( string.IsNullOrEmpty( controlId ) )
					{
						add = false;
						Debug.WriteLine( "PropertySettingCollector: missing id for control " + control );
					}
				}

				if ( add && !OnCollectingSetting( control ) )
				{
					add = false;
				}

				if ( add )
				{
					string settingName = string.Concat( controlId, ".", propertyName );
					PropertySetting propertySetting = new PropertySetting( settingName, control, propertyName );
					propertySetting.DefaultValue = propertySetting.Value;
					ApplicationSettings.Settings.Add( propertySetting );
				}

				if ( recursive && control.Controls.Count > 0 )
				{
					Collect( control.Controls, true );
				}
			}
		} // Collect

		// ----------------------------------------------------------------------
		private string GetControlId( Control control )
		{
			if ( control.Parent == owner )
			{
				return control.Name;
			}

			StringBuilder sb = new StringBuilder();

			while ( control != null && control != owner )
			{
				if ( sb.Length > 0 )
				{
					sb.Insert( 0, "." );
				}
				sb.Insert( 0, control.Name );
				control = control.Parent;
			}

			return sb.ToString();
		} // GetControlId

		// ----------------------------------------------------------------------
		// members
		private readonly Control owner;
		private readonly Type elementType;
		private readonly string propertyName;

	} // class PropertySettingCollector

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
