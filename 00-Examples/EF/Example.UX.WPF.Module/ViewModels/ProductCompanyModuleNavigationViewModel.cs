// -----------------------------------------------------------------------
// <copyright file="PoliticaComercialModuleNavigationViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Company.Product.Shared.UX.WPF.Module.ViewModels
{
    using System.Windows.Input;
    using Inflexion.Framework.UX.Windows.MVVM;
    using Inflexion.Framework.UX.Windows.MVVM.Commands;
    using Inflexion.Framework.UX.Windows.MVVM.ViewModels;

    //using Company.Product.Shared.UX.WPF.ClaseRoot.View;
    

    /// <summary>
    /// Representa el modelo de vista de <see cref="T:CompanyProductModuleNavigationView"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public sealed class CompanyProductModuleNavigationViewModel : NavigationViewModel
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:PoliticaComercialModuleNavigationViewModel"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:PoliticaComercialModuleNavigationViewModel"/>.
        /// </remarks>
        public CompanyProductModuleNavigationViewModel()
        {
            this.Initialize();
        }

        #endregion

        #region Command Properties

            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de Desconexion.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Desconexion.
            /// </value>
            public ICommand ShowDesconexionView { get; set; }

            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de Ambito.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Ambito..
            /// </value>
            public ICommand ShowAmbitoView { get; set; }



            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de GranFranjaMaestra.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Gran Franja Maestra..
            /// </value>
            public ICommand ShowGranFranjaMaestraView { get; set; }


            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de Ambito.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Ambito..
            /// </value>
            public ICommand ShowGranFranjaSofresView { get; set; }


            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de Medio.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Ambito..
            /// </value>
            public ICommand ShowMedioView { get; set; }

            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de Medio.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Ambito..
            /// </value>
            public ICommand ShowTipoMedioView { get; set; }


            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de Soporte.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Soporte..
            /// </value>
            public ICommand ShowSoporteView { get; set; }


            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de Medio.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Ambito..
            /// </value>
            public ICommand ShowPoliticasView { get; set; }

            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de Diseño Politica.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Diseño Politica.
            /// </value>
            public ICommand ShowDesignPoliticasView { get; set; }

            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de 
            /// Grupo Desconexion.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Grupo Desconexion.
            /// </value>
            public ICommand ShowGrupoDesconexionView { get; set; }

            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de 
            /// Tipo Posicion.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Tipo Posición.
            /// </value>
            public ICommand ShowTipoPosicionView { get; set; }

            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de 
            /// Tipo Recargo Generico.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Tipo Recargo Generico.
            /// </value>
            public ICommand ShowTipoRecargoGenericoView { get; set; }

            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de 
            /// Tipo Tiempo.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Tipo Tiempo.
            /// </value>
            public ICommand ShowTipoTiempoView { get; set; }

            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de 
            /// Tipo Forma Publicitaria.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Tipo Forma Publicitaria.
            /// </value>
            public ICommand ShowTipoFormaPublicitariaView { get; set; }

        #endregion

        #region Private Methods

        /// <summary>
        /// Inicializa el modelo de vista.
        /// </summary>
        private void Initialize()
        {

            // ClassRoot
            //this.ShowDesconexionView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            //    this, RegionNames.WorkspaceRegion, typeof(ClassRootQueryView).FullName);

            

        }

        #endregion
    }
}




