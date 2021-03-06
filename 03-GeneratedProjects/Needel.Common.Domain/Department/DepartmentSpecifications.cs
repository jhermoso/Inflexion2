﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Department" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " DomainBaseEntitySpecificationsCT.tt" with "public class DomainBaseEntitySpecificationsCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "DomainBaseEntitySpecificationsCT.tt" con "public class DomainBaseEntitySpecificationsCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.Domain
{



    #region usings
    // en una clase parcial los using solo son necesarios una vez pero se dejan por si sirven de ayuda

    using System;
    using System.Linq;
    using Needel.Common.Domain;
    using Inflexion2.Domain;
    using Inflexion2;
    using Inflexion2.Domain.Specification;

    using System.ComponentModel.DataAnnotations;
    #endregion

    /// <summary>
    /// Clase que representa las especificaciones para la entidad <see cref="T:Department"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public static class DepartmentSpecifications
    {
        #region Department Basic Specifications

        // ha continuación se incorporan las especificaciones correspondientes a los campos marcados como filter o como identification
 
        /// <summary>
        /// Método que devuelve especificación de aquellos objetos de tipo Department  
        /// seleccionados por el valor del campo Name.
        /// </summary>
        /// <param name="name">
        /// Parámetro que indica el valor del campo Name.
        /// </param>
        /// <returns>
        /// Devuelve <see cref="Specification{Department}"/> asociado con este criterio.
        /// </returns>
        public static Specification<Department> FindAllByName(string name)
        {
            // Especificación para Department por Name
            Specification<Department> specification =
                            new DirectSpecification<Department>(c => c.Name == name);
            // Devolvemos la especificación.
            return specification;
        } // FindAllByName


 
        /// <summary>
        /// Método que devuelve especificación de aquellos objetos de tipo Department  
        /// seleccionados por el valor del campo Visible.
        /// </summary>
        /// <param name="visible">
        /// Parámetro que indica el valor del campo Visible.
        /// </param>
        /// <returns>
        /// Devuelve <see cref="Specification{Department}"/> asociado con este criterio.
        /// </returns>
        public static Specification<Department> FindAllByVisible(bool visible)
        {
            // Especificación para Department por Visible
            Specification<Department> specification =
                            new DirectSpecification<Department>(c => c.Visible == visible);
            // Devolvemos la especificación.
            return specification;
        } // FindAllByVisible


        
        #endregion

        #region Department Complex Specifications
        #endregion

    } // class Department

} //  Needel.Common.Domain

