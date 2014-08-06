using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Inflexion.Framework.UX.WPF.Common.Events;
using Inflexion.Framework.UX.WPF.Common.Shell;

namespace Inflexion.Framework.UX.WPF.ModuleB.Commands
{
    public class ShowModuleBViewCommand : ICommand
    {
        #region Campos

        // Variables Miembro
        private ModuleBTaskButtonViewModel m_ViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ShowModuleBViewCommand(ModuleBTaskButtonViewModel viewModel)
        {
            m_ViewModel = viewModel;
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// Comprueba si el ShowModuleBViewCommand esta habilitado.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Aciones a ealizar cuando CanExecute() cambia.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Ejecuta el ShowModuleBViewCommand
        /// </summary>
        public void Execute(object parameter)
        {
            // Inicializa
            var regionManager = (RegionManager)ServiceLocator.Current.GetInstance<IRegionManager>();

            // Mostrar la pestaña del ribbon
            var moduleBRibbonTab = new Uri("ModuleBRibbonTab", UriKind.Relative);
            regionManager.RequestNavigate(RegionNames.RibbonRegion, moduleBRibbonTab);

            // Mostrar el area de navegación
            var moduleBNavigator = new Uri("ModuleBNavigator", UriKind.Relative);
            regionManager.RequestNavigate(RegionNames.NavigatorRegion, moduleBNavigator);

            /* Invocamos el NavigationCompleted() callback method en la siguiente  
             * solicitud de navegación desde que se ha realizado la ultima solicitud. */

            // Mostramos el area de trabajo
            var moduleBWorkspace = new Uri("ModuleBWorkspace", UriKind.Relative);
            regionManager.RequestNavigate(RegionNames.WorkspaceRegion, moduleBWorkspace, NavigationCompleted);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Callback method invocado cuando la navegacion se ha completado.
        /// </summary>
        /// <param name="result">Proporciona información acerca del resultado de la navegación..</param>
        private void NavigationCompleted(NavigationResult result)
        {
            // Salimos si la navegación no se ha completado correctamente.
            if (result.Result != true) return;

            // Publicamos el ViewRequestedEvent
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var navigationCompletedEvent = eventAggregator.GetEvent<NavigationCompletedEvent>();
            navigationCompletedEvent.Publish("ModuleB");
        }

        #endregion
    }
}
