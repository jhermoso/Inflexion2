﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Address" company="Company">
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
    
    
    using Inflexion2;
    using Inflexion2.Domain;
    using Needel.Common.Domain;
    using Needel.Common.Domain.Data;
    #endregion

    /// <summary>
    /// Clase factoría para la creación de  una entidad de tipo <see cref="Address"/>.
    /// </summary>
    static public class AddressFactory 
    {

        #region Constructor vacio de la clase
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AddressFactory"/>.
        /// </summary>
        /// <remarks>
        /// Constructor vacío de la clase <see cref="AddressFactory"/>.
        /// </remarks>
        /// <returns>
        /// Devuelve una instancia de dela clase AddressFactory />
        /// </returns>
        static AddressFactory()
        {
        }
        #endregion

        #region Método (Patrón Factory)
        /// <summary>
        /// Función para crear una entidad dentro de la factoría a partir 
        /// de los argumentos especificados.
        /// </summary>
        /// <remarks>
        /// Crea una entidad de tipo <see cref="Address"/>
        /// </remarks>
        /// <param name="streetName"> 
        /// 
        /// </param>
        /// <param name="userAddress"> 
        /// referencia al rol source de la relación.
        /// </param>
        /// <returns>
        /// Devuelve  una entidad de tipo <see cref="AddressFactory"/>
        /// </returns>
        public static Address Create(string streetName, User userAddress)
        {
            // Creamos la nueva entidad.
            Address EntityAddress = new Address(  streetName, userAddress );
            //devolvemos la entidad recien creada
            return EntityAddress;
        }

        #endregion

    } // end class AddressFactory
} //  Needel.Common.Domain

