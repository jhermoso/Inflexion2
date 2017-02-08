// -----------------------------------------------------------------------
// <copyright file="RegionViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Windows;

    using Inflexion2.UX.WPF.MVVM;
    using Inflexion2.UX.WPF.Services;

    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// Clase base para las clases modelo de vista (MVVM) que utilizan regiones Prism.
    /// </summary>
    public abstract class RegionViewModel : BaseViewModel, IRegionViewModel
    {
        #region Fields

        /// <summary>
        /// Referencia a la interfaz para obtener las instancias de un tipo de evento.
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// Referencia al gestor de regiones Prism.
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// Referencia al contenedor de inyección de dependencias Unity.
        /// </summary>
        private readonly IUnityContainer unityContainer;

        /// <summary>
        /// Valor que indica si esta instancia está activa.
        /// </summary>
        private bool isActive;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:RegionViewModel"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:RegionViewModel"/>.
        /// </remarks>
        protected RegionViewModel()
        {
            if (!this.IsDesignTime)
            {
                this.eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                this.regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
                this.unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Se produce después de que la propiedad <see cref="P:IsActive"/> cambia de valor.
        /// </summary>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:Microsoft.Practices.Prism.IActiveAware"/>.
        /// </remarks>
        public event EventHandler IsActiveChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Obtiene o establece un valor que indica si esta instancia está activa.
        /// </summary>
        /// <value>
        /// Es true para indicar que la instancia está activa; en caso contrario, false.
        /// </value>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:Microsoft.Practices.Prism.IActiveAware"/>.
        /// </remarks>
        public virtual bool IsActive
        {
            get
            {
                return this.isActive;
            }
            set
            {
                if (value != this.isActive)
                {
                    this.isActive = value;
                    this.RaiseIsActiveChanged();
                }
            }
        }

        /// <summary>
        /// Obtiene un valor que indica si esta instancia debe ser mantenida cuando se desactiva.
        /// </summary>
        /// <value>
        /// Es true para indicar que la instancia debe ser mantenida; en caso contrario, false.
        /// </value>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:Microsoft.Practices.Prism.Regions.IRegionMemberLifetime"/>.
        /// </remarks>
        public virtual bool KeepAlive
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// get instace of i navigation service to manage the navigation betwen views
        /// </summary>
        protected INavigationService NavigationService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        #endregion

        #region Protected Properties

        /// <summary>
        /// Obtiene la referencia a la interfaz para obtener las instancias de un tipo de evento.
        /// </summary>
        /// <value>
        /// Referencia a la interfaz para obtener las instancias de un tipo de evento.
        /// </value>
        protected IEventAggregator EventAggregator
        {
            get { return this.eventAggregator; }
        }

        /// <summary>
        /// Proporciona acceso al controlador de eventos <see cref="M:IsActiveChanged"/> para las clases derivadas.
        /// </summary>
        /// <value>
        /// La referencia al controlador de eventos <see cref="M:IsActiveChanged"/>.
        /// </value>
        protected EventHandler IsActiveChangedHandler
        {
            get { return this.IsActiveChanged; }
        }

        /// <summary>
        /// Obtiene la referencia al gestor de regiones Prism.
        /// </summary>
        /// <value>
        /// Referencia al gestor de regiones Prism.
        /// </value>
        protected IRegionManager RegionManager
        {
            get { return this.regionManager; }
        }

        /// <summary>
        /// Obtiene la referencia al contenedor de inyección de dependencias Unity.
        /// </summary>
        /// <value>
        /// Referencia al contenedor de inyección de dependencias Unity.
        /// </value>
        protected IUnityContainer UnityContainer
        {
            get { return this.unityContainer; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Determina si esta instancia puede manejar la solicitud de navegación.
        /// </summary>
        /// <param name="navigationContext">
        /// El contexto de navegación.
        /// </param>
        /// <returns>
        /// Es true si esta instancia acepta la solicitud de navegación; en caso contrario, false.
        /// </returns>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:Microsoft.Practices.Prism.Regions.INavigationAware"/>.
        /// </remarks>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// Se invoca antes de ejecutar una operación de navegación.
        /// </summary>
        /// <param name="navigationContext">
        /// El contexto de navegación.
        /// </param>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:Microsoft.Practices.Prism.Regions.INavigationAware"/>.
        /// </remarks>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        /// <summary>
        /// Se invoca cuando finaliza una operación de navegación.
        /// </summary>
        /// <param name="navigationContext">
        /// El contexto de navegación.
        /// </param>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:Microsoft.Practices.Prism.Regions.INavigationAware"/>.
        /// </remarks>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Provoca el evento <see cref="M:IsActiveChanged"/> si es necesario.
        /// </summary>
        protected virtual void RaiseIsActiveChanged()
        {
            var handler = this.IsActiveChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}