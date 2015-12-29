
// ---------------------------------------------------------------------------
// <copyright file="ProductoQueryView.cs" company="Company">
//     Copyright (c) 2014. Company. All Rights Reserved.
// </copyright>
// ---------------------------------------------------------------------------


namespace EF.UX.WPF.Module.Entities
{
    using System.Windows.Controls;

    /// <summary>
    /// .en Interaction logic for ProductoQueryView.xaml
    /// .es Logica de interación para la vista ProductoQueryView.xaml
    /// </summary>
    /// <remarks>
    /// .en No coment
    /// .es Sin comentarios adicionales.
    /// </remarks>
    public partial class EntityBQueryView : UserControl
    {

        #region CONSTRUCTORS

        /// <summary>
        /// .en Initialize a new instace for the class <see cref="T:ProductoQueryView"/>.
        /// .es Inicializa una nueva instancia de la clase <see cref="T:ProductoQueryView"/>.
        /// </summary>
        /// <remarks>
        /// .en No coment
        /// .es Sin comentarios adicionales.
        /// </remarks>
        public EntityBQueryView()
        {
            InitializeComponent();
            this.DataContext = new EntityBQueryViewModel();
            // Here you can configure future filters.
            // Aqui e intrucira al configuración de futuros filtros.
  
        } // ProductoQueryView Constructor

        #endregion

    } // ProductoQueryView

} // 

