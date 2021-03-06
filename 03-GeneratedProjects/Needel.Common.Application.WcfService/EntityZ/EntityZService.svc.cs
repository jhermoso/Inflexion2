﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="EntityZ" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " ApplicationRemoteFacadeBaseSvcCsCT.tt" with "public class ApplicationRemoteFacadeBaseSvcCsCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "ApplicationRemoteFacadeBaseSvcCsCT.tt" con "public class ApplicationRemoteFacadeBaseSvcCsCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.Application.WcfService
{
    #region sharedKernel usings
    #endregion 

    #region general usings
    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Inflexion2.Domain;
    //using Inflexion2.Application.Security.Data.Base;
    using Needel.Common.Application.Dtos;
    using Needel.Common.Domain;

    using Inflexion2.Application;
    //using Inflexion2.Application.DataTransfer.Core;
    //using Inflexion2.Application.Security.RemoteFacade;
    using Inflexion2.Infrastructure;

    using Needel.Common.Application;
    using Needel.Common.Application.WcfService.Contracts;
    //using AppSrvCore = Needel.Common.Application;
    #endregion

    /// <summary>
    /// Clase pública del servicio Wcf encargada de realizar las tareas 
    /// relacionadas con la entidad EntityZ.
    /// </summary>
    [ApplicationErrorHandlerAttribute]
    public partial class EntityZService : IEntityZService
    {

        #region Fields

        /// <summary>
        /// Referencia a los servicios de administración de la entidad EntityZ.
        /// </summary>
        private readonly Needel.Common.Application.IEntityZServices service;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:EntityZService"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:EntityZService"/>.
        /// </remarks>
        public EntityZService()
        {
            // HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            // configuramos aqui el servicio o lo hacemos en el global asax
            // resolvemos con el ioc la interface de servicios de 
            this.service = new EntityZServices();
        } // end EntityZService Constructor

        #endregion

        #region Methods

        /// <summary>
        /// Función encargada de la creación de una entidad de tipo EntityZ.
        /// </summary>
        /// <param name="entityZDto">
        /// Parámetro de tipo <see cref="EntityZDto"/> con los datos necesarios
        /// para la creación de la entidad EntityZ.
        /// </param>
        /// <return>
        /// Devuelve el identificador único de la entidad creada.
        /// </return>
        public Int32 Create(EntityZDto entityZDto)
        {
            // opción 1
            // Instanciamos el servicio de aplicación de creación mediante el contenedor de IoC.
            // var data = ManagerIoC.Container.Resolve<ICreateEntityZ>();
            // Ejecutamos el servicio y obtenemos la respuesta.
            // Int32 identifier = data.Execute( entityZDto);
            // Devolvemos la respuesta.
            // return identifier;

            //opción 2
            Int32 result = 0;
            try
            {
                result = this.service.Create(entityZDto);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
            }

            return result;
        } // end Create

        /// <summary>
        /// Función encargada de la actualziación de una entidad de tipo EntityZ.
        /// </summary>
        /// <param name="entityZDto">
        /// Parámetro de tipo <see cref="EntityZDto"/> con los datos necesarios
        /// para el borrado de la entidad EntityZr.
        /// </param>
        /// <returns>
        /// Devuelve <b>true</b> si la actualización ha sido correcta y
        /// <b>false</b> en caso contrario.
        /// </returns>
        public bool Update( EntityZDto entityZDto)
        {
            // opción 1
            // Instanciamos el servicio de aplicación de actualización mediante el contenedor de IoC.
            // var data = ManagerIoC.Container.Resolve<IUpdateEntityZ>();
            // Ejecutamos el servicio y obtenemos la respuesta.
            // bool response = data.Execute( entityZDto);
            // Devolvemos la respuesta.
            // return response;

            // opción 2
            bool result = false;
            try
            {
                result = this.service.Update(entityZDto);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
            }

            return result;
        } // end Update

        /// <summary>
        /// Función encargada del borrado de una entidad de tipo EntityZ.
        /// </summary>
        /// <param name="id">
        /// Parámetro que indica el identificador único de la entidad a borrar.
        /// </param>
        /// <returns>
        /// Devuelve <b>true</b> si la eliminación ha sido correcta y
        /// <b>false</b> en caso contrario.
        /// </returns>
        public bool Delete(Int32 id)
        {
            // opción 1
            // Instanciamos el servicio de aplicación de borrado mediante el contenedor de IoC.
            // var data = ManagerIoC.Container.Resolve<IDeleteEntityZ>();
            // Ejecutamos el servicio y obtenemos la respuesta.
            // bool response = data.Execute( entityZId);
            // Devolvemos la respuesta.
            //return response;

            //opcion 2
            bool result = false;
            try
            {
                result = this.service.Delete(id);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
            }

            return result;
        } // Delete

        /// <summary>
        /// Método encargado de obtener todas las entidades EntityZ.
        /// </summary>
        /// <returns>
        /// Devuelve listado de Dto´s de la entidad EntityZ.
        /// </returns>
        public IEnumerable<EntityZDto> GetAll()
        {
            // opcion 1
            // Instanciamos el servicio de aplicación correspondiente mediante el contenedor de IoC.
            //var service = ManagerIoC.Container.Resolve<IGetAllEntityZ>();
            // Ejecutamos el servicio y obtenemos la respuesta.
            //IEnumerable<EntityZDto> result = service.Execute();
            // Devolvemos el resultado.
            //return result;
            
            // opcion 2
            IEnumerable<EntityZDto> result = null;
            try
            {
                result = this.service.GetAll();
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
            }

            return result;
        } // GetAll

        /// <summary>
        /// Método encargado de obtener una entidad EntityZ de acuerdo a
        /// su identificador.
        /// </summary>
        /// <param name="entityZId">
        /// Parámetro que indica el identificador único de la entidad cuya
        /// información se desea obtener.
        /// </param>
        /// <returns>
        /// Devuelve objeto dto <see cref="EntityZDto"/> con la información
        /// requerida.
        /// </returns>
        public EntityZDto GetById( Int32 entityZId )
        {
            // opcion 1
            // Instanciamos el servicio de aplicación correspondiente mediante el contenedor de IoC.
            //var service = ManagerIoC.Container.Resolve<IGetByEntityZId>();
            // Ejecutamos el servicio y obtenemos la respuesta.
            //EntityZDto entityZDto = service.Execute( entityZId);
            // Devolvemos el resultado.
            //return entityZDto;

            // opcion 2
            EntityZDto result = null;
            try
            {
                result = this.service.GetById(entityZId);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
            }

            return result;
        } // GetById

        /// <summary>
        /// Recupera una lista paginada de entidades EntityZ, según la especificación indicada.
        /// </summary>
        /// <param name="specificationDto">
        /// Especificación que se va a aplicar.
        /// </param>
        /// <returns>
        /// La lista paginada de entidades EntityZ, según la especificación indicada.
        /// </returns>
        public PagedElements<EntityZDto> GetPaged(SpecificationDto specificationDto)
        {
            PagedElements<EntityZDto>	result = null;
            try
            {
                result = this.service.GetPaged(specificationDto);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Int32> DeleteAll()
        {
            IEnumerable<Int32> result = null;
            try
            {
                result = this.service.DeleteAll();
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityZId"></param>
        /// <returns></returns>
        public IEnumerable<EntityZDto> GetAllExceptThis(Int32 entityZId)
        {
            IEnumerable<EntityZDto> result = null;
            try
            {
                result = this.service.GetAllExceptThis(entityZId);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
            }

            return result;
        }

        public IEnumerable<EntityZDto> GetSelectedThese(IEnumerable<Int32> entityZIds)
        {
            IEnumerable<EntityZDto> result = null;
            try
            {
                result = this.service.GetSelectedThese(entityZIds);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityZIds"></param>
        /// <returns></returns>
        public IEnumerable<EntityZDto> GetAllExceptThese(IEnumerable<Int32> entityZIds)
        {
            IEnumerable<EntityZDto> result = null;
            try
            {
                result = this.service.GetAllExceptThese(entityZIds);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specificationDto"></param>
        /// <returns></returns>
        public IEnumerable<EntityZDto> GetFiltered(SpecificationDto specificationDto)
        {
            IEnumerable<EntityZDto> result = null;
            try
            {
                result = this.service.GetFiltered(specificationDto);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
            }

            return result;
        }

        #endregion

    } // end public partial class EntityZService
} // end Needel.Common.Application.WcfService

