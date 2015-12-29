// -----------------------------------------------------------------------
// <copyright file="ProductoView.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace EF.UX.WPF.Module.Entities
{
    using System.Windows.Controls;

    /// <summary>
    /// .es codeBehind de la vista ProductoView.xaml
    /// .en codeBehind for the view ProductoView.xaml 
    /// </summary>
    /// <remarks>
    /// .en No comment.
    /// .es Sin comentarios adicionales.
    /// </remarks>
    public partial class EntityBView : UserControl
    {

        /// <summary>
        /// Interaction logic for EntityView.xaml
        /// </summary>
        public EntityBView()
            {
                InitializeComponent();
                this.DataContext = new EntityBViewModel();
            }

    } // ProductoView

} // EF.UX.WPF.Module.Entities



