
// -----------------------------------------------------------------------
// <copyright file="PoliticiaComercialModuleTaskbarView.xaml.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EF.UX.WPF.Module.Prism
{
    using System.Windows.Controls;
    using Microsoft.Practices.Prism.Regions;

    /// <summary>
    /// .es Lógica de interacción para <see cref="T:EFExampleModuleTaskbarView.xaml"/>.
    /// .en Interaction ogic <see cref="T:EFExampleModuleTaskbarView.xaml"/>.
    /// </summary>
    /// <remarks>
    /// .es Sin comentarios adicionales.
    /// .en No coments.
    /// </remarks>
    [ViewSortHint("03")] // Permite ordenar los elementos que insertamos en una región.
    public partial class EFExampleModuleTaskbarView : UserControl
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:EFExampleModuleTaskbarView"/>.
        /// </summary>
        /// <param name="viewModel">
        /// Indica el modelo de vista de <see cref="T:EFExampleModuleTaskbarView"/>.
        /// </param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:EFExampleModuleTaskbarView"/>.
        /// </remarks>
        public EFExampleModuleTaskbarView(EFExampleModuleTaskbarViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }

        #endregion
    }
}


