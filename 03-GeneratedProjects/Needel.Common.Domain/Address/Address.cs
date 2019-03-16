﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Address" company="Company">
//     Copyright (c) 2019. Company. All Rights Reserved.
//     Copyright (c) 2019. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " DomainBaseEntityCT.tt" with "public class DomainBaseEntityCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "DomainBaseEntityCT.tt" con "public class DomainBaseEntityCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.Domain
{

    #region usings
    using System;
	using System.Collections.Generic;
    using System.Linq;
    using Needel.Common.Domain.Data;
    using Needel.Common.Infrastructure.Resources;
    using Inflexion2;
    using Inflexion2.Domain;

    using System.ComponentModel.DataAnnotations;
    #endregion

    /// <summary>
    /// <see cref="Address"/>
    /// </summary>
	[System.Runtime.InteropServices.Guid("ad19c8f6-bea7-4a38-8c3d-2ea098cd2aef")]
    [Serializable]
    public partial class Address : Inflexion2.Domain.Entity<Address, Int32>, IAddress
    {

        #region Campos y constantes
        #endregion

        #region Constructors

        /// <summary>
        /// .en Empty Constructor for the class <see cref="Address"/> it is required by nHibernate and EntityFramework.
        /// .es Constructor vacio de la clase <see cref="Address"/> exigido por nHibernate o EntityFramework.
        /// </summary>
        /// <remarks>
        /// .en by convention the empty constructor initialize the default values and make the news for the collections.
        /// .es por convenicón el constructor vacio inizializa los valores por defecto y hace los news de las colecciones.
        /// </remarks>
        protected internal Address()                
        {
        } // end empty constructor Address

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad pública que permite obtener StreetName.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener StreetName.
        /// </value>
        [Required(ErrorMessageResourceType = typeof(Inflexion2.Resources.FrameworkResource), 
                  ErrorMessageResourceName = "FieldIsMandatory" )]
        public virtual string StreetName 
            {
                get;
                set;
            }


        /// <summary>
        /// Propiedad pública que permite obtener BuildingNumber.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener BuildingNumber.
        /// </value>
        public virtual string BuildingNumber 
            {
                get;
                set;
            }

        #endregion

        #region Métodos Set de propiedades comunes
        #endregion

    } // class Address 

} //  Needel.Common.Domain

