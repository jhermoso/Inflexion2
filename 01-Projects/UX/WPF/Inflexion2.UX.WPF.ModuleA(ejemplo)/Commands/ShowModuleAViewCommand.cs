using System;
using System.Windows.Input; // este namespace se encuentra en el ensamblado de WindowsBase
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Inflexion.Framework.UX.WPF.Common.Events;
using Inflexion.Framework.UX.WPF.ModuleA.ViewModels;

namespace Inflexion.Framework.UX.WPF.ModuleA.Commands
{
    public class ShowModuleAViewCommand : ICommand
    {
        #region Fields

        // Variables miembro
        private ModuleATaskButtonViewModel m_ViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public ShowModuleAViewCommand(ModuleATaskButtonViewModel viewModel)
        {
            m_ViewModel = viewModel;
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// comprobamos si el ShowModuleAViewCommand esta habilitado. Podemos introducir una lógica de habilitación.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Acciones que se pueden llevar a cabo cuando el CanExecute() cambia.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// ejecuta el comando ShowModuleAViewCommand
        /// </summary>
        public void Execute(object parameter)
        {
            // Inicializamos obteniendo la instancia de Iregionmanager del contenedor actual
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            // Mostramos la pestaña en el Ribbon
            var moduleARibbonTab = new Uri("ModuleARibbonTab", UriKind.Relative);
            regionManager.RequestNavigate("RibbonRegion", moduleARibbonTab);

            // Mostramos la vista del navegador
            var moduleANavigator = new Uri("ModuleANavigator", UriKind.Relative);
            regionManager.RequestNavigate("NavigatorRegion", moduleANavigator);

            /* Invocamos el metodo callback de NavigationCompleted al finalizar la solicitud de navegación.*/

            // Mostramos el Workspace
            var moduleAWorkspace = new Uri("ModuleAWorkspace", UriKind.Relative);
            regionManager.RequestNavigate("WorkspaceRegion", moduleAWorkspace, NavigationCompleted);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Callback method invoked when navigation has completed.
        /// </summary>
        /// <param name="result">Provides information about the result of the navigation.</param>
        private void NavigationCompleted(NavigationResult result)
        {
            // Exit if navigation was not successful
            if (result.Result != true) return;

            // Publish ViewRequestedEvent
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var navigationCompletedEvent = eventAggregator.GetEvent<NavigationCompletedEvent>();
            navigationCompletedEvent.Publish("ModuleA");
        }

        #endregion
    }
}
