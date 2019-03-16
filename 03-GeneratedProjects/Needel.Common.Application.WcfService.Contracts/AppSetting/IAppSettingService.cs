﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="AppSetting" company="Company">
//     Copyright (c) 2019. Company. All Rights Reserved.
//     Copyright (c) 2019. Company. Todos los derechos reservados.
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
    #endregion

    /// <summary>
    /// Interfaz que permite definir el contrato de servicio para las acciones
    /// relacionadas con la entidad AppSetting.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [ServiceContract, ServiceFaultContracts]
    public partial interface IAppSettingService
    {

        #region Methods
        /// <summary>
        /// Función encargada de la creación de una entidad de tipo AppSetting.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="appSettingDto">
        /// Parámetro de tipo <see cref="AppSettingDto"/> con los datos necesarios
        /// para la creación de la entidad AppSetting.
        /// </param>
        /// <return>
        /// Devuelve el identificador único de la entidad creada.
        /// </return>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        int Create(
                    AppSettingDto appSettingDto);

        /// <summary>
        /// Función encargada de la actualziación de una entidad de tipo AppSetting.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="appSettingDto">
        /// Parámetro de tipo <see cref="AppSettingDto"/> con los datos necesarios
        /// para el borrado de la entidad AppSettingr.
        /// </param>
        /// <returns>
        /// Devuelve <b>true</b> si la actualización ha sido correcta y
        /// <b>false</b> en caso contrario.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        bool Update(
                    AppSettingDto appSettingDto);

        /// <summary>
        /// Elimina una determinada entidad AppSetting.
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
        bool Delete(int id);


        /// <summary>
        /// Método encargado de obtener todas las entidades AppSetting.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <returns>
        /// Devuelve listado de Dto´s de la entidad AppSetting.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        IEnumerable<AppSettingDto> GetAll();

        /// <summary>
        /// Método encargado de obtener una entidad AppSetting de acuerdo a
        /// su identificador.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="appSettingId">
        /// Parámetro que indica el identificador único de la entidad cuya
        /// información se desea obtener.
        /// </param>
        /// <returns>
        /// Devuelve objeto dto <see cref="AppSettingDto"/> con la información
        /// requerida.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        AppSettingDto GetById(
                            Int32 appSettingId );

        /// <summary>
        /// Recupera una lista paginada de entidades AppSetting, según la especificación indicada.
        /// </summary>
        /// <param name="specificationDto">
        /// Especificación que se va a aplicar.
        /// </param>
        /// <returns>
        /// La lista paginada de entidades AppSetting, según la especificación indicada.
        /// </returns>
        [OperationContract, FaultContract(typeof(FaultObject))]
        [FaultContract(typeof(ValidationException))]
        [FaultContract(typeof(InternalException))]
        PagedElements<AppSettingDto> GetPaged(SpecificationDto specificationDto);

        #endregion

    } // end public partial interface AppSettingService
} // end Needel.Common.Application.WcfService.Contracts

