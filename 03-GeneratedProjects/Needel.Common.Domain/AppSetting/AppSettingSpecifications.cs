﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="AppSetting" company="Company">
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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    #endregion

    /// <summary>
    /// Clase que representa las especificaciones para la entidad <see cref="T:AppSetting"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public static class AppSettingSpecifications
    {
        #region AppSetting Basic Specifications

        // ha continuación se incorporan las especificaciones correspondientes a los campos marcados como filter o como identification
 
        /// <summary>
        /// Método que devuelve especificación de aquellos objetos de tipo AppSetting  
        /// seleccionados por el valor del campo Key.
        /// </summary>
        /// <param name="key">
        /// Parámetro que indica el valor del campo Key.
        /// </param>
        /// <returns>
        /// Devuelve <see cref="Specification{AppSetting}"/> asociado con este criterio.
        /// </returns>
        public static Specification<AppSetting> FindAllByKey(string key)
        {
            // Especificación para AppSetting por Key
            Specification<AppSetting> specification =
                            new DirectSpecification<AppSetting>(c => c.Key == key);
            // Devolvemos la especificación.
            return specification;
        } // FindAllByKey


 
        /// <summary>
        /// Método que devuelve especificación de aquellos objetos de tipo AppSetting  
        /// seleccionados por el valor del campo Value.
        /// </summary>
        /// <param name="value">
        /// Parámetro que indica el valor del campo Value.
        /// </param>
        /// <returns>
        /// Devuelve <see cref="Specification{AppSetting}"/> asociado con este criterio.
        /// </returns>
        public static Specification<AppSetting> FindAllByValue(string value)
        {
            // Especificación para AppSetting por Value
            Specification<AppSetting> specification =
                            new DirectSpecification<AppSetting>(c => c.Value == value);
            // Devolvemos la especificación.
            return specification;
        } // FindAllByValue


        
        #endregion

        #region AppSetting Complex Specifications
        #endregion

    } // class AppSetting

} //  Needel.Common.Domain

