﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="User" company="Company">
//     Copyright (c) 2019. Company. All Rights Reserved.
//     Copyright (c) 2019. Company. Todos los derechos reservados.
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
    using System.Windows;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// .en Interaction logic for UserQueryView.xaml
    /// .es Logica de interación para la vista UserQueryView.xaml
    /// </summary>
    public partial class UserQueryView : UserControl
    {
        #region CONSTRUCTORS
        /// <summary>
        /// .en Initialize a new instace for the class <see cref="T:UserQueryView"/>.
        /// .es Inicializa una nueva instancia de la clase <see cref="T:UserQueryView"/>.
        /// </summary>
        public UserQueryView()
        {
            InitializeComponent();
            if (this.DataContext == null)
            {
                this.DataContext = new UserQueryViewModel();
            }
            // .en Here you can configure future filters.
            // .es Aquí se puede introducir la configuración de futuros filtros.
  
        } // UserQueryView Constructor
        #endregion
    }

} //  Needel.Common.FrontEnd.WpfModule
