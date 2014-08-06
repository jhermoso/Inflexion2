// -----------------------------------------------------------------------
// <copyright file="IDataMapper.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application.Core
{
    using Inflexion2.Application.DataTransfer.Core;

    /// <summary>
    /// Interfaz para los mapeadores entre entidades del dominio.
    /// (<see cref="Inflexion.Framework.Domain.Core.IEntity{TIdentifier}"/>) y
    /// objetos de transferencia de datos (<see cref="IDataTransferObject"/>).
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    /// <typeparam name="TDataTransferObject">
    /// Representa la interfaz de los objetos de transferencia de datos.
    /// </typeparam>
    /// <typeparam name="TEntity">
    /// Representa las entidades del negocio.
    /// </typeparam>
    /// <typeparam name="TIdentifier">
    /// Representa un identificador unívoco de entidad.
    /// </typeparam>
    public interface IDataMapper<TDataTransferObject, TEntity, TIdentifier> : IGenericMapper<TDataTransferObject, TEntity, TIdentifier>
        where TDataTransferObject : IDataTransferObject
        where TEntity : Inflexion2.Domain.IEntity<TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Methods

        /// <summary>
        /// Función encargada de mapear un Dto con una entidad.
        /// </summary>
        /// <remarks>
        /// Con esta función, mapeamos un Dto con una entidad.
        /// </remarks>
        /// <param name="dataTransferObject">
        /// Representa la interfaz de los objetos de transferencia de datos.
        /// </param>
        /// <returns>
        /// Devuelve una entidad de negocio.
        /// </returns>
        TEntity DataMapping(TDataTransferObject dataTransferObject);

        #endregion Methods
    }
}