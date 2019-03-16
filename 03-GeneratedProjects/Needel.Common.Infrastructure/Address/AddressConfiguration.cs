﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Address" company="Company">
//     Copyright (c) 2019. Company. All Rights Reserved.
//     Copyright (c) 2019. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " InfraestructureEntityFrameworkMappingCT.tt" with "public class InfraestructureEntityFrameworkMappingCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "InfraestructureEntityFrameworkMappingCT.tt" con "public class InfraestructureEntityFrameworkMappingCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.Infrastructure
{

    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using Inflexion2.Domain;

    using Needel.Common.Domain.Data;
    using Needel.Common.Domain;

    #endregion

    /// <summary>
    /// inicializa una nueva instancia de  una entidad Address/>.
    /// </summary>
    /// <remarks>
    /// Mapea un objeto <see cref="Address"/>
    /// </remarks>
     public class AddressConfiguration : EntityConfiguration<Address, Int32>
    {
        #region Constructors

        /// <summary>
        /// inicializa una nueva instancia de <see cref="AddressConfiguration"/>.
        /// </summary>
        public AddressConfiguration()
        {
            // remember the "Id" property is mapped in the base class. with a default name for the database table.
            this.ToTable("Address");//Inflector.Underscore(typeof(Address).Name


            this.Property(e => e.StreetName).IsRequired();

            this.Property(e => e.BuildingNumber).IsOptional();
        }
        #endregion
    } // 

} //  Needel.Common.Infrastructure
