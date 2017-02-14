namespace Inflexion2.Application
{
    using System.Collections.Generic;
    using System;
    using Inflexion2.Domain;
    using Inflexion2;

    /// <summary>
    /// Interfaz para los mapeadores entre entidades del dominio.
    /// (<see cref="Inflexion2.Domain.IEntity{TIdentifier}"/>) y
    /// objetos de transferencia de datos (<see cref="IDataTransferObject"/>).
    /// </summary>
    /// <remarks>
    /// La interfaz <c>IGenericMapper</c> permite mapear entre entidades del dominio.
    /// </remarks>
    /// <typeparam name="TDto">
    /// Representa la interfaz de los objetos de transferencia de datos.
    /// </typeparam>
    /// <typeparam name="TEntity">
    /// Representa las entidades del negocio.
    /// </typeparam>
    /// <typeparam name="TIdentifier">
    /// Representa un identificador unívoco de entidad.
    /// </typeparam>
    public interface IGenericServices<TDto, TEntity, TIdentifier> //: IServices
        where TDto : class, IDataTransferObject
        where TEntity : Inflexion2.Domain.IAggregateRoot<TEntity, TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        /// <summary>
        /// Service to create a new entity
        /// </summary>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        Int32 Create(TDto entityDto);

        /// <summary>
        /// Service to ask for to remove or to deactivate the entity identified by the id
        /// </summary>
        /// <param name="Id">unique entity's identifier </param>
        /// <returns></returns>
        bool Delete(TIdentifier Id);

        /// <summary>
        /// Service to ask for all the entities in the respository
        /// </summary>
        /// <returns></returns>
        IEnumerable<TDto> GetAll();

        /// <summary>
        /// get paged elements throught an specification dto 
        /// </summary>
        /// <param name="specificationDto"></param>
        /// <returns></returns>
        PagedElements<TDto> GetPaged(SpecificationDto specificationDto);

        /// <summary>
        /// Get an entity dto throught his Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TDto GetById(TIdentifier Id);

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Update(TDto dto);

    }
}
