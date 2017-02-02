﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Categoria" company="Atento">
//     Copyright (c) 2016. Atento. All Rights Reserved.
//     Copyright (c) 2016. Atento. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " DomainCoreIEntityCT.tt" with "public class DomainCoreIEntityCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "DomainCoreIEntityCT.tt" con "public class DomainCoreIEntityCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Atento.Suite.Shared.Domain
{


    #region Usings
    using System;
    using Atento.Suite.Shared.Domain.Data;
    using Inflexion2.Domain;
    using Inflexion2;
    
    #endregion

    /// <summary>
    /// .en Interfaz to identify an entidad of type Categoria in the application.
    /// .es Interfaz que identifica una entidad de tipo Categoria de la aplicación.
    /// Clasificador
    /// </summary>
    /// <remarks>
    /// .en Interfaz for an Entity implemented by Categoria/>.
    /// .es Interfaz que representa  una entidad implementado enCategoria/>.
    /// </remarks>
    public interface ICategoria : 	Inflexion2.Domain.IAggregateRoot<ICategoria, Int32> 	
    {

        #region Properties
        /// <summary>
        /// .en Property to get and set Name.
        /// .es Propiedad que permite obtener y establecer Name.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <value>
        /// .en Value used to get & set Name.
        /// .es Valor que es utilizado para obtener y establecer Name.
        /// </value>
        string Name { get; set; }
        #endregion

        #region Methods
        #endregion

    } // End class Categoria.

} // End NameSpace Atento.Suite.Shared.Domain.
