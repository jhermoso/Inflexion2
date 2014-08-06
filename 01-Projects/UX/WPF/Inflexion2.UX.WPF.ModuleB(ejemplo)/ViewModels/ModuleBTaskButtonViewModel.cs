using System.Windows.Input;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Inflexion.Framework.UX.WPF.Common.BaseClasses;
using Inflexion.Framework.UX.WPF.Common.Events;
using Inflexion.Framework.UX.WPF.ModuleB.Commands;

namespace Inflexion.Framework.UX.WPF.ModuleB
{
    public class ModuleBTaskButtonViewModel : ViewModelBase, INavigationAware
    {
        #region Campos

        // Property variables
        private bool? p_IsChecked;

        #endregion

        #region Constructores

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ModuleBTaskButtonViewModel()
        {
            this.Initialize();
        }

        #endregion

        #region Miembros INavigationAware

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Command Properties

        /// <summary>
        /// Cargamos la vista que por defecto se ha asociado al módulo
        /// </summary>
        public ICommand ShowModuleBView { get; set; }   

        #endregion

        #region Administrative Properties

        /// <summary>
        /// Cuando el botón es pinchado,  el botón se queda en el estado de seleccionado y se disparan los eventos pre y post. con el objeto de que los 
        /// demas botones de otros modulos puedan desactivarse.
        /// 
        /// </summary>
        public bool? IsChecked
        {
            get { return p_IsChecked; }

            set
            {
                base.RaisePropertyChangingEvent("IsChecked");
                p_IsChecked = value;
                base.RaisePropertyChangedEvent("IsChecked");
            }
        }

        #endregion

        #region Event Handlers

        private void OnNavigationCompleted(string publisher)
        {
            // salir si el módulo publica el evento
            if (publisher == "ModuleB") return;

            // En caso contrario desahabilitar el botón.
            this.IsChecked = false;
        }

        #endregion

        #region metodos privados

        /// <summary>
        /// Incializa el view model.
        /// </summary>
        private void Initialize()
        {
            // Inicializa los command properties
            this.ShowModuleBView = new ShowModuleBViewCommand(this); // le pasamos la instancia del propio ViewModel

            // Inicializa las propiedades de administración.
            this.IsChecked = false;

            // Suscribre los eventos de Composite Presentation
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var navigationCompletedEvent = eventAggregator.GetEvent<NavigationCompletedEvent>();
            navigationCompletedEvent.Subscribe(OnNavigationCompleted, ThreadOption.UIThread);
        }

        #endregion
    }
}