// -----------------------------------------------------------------------
// <copyright file="IQueryService.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Services
{
    #region Imports

    using System.Collections.Generic;
    using System.ComponentModel;

    #endregion

    /// <summary>
    /// Define el contrato para el servicio de consulta.
    /// </summary>
    public interface IQueryService
    {
        #region Methods

        /// <summary>
        /// Obtiene un conjunto de elementos clave-valor resultado de la consulta.
        /// </summary>
        /// <returns>
        /// El conjunto de elementos clave-valor resultante.
        /// </returns>
        IEnumerable<IKeyValueItem> GetKeyValueItems();

        /// <summary>
        /// Obtiene una colección de elementos clave-valor resultado de la consulta.
        /// </summary>
        /// <param name="selectedId">
        /// Identificador del elemento clave-valor seleccionado.
        /// </param>
        /// <returns>
        /// La colección de elementos clave-valor resultante.
        /// </returns>
        ICollectionView GetKeyValueItems(int selectedId);

        #endregion
    }
}