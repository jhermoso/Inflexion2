
// -----------------------------------------------------------------------
// <copyright file="PoliticaComercialModuleTaskbarViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Company.Product.Shared.UX.WPF.Module.ViewModels
{
    using Inflexion.Framework.UX.Windows.MVVM;
    using Inflexion.Framework.UX.Windows.MVVM.Commands;
    using Inflexion.Framework.UX.Windows.MVVM.ViewModels;

    using Company.Product.Shared.UX.WPF.Module.Views;
    using Company.Product.Shared.UX.WPF.Module;
    /// <summary>
    /// Representa el modelo de vista de <see cref="T:PoliticaComercialModuleTaskbarView"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public sealed class CompanyProductModuleTaskbarViewModel : TaskbarViewModel
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:PoliticaComercialModuleTaskbarViewModel"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:PoliticaComercialModuleTaskbarViewModel"/>.
        /// </remarks>
        public CompanyProductModuleTaskbarViewModel()
            : base(typeof(CompanyProductSharedModule))
        {
            //this.TaskButtonImage = "../Views/Images/classroot.png";
            this.TaskButtonText = "Política Comercial";

            this.ShowModuleNavigationView = new NavigationCommand<CompanyProductModuleTaskbarViewModel>(
                this, RegionNames.NavigationRegion, typeof(CompanyProductModuleNavigationViewModel).FullName, this.NavigationCompleted);
        }

        #endregion
    }
}

