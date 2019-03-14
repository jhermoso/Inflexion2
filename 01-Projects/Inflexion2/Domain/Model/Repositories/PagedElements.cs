// -----------------------------------------------------------------------
// <copyright file="PagedElements.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Clase que representa los elementos paginados de una entidad.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [DataContract]
    public class PagedElements<TDto> : ICollection<TDto>
        where TDto : class
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase PagedElements.
        /// </summary>
        public PagedElements()
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
        public PagedElements(IEnumerable<TDto> items, int totalElements)
        {
            this.Elements = new List<TDto>(items);
            this.TotalElements = totalElements;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Total num of elements in the repository
        /// </summary>
        public int Count
        {
            get
            {
                return this.Elements.Count;
            }
        }

        /// <summary>
        /// a page of elements
        /// </summary>
        [DataMember]
        public List<TDto> Elements
        {
            get;
            set;
        }

        /// <summary>
        /// mark read only
        /// </summary>
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

        /// <summary>
        /// indexer implementation
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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

        /// <summary>
        /// add entity to the page
        /// </summary>
        /// <param name="item"></param>
        public void Add(TDto item)
        {
            Elements.Add(item);
        }

        /// <summary>
        /// clear the page
        /// </summary>
        public void Clear()
        {
            this.Elements.Clear();
        }

        /// <summary>
        /// asking if the page contains the entity
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(TDto item)
        {
            return Elements.Contains(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(TDto[] array, int arrayIndex)
        {
            this.Elements.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// enumerator implementation
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TDto> GetEnumerator()
        {
            return this.Elements.GetEnumerator();
        }

        /// <summary>
        /// remove item from page
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(TDto item)
        {
            return this.Elements.Remove(item);
        }

        /// <summary>
        /// enumerator to iterate the page
        /// </summary>
        /// <returns></returns>
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

        public TDto GetFirst()
        {

            return this.Elements.FirstOrDefault();
        }

        public TDto GetLast()
        {
            return this.Elements.LastOrDefault();
        }

        public TDto GetPrevious(TDto reference)
        {
            var i = this.Elements.FindIndex(c  => c == reference);
            if (i <= 0)
                return null;

            return this.Elements[i - 1];

        }

        public TDto GetNext(TDto reference)
        {
            var i = this.Elements.FindIndex(c => c == reference);
            if (i >= this.Elements.Count - 1)
                return null;

            return this.Elements[i + 1];
        }

        #endregion Methods
    }
}