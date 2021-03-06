﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Address" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " WpfEntityQueryViewXamlCsCT.tt" with "public class WpfEntityQueryViewXamlCsCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "WpfEntityQueryViewXamlCsCT.tt" con "public class WpfEntityQueryViewXamlCsCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.FrontEnd.WpfModule
{

    #region usings
    using Application.Dtos;
    using Inflexion2.UX.WPF.Helpers;
    using Inflexion2.UX.WPF.MVVM.ViewModels;
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    #endregion

    /// <summary>
    /// .en Interaction logic for AddressQueryView.xaml
    /// .es Logica de interación para la vista AddressQueryView.xaml
    /// </summary>
    public partial class AddressQueryView : UserControl
    {
        #region CONSTRUCTORS
        /// <summary>
        /// .en Initialize a new instace for the class <see cref="T:AddressQueryView"/>.
        /// .es Inicializa una nueva instancia de la clase <see cref="T:AddressQueryView"/>.
        /// </summary>
        public AddressQueryView()
        {
            InitializeComponent();
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) && this.DataContext == null)
            {
                this.DataContext = new AddressQueryViewModel();
            }
            // .en Here you can configure future filters.
            // .es Aquí se puede introducir la configuración de futuros filtros.
  
        } // AddressQueryView Constructor
        #endregion

    }

} //  Needel.Common.FrontEnd.WpfModule
