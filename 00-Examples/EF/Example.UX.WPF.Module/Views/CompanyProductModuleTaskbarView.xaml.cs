
// -----------------------------------------------------------------------
// <copyright file="PoliticiaComercialModuleTaskbarView.xaml.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Company.Product.Shared.UX.WPF.Module.Views
{
    using System.Windows.Controls;

    using Company.Product.Shared.UX.WPF.Module.ViewModels;
    using Microsoft.Practices.Prism.Regions;

    /// <summary>
    /// Lógica de interacción para <see cref="T:PoliticaComercialModuleTaskbarView.xaml"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [ViewSortHint("03")] // Permite ordenar los elementos que insertamos en una región.
    public partial class CompanyProductModuleTaskbarView : UserControl
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:PoliticaComercialModuleTaskbarView"/>.
        /// </summary>
        /// <param name="viewModel">
        /// Indica el modelo de vista de <see cref="T:AudienciasModuleTaskbarView"/>.
        /// </param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:AudienciasModuleTaskbarView"/>.
        /// </remarks>
        public CompanyProductModuleTaskbarView(CompanyProductModuleTaskbarViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }

        #endregion
    }
}


