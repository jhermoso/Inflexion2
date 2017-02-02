// -----------------------------------------------------------------------
// <copyright file="IEntityMapper.cs" company="Inflexion Software">
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
    /// <typeparam name="TDataTransferObject">
    /// Representa la interfaz de los objetos de transferencia de datos.
    /// </typeparam>
    /// <typeparam name="TEntity">
    /// Representa las entidades del negocio.
    /// </typeparam>
    /// <typeparam name="TIdentifier">
    /// Representa un identificador unívoco de entidad.
    /// </typeparam>
    /// <example>
    /// Ejemplo de implementación de esta interfaz suponiendo la interfaz
    /// <c>IAmbitoMapper</c> que la implementa:
    /// <code>
    ///   <![CDATA[
    ///
    /// using Inflexion.Framework.Application.Core;
    ///
    /// using Inflexion.Suite.Foo.BoundedContext.Application.Data.Base;
    /// using Inflexion.Suite.Foo.BoundedContext.Domain.Core;
    ///
    /// /// <summary>
    /// /// Interfaz que identifica los mapeos de
    /// /// datos con la entidad <see cref="IAmbito"/>.
    /// /// </summary>
    /// public interface IAmbitoMapper : IEntityMapper<AmbitoDto, IAmbito, int>
    /// {
    ///
    /// } // IAmbitoMapper
    ///
    ///   ]]>
    /// </code>
    /// </example>
    public interface IEntityMapper<TDataTransferObject, TEntity, TIdentifier> : IGenericMapper<TDataTransferObject, TEntity, TIdentifier>
        where TDataTransferObject : IDataTransferObject
        where TEntity : Inflexion2.Domain.IAggregateRoot<TEntity, TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Methods

        /// <summary>
        /// Función encargada de mapear una entidad con un Dto.
        /// </summary>
        /// <remarks>
        /// Con esta función, mapeamos una entidad con un Dto.
        /// </remarks>
        /// <param name="entity">Representa las entidades de negocio.</param>
        /// <returns>Devuelve un objeto de transferencia de datos.</returns>
        TDataTransferObject EntityMapping(TEntity entity);

        #endregion Methods
    }
}