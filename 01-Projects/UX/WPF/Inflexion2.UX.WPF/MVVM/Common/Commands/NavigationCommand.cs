// -----------------------------------------------------------------------
// <copyright file="NavigationCommand.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.Commands
{
    using System;
    using System.Windows.Input;

    using Inflexion2.UX.WPF.MVVM;

    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// Representa el comando de navegación.
    /// </summary>
    /// <typeparam name="T">
    /// Tipo de ViewModel que contiene la referencia a este comando.
    /// </typeparam>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public sealed class NavigationCommand<T> : ICommand 
        where T : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// Referencia a la devolución de llamada cuando se ha completado la navegación.
        /// </summary>
        private readonly Action<NavigationResult> navigationCallback;

        /// <summary>
        /// Referencia al modelo de vista que contiene la referencia a este comando.
        /// </summary>
        private readonly T navigationViewModel;

        /// <summary>
        /// Indica el nombre de la región donde se va a mostrar la vista.
        /// </summary>
        private readonly string regionName;

        /// <summary>
        /// Indica el nombre de la vista que se va a mostrar.
        /// </summary>
        private readonly string viewName;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:NavigationCommand"/>.
        /// </summary>
        /// <param name="navigationViewModel">
        /// Referencia al modelo de vista que contiene la referencia a este comando.
        /// </param>
        /// <param name="regionName">
        /// Indica el nombre de la región donde se va a mostrar la vista.
        /// </param>
        /// <param name="viewName">
        /// Indica el nombre de la vista que se va a mostrar.
        /// </param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:NavigationCommand"/>.
        /// </remarks>
        public NavigationCommand(T navigationViewModel, string regionName, string viewName)
            : this(navigationViewModel, regionName, viewName, delegate { })
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:NavigationCommand"/>.
        /// </summary>
        /// <param name="navigationViewModel">
        /// Referencia al modelo de vista que contiene la referencia a este comando.
        /// </param>
        /// <param name="regionName">
        /// Indica el nombre de la región donde se va a mostrar la vista.
        /// </param>
        /// <param name="viewName">
        /// Indica el nombre de la vista que se va a mostrar.
        /// </param>
        /// <param name="navigationCallback">
        /// Referencia a la devolución de llamada cuando se ha completado la navegación.
        /// </param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:NavigationCommand"/>.
        /// </remarks>
        public NavigationCommand(T navigationViewModel, string regionName, string viewName, Action<NavigationResult> navigationCallback)
        {
            this.navigationCallback = navigationCallback;
            this.navigationViewModel = navigationViewModel;
            this.regionName = regionName;
            this.viewName = viewName;
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// Se produce cuando se produzcan cambios que afecten o no
        /// al comando que debe ejecutarse.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Determina si el comando se puede ejecutar.
        /// </summary>
        /// <param name="parameter">
        /// Datos utilizados por el comando.
        /// </param>
        /// <returns>
        /// Es true si el comando se puede ejecutar; en caso contrario, false.
        /// </returns>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Ejecuta el comando.
        /// </summary>
        /// <param name="parameter">
        /// Datos utilizados por el comando.
        /// </param>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public void Execute(object parameter)
        {
            // Obtener el gestor de regiones Prism del contenedor actual.
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            // Mostramos la vista.
            var moduleNavigator = new Uri(this.viewName, UriKind.Relative);
            regionManager.RequestNavigate(this.regionName, moduleNavigator, this.navigationCallback);
        }

        #endregion
    }
}