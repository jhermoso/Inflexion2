// -- FILE ------------------------------------------------------------------
// name       : PropertySettingCollector.cs
// created    : Jani Giannoudis - 2008.05.09
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.Windows;
using System.Diagnostics;

namespace Itenso.Configuration
{

	// ------------------------------------------------------------------------
	public class PropertySettingCollector : SettingCollector
	{
		
		// ----------------------------------------------------------------------
		public PropertySettingCollector( FrameworkElement owner, Type elementType, string propertyName )
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
		public FrameworkElement Owner
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
			Collect( owner, true );
		} // Collect

		// ----------------------------------------------------------------------
		private void Collect( DependencyObject currentObject, bool recursive )
		{
			foreach ( object child in LogicalTreeHelper.GetChildren( currentObject ) )
			{
				DependencyObject dependencyObject = child as DependencyObject;
				if ( dependencyObject == null )
				{
					continue;
				}

				FrameworkElement frameworkElement = child as FrameworkElement;
				if ( frameworkElement != null )
				{
// ReSharper disable UseMethodIsInstanceOfType
					bool add = elementType.IsAssignableFrom( frameworkElement.GetType() );
// ReSharper restore UseMethodIsInstanceOfType

					if ( add && string.IsNullOrEmpty( frameworkElement.Name ) )
					{
						add = false;
						Debug.WriteLine( "PropertySettingCollector: missing name for framework element " + frameworkElement );
					}

					if ( add && !OnCollectingSetting( frameworkElement ) )
					{
						add = false;
					}

					if ( add )
					{
						string settingName = string.Concat( frameworkElement.Name, ".", propertyName );
						PropertySetting propertySetting = new PropertySetting( settingName, frameworkElement, propertyName );
						propertySetting.DefaultValue = propertySetting.Value;
						ApplicationSettings.Settings.Add( propertySetting );
					}
				}

				if ( recursive )
				{
					Collect( dependencyObject, true );
				}
			}
		} // Collect

		// ----------------------------------------------------------------------
		// members
		private readonly FrameworkElement owner;
		private readonly Type elementType;
		private readonly string propertyName;

	} // class PropertySettingCollector

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
