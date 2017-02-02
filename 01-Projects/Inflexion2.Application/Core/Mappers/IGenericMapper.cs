// -----------------------------------------------------------------------
// <copyright file="IGenericMapper.cs" company="Inflexion Software">
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
    /// La interfaz <c>IGenericMapper</c> permite mapear entre entidades del dominio.
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
    public interface IGenericMapper<TDataTransferObject, TEntity, TIdentifier> //: IMapper
        where TDataTransferObject : IDataTransferObject
        where TEntity : Inflexion2.Domain.IAggregateRoot<TEntity, TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
    }
}