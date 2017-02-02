// -----------------------------------------------------------------------
// <copyright file="PagedElements.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Clase que representa los elementos paginados de una entidad.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [DataContract]
    public class DtoPagedElements<TDto> : ICollection<TDto>
        where TDto : IDataTransferObject
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase PagedElements.
        /// </summary>
        public DtoPagedElements()
        {
            this.Elements = new List<TDto>();
            this.TotalElements = 0;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase PagedElements.
        /// </summary>
        /// <param name="items">
        /// Parámetro que identifica la lista de items.
        /// </param>
        /// <param name="totalElements">
        /// Parámetro que indica el número total de elemntos de la lista.
        /// </param>
        public DtoPagedElements(IEnumerable<TDto> items, int totalElements)
        {
            this.Elements = new List<TDto>(items);
            this.TotalElements = totalElements;
        }

        #endregion Constructors

        #region Properties

        public int Count
        {
            get
            {
                return this.Elements.Count;
            }
        }

        [DataMember]
        public List<TDto> Elements
        {
            get;
            set;
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Propiedad que obtiene el total de elementos.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener el total de elementos.
        /// </value>
        [DataMember]
        public int TotalElements
        {
            get;
            set;
        }

        #endregion Properties

        #region Indexers

        public TDto this[int index]
        {
            get
            {
                return this.Elements[index];
            }
            set
            {
                this.Elements[index] = value;
            }
        }

        #endregion Indexers

        #region Methods

        public void Add(TDto item)
        {
            Elements.Add(item);
        }

        public void Clear()
        {
            this.Elements.Clear();
        }

        public bool Contains(TDto item)
        {
            return Elements.Contains(item);
        }

        public void CopyTo(TDto[] array, int arrayIndex)
        {
            this.Elements.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TDto> GetEnumerator()
        {
            return this.Elements.GetEnumerator();
        }

        public bool Remove(TDto item)
        {
            return this.Elements.Remove(item);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Elements.GetEnumerator();
        }

        /// <summary>
        /// Método que devuelve el total de páginas a partir
        /// del tamaño de cada página
        ///  </summary>
        /// <param name="pageSize">
        /// Parámetro que indica el tamaño de cada página.
        /// </param>
        /// <returns>
        /// Devuelve el total de páginas.
        /// </returns>
        public int TotalPages(int pageSize)
        {
            return (int)Math.Ceiling(Convert.ToDouble(this.TotalElements) / pageSize);
        }

        #endregion Methods
    }
}