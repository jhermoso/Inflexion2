﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="EntityM" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
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
    /// .e inicializa una nueva instancia de  una entidad EntityM/>.
    /// </summary>
    /// <remarks>
    /// Mapea un objeto <see cref="EntityM"/>
    /// </remarks>
    public class EntityMConfiguration : EntityConfiguration<EntityM,Int32>
    {
        #region Constructors

        /// <summary>
        /// inicializa una nueva instancia de <see cref="EntityMConfiguration"/>.
        /// </summary>
        public EntityMConfiguration()
        {
            // remember the "Id" property is mapped in the base class. with a default name for the database table.
            this.ToTable("EntityM"); //Inflector.Underscore(typeof(EntityM).Name

            this.Property(e => e.Name).IsRequired();

            this.HasMany<MNZ>(x => x.NZs)
                .WithRequired(x => x.EntityM)
                .HasForeignKey(x => x.EntityM_Id)
                ;
        }
        #endregion
    } // 

} //  Needel.Common.Infrastructure