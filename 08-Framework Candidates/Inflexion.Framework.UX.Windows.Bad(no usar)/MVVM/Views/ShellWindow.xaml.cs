// -----------------------------------------------------------------------
// <copyright file="ShellWindow.xaml.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.Views
{
    #region Imports

    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Windows.Media;


    using Inflexion.Framework.UX.Windows.MVVM.ViewModels;

    using MahApps.Metro.Controls;

    #endregion

    /// <summary>
    /// Representa la ventana principal de aplicación.
    /// </summary>
    /// <remarks>
    /// Ventana de alto nivel Prism.
    /// </remarks>
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
            this.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name);

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