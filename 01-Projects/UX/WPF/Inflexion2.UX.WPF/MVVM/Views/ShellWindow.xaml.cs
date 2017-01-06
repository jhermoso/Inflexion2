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
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

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
            //windowSettings = new Itenso.Configuration.WindowSettings(this);
            //windowSettings.CollectingSetting += WindowCollectingSetting;
            //this.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name);

            //WindowLanguageProperty =
            //DependencyProperty.Register(
            //"WindowLanguaje", typeof(string), typeof(ApplicationSettings),
            //new FrameworkPropertyMetadata("0", FrameworkPropertyMetadataOptions.AffectsRender));

            this.ApplicationRibbon.DataContext = new ToolbarViewModel(this.ApplicationRibbon);

            //windowSettings.Settings.Add(
            //    new DependencyPropertySetting(this, WindowLanguageProperty, WindowLanguage));
        }

        #endregion

        /// <summary>
        /// Atributo para salvar la configuración del usuario el idioma seleccionado.
        /// </summary>
        //public static DependencyProperty WindowLanguageProperty;

        private void ApplicationRibbon_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Grid child = VisualTreeHelper.GetChild((DependencyObject)sender, 0) as Grid;
            if (child != null)
            {
                child.RowDefinitions[0].Height = new GridLength(0);
            }
        }


        //public string WindowLanguage
        //{
        //    get { return (string)GetValue(WindowLanguageProperty); }
        //    set { SetValue(WindowLanguageProperty, value); }
        //}

        //private void WindowCollectingSetting(object sender, SettingCollectorCancelEventArgs e)
        //{
        //    OnCollectingSetting(e);
        //} // WindowCollectingSetting

        ///// <summary>
        ///// implementation of settings following example from http://www.codeproject.com/Articles/25829/User-Settings-Applied
        ///// </summary>
        ///// <param name="e"></param>
        //protected virtual void OnCollectingSetting(SettingCollectorCancelEventArgs e)
        //{
        //} // OnCollectingSetting

        //todo: check the ambiguiti betwen Itenso.Configuration.WindowSettings and MahApps.Metro.Controls.WindowSettings
        //private readonly Itenso.Configuration.WindowSettings windowSettings;
    }
}