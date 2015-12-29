using System.Windows.Input;  // para la interface ICommand
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Inflexion.Framework.UX.WPF.Common.BaseClasses;
using Inflexion.Framework.UX.WPF.Common.Events;

using Inflexion.Framework.UX.WPF.ModuleA.Commands;

namespace Inflexion.Framework.UX.WPF.ModuleA.ViewModels
{
    public class ModuleATaskButtonViewModel : ViewModelBase, INavigationAware
    {
        #region Fields

        // Property variables
        private bool? p_IsChecked; // nullable

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ModuleATaskButtonViewModel()
        {
            this.Initialize();
        }

        #endregion

        #region INavigationAware Members

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
        /// Exponemos el comando de carga de la vista del modulo A.
        /// </summary>
        public ICommand ShowModuleAView { get; set; }   

        #endregion

        #region Administrative Properties

        /// <summary>
        /// La base del task botton se ha construido sobre boton check por lo que podemos cambiar el estado de checked (selected).
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

        /// <summary>
        /// Establecemos cual es el estado de IsChecked del task button cuando se ha completado la navegación.
        /// </summary>
        /// <param name="publisher">The publisher of the event.</param>
        private void OnNavigationCompleted(string publisher)
        {
            // Si es nuestro propio modulo quien ha publicado el evento entonces salimos.
            if (publisher == "ModuleA") return;

            // en cualquiere otro caso, es decir para los buton task del resto de los modulos establcemos su estado IsChecked a falso
            // para que aprezcan deseleccionados.
            this.IsChecked = false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Inicializa el view model.
        /// </summary>
        private void Initialize()
        {
            // Initialize command properties
            this.ShowModuleAView = new ShowModuleAViewCommand(this);

            // Initialize administrative properties
            this.IsChecked = false;

            // Subscribe to Composite Presentation Events
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var navigationCompletedEvent = eventAggregator.GetEvent<NavigationCompletedEvent>();
            navigationCompletedEvent.Subscribe(OnNavigationCompleted, ThreadOption.UIThread);
        }

        #endregion
    }
}