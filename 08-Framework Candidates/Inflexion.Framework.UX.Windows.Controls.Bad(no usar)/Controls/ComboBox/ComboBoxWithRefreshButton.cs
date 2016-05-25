// -----------------------------------------------------------------------
// <copyright file="ComboBoxWithRefreshButton.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Input;

    public class ComboBoxWithRefreshButton : DependencyObject
    {
        public static readonly DependencyProperty ShowRefreshButtonProperty = DependencyProperty.RegisterAttached("ShowRefreshButton", typeof(bool), typeof(ComboBoxWithRefreshButton), new UIPropertyMetadata(false));
        public static readonly DependencyProperty RefreshCommandProperty = DependencyProperty.RegisterAttached("RefreshCommand", typeof(ICommand), typeof(ComboBoxWithRefreshButton));

        public static void SetShowRefreshButton(
                                           DependencyObject obj,
                                           bool value)
        {
            obj.SetValue(ShowRefreshButtonProperty, value);
        }

        public static bool GetShowRefreshButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowRefreshButtonProperty);
        }

        public static void SetRefreshCommand(
                                        DependencyObject obj,
                                        ICommand value)
        {
            obj.SetValue(RefreshCommandProperty, value);
        }

        public static ICommand GetRefreshCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(RefreshCommandProperty);
        }

    } // ComboBoxWithRefreshButton

} // Inflexion.Framework.UX.Windows.Controls