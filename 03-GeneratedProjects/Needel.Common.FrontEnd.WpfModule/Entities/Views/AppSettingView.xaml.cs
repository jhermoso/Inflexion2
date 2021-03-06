﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="AppSetting" company="Company">
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
    /// .en Interaction logic for AppSettingView.xaml
    /// .es Logica de interación para la vista AppSettingView.xaml
    /// </summary>
    /// <remarks>
    /// .en No coment
    /// .es Sin comentarios adicionales.
    /// </remarks>
    public partial class AppSettingView : UserControl
    {
        #region CONSTRUCTORS
        /// <summary>
        /// .en Initialize a new instace for the class <see cref="T:AppSettingView"/>.
        /// .es Inicializa una nueva instancia de la clase <see cref="T:AppSettingView"/>.
        /// </summary>
        /// <remarks>
        /// .en No coment
        /// .es Sin comentarios adicionales.
        /// </remarks>
        public AppSettingView()
        {
            InitializeComponent();
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) && this.DataContext == null)
            {
                this.DataContext = new AppSettingViewModel();
            }

            // Here you can configure future filters.
            // Aqui puede introducir la configuración de futuros filtros.

        } // AppSettingQueryView Constructor
        #endregion

        //.en managment focus events of children query controls 
        //.es Gestión de los eventos de "focus" en los controles para mostrar entidades hijas.
        private void OnGotFocusMainViewControl(object sender, RoutedEventArgs e)
        {
            var ownVm = ((AppSettingViewModel)this.DataContext);
            if (ownVm != null )
            {
                ownVm.UnregisterCommands();
                ownVm.RegisterCommands();
            }

            e.Handled = true;
        }

    }
} //  Needel.Common.FrontEnd.WpfModule
