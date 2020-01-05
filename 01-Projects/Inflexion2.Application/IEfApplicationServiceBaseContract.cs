namespace Inflexion2.Application
{
    #region usings 
    using Inflexion2.Domain;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    #endregion

    [ContractClassFor(typeof(IEfApplicationServiceBase<,,>))]
    abstract class IEfApplicationServiceBaseContract<TDto, TEntity, TIdentifier> : IEfApplicationServiceBase<TDto, TEntity, TIdentifier>
        where TDto : class, IEntityDataTransferObject<TIdentifier>, IDataTransferObject
        where TEntity : class, IEntity<TIdentifier>
        where TIdentifier : IEquatable<TIdentifier>, IComparable<TIdentifier>
    {
        #region Common Services Contracts

        /// <summary>
        /// .en Function in charge to create an entity of type <typeparamref name="TEntity"/>.
        /// .es Función encargada de la creación de una entidad de tipo <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="dto"><typeparamref name="TDto"/></param>
        /// <returns><typeparamref name="TIdentifier"/> of the new <typeparamref name="TEntity"/>.</returns>
        public TIdentifier Create(TDto dto)
        {
            //preconditions
            Contract.Requires<ArgumentNullException>(dto != null, "entity dto");
            Contract.Requires<ArgumentNullException>(dto.Id.Equals(default(TIdentifier)), "entity dto");

            //Postconditions
            Contract.Ensures(!Contract.Result<TIdentifier>().Equals(default(TIdentifier)));
            return default(TIdentifier); // fake implentation
        }

        /// <summary>
        /// .en Function in charge to delete an entity of type <typeparamref name="TEntity"/>.
        /// .es Función encargada del borrado de una entidad de tipo <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="id"><typeparamref name="TIdentifier"/> entity's id to delete</param>
        /// <returns><b>True:</b> the entity has been deleted succesefuly, <b>False</b> not</returns>
        public bool Delete(TIdentifier id)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(id != null && !id.Equals(default(TIdentifier)), "id");
            return false; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to get all entities of type <typeparamref name="TEntity"/>.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TEntity"/>.
        /// </summary>
        /// <returns>the whole collection of entities of type <typeparamref name="TEntity"/>.</returns>
        public IEnumerable<TDto> GetAll()
        {
            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to delete all entities of type <typeparamref name="TEntity"/> selected.
        /// </summary>
        /// <param name="ids"><typeparamref name="TIdentifier"/>Selection of <typeparamref name="TEntity"/> to delete.</param>
        /// <returns>array of <typeparamref name="TIdentifier"/> of entities that has not been posible to delete.</returns>
        public IEnumerable<TIdentifier> Delete(IEnumerable<TIdentifier> ids)
        {
            // preconditions
            //Contract.Requires<ArgumentNullException>(ids != null , "ids");
            return null; // fake implentation
        }

        public IEnumerable<TIdentifier> Delete(IEnumerable<TDto> dtos)
        {
            // preconditions
            //Contract.Requires<ArgumentNullException>(ids != null , "ids");
            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to delete all entities of type <typeparamref name="TEntity"/> selected by the satisfaction of the specification in the parameter.
        /// </summary>
        /// <param name="specificationDto">Specification to select all the entities to delete.</param>
        /// <returns>array of <typeparamref name="TIdentifier"/> of entities that has not been posible to delete.</returns>
        public IEnumerable<TIdentifier> Delete(SpecificationDto specificationDto)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(specificationDto != null, "specification dto");
            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to delete all entities of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <returns>array of <typeparamref name="TIdentifier"/> of entities that has not been posible to delete.</returns>
        public IEnumerable<TIdentifier> DeleteAll()
        {
            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to get a collection of all entities of type <typeparamref name="TEntity"/> except the entity with the <typeparamref name="TIdentifier"/> in the parameter.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TEntity"/> excepto la indicada por el id en el parametro.
        /// </summary>
        /// <param name="id"><typeparamref name="TDto"/> to avoid.</param>
        /// <returns></returns>
        public IEnumerable<TDto> GetAllExceptThis(TIdentifier id)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(id != null && !id.Equals(default(TIdentifier)), "id");
            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to get all entities of type <typeparamref name="TEntity"/> selected by the array of <typeparamref name="TIdentifier"/>.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TEntity"/> seleccionadas por el array de <typeparamref name="TIdentifier"/>.
        /// </summary>
        /// <param name="ids">array of <typeparamref name="TIdentifier"/> of <typeparamref name="TDto"/> to select</param>
        /// <returns></returns>
        public IEnumerable<TDto> GetSelectedThese(IEnumerable<TIdentifier> ids)
        {
            // preconditions
            //Contract.Requires<ArgumentNullException>(ids != null, "ids");
            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to get all entities of type <typeparamref name="TEntity"/>except those selected by the array of <typeparamref name="TIdentifier"/>.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TEntity"/>excepto aquellas seleccionadas por el array de <typeparamref name="TIdentifier"/>.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<TDto> GetAllExceptThese(IEnumerable<TIdentifier> ids)
        {
            // preconditions
            //Contract.Requires<ArgumentNullException>(ids != null, "ids");
            return null; // fake implentation
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specificationDto"></param>
        /// <returns></returns>
        public IEnumerable<TDto> GetFiltered(SpecificationDto specificationDto)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(specificationDto != null, "specification dto");

            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to get all entities of type <typeparamref name="TEntity"/> selected by the satisfaction of the specification.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TEntity"/> seleccionadas por la satisfacción de la especificación en el parametro.
        /// </summary>
        /// <param name="specificationDto"> especificación a satisfaccer por las entidades recuperadas</param>
        /// <returns></returns>
        public IEnumerable<TDto> GetFilteredEntities(SpecificationDto specificationDto)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(specificationDto != null, "specification dto");

            // postconditions
            Contract.Ensures(Contract.Result<System.Collections.Generic.IEnumerable<TDto>>() != null);
            return null; // fake implentation
        }
        /// <summary>
        /// .es Recupera una lista paginada de dto <typeparamref name="TDto"/> de tipo <typeparamref name="TEntity"/>, según la especificación indicada el parametro.
        /// </summary>
        /// <param name="specificationDto">Especificación que se va a aplicar.</param>
        /// <returns> collección de <typeparamref name="TDto"/></returns>
        public PagedElements<TDto> GetPaged(SpecificationDto specificationDto)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(specificationDto != null, "specification dto");

            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to get the <typeparamref name="TDto"/> of the entity <typeparamref name="TEntity"/> by his <typeparamref name="TIdentifier"/>.
        /// .es Función encargada de recuperar el <typeparamref name="TDto"/> de la entidad <typeparamref name="TEntity"/> por su <typeparamref name="TIdentifier"/>.
        /// </summary>
        /// <param name="id"><typeparamref name="TIdentifier"/> of the <typeparamref name="TEntity"/> to get</param>
        /// <returns></returns>
        public TDto GetById(TIdentifier id)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(id != null && !id.Equals(default(TIdentifier)), "id");

            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to update the entity <typeparamref name="TEntity"/>  with the <typeparamref name="TDto"/> in the parameter.
        /// .es Función encargada de actualizar la entidad <typeparamref name="TEntity"/> con su <typeparamref name="TDto"/> en el parametro.
        /// </summary>
        /// <param name="dto">new status for the entity <typeparamref name="TEntity"/></param>
        /// <returns><b>True:</b> the entity has been updated succesefuly, <b>False</b> not</returns>
        public bool Update(TDto dto)
        {
            //preconditions
            Contract.Requires<ArgumentNullException>(dto != null, "entity dto");
            Contract.Requires<ArgumentNullException>(!dto.Id.Equals(default(TIdentifier)), "entity dto");

            return false; // fake implentation
        }
        #endregion
    }
}