// -----------------------------------------------------------------------
// <copyright file="Filter.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application.DataTransfer.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// Clase que representa un filtro para las especificaciones.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [DataContract]
    public class Filter
    {
        #region Properties

        /// <summary>
        /// Propiedad que obtiene o establece el operador que aplicará en el filtro.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el
        /// operador que aplicará en el filtro.
        /// </value>
        [DataMember]
        public string Operator
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que obtiene o establece el nombre de la propiedad
        /// sobre la que se aplicará el filtro.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el nombre de la propiedad
        /// sobre la que se aplicará el filtro.
        /// </value>
        [DataMember]
        public string Property
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que obtiene o establece el valor para el filtro.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el valor del filtro.
        /// </value>
        [DataMember]
        public string Value
        {
            get;
            set;
        }

        #endregion Properties
    }
}