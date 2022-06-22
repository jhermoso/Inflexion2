﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="EntityZ" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " WpfEntityViewXamlCsCT.tt" with "public class WpfEntityViewXamlCsCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "WpfEntityViewXamlCsCT.tt" con "public class WpfEntityViewXamlCsCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.FrontEnd.WpfModule
{

    #region usings   
    using System.Windows;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// .en Interaction logic for EntityZView.xaml
    /// .es Logica de interación para la vista EntityZView.xaml
    /// </summary>
    /// <remarks>
    /// .en No coment
    /// .es Sin comentarios adicionales.
    /// </remarks>
    public partial class EntityZView : UserControl
    {
        #region CONSTRUCTORS
        /// <summary>
        /// .en Initialize a new instace for the class <see cref="T:EntityZView"/>.
        /// .es Inicializa una nueva instancia de la clase <see cref="T:EntityZView"/>.
        /// </summary>
        /// <remarks>
        /// .en No coment
        /// .es Sin comentarios adicionales.
        /// </remarks>
        public EntityZView()
        {
            InitializeComponent();
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) && this.DataContext == null)
            {
                this.DataContext = new EntityZViewModel();
            }

            // Here you can configure future filters.
            // Aqui puede introducir la configuración de futuros filtros.

        } // EntityZQueryView Constructor
        #endregion

        //.en managment focus events of children query controls 
        //.es Gestión de los eventos de "focus" en los controles para mostrar entidades hijas.
        private void OnGotFocusMainViewControl(object sender, RoutedEventArgs e)
        {
            var ownVm = ((EntityZViewModel)this.DataContext);
            if (ownVm != null )
            {
                ownVm.UnregisterCommands();
                ownVm.RegisterCommands();
            }

            e.Handled = true;
        }

        private void OnLoadMNsQueryViewControl(object sender, RoutedEventArgs e)//**1
        {
            MNsQueryView.DataContext = ((EntityZViewModel)this.DataContext).MNsQueryVM;
            if (MNsQueryView.DataContext != null)
            {
                ((MNZQueryViewModel)MNsQueryView.DataContext).RefreshItems();
            }
        }

        private void OnGotFocusMNsQueryViewControl(object sender, RoutedEventArgs e)//**2
        {
            EntityZViewModel ownVm = null;
            MNZQueryViewModel vm = null;

            if (sender.GetType() == MNsQueryView.GetType())
            {
                ownVm = ((EntityZViewModel)this.DataContext);
                vm = ((EntityZViewModel)this.DataContext).MNsQueryVM;
                ownVm.UnregisterCommands();
                vm.RegisterCommands();
                vm.RefreshCommands();
                e.Handled = true;
            }
        }


        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var dc = ((EntityZViewModel)this.DataContext);

            dc.RefreshRelatedEntities();
        }
    }
} //  Needel.Common.FrontEnd.WpfModule