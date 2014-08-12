// -----------------------------------------------------------------------
// <copyright file="CompanyProductModuleNavigationViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EF.UX.WPF.Module.Prism
{
    using EF.UX.WPF.Module.Entities;
    using System.Windows.Input;
    using Inflexion2.UX.WPF.MVVM;
    using Inflexion2.UX.WPF.MVVM.Commands;
    using Inflexion2.UX.WPF.MVVM.ViewModels;

    //TODO DESCOMENTAR
    //using Company.Product.Shared.Module.UX.WPF.Ambito.View;
    //using Company.Product.Shared.Module.UX.WPF.Contenedores.View;
    //using Company.Product.Shared.Module.UX.WPF.Entitys.Producto.View; // EF.UX.WPF.Module
    //using Company.Product.Shared.Module.UX.WPF.GranFranjaMaestra.View;
    //using Company.Product.Shared.Module.UX.WPF.GranFranjaSofres.View;
    ////using Company.Product.Shared.Module.UX.WPF.Parrilla.Views;
    //using Company.Product.Shared.Module.UX.WPF.GrupoProducto.View;
    //using Company.Product.Shared.Module.UX.WPF.Medio.View;
    //using Company.Product.Shared.Module.UX.WPF.Politica.View;
    //using Company.Product.Shared.Module.UX.WPF.Soporte.View;
    //using Company.Product.Shared.Module.UX.WPF.TipoMedio.View;
    //using Company.Product.Shared.Module.UX.WPF.Recargos.TipoRecargoGenerico.View;
    //using Company.Product.Shared.Module.UX.WPF.FormaPublicitaria.View;

    /// <summary>
    /// Representa el modelo de vista de <see cref="T:CompanyProductModuleNavigationView"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public sealed class EFExampleModuleNavigationViewModel : NavigationViewModel
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:CompanyProductModuleNavigationViewModel"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:CompanyProductModuleNavigationViewModel"/>.
        /// </remarks>
        public EFExampleModuleNavigationViewModel()
        {
            this.Initialize();
        }

        #endregion

        #region Command Properties

            /// <summary>
            /// Obtiene o establece el comando de carga de la vista de Producto.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Producto.
            /// </value>
            public ICommand ShowProductoView { get; set; }

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
            /// Grupo Producto.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Indica el comando de carga de la vista Grupo Producto.
            /// </value>
            public ICommand ShowGrupoProductoView { get; set; }

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
            //TODO DESCOMENTAR
            //// Producto
            this.ShowProductoView = new NavigationCommand<EFExampleModuleNavigationViewModel>(
                this, RegionNames.WorkspaceRegion, typeof(EntityBQueryView).FullName);


            //this.ShowProductoView = new NavigationCommand<EFExampleModuleNavigationViewModel>(
            //     this, RegionNames.TaskbarRegion, typeof(ModuleARibbonTab).FullName);

            //// Grupo Producto
            this.ShowGrupoProductoView = new NavigationCommand<EFExampleModuleNavigationViewModel>(
                this, RegionNames.ToolbarRegion, typeof(ModuleARibbonTab).FullName);

            //// Ambito
            //this.ShowAmbitoView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            //    this, RegionNames.WorkspaceRegion, typeof(AmbitoQueryView).FullName);

            //// Gran Franja Maestra
            //this.ShowGranFranjaMaestraView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            //    this, RegionNames.WorkspaceRegion, typeof(GranFranjaMaestraQueryView).FullName);
            
            //// Gran Franja Sofres
            //this.ShowGranFranjaSofresView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            //    this, RegionNames.WorkspaceRegion, typeof(GranFranjaSofresQueryView).FullName);

            //// Medio
            //this.ShowMedioView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            //    this, RegionNames.WorkspaceRegion, typeof(MedioQueryView).FullName);

            //// Tipo Medio
            //this.ShowTipoMedioView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            //    this, RegionNames.WorkspaceRegion, typeof(TipoMedioQueryView).FullName);

            //// Soporte
            //this.ShowSoporteView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            //    this, RegionNames.WorkspaceRegion, typeof(SoporteQueryView).FullName);

            //// Politica
            //this.ShowPoliticasView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            //    this, RegionNames.WorkspaceRegion, typeof(PoliticaQueryView).FullName);

            //// Tipo Posición
            //this.ShowTipoPosicionView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            //    this, RegionNames.WorkspaceRegion, typeof(TipoPosicionQueryView).FullName);

            //// Tipo Tiempo
            //this.ShowTipoTiempoView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            //    this, RegionNames.WorkspaceRegion, typeof(TipoTiempoQueryView).FullName);

            //// Tipo Forma Publicitaria
            //this.ShowTipoFormaPublicitariaView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            //    this, RegionNames.WorkspaceRegion, typeof(TipoFormaPublicitariaQueryView).FullName);

            //// Tipo Recargo Generico
            //this.ShowTipoRecargoGenericoView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            //    this, RegionNames.WorkspaceRegion, typeof(TipoRecargoGenericoQueryView).FullName);

            //// Diseño Politica
            ////this.ShowDesignPoliticasView = new NavigationCommand<CompanyProductModuleNavigationViewModel>(
            ////    this, RegionNames.WorkspaceRegion, typeof(DesignPoliticaView).FullName);

        }

        #endregion
    }
}




