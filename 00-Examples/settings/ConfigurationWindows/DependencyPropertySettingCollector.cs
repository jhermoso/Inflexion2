// -- FILE ------------------------------------------------------------------
// name       : DependencyPropertySettingCollector.cs
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
	public class DependencyPropertySettingCollector : SettingCollector
	{
		
		// ----------------------------------------------------------------------
		public DependencyPropertySettingCollector( FrameworkElement owner, DependencyProperty dependencyProperty )
		{
			if ( owner == null )
			{
				throw new ArgumentNullException( "owner" );
			}
			if ( dependencyProperty == null )
			{
				throw new ArgumentNullException( "dependencyProperty" );
			}

			this.owner = owner;
			this.dependencyProperty = dependencyProperty;
		} // DependencyPropertySettingCollector

		// ----------------------------------------------------------------------
		public FrameworkElement Owner
		{
			get { return owner; }
		} // Owner

		// ----------------------------------------------------------------------
		public DependencyProperty DependencyProperty
		{
			get { return dependencyProperty; }
		} // DependencyProperty

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
					bool add = dependencyProperty.OwnerType.IsAssignableFrom( frameworkElement.GetType() );
// ReSharper restore UseMethodIsInstanceOfType

					if ( add && string.IsNullOrEmpty( frameworkElement.Name ) )
					{
						add = false;
						Debug.WriteLine( "DependencyPropertySettingCollector: missing name for framework element " + frameworkElement );
					}

					if ( add && !OnCollectingSetting( frameworkElement ) )
					{
						add = false;
					}

					if ( add )
					{
						string settingName = string.Concat( frameworkElement.Name, ".", dependencyProperty.Name );
						DependencyPropertySetting dependencyPropertySetting =
							new DependencyPropertySetting( settingName, frameworkElement, dependencyProperty );
						dependencyPropertySetting.DefaultValue = dependencyPropertySetting.Value;
						ApplicationSettings.Settings.Add( dependencyPropertySetting );
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
		private readonly DependencyProperty dependencyProperty;

	} // class DependencyPropertySettingCollector

} // namespace Itenso.Configuration
// -- EOF -------------------------------------------------------------------
