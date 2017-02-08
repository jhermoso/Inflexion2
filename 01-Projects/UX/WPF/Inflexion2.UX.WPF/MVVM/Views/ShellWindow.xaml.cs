// -----------------------------------------------------------------------
// <copyright file="ShellWindow.xaml.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.Views
{
    #region Imports

    using Inflexion2.UX.WPF.MVVM.ViewModels;
    using MahApps.Metro.Controls;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    #endregion

    /// <summary>
    /// Representa la ventana principal de aplicación.
    /// todo: check if new versions of metrowindow are cls compliant
    /// </summary>
    /// <remarks>
    /// Ventana de alto nivel Prism.
    /// </remarks>
    [CLSCompliant(false)]
    public partial class ShellWindow : MetroWindow
    {

        #region Constructors

        /// <summary>
        /// Permite crear una nueva ventana principal de aplicación.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:ShellWindow"/>.
        /// </remarks>
        public ShellWindow()
        {
            this.InitializeComponent();

            this.ApplicationRibbon.DataContext = new ToolbarViewModel(this.ApplicationRibbon);
        }

        #endregion

        private void ApplicationRibbon_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Grid child = VisualTreeHelper.GetChild((DependencyObject)sender, 0) as Grid;
            if (child != null)
            {
                child.RowDefinitions[0].Height = new GridLength(0);
            }
        }
    }
}