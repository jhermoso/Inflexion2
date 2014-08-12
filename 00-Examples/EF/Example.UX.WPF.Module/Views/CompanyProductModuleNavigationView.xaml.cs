
// -----------------------------------------------------------------------
// <copyright file="AudienciasModuleNavigationView.xaml.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Company.Product.Shared.UX.WPF.Module.Views
{
    using System.Windows.Controls;

    using Company.Product.Shared.UX.WPF.Module.ViewModels;

    /// <summary>
    /// Lógica de interacción para <see cref="T:PoliticaComercialModuleNavigationView.xaml"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public partial class CompanyProductModuleNavigationView : UserControl
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:AudienciasModuleNavigationView"/>.
        /// </summary>
        /// <param name="viewModel">
        /// Indica el modelo de vista de <see cref="T:AudienciasModuleNavigationView"/>.
        /// </param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:AudienciasModuleNavigationView"/>.
        /// </remarks>
        public CompanyProductModuleNavigationView(CompanyProductModuleTaskbarViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }

        #endregion
    }
}