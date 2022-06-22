﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="EntityM" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " DomainBaseEntityFactoryCT.tt" with "public class DomainBaseEntityFactoryCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "DomainBaseEntityFactoryCT.tt" con "public class DomainBaseEntityFactoryCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion


namespace Needel.Common.Domain
{
    #region using de los sharedKernels 
    #endregion

    #region Usings de arquitectura
    using System;
    using System.Diagnostics.Contracts;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Inflexion2;
    using Inflexion2.Domain;
    using Needel.Common.Domain;
    using Needel.Common.Domain.Data;
    #endregion

    /// <summary>
    /// Clase factoría para la creación de  una entidad de tipo <see cref="EntityM"/>.
    /// </summary>
    static public class EntityMFactory 
    {

        #region Constructor vacio de la clase
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EntityMFactory"/>.
        /// </summary>
        /// <remarks>
        /// Constructor vacío de la clase <see cref="EntityMFactory"/>.
        /// </remarks>
        /// <returns>
        /// Devuelve una instancia de dela clase EntityMFactory />
        /// </returns>
        static EntityMFactory()
        {
        }
        #endregion

        #region Método (Patrón Factory)
        /// <summary>
        /// Función para crear una entidad dentro de la factoría a partir 
        /// de los argumentos especificados.
        /// </summary>
        /// <remarks>
        /// Crea una entidad de tipo <see cref="EntityM"/>
        /// </remarks>
        /// <param name="name"> 
        /// 
        /// </param>
        /// <returns>
        /// Devuelve  una entidad de tipo <see cref="EntityMFactory"/>
        /// </returns>
        public static EntityM Create(string name)
        {
            // Creamos la nueva entidad.
            EntityM EntityEntityM = new EntityM(  name );
            //devolvemos la entidad recien creada
            return EntityEntityM;
        }

        #endregion

    } // end class EntityMFactory
} //  Needel.Common.Domain
