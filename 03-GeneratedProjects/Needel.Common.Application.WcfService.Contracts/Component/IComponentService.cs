﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Component" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " ApplicationRemoteFacadeCoreServiceCT.tt" with "public class ApplicationRemoteFacadeCoreServiceCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "ApplicationRemoteFacadeCoreServiceCT.tt" con "public class ApplicationRemoteFacadeCoreServiceCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.Application.WcfService.Contracts
{

    #region sharedKernel usings
    #endregion 

    #region general usings
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Inflexion2.Domain;
    using Inflexion2.Application;
    //using Inflexion.Framework.Application.Security.Data.Base;
    using Needel.Common.Application.Dtos;
    using Needel.Common.Domain;
    #endregion

    /// <summary>
    /// Interfaz que permite definir el contrato de servicio para las acciones
    /// relacionadas con la entidad Component.
    /// </summary>
    [ServiceContract, ServiceFaultContracts]
    public partial interface IComponentService
    {

        #region Methods
        /// <summary>
        /// Función encargada de la creación de una entidad de tipo Component.
        /// </summary>
        /// <param name="componentDto">
        /// Parámetro de tipo <see cref="ComponentDto"/> con los datos necesarios
        /// para la creación de la entidad Component.
        /// </param>
        /// <return>
        /// Devuelve el identificador único de la entidad creada.
        /// </return>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        Int32 Create(
                    ComponentDto componentDto);

        /// <summary>
        /// Función encargada de la actualización de una entidad de tipo Component.
        /// </summary>
        /// <param name="componentDto">
        /// Parámetro de tipo <see cref="ComponentDto"/> con los datos necesarios
        /// para el borrado de la entidad Componentr.
        /// </param>
        /// <returns>
        /// Devuelve <b>true</b> si la actualización ha sido correcta y
        /// <b>false</b> en caso contrario.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        bool Update(
                    ComponentDto componentDto);
        /// <summary>
        /// Elimina una determinada entidad Component.
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
        bool Delete(Int32 id);


        /// <summary>
        /// Método encargado de obtener todas las entidades Component.
        /// </summary>
        /// <returns>
        /// Devuelve listado de Dto´s de la entidad Component.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<ComponentDto> GetAll();

        /// <summary>
        /// Método encargado de obtener una entidad Component de acuerdo a
        /// su identificador.
        /// </summary>
        /// <param name="componentId">
        /// Parámetro que indica el identificador único de la entidad cuya
        /// información se desea obtener.
        /// </param>
        /// <returns>
        /// Devuelve objeto dto <see cref="ComponentDto"/> con la información
        /// requerida.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        ComponentDto GetById(Int32 componentId );

        /// <summary>
        /// Recupera una lista paginada de entidades Component, según la especificación indicada.
        /// </summary>
        /// <param name="specificationDto">
        /// Especificación que se va a aplicar.
        /// </param>
        /// <returns>
        /// La lista paginada de entidades Component, según la especificación indicada.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        PagedElements<ComponentDto> GetPaged(SpecificationDto specificationDto);

        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<Int32> DeleteAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="componentId"></param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<ComponentDto> GetAllExceptThis(Int32 componentId);

        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<ComponentDto> GetAllExceptIdAndChildren(Int32 componentId);

        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<ComponentDto> GetSelectedThese(IEnumerable<Int32> componentIds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="componentIds"></param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<ComponentDto> GetAllExceptThese(IEnumerable<Int32> componentIds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specificationDto"></param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<ComponentDto> GetFiltered(SpecificationDto specificationDto);

        #endregion
    } // end public partial interface ComponentService
} // end Needel.Common.Application.WcfService.Contracts
