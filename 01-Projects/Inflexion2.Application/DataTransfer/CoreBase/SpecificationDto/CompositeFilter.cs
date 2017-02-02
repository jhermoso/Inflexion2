// -----------------------------------------------------------------------
// <copyright file="CompositeFilter.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Clase para los filtros compuestos en las especificaciones para Dto´s.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [DataContract]
    public class CompositeFilter
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:CompositeFilter"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public CompositeFilter()
        {
            this.LogicalOperator = CompositeFilterLogicalOperator.And;
            this.Filters = new List<Filter>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad que obtiene o establece la lista de filtros.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer la lista de filtros.
        /// </value>
        [DataMember]
        public List<Filter> Filters
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que obtiene o establece el operador lógico del filtro.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el operador lógico del filtro.
        /// </value>
        [DataMember]
        public CompositeFilterLogicalOperator LogicalOperator
        {
            get;
            set;
        }

        #endregion Properties
    }
}