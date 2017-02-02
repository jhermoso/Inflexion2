// -----------------------------------------------------------------------
// <copyright file="SpecificationDto.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application
{
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Clase Dto que representa la especificación para la obtención de datos.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [DataContract]
    public class SpecificationDto
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:SpecificationDto"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public SpecificationDto()
        {
            this.CompositeFilter = new CompositeFilter();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad que obtiene el filtro compuesto para la especificación.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener el filtro compuesto para la especificación.
        /// </value>
        [DataMember]
        public CompositeFilter CompositeFilter
        {
            get;
            private set;
        }

        /// <summary>
        /// Propiedad de solo lectura que indica si el filtro es de búsqueda.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para indica si el filtro es de búsqueda.
        /// </value>
        public bool IsSearch
        {
            get
            {
                return this.CompositeFilter.Filters.Any();
            }
        }

        /// <summary>
        /// Propiedad que obtiene o establece el índice de la página en la búsqueda.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor utilizado para obtener o establecer el índice de la página en la búsqueda.
        /// </value>
        [DataMember]
        public int PageIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que obtiene o establece el número de páginas que se van a devolver.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor utilizado para obtener o establecer el número de páginas que se van a devolver.
        /// </value>
        [DataMember]
        public int PageSize
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad obtiene o establece el nombre de la columna por la que se ordenará.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor utilizado para obtener o establecer el nombre de la columna por la que se ordenará.
        /// </value>
        [DataMember]
        public string SortColumn
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad obtiene o establece el ordinal
        /// de la columna por la que se ordenará.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor utilizado para obtener o establecer
        /// el ordinal de la columna por la que se ordenará.
        /// </value>
        [DataMember]
        public string SortOrder
        {
            get;
            set;
        }

        #endregion Properties
    }
}