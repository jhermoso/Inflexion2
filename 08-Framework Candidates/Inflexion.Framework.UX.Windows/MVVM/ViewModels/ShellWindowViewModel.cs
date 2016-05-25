// -----------------------------------------------------------------------
// <copyright file="ShellWindowViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.ViewModels
{
    #region Imports

    using System.Collections.Specialized;

    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    #endregion

    /// <summary>
    /// ViewModel de ShellWindow.
    /// </summary>
    public class ShellWindowViewModel : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// Referencia al gestor de regiones Prism.
        /// </summary>
        private readonly IRegionManager regionManager;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ShellWindowViewModel" />.
        /// </summary>
        public ShellWindowViewModel()
        {
            if (!this.IsDesignTime)
            {
                this.regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
                this.regionManager.Regions.CollectionChanged += Regions_CollectionChanged;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the NavigationFailed event of the NavigationService.
        /// 
        /// Developers you can use this event handler as a central place to 
        /// display a navigation failed message.  This handler can come in handy
        /// when initiating navigation from XAML where no call back is available.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Microsoft.Practices.Prism.Regions.RegionNavigationFailedEventArgs"/> instance containing the event data.</param>
        private void NavigationService_NavigationFailed(object sender, RegionNavigationFailedEventArgs e)
        {
            //this.Logger.Log(String.Format(Constants.Global.NavigationFailedMessage_FormatString, e.Uri.ToString(), e.Error.Message));

            //// demo only. In a real-world application, use a dialog service or interaction request to display messages.
            //MessageBox.Show(String.Format(Constants.Global.NavigationFailedMessage_FormatString, e.Uri.ToString(), e.Error.Message),
            //    Constants.Global.NavigationFailed, MessageBoxButton.OK, MessageBoxImage.Error);

            throw e.Error;
        }

        private void Regions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var list = e.NewItems;
                foreach (var item in list)
                {
                    var region = item as Region;
                    region.NavigationService.NavigationFailed += NavigationService_NavigationFailed;
                }
            }
        }

        #endregion
    }
}
