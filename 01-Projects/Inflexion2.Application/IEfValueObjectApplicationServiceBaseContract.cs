namespace Inflexion2.Application
{
    #region usings 
    using Inflexion2.Domain;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    #endregion


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TValueObject"></typeparam>
    [ContractClassFor(typeof(IEfValueObjectApplicationServiceBase<,>))]
     abstract class IEfValueObjectApplicationServiceBaseContract<TDto, TValueObject> : IEfValueObjectApplicationServiceBase<TDto, TValueObject>
        where TDto : BaseValueObjectDataTransferObject, IDataTransferObject
        where TValueObject : ValueObject<TValueObject>, IValueObject, /*IComparable<TValueObject>,*/ IEquatable<TValueObject>
    {
        #region Common Services Contracts

        /// <summary>
        /// .en Function in charge to create an Value Object of type <typeparamref name="TValueObject"/>.
        /// .es Función encargada de la creación de un value object. <typeparamref name="TValueObject"/>.
        /// </summary>
        /// <param name="dto"><typeparamref name="TDto"/></param>
        /// <returns><typeparamref name="TDto"/> of the new <typeparamref name="TValueObject"/>.</returns>
        public TDto Create(TDto dto)
        {
            //preconditions
            Contract.Requires<ArgumentNullException>(dto != null, "Value Object dto");


            //Postconditions
            //Contract.Ensures(Contract.Result<TDto>() != null);
            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to delete an Value Object of type <typeparamref name="TValueObject"/>.
        /// .es Función encargada del borrado de un value object <typeparamref name="TValueObject"/>.
        /// </summary>
        /// <param name="dto"><typeparamref name="TDto"/> Value Object's id to delete</param>
        /// <returns><b>True:</b> the Value Object has been deleted succesefuly, <b>False</b> not</returns>
        public bool Delete(TDto dto)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(dto != null , "Argument can't be null");
            return true; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to get all Value Objects of type <typeparamref name="TValueObject"/>.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TValueObject"/>.
        /// </summary>
        /// <returns>the whole collection of Value Objects of type <typeparamref name="TValueObject"/>.</returns>
        public IEnumerable<TDto> GetAll()
        {
            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to delete all Value Objects of type <typeparamref name="TValueObject"/> selected.
        /// </summary>
        /// <param name="dto"><typeparamref name="TDto"/>Selection of <typeparamref name="TValueObject"/> to delete.</param>
        /// <returns>array of <typeparamref name="TDto"/> of Value Objects that has not been posible to delete.</returns>
        public IEnumerable<TDto> Delete(IEnumerable<TDto> dto)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(dto != null , "Argument can't be null");
            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to delete all Value Objects of type <typeparamref name="TValueObject"/> selected by the satisfaction of the specification in the parameter.
        /// </summary>
        /// <param name="specificationDto">Specification to select all the Value Objects to delete.</param>
        /// <returns>array of <typeparamref name="TDto"/> of Value Objects that has not been posible to delete.</returns>
        public IEnumerable<TDto> Delete(SpecificationDto specificationDto)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(specificationDto != null, "Specification argument can't be null");
            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to delete all Value Objects of type <typeparamref name="TValueObject"/>.
        /// </summary>
        /// <returns>array of <typeparamref name="TDto"/> of Value Objects that has not been posible to delete.</returns>
        public IEnumerable<TDto> DeleteAll()
        {
            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to get a collection of all Value Objects of type <typeparamref name="TValueObject"/> except the Value Object with the <typeparamref name="TDto"/> in the parameter.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TValueObject"/> excepto la indicada por el id en el parametro.
        /// </summary>
        /// <param name="dto"><typeparamref name="TDto"/> to avoid.</param>
        /// <returns></returns>
        public IEnumerable<TDto> GetAllExceptThis(TDto dto)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(dto != null, "Argument can't be null");
            return null; // fake implentation
        }


        /// <summary>
        /// .en Function in charge to get all Value Objects of type <typeparamref name="TValueObject"/>except those selected by the array of <typeparamref name="TDto"/>.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TValueObject"/>excepto aquellas seleccionadas por el array de <typeparamref name="TDto"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public IEnumerable<TDto> GetAllExceptThese(IEnumerable<TDto> dtos)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(dtos != null, "Argument can't be null");
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
            Contract.Requires<ArgumentNullException>(specificationDto != null, "Specification argument can't be null");

            return null; // fake implentation
        }

        /// <summary>
        /// .en Function in charge to get all Value Objects of type <typeparamref name="TValueObject"/> selected by the satisfaction of the specification.
        /// .es Función encargada de obtener todas las entidades de tipo <typeparamref name="TValueObject"/> seleccionadas por la satisfacción de la especificación en el parametro.
        /// </summary>
        /// <param name="specificationDto"> especificación a satisfaccer por las entidades recuperadas</param>
        /// <returns></returns>
        public IEnumerable<TDto> GetFilteredValueObjects(SpecificationDto specificationDto)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(specificationDto != null, "Specification argument can't be null");

            return null; // fake implentation
        }
        /// <summary>
        /// .es Recupera una lista paginada de dto <typeparamref name="TDto"/> de tipo <typeparamref name="TValueObject"/>, según la especificación indicada el parametro.
        /// </summary>
        /// <param name="specificationDto">Especificación que se va a aplicar.</param>
        /// <returns> collección de <typeparamref name="TDto"/></returns>
        public PagedElements<TDto> GetPaged(SpecificationDto specificationDto)
        {
            // preconditions
            Contract.Requires<ArgumentNullException>(specificationDto != null, "Specification argument can't be null");

            return null; // fake implentation
        }

        #endregion
    }
}