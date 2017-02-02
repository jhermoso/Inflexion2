﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Persona" company="Atento">
//     Copyright (c) 2016. Atento. All Rights Reserved.
//     Copyright (c) 2016. Atento. Todos los derechos reservados.
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

namespace Atento.Suite.Shared.Infrastructure
{

    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using Inflexion2.Domain;

    using Atento.Suite.Shared.Domain.Data;
    using Atento.Suite.Shared.Domain;

    #endregion

    /// <summary>
    /// inicializa una nueva instancia de  una entidad Persona/>.
    /// </summary>
    /// <remarks>
    /// Mapea un objeto <see cref="Persona"/>.
    /// </remarks>
     public class PersonaConfiguration : EntityConfiguration<Persona, Int32>
    {
        #region Constructors

        /// <summary>
        /// inicializa una nueva instancia de <see cref="PersonaConfiguration"/>.
        /// </summary>
        public PersonaConfiguration()
        {
            // remember the "Id" property is mapped in the base class. with a default name for the database table.
            this.ToTable("Persona");
            this.Property(e => e.Nombre).IsRequired();

            this.Property(e => e.BooleanField).IsRequired();

            this.Property(e => e.DatetimeField);

            this.Property(e => e.ByteField).IsRequired();

            this.Property(e => e.GuidField).IsRequired();

            this.Property(e => e.DecimalField).IsRequired();

            this.Property(e => e.DobleField).IsRequired();

            this.Property(e => e.FloatField).IsRequired();

            this.Property(e => e.IntField).IsRequired();

            this.Property(e => e.LongField).IsRequired();

            this.Property(e => e.DateTimeOffsetField).IsRequired();

            this.Property(e => e.ShortField).IsRequired();

            this.Property(e => e.TimeSpanField).IsRequired();

            this.Property(e => e.Int16Field).IsRequired();

            this.Property(e => e.Int32Field).IsRequired();

            this.Property(e => e.Int64Field).IsRequired();
        }
        #endregion
    } // 

} //  Atento.Suite.Shared.Infrastructure
