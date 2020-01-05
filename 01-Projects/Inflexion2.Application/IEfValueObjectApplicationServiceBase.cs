

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
    /// <typeparam name="TValueObject"></typeparam>

    [ContractClass(typeof(IEfValueObjectApplicationServiceBaseContract<,>))]
    public interface IEfValueObjectApplicationServiceBase<TDto, TValueObject> 
        where TDto : BaseValueObjectDataTransferObject, IDataTransferObject
        where TValueObject : ValueObject<TValueObject>, IValueObject, /*IComparable<TValueObject>,*/ IEquatable<TValueObject>

    {
        #region Common Methods
        /// <summary>
        /// .en Function in charge to create an entity of type <typeparamref name="TValueObject"/>.
        /// .es Función encargada de la creación de una entidad de tipo <typeparamref name="TValueObject"/>.
        /// </summary>
        /// <param name="dto"><typeparamref name="TValueObject"/></param>
        /// <returns><typeparamref name="TValueObject"/> of the new <typeparamref name="TValueObject"/>.</returns>
        TDto Create(TDto dto);

        /// <summary>
        /// .en Function in charge to delete an entity of type <typeparamref name="TValueObject"/>.
        /// .es Función encargada del borrado de una entidad de tipo <typeparamref name="TValueObject"/>.
        /// </summary>
        /// <param name="dto"><typeparamref name="TDto"/> value Object to delete</param>
        /// <returns><b>True:</b> the entity has been deleted succesefuly, <b>False</b> not</returns>
        //bool Delete(TDto dto);
        bool Delete(TDto dto);

        /// <summary>
        /// .en Function in charge to get all entities of type <typeparamref name="TValueObject"/>.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TValueObject"/>.
        /// </summary>
        /// <returns>the whole collection of entities of type <typeparamref name="TValueObject"/>.</returns>
        IEnumerable<TDto> GetAll();

        /// <summary>
        /// .en Function in charge to delete all value objects of type <typeparamref name="TValueObject"/> selected.
        /// </summary>
        /// <param name="dto"><typeparamref name="TValueObject"/>Selection of <typeparamref name="TValueObject"/> to delete.</param>
        /// <returns>array of <typeparamref name="TValueObject"/> of entities that has not been posible to delete.</returns>

        IEnumerable<TDto> Delete(IEnumerable<TDto> dto);

        /// <summary>
        /// .en Function in charge to delete all value objects of type <typeparamref name="TValueObject"/> selected by the satisfaction of the specification in the parameter.
        /// </summary>
        /// <param name="specificationDto">Specification to select all the value objects to delete.</param>
        /// <returns>array of <typeparamref name="TDto"/> of value objects that has not been posible to delete.</returns>
        IEnumerable<TDto> Delete(SpecificationDto specificationDto);

        /// <summary>
        /// .en Function in charge to delete all value objects of type <typeparamref name="TValueObject"/>.
        /// </summary>
        /// <returns>array of <typeparamref name="TDto"/> of value objects that has not been posible to delete.</returns>
        IEnumerable<TDto> DeleteAll();

        /// <summary>
        /// .en Function in charge to get a collection of all value objects of type <typeparamref name="TValueObject"/> except the value object with the <typeparamref name="TDto"/> in the parameter.
        /// .es Función encargada de obtener todas las value objects de tipo <typeparamref name="TValueObject"/> excepto la indicada por el id en el parametro.
        /// </summary>
        /// <param name="dto"><typeparamref name="TDto"/> to avoid.</param>
        /// <returns></returns>
        //IEnumerable<TDto> GetAllExceptThis(TDto dto);
        IEnumerable<TDto> GetAllExceptThis(TDto dto);

        /// <summary>
        /// .en Function in charge to get all entities of type <typeparamref name="TValueObject"/>except those selected by the array of <typeparamref name="TDto"/>.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TValueObject"/>excepto aquellas seleccionadas por el array de <typeparamref name="TDto"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        //IEnumerable<TDto> GetAllExceptThese(TDto[] dtos);
        IEnumerable<TDto> GetAllExceptThese(IEnumerable<TDto> dtos);

        /// <summary>
        /// .en Function in charge to get all entities of type <typeparamref name="TValueObject"/> selected by the satisfaction of the specification.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TValueObject"/> seleccionadas por la satisfacción de la especificación en el parametro.
        /// </summary>
        /// <param name="specificationDto"> especificación a satisfaccer por las entidades recuperadas</param>
        /// <returns></returns>
        IEnumerable<TDto> GetFiltered(SpecificationDto specificationDto);

        /// <summary>
        /// .es Recupera una lista paginada de dto <typeparamref name="TDto"/> de tipo <typeparamref name="TValueObject"/>, según la especificación indicada el parametro.
        /// </summary>
        /// <param name="specificationDto">Especificación que se va a aplicar.</param>
        /// <returns> collección de <typeparamref name="TDto"/></returns>
        PagedElements<TDto> GetPaged(SpecificationDto specificationDto);


        #endregion
    }
}