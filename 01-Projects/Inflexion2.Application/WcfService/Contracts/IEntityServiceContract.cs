#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="IEntityServiceContract.cs" company="Inflexion2">
//     Copyright (c) 2019. Company. All Rights Reserved.
//     Copyright (c) 2019. Company. Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Inflexion2.Application.WcfService.Contracts
{

    #region general usings
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using Inflexion2.Domain;
    using Inflexion2.Application;
    #endregion

    /// <summary>
    /// Interfaz que permite definir el contrato de servicio para las acciones
    /// relacionadas con la entidad.
    /// </summary>
    [ServiceContract, ServiceFaultContracts]
    public partial interface IEntityServiceContract<TDto, TEntity, TIdentifier> 
        where TDto : class, IDataTransferObject
        where TEntity : class, Inflexion2.Domain.IEntity<TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {

        #region Methods
        /// <summary>
        /// .es Función encargada de la creación de la entidad.
        /// </summary>
        /// <param name="dto">
        /// Parámetro de tipo TDto holder de datos para transmision de la información de la entidad .
        /// </param>
        /// <return>
        /// Devuelve el identificador único de la entidad creada.
        /// </return>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        TIdentifier Create(TDto dto);

        /// <summary>
        /// .es Función encargada de la actualización de una entidad.
        /// </summary>
        /// <param name="dto">
        /// Parámetro de tipo TDto con los datos necesarios
        /// para el borrado de la entidad.
        /// </param>
        /// <returns>
        /// Devuelve <b>true</b> si la actualización ha sido correcta y
        /// <b>false</b> en caso contrario.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        bool Update(
                    TDto dto);

        /// <summary>
        /// Elimina una determinada entidad.
        /// </summary>
        /// <param name="id">
        /// Identificador de la entidad que se va a eliminar.
        /// </param>
        /// <returns>
        /// Es <b>true</b> si la eliminación ha sido correcta; en caso contrario <b>false</b>.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        bool Delete(TIdentifier id);


        /// <summary>
        /// Método encargado de obtener todas las entidades.
        /// </summary>
        /// <returns>
        /// Devuelve listado de Dtos de la entidad.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<TDto> GetAll();

        /// <summary>
        /// Método encargado de obtener una entidad de acuerdo a
        /// su identificador.
        /// </summary>
        /// <param name="id">
        /// Parámetro que indica el identificador único de la entidad cuya
        /// información se desea obtener.
        /// </param>
        /// <returns>
        /// Devuelve objeto TDto con la información requerida.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        TDto GetById(TIdentifier id );

        /// <summary>
        /// Recupera una lista paginada de entidades, según la especificación indicada.
        /// </summary>
        /// <param name="specificationDto">
        /// Especificación que se va a aplicar.
        /// </param>
        /// <returns>
        /// La lista paginada de entidades, según la especificación indicada.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        PagedElements<TDto> GetPaged(SpecificationDto specificationDto);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<TIdentifier> DeleteAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<TDto> GetAllExceptId(TIdentifier id);
  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<TDto> GetSelectedIds(IEnumerable<TIdentifier> ids);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<TDto> GetAllExceptIds(IEnumerable<TIdentifier> ids);

        /// <summary>
        /// /
        /// </summary>
        /// <param name="specificationDto"></param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<TDto> GetFiltered(SpecificationDto specificationDto);

        #endregion

    } // end public partial interface Service
} // end Inflexion2.Application.WcfService.Contracts

