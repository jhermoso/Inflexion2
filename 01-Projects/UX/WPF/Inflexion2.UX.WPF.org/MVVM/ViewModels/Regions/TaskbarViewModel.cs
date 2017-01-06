// -----------------------------------------------------------------------
// <copyright file="TaskbarViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.ViewModels
{
    using System;
    using System.Windows.Input;

    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;

    /// <summary>
    /// Clase base para las clases modelo de vista (MVVM) que utilizan la región TaskbarRegion.
    /// </summary>
    public abstract class TaskbarViewModel : RegionViewModel
    {
        #region Fields

        /// <summary>
        /// Indica el tipo de módulo al que pertenece este ViewModel.
        /// </summary>
        private readonly Type moduleType;

        /// <summary>
        /// Indica si el botón está chequeado.
        /// </summary>
        private bool? isChecked;

        /// <summary>
        /// Indica el comando de carga de la vista de navegación de este módulo.
        /// </summary>
        private ICommand showModuleNavigationView; 

        private RegionViewModel moduleRibbonViewModel;//*

        /// <summary>
        /// Indica el comando de carga de la pestaña de ribbon de este módulo.
        /// </summary>
        private ICommand showModuleRibbonView; //*

        /// <summary>
        /// Indica la imagen del botón.
        /// </summary>
        private string taskButtonImage;

        /// <summary>
        /// Indica el texto del botón.
        /// </summary>
        private string taskButtonText;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:TaskbarViewModel"/>.
        /// </summary>
        /// <param name="moduleType">
        /// Tipo de módulo al que pertenece este ViewModel.
        /// </param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:TaskbarViewModel"/>.
        /// </remarks>
        protected TaskbarViewModel(Type moduleType)
        {
            if (!this.IsDesignTime)
            {
                // Inicialición.
                this.moduleType = moduleType;

                this.isChecked                  = false;
                this.showModuleNavigationView   = null;

                this.showModuleRibbonView       = null;//*
                this.moduleRibbonViewModel = null;//*

                this.taskButtonImage            = string.Empty;
                this.taskButtonText             = string.Empty;

                // Suscripción de eventos.
                var navigationCompletedEvent = this.EventAggregator.GetEvent<NavigationCompletedEvent>();
                navigationCompletedEvent.Subscribe(this.OnNavigationCompleted, ThreadOption.UIThread);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Obtiene o establece un valor que indica si el botón está checkeado.
        /// </summary>
        /// <value>
        /// Indica si el botón está chequeado.
        /// </value>
        public bool? IsChecked
        {
            get
            {
                return this.isChecked;
            }

            set
            {
                if (this.isChecked != value)
                {
                    this.RaisePropertyChanging(() => this.IsChecked);
                    this.isChecked = value;
                    this.RaisePropertyChanged(() => this.IsChecked);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el comando de carga de la vista de navegación de este módulo.
        /// </summary>
        /// <value>
        /// Indica el comando de carga de la vista de navegación de este módulo.
        /// </value>
        public ICommand ShowModuleNavigationView
        {
            get { return this.showModuleNavigationView; }
            set { this.showModuleNavigationView = value; }
        }

        /// <summary>
        /// Obtiene o establece el comando de carga de la vista de navegación de este módulo.
        /// </summary>
        /// <value>
        /// Indica el comando de carga de la vista de navegación de este módulo.
        /// </value>
        public ICommand ShowModuleRibbonView//*
        {
            get { return this.showModuleRibbonView; }
            set { this.showModuleRibbonView = value; }
        }


        public RegionViewModel ModuleRibbonViewModel//*
        {
            get { return this.moduleRibbonViewModel; }
            set { this.moduleRibbonViewModel = value; }
        }
        /// <summary>
        /// Obtiene o establece la imagen del botón.
        /// </summary>
        /// <value>
        /// Imagen del botón.
        /// </value>
        public string TaskButtonImage
        {
            get
            {
                return this.taskButtonImage;
            }
            set
            {
                if (this.taskButtonImage != value)
                {
                    this.RaisePropertyChanging(() => this.TaskButtonImage);
                    this.taskButtonImage = value;
                    this.RaisePropertyChanged(() => this.TaskButtonImage);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el texto del botón.
        /// </summary>
        /// <value>
        /// Texto del botón.
        /// </value>
        public string TaskButtonText
        {
            get
            {
                return this.taskButtonText;
            }
            set
            {
                if (this.taskButtonText != value)
                {
                    this.RaisePropertyChanging(() => this.TaskButtonText);
                    this.taskButtonText = value;
                    this.RaisePropertyChanged(() => this.TaskButtonText);
                }
            }
        }

        #endregion

        #region Protected Properties

        /// <summary>
        /// Obtiene el tipo de módulo al que pertenece este ViewModel.
        /// </summary>
        /// <value>
        /// Tipo de módulo al que pertenece este ViewModel.
        /// </value>
        protected Type ModuleType
        {
            get { return this.moduleType; }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Se ejecuta cuando se ha completado la navegación.
        /// </summary>
        /// <param name="publisher">
        /// Indica el nombre del módulo que ha publicado del evento
        /// </param>
        protected virtual void OnNavigationCompleted(string publisher)
        {
            if (publisher != this.ModuleType.Name)
            {
                // Deseleccionamos los botones del resto de los módulos.
                this.IsChecked = false;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Se ejecuta cuando se ha completado la navegación.
        /// </summary>
        /// <param name="result">
        /// Indica información sobre el resultado de la navegación.
        /// </param>
        protected virtual void NavigationCompleted(NavigationResult result)
        {
            if (result.Result.HasValue && result.Result.Value)
            {
                // Propagamos el nombre del módulo activo para desactivar
                // los TaskButtons del resto de módulos cargados en la región TaskbarRegion.
                var navigationCompletedEvent = this.EventAggregator.GetEvent<NavigationCompletedEvent>();
                navigationCompletedEvent.Publish(this.ModuleType.Name);
            }
        }

        #endregion
    }
}