// -----------------------------------------------------------------------
// <copyright file="NavigationCommand.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.Commands
{
    using Inflexion2.UX.WPF.MVVM;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using System;
    using System.Windows.Input;

    /// <summary>
    /// .en navigation command
    /// .es Representa el comando de navegación.
    /// </summary>
    /// <typeparam name="T">
    /// Tipo de ViewModel que contiene la referencia a este comando.
    /// </typeparam>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public sealed class MultipleViewsNavigationCommand<T> : ICommand 
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
        private readonly string[] regionNames;

        /// <summary>
        /// Indica el nombre de la vista que se va a mostrar.
        /// </summary>
        private readonly string[] viewNames;

        /// <summary>
        /// numero de vistas que tenemos que cargar, se deduce del array de vistas.
        /// </summary>
        private int numViews;

        #endregion

        #region Constructors

        /// <summary>
        /// not implemented
        /// Inicializa una nueva instancia de la clase <see cref="T:NavigationCommand"/>.
        /// </summary>
        /// <param name="navigationViewModel">
        /// Referencia al modelo de vista que contiene la referencia a este comando.
        /// </param>
        /// <param name="regionNames">
        /// Indica el nombre de la región donde se va a mostrar la vista.
        /// </param>
        /// <param name="viewNames">
        /// Indica el nombre de la vista que se va a mostrar.
        /// </param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:NavigationCommand"/>.
        /// </remarks>
        public MultipleViewsNavigationCommand(T navigationViewModel, string[] regionNames, string[] viewNames)
            : this(navigationViewModel, regionNames, viewNames, delegate { })
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:NavigationCommand"/>.
        /// </summary>
        /// <param name="navigationViewModel">
        /// Referencia al modelo de vista que contiene la referencia a este comando.
        /// </param>
        /// <param name="regionNames">
        /// Indica el nombre de la región donde se va a mostrar la vista.
        /// </param>
        /// <param name="viewNames">
        /// Indica el nombre de la vista que se va a mostrar.
        /// </param>
        /// <param name="navigationCallback">
        /// Referencia a la devolución de llamada cuando se ha completado la navegación.
        /// </param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:NavigationCommand"/>.
        /// </remarks>
        public MultipleViewsNavigationCommand(T navigationViewModel, string[] regionNames, string[] viewNames, Action<NavigationResult> navigationCallback)
        {
            if (regionNames.Length == viewNames.Length)
            {
                this.navigationCallback = navigationCallback;
                this.navigationViewModel = navigationViewModel;
                this.regionNames = regionNames;
                this.viewNames = viewNames;
                this.numViews = this.viewNames.Length;
            }
            else throw new Exception("el numero de nombres de region y de vistas no coincide:MultipleViewsNavigationCommand ");

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

            Uri[] modulesNavigator = new Uri[this.numViews];

            // Mostramos la vistas.
            for (int i = 0; i < this.numViews; i++)
            {
                modulesNavigator[i] = new Uri(this.viewNames[i], UriKind.Relative);
                if (i < this.numViews - 1)
                {
                    regionManager.RequestNavigate(this.regionNames[i], modulesNavigator[i]);
                }
                else 
                {   // solo la ultima vista indica que se ha terminado la navegación
                    regionManager.RequestNavigate(this.regionNames[i], modulesNavigator[i], this.navigationCallback);
                }
                
            }

        }

        #endregion
    }
}