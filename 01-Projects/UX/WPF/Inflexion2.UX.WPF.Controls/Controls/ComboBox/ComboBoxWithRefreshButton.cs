// -----------------------------------------------------------------------
// <copyright file="ComboBoxWithRefreshButton.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Controls
{
    using System.Windows;
    using System.Windows.Input;


    /// <summary>
    /// Dependency propertie for ComboBox with refresh button
    /// </summary>
    public class ComboBoxWithRefreshButton : DependencyObject
    {
        /// <summary>
        /// Boolean Atached Dependency Property to show or not a button with the option to refresh
        /// </summary>
        public static readonly DependencyProperty ShowRefreshButtonProperty = DependencyProperty.RegisterAttached("ShowRefreshButton", typeof(bool), typeof(ComboBoxWithRefreshButton), new UIPropertyMetadata(false));

        /// <summary>
        /// command Attached dependency property to asig an action to the refresh button
        /// </summary>
        public static readonly DependencyProperty RefreshCommandProperty = DependencyProperty.RegisterAttached("RefreshCommand", typeof(ICommand), typeof(ComboBoxWithRefreshButton));

        /// <summary>
        /// method to set the refres button
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetShowRefreshButton(
                                           DependencyObject obj,
                                           bool value)
        {
            obj.SetValue(ShowRefreshButtonProperty, value);
        }

        /// <summary>
        /// Get the visibility of the button
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetShowRefreshButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowRefreshButtonProperty);
        }

        /// <summary>
        /// set the action for the command
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetRefreshCommand(
                                        DependencyObject obj,
                                        ICommand value)
        {
            obj.SetValue(RefreshCommandProperty, value);
        }

        /// <summary>
        /// get the command
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ICommand GetRefreshCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(RefreshCommandProperty);
        }

    } // ComboBoxWithRefreshButton

} // Inflexion2.UX.WPF.Controls