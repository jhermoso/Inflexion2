﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Teacher" company="Company">
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
    /// .e inicializa una nueva instancia de  una entidad Teacher/>.
    /// </summary>
    /// <remarks>
    /// Mapea un objeto <see cref="Teacher"/>
    /// </remarks>
    public class TeacherConfiguration : EntityConfiguration<Teacher,Int32>
    {
        #region Constructors

        /// <summary>
        /// inicializa una nueva instancia de <see cref="TeacherConfiguration"/>.
        /// </summary>
        public TeacherConfiguration()
        {
            // remember the "Id" property is mapped in the base class. with a default name for the database table.
            this.ToTable("Teacher"); //Inflector.Underscore(typeof(Teacher).Name

            this.Property(e => e.Name).IsRequired();
            // note: for many 2 many realtionships deactivate Contract Reference Assembly in CodeContracts form Project's Properties, otherwise you get an error con ccdocgen exits with error -1073741571
            this.HasMany<Student>(x => x.Students)
                .WithMany(c => c.Teachers)
                .Map(c =>
                    {
                        c.MapLeftKey("Left_Teacher_Id");
                        c.MapRightKey("Right_Student_Id");
                        c.ToTable("StudentTeachers");  
                    });
        }
        #endregion
    } // 

} //  Needel.Common.Infrastructure