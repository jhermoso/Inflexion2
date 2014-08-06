// -----------------------------------------------------------------------
// <copyright file="IDataEntityMapper.cs" company="Inflexion Software">
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
    /// La interfaz <c>IMapper</c> permite mapear entre entidades del dominio.
    /// </remarks>
    /// <typeparam name="TDataTransferObject">Representa la interfaz de los objetos de transferencia de datos.</typeparam>
    /// <typeparam name="TEntity">Representa las entidades del negocio.</typeparam>
    /// <typeparam name="TIdentifier">Representa un identificador unívoco de entidad.</typeparam>
    public interface IDataEntityMapper<TDataTransferObject, TEntity, TIdentifier> : IDataMapper<TDataTransferObject, TEntity, TIdentifier>, IEntityMapper<TDataTransferObject, TEntity, TIdentifier>
        where TDataTransferObject : IDataTransferObject
        where TEntity : Inflexion2.Domain.IEntity<TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
    }
}