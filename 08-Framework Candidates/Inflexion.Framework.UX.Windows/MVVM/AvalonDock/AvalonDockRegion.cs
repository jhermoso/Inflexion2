using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AvalonDock.Layout;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Regions.Behaviors;
using System.ComponentModel;

namespace Inflexion.Framework.UX.Windows.MVVM
{
    class AvalonDockRegion : DependencyObject
    {
        #region Name

        /// <summary>
        /// Name Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.RegisterAttached("Name", typeof(string), typeof(AvalonDockRegion),
                new FrameworkPropertyMetadata((string)null,
                    new PropertyChangedCallback(OnNameChanged)));

        /// <summary>
        /// Gets the Name property.  This dependency property 
        /// indicates the region name of the layout item.
        /// </summary>
        public static string GetName(DependencyObject d)
        {
            return (string)d.GetValue(NameProperty);
        }

        /// <summary>
        /// Sets the Name property.  This dependency property 
        /// indicates the region name of the layout item.
        /// </summary>
        public static void SetName(DependencyObject d, string value)
        {
            d.SetValue(NameProperty, value);
        }

        /// <summary>
        /// Handles changes to the Name property.
        /// </summary>
        private static void OnNameChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            CreateRegion((LayoutAnchorable)s, (string)e.NewValue);
        }

        #endregion




        static void CreateRegion(LayoutAnchorable element, string regionName)
        {
            if (element == null) 
                throw new ArgumentNullException("element");

            //If I'm in design mode the main window is not set
            if ((bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue)
            {
                return;
            }

            try
            {
                if (ServiceLocator.Current == null)
                    return;

                // Build the region
                var mappings = ServiceLocator.Current.GetInstance<RegionAdapterMappings>();
                if (mappings == null)
                    return;
                IRegionAdapter regionAdapter = mappings.GetMapping(element.GetType());
                if (regionAdapter == null)
                    return;

                regionAdapter.Initialize(element, regionName);
            }
            catch (Exception ex)
            {
                throw new RegionCreationException(string.Format("Unable to create region {0}", regionName), ex);
            }

        }
    }
}
