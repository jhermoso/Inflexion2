// -----------------------------------------------------------------------
// <copyright file="SpecificationDto.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Clase Dto que representa la especificación para la obtención de datos.
    /// </summary>
    [DataContract]
    public class SpecificationDto
    {

        #region Fields
        private CompositeFilter compositeFilter_;
        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:SpecificationDto"/>.
        /// </summary>
        public SpecificationDto()
        {
            this.compositeFilter_ = new CompositeFilter();
        }

        /// <summary>
        /// Parse filters to
        /// </summary>
        /// <remarks>
        /// the current version of json in the facade needs at least .net of 4.5.2 but this porjects works with .net 4.0.
        /// the only way to use the deserializer of josn in the constructor is to pass it like a func.
        /// In this way is also posible to use other deserializers
        /// </remarks>
        /// <param name="deserializer"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="sortColum"></param>
        /// <param name="sortOrder"></param>
        public SpecificationDto(Func<string, CompositeFilter> deserializer,  int pageIndex, int pageSize, string filter, string sortColum, string sortOrder)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.SortOrder = sortOrder;
            this.SortColumn = sortColum;
            if (filter != null)
                this.compositeFilter_ = deserializer(filter); //JsonConvert.DeserializeObject<CompositeFilter>(filter);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad que obtiene el filtro compuesto para la especificación.
        /// </summary>
        /// <value>
        /// Valor que es utilizado para obtener el filtro compuesto para la especificación.
        /// </value>
        [DataMember]
        public CompositeFilter CompositeFilter
        {
            get
            {
                return compositeFilter_;
            }
            private set
            {
                compositeFilter_ = value;
            }
        }

        /// <summary>
        /// Propiedad de solo lectura que indica si el filtro es de búsqueda.
        /// </summary>
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
