// -----------------------------------------------------------------------
// <copyright file="IDataEntityMapper.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
using Inflexion2.Domain;

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
    /// <typeparam name="TValueObjec">Representa las entidades del negocio.</typeparam>
    
    public interface IDataValueObjectMapper<TDto, TValueObjec> //: IEntityMapper<TDataTransferObject, TValueObjec, TIdentifier> //,IDataMapper<TDataTransferObject, TValueObjec, TIdentifier>
        where TDto : BaseValueObjectDataTransferObject
        where TValueObjec : Domain.IValueObject //, Inflexion2.Domain.IAggregateRoot<TValueObjec, TIdentifier>

    {
        /// <summary>
        /// Función encargada de mapear una entidad con un Dto.
        /// </summary>
        /// <remarks>
        /// Con esta función, mapeamos una entidad con un Dto.
        /// </remarks>
        /// <param name="entity">Representa las entidades de negocio.</param>
        /// <returns>Devuelve un objeto de transferencia de datos.</returns>
        TDto ValueObjectMapping(TValueObjec entity);

        /// <summary>
        /// Función encargada de mapear una entidad con un Dto,
        /// con la opción de seleccionar si se mapean también los hijos y los padres 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="mapParents"></param>
        /// <param name="mapChildren"></param>
        /// <returns></returns>
        TDto ValueObjectMapping(TValueObjec entity, bool mapParents, bool mapChildren);
    }
}