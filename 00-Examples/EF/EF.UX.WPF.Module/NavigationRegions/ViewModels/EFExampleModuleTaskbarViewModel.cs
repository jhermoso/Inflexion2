
// -----------------------------------------------------------------------
// <copyright file="CompanyProductModuleTaskbarViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EF.UX.WPF.Module.Prism
{
    using Inflexion2.UX.WPF.MVVM;
    using Inflexion2.UX.WPF.MVVM.Commands;
    using Inflexion2.UX.WPF.MVVM.ViewModels;   

    /// <summary>
    /// Representa el modelo de vista de <see cref="T:CompanyProductModuleTaskbarView"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public sealed class EFExampleModuleTaskbarViewModel : TaskbarViewModel
    {

        string[] regions;
        string[] views;
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:CompanyProductModuleTaskbarViewModel"/>.
        /// </summary>
          ///<remarks>
          ///Constructor de la clase <see cref="T:CompanyProductModuleTaskbarViewModel"/>.
        ///</remarks>
        public EFExampleModuleTaskbarViewModel()
            : base(typeof(EF.UX.WPF.Module.EFExampleModule))
        {
            //this.TaskButtonImage = "../Views/Images/Clientes.png";
            this.TaskButtonText = "Contexto limitado";

            this.ShowModuleNavigationView = new NavigationCommand<EFExampleModuleTaskbarViewModel>(
                this, RegionNames.NavigationRegion, typeof(EFExampleModuleNavigationView).FullName, this.NavigationCompleted);


            regions = new string[] { RegionNames.NavigationRegion, RegionNames.ToolbarRegion };
            views = new string[] { typeof(EFExampleModuleNavigationView).FullName, typeof(ModuleARibbonTab).FullName };


            //this.ShowModuleRibbonView = new MultipleViewsNavigationCommand<EFExampleModuleTaskbarViewModel>(
            //this, RegionNames.ToolbarRegion, typeof(ModuleARibbonTab).FullName, this.NavigationCompleted);

            this.ShowModuleRibbonView = new MultipleViewsNavigationCommand<EFExampleModuleTaskbarViewModel>( this, regions, views, this.NavigationCompleted);
       
        }

        #endregion
    }
}

