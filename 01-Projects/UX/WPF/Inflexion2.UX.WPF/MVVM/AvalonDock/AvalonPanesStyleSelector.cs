// -----------------------------------------------------------------------
// <copyright file="AvalonPanesStyleSelector.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows;
    using Inflexion2.UX.WPF.MVVM.ViewModels;
    using Inflexion2.UX.WPF.MVVM.ViewModels.Regions;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AvalonPanesStyleSelector : StyleSelector
    {

        /// <summary>
        /// work space style
        /// </summary>
        public Style DocumentStyle
        {
            get;
            set;
        }

        /// <summary>
        /// toolbar style
        /// </summary>
        public Style ToolStyle
        {
            get;
            set;
        }

        /// <summary>
        /// select the style depending on type of container use.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public override System.Windows.Style SelectStyle(object item, System.Windows.DependencyObject container)
        {
            FrameworkElement element = item as FrameworkElement;

            if (element.DataContext is ToolbarViewModel || element.DataContext is TaskbarViewModel)
                return ToolStyle;

            if (element.DataContext is IWorkspaceViewModel)
                return DocumentStyle;

            return base.SelectStyle(item, container);
        }
    }
}
