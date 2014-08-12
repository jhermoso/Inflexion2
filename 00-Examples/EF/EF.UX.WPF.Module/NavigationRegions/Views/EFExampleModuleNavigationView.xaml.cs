
// -----------------------------------------------------------------------
// <copyright file="AudienciasModuleNavigationView.xaml.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EF.UX.WPF.Module.Prism
{
    using System.Windows.Controls;

    /// <summary>
    /// Lógica de interacción para <see cref="T:CompanyProductModuleNavigationView.xaml"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public partial class EFExampleModuleNavigationView : UserControl
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
        public EFExampleModuleNavigationView(EFExampleModuleNavigationViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }

        #endregion
    }
}