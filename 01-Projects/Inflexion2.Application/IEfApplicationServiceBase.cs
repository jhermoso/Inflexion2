

namespace Inflexion2.Application
{
    #region usings 
    using Inflexion2.Domain;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    #endregion

    /// <summary>
    /// .es Interface genérica para los contratos de base en servicios de la capa de aplicación con EntityFramework
    /// .en Base generic interface for the contracts of application services layer with EntityFramework
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdentifier"></typeparam>
    [ContractClass(typeof(IEfApplicationServiceBaseContract<,,>))]
    public interface IEfApplicationServiceBase<TDto, TEntity, TIdentifier> 
        where TDto : class, IEntityDataTransferObject<TIdentifier>, IDataTransferObject
        where TEntity : class, IEntity<TIdentifier>
        where TIdentifier : IEquatable<TIdentifier>, IComparable<TIdentifier>
    {
        #region Common Methods
        /// <summary>
        /// .en Function in charge to create an entity of type <typeparamref name="TEntity"/>.
        /// .es Función encargada de la creación de una entidad de tipo <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="dto"><typeparamref name="TDto"/></param>
        /// <returns><typeparamref name="TIdentifier"/> of the new <typeparamref name="TEntity"/>.</returns>
        TIdentifier Create(TDto dto);

        /// <summary>
        /// .en Function in charge to delete an entity of type <typeparamref name="TEntity"/>.
        /// .es Función encargada del borrado de una entidad de tipo <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="id"><typeparamref name="TIdentifier"/> entity's id to delete</param>
        /// <returns><b>True:</b> the entity has been deleted succesefuly, <b>False</b> not</returns>
        bool Delete(TIdentifier id);

        /// <summary>
        /// .en Function in charge to get all entities of type <typeparamref name="TEntity"/>.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TEntity"/>.
        /// </summary>
        /// <returns>the whole collection of entities of type <typeparamref name="TEntity"/>.</returns>
        IEnumerable<TDto> GetAll();

        /// <summary>
        /// .en Function in charge to delete all entities of type <typeparamref name="TEntity"/> selected.
        /// </summary>
        /// <param name="ids"><typeparamref name="TIdentifier"/>Selection of <typeparamref name="TEntity"/> to delete.</param>
        /// <returns>array of <typeparamref name="TIdentifier"/> of entities that has not been posible to delete.</returns>
        IEnumerable<TIdentifier> Delete(IEnumerable<TIdentifier> ids);

        /// <summary>
        /// .en Function in charge to delete all entities of type <typeparamref name="TEntity"/> selected.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        IEnumerable<TIdentifier> Delete(IEnumerable<TDto> dtos);

        /// <summary>
        /// .en Function in charge to delete all entities of type <typeparamref name="TEntity"/> selected by the satisfaction of the specification in the parameter.
        /// </summary>
        /// <param name="specificationDto">Specification to select all the entities to delete.</param>
        /// <returns>array of <typeparamref name="TIdentifier"/> of entities that has not been posible to delete.</returns>
        IEnumerable<TIdentifier> Delete(SpecificationDto specificationDto);

        /// <summary>
        /// .en Function in charge to delete all entities of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <returns>array of <typeparamref name="TIdentifier"/> of entities that has not been posible to delete.</returns>
        IEnumerable<TIdentifier> DeleteAll();

        /// <summary>
        /// .en Function in charge to get a collection of all entities of type <typeparamref name="TEntity"/> except the entity with the <typeparamref name="TIdentifier"/> in the parameter.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TEntity"/> excepto la indicada por el id en el parametro.
        /// </summary>
        /// <param name="id"><typeparamref name="TDto"/> to avoid.</param>
        /// <returns></returns>
        IEnumerable<TDto> GetAllExceptThis(TIdentifier id);

        /// <summary>
        /// .en Function in charge to get all entities of type <typeparamref name="TEntity"/> selected by the array of <typeparamref name="TIdentifier"/>.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TEntity"/> seleccionadas por el array de <typeparamref name="TIdentifier"/>.
        /// </summary>
        /// <param name="ids">array of <typeparamref name="TIdentifier"/> of <typeparamref name="TDto"/> to select</param>
        /// <returns></returns>
        IEnumerable<TDto> GetSelectedThese(IEnumerable<TIdentifier> ids);

        /// <summary>
        /// .en Function in charge to get all entities of type <typeparamref name="TEntity"/>except those selected by the array of <typeparamref name="TIdentifier"/>.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TEntity"/>excepto aquellas seleccionadas por el array de <typeparamref name="TIdentifier"/>.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        IEnumerable<TDto> GetAllExceptThese(IEnumerable<TIdentifier> ids);

        /// <summary>
        /// .en Function in charge to get all entities of type <typeparamref name="TEntity"/> selected by the satisfaction of the specification.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TEntity"/> seleccionadas por la satisfacción de la especificación en el parametro.
        /// </summary>
        /// <param name="specificationDto"> especificación a satisfaccer por las entidades recuperadas</param>
        /// <returns></returns>
        IEnumerable<TDto> GetFiltered(SpecificationDto specificationDto);

        /// <summary>
        /// .en Function in charge to get all entities of type <typeparamref name="TEntity"/> selected by the satisfaction of the specification.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TEntity"/> seleccionadas por la satisfacción de la especificación en el parametro.
        /// </summary>
        /// <param name="specificationDto"> especificación a satisfaccer por las entidades recuperadas</param>
        /// <returns></returns>
        IEnumerable<TDto> GetFilteredEntities(SpecificationDto specificationDto);

        /// <summary>
        /// .es Recupera una lista paginada de dto <typeparamref name="TDto"/> de tipo <typeparamref name="TEntity"/>, según la especificación indicada el parametro.
        /// </summary>
        /// <param name="specificationDto">Especificación que se va a aplicar.</param>
        /// <returns> collección de <typeparamref name="TDto"/></returns>
        PagedElements<TDto> GetPaged(SpecificationDto specificationDto);

        /// <summary>
        /// .en Function in charge to get the <typeparamref name="TDto"/> of the entity <typeparamref name="TEntity"/> by his <typeparamref name="TIdentifier"/>.
        /// .es Función encargada de recuperar el <typeparamref name="TDto"/> de la entidad <typeparamref name="TEntity"/> por su <typeparamref name="TIdentifier"/>.
        /// </summary>
        /// <param name="id"><typeparamref name="TIdentifier"/> of the <typeparamref name="TEntity"/> to get</param>
        /// <returns></returns>
        TDto GetById(TIdentifier id);


        /// <summary>
        /// .en Function in charge to update the entity <typeparamref name="TEntity"/>  with the <typeparamref name="TDto"/> in the parameter.
        /// .es Función encargada de actualizar la entidad <typeparamref name="TEntity"/> con su <typeparamref name="TDto"/> en el parametro.
        /// </summary>
        /// <param name="dto">new status for the entity <typeparamref name="TEntity"/></param>
        /// <returns><b>True:</b> the entity has been updated succesefuly, <b>False</b> not</returns>
        bool Update(TDto dto);

        #endregion
    }
}