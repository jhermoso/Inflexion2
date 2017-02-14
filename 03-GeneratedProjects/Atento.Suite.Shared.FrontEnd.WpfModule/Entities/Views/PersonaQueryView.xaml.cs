﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Persona" company="Atento">
//     Copyright (c) 2017. Atento. All Rights Reserved.
//     Copyright (c) 2017. Atento. Todos los derechos reservados.
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

namespace Atento.Suite.Shared.FrontEnd.WpfModule
{

    #region usings   
    using System.Windows;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// .en Interaction logic for PersonaQueryView.xaml
    /// .es Logica de interación para la vista PersonaQueryView.xaml
    /// </summary>
    public partial class PersonaQueryView : UserControl
    {
        #region CONSTRUCTORS
        /// <summary>
        /// .en Initialize a new instace for the class <see cref="T:PersonaQueryView"/>.
        /// .es Inicializa una nueva instancia de la clase <see cref="T:PersonaQueryView"/>.
        /// </summary>
        public PersonaQueryView()
        {
            InitializeComponent();
            this.DataContext = new PersonaQueryViewModel();
            // .en Here you can configure future filters.
            // .es Aquí se puede introducir la configuración de futuros filtros.
  
        } // PersonaQueryView Constructor
        #endregion
    }

} //  Atento.Suite.Shared.FrontEnd.WpfModule
