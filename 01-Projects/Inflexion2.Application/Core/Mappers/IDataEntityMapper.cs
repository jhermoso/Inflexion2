﻿// -----------------------------------------------------------------------
// <copyright file="IDataEntityMapper.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application
{
    /// <summary>
    /// Interfaz para los mapeadores entre entidades del dominio.
    /// (<see cref="Inflexion2.Domain.IEntity{TIdentifier}"/>) y
    /// objetos de transferencia de datos (<see cref="IDataTransferObject"/>).
    /// </summary>
    /// <remarks>
    /// La interfaz <c>IMapper</c> permite mapear entre entidades del dominio.
    /// </remarks>
    /// <typeparam name="TDto">Representa la interfaz de los objetos de transferencia de datos.</typeparam>
    /// <typeparam name="TEntity">Representa las entidades del negocio.</typeparam>
    /// <typeparam name="TIdentifier">Representa un identificador unívoco de entidad.</typeparam>
    public interface IDataEntityMapper<TDto, TEntity, TIdentifier> //: IEntityMapper<TDataTransferObject, TEntity, TIdentifier> //,IDataMapper<TDataTransferObject, TEntity, TIdentifier>
        where TDto : IDataTransferObject
        where TEntity : class //, Inflexion2.Domain.IAggregateRoot<TEntity, TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        /// <summary>
        /// Función encargada de mapear una entidad con un Dto.
        /// </summary>
        /// <remarks>
        /// Con esta función, mapeamos una entidad con un Dto.
        /// </remarks>
        /// <param name="entity">Representa las entidades de negocio.</param>
        /// <returns>Devuelve un objeto de transferencia de datos.</returns>
        TDto EntityMapping(TEntity entity);
    }
}