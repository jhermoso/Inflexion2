﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Component" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " ApplicationEntityServicesBaseCT.tt" with "public class ApplicationEntityServicesBaseCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "ApplicationEntityServicesBaseCT.tt" con "public class ApplicationEntityServicesBaseCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.Application
{
    #region usings 

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Globalization;
    using System.Reflection;
    using System.Data.Entity;
    using System.Configuration;

    using Microsoft.Practices.Unity;

    using Inflexion2.Domain;
    using Inflexion2.Application;
    using Inflexion2;
    using Inflexion2.Domain.Specification;
    using Inflexion2.Logging;
    using Inflexion2.Data;
    using Inflexion2.Resources;

    using Needel.Common.Application.Dtos;
    using Needel.Common.Application;    
    using Needel.Common.Domain;
    using Needel.Common.Infrastructure;
    using Needel.Common.Infrastructure.Resources;
// Common

    using System.ComponentModel.DataAnnotations;
    using System.Collections.ObjectModel;
    #endregion

    /// <summary>
    /// .en generated with ServiceHeaderClass.tt
    /// Administration services of the entity Component.
    /// .es geenrado con la plantilla ServiceHeaderClass.tt
    /// Representa los servicios de administración de la entidad Component.
    /// </summary>
    /// <remarks>
    /// .en Create an object of type <see cref="Component"/>.
    /// .es Crea un objeto <see cref="Component"/>.
    ///  permanent guid = 
    /// </remarks>
    public partial class ComponentServices : Inflexion2.Application.EfApplicationServicesBase<ComponentDto, Component, Int32>, IComponentServices
    {

        #region Fields
        // Mappers of related entitites
        new IComponentRepository EntityRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// .es Inicializa una nueva instancia de la clase <see cref="T:Component>Service"/>.
        /// </summary>
        /// <remarks>
        /// .es Constructor de la clase <see cref="T:ComponentServices"/>.
        /// </remarks>
        public ComponentServices() : base()
        {
            this.EntityMapper = new ComponentMapper();
            this.EntityRepository = ApplicationLayer.IocContainer.Resolve<IComponentRepository>();
        }
        #endregion

        #region Create Method
        // from template Application\UpdateBase\I2ServiceRegionCreateMethod.tt

        /// <summary>
        /// Crea una entidad Component.
        /// </summary>
        /// <param name="componentDto">
        /// DTO que contiene la información para crear la entidad.
        /// </param>
        /// <returns>
        /// El identificador de la entidad creada.
        /// </returns>
        public override Int32 Create(ComponentDto componentDto)
        {

            #region Preconditions

            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(
                                    componentDto,
                                    string.Format(
                                                    FrameworkResource.DataTransferObjectIsNull,
                                                    CommonResources.ComponentAlias));
            // Comprobar los campos mandatory dentro del DTO.
            Guard.ArgumentNotNullOrEmpty(
                                        componentDto.Name,
                                        string.Format(
                                                        FrameworkResource.PropertyRequired,
                                                        CommonResources.Component_NameAlias, 
                                                        CommonResources.ComponentAlias)
                                        );

            Guard.ArgumentNotNullOrEmpty(
                                        componentDto.PartNumber,
                                        string.Format(
                                                        FrameworkResource.PropertyRequired,
                                                        CommonResources.Component_PartNumberAlias, 
                                                        CommonResources.ComponentAlias)
                                        );

            #endregion

            // .en the dto has to be transient, so the Id has to have a default value.
            // .es el dto debe corresponder a un transient por lo que el id debe tener el valor por defecto
            Guard.Against<ArgumentException>(componentDto.Id != default(Int32),                                    
                                                    string.Format(
                                                                FrameworkResource.IsNotTransient,
                                                                CommonResources.ComponentAlias
                                                                    )
                                            );

            var parent = new System.Collections.Generic.List<Component>();


            Component component = ComponentFactory.Create
            (
                componentDto.Name, componentDto.PartNumber
            );//**
            component.Description = componentDto.Description; // property.AutoProperty = True; property.OnlyGetProperty = False
                //.en Getting properties that comes from parent relationships
                //.es Obtenemos las propiedades que provienen the relaciones parentales.
            if (componentDto.Parent != null)
            {
                IComponentRepository repocomponent = ApplicationLayer.IocContainer.Resolve<IComponentRepository>();
                var componentTemp = repocomponent.GetById(componentDto.Parent.Id);
                component.SetParent(componentTemp);
            }
            this.EntityRepository.Add(component);
            this.Commit();

            return component.Id;
        }
        #endregion

        #region Service Delete

        /// <summary>
        /// .es Elimina una determinada entidad Component.
        /// </summary>
        /// <param name="id">
        /// Identificador de la entidad que se va a eliminar.
        /// </param>
        /// <returns>
        /// Es <b>true</b> si la eliminación ha sido correcta; en caso contrario <b>false</b>.
        /// </returns>
        public override bool Delete(Int32 id)
        {
             IEnumerable<Component> results = this.EntityRepository.GetFilteredElements(u => u.Id == id);
            Component component2Delete = results.First();
            if (!component2Delete.CanBeDeleted())
            {
                return false;
            }


            try
            {
                this.EntityRepository.Remove(component2Delete);
                this.Commit();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        /// <summary>
        /// .es Elimina las entidades Component seleccionadas por los ids del parametro.
        /// </summary>
        /// <param name="componentIds"></param>
        /// <returns></returns>
        public override IEnumerable<Int32> Delete(IEnumerable<Int32> componentIds)
        {
            foreach (var id in componentIds)
            {
                if ((!Delete(id)))
                {
                    yield return id;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specificationDto"></param>
        /// <returns></returns>
        public override IEnumerable<Int32> Delete(SpecificationDto specificationDto)
        {
            var dtos2delete = GetFilteredEntities(specificationDto).Select(c => c.Id).ToList();
            return Delete(dtos2delete);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Int32> DeleteAll()
        {
            List<Int32> result = new List<Int32>();

            try
            {
                var entities = this.EntityRepository.RemoveAll();
                this.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToArray();
        }




        #endregion


        #region GetAll Method
        /// <summary>
        /// .es Recupera todas las entidades Component.
        /// </summary>
        /// <returns>
        /// Todas las entidades Component.
        /// </returns>
        public override IEnumerable<ComponentDto> GetAll()
        {
            // .en answer variable
            // .es Variable de respuesta.
            // list new cosntructor (int32) initial size http://msdn.microsoft.com/en-us/library/dw8e0z9z(v=vs.110).aspx
            var result = new List<ComponentDto>(0);

            try
            {
                var entities = this.EntityRepository.GetAll();
                // Mapeamos los datos.
                entities.ToList()
                        .ForEach(entity =>
                        {
                            var entityDto = this.EntityMapper.EntityMapping(entity);
                            result.Add(entityDto);
                        });

                // Confirmamos la transacción.
                this.Commit();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Devolver resultado.
            return result;
        }

        /// <summary>
        /// .es Recupera todas las instancias de Component excepto la indicada por el parametro. 
        /// </summary>
        /// <param name="componentId">.es Entidad a evitar.</param>
        /// <returns></returns>
        public override IEnumerable<ComponentDto> GetAllExceptThis(Int32 componentId)
        {
            try
            {
                List<ComponentDto> result = new List<ComponentDto>(0);

                 IEnumerable<Component> entities = this.EntityRepository.GetAllExceptThis(componentId);

                // Mapeamos los datos.
                entities.ToList()
                        .ForEach(entity =>
                        {
                            var entityDto = this.EntityMapper.EntityMapping(entity);
                            result.Add(entityDto);
                        });

                // Confirmamos la transacción.
                this.Commit();

                // Devolver el resultado.
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// self relationsships not many 2 many
        /// </summary>
        /// <param name="componentId"></param>
        /// <returns></returns>
        public IEnumerable<ComponentDto> GetAllExceptIdAndChildren(Int32 componentId)
        {
            try
            {
                List<ComponentDto> result = new List<ComponentDto>(0);

                 IEnumerable<Component> entities = this.EntityRepository.GetAllExceptIdAndChildren(componentId);

                // Mapeamos los datos.
                entities.ToList()
                        .ForEach(entity =>
                        {
                            var entityDto = this.EntityMapper.EntityMapping(entity);
                            result.Add(entityDto);
                        });

                // Confirmamos la transacción.
                this.Commit();

                // Devolver el resultado.
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="componentIds"></param>
        /// <returns></returns>
        public override IEnumerable<ComponentDto> GetSelectedThese(IEnumerable<Int32> componentIds)
        {
            try
            {
                List<ComponentDto> result = new List<ComponentDto>(0);

                IEnumerable<Component> entities = this.EntityRepository.GetSelectedThese(componentIds);

                // Mapeamos los datos.
                entities.ToList()
                        .ForEach(entity =>
                        {
                            var entityDto = this.EntityMapper.EntityMapping(entity);
                            result.Add(entityDto);
                        });

                // Confirmamos la transacción.
                this.Commit();

                // Devolver el resultado.
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="componentIds"></param>
        /// <returns></returns>
        public override IEnumerable<ComponentDto> GetAllExceptThese(IEnumerable<Int32> componentIds )
        {
            IEnumerable<Component> entities;
            try
            {
                entities = this.EntityRepository.GetAllExceptThese(componentIds);
                this.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Mapeamos los datos. 
            foreach (var entity in entities)
            {
                yield return this.EntityMapper.EntityMapping(entity);
            }
        }
        #endregion


        #region service GetById
        /// <summary>
        /// .es Recupera una entidad Component mediante su identificador correspondiente.
        /// </summary>
        /// <param name="id">
        /// .es Identificador de la entidad que se va a recuperar.
        /// </param>
        /// <returns>
        /// La entidad Component recuperada o valor nulo si no se encuentra.
        /// </returns>
        public override ComponentDto GetById(Int32 id)
        {
            // Variable de respuesta.
            ComponentDto entityDto = null;

            try
            {               
                var entity = this.EntityRepository.GetAggregateById(id); //TODO: call async
                entityDto = this.EntityMapper.EntityMapping(entity, true, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Confirmamos la transacción.
                this.Commit();
            }

            // Devolvemos el resultado.
            return entityDto;
        }
        #endregion


        #region Service GetPaged
        // code generated from template "ServiceGetPaged.tt"

        /// <summary>
        /// Recupera una lista paginada de entidades Component, según la especificación indicada.
        /// </summary>
        /// <param name="specificationDto">
        /// Especificación que se va a aplicar.
        /// </param>
        /// <returns>
        /// La lista paginada de entidades 'Component', según la especificación indicada.
        /// </returns>
        public override PagedElements<ComponentDto> GetPaged(SpecificationDto specificationDto)
        {
            #region Preconditions
            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(
                                    specificationDto,
                                    string.Format(
                                                  FrameworkResource.EspecificationDataTransferObjectIsNull,
                                                  "Component")); 
            #endregion
            List<ComponentDto> result = new List<ComponentDto>(0);
            int totalElements = 0;

            try
            {
                // Obtenemos las entidades aplicando la especificación.
                ISpecification<Component> filter =
                    specificationDto.ToSpecification<Component>();

                PagedElements<Component> entities =
                    this.EntityRepository.GetPagedElements(
                                      specificationDto.PageIndex,
                                      specificationDto.PageSize,
                                      filter.IsSatisfiedBy(),
                                                        entity => entity.Id,
                                                        true);
                totalElements = entities.TotalElements;

                // Mapeamos los datos.
                entities.ToList()
                        .ForEach(entity =>
                            {
                                var entityDto = this.EntityMapper.EntityMapping(entity);
                                result.Add(entityDto);
                            });

                // Confirmamos la transacción.
                this.Commit();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Devolver el resultado.
            return new PagedElements<ComponentDto>(result, totalElements);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="specificationDto"></param>
        ///// <returns></returns>
        //public override IEnumerable<ComponentDto> GetFilteredEntities(SpecificationDto specificationDto)
        //{
        //    #region Preconditions
        //    // Comprobar el DTO de entrada.
        //    Guard.ArgumentIsNotNull(
        //                            specificationDto,
        //                            string.Format(
        //                                          FrameworkResource.EspecificationDataTransferObjectIsNull,
        //                                          "Component"));
        //    #endregion
        //
        //    List<ComponentDto> result = new List<ComponentDto>(0);
        //    try
        //    {
        //        // Obtenemos las entidades aplicando la especificación.
        //        ISpecification<Component> filter = specificationDto.ToSpecification<Component>();
        //        IEnumerable<Component> entities = this.EntityRepository.GetFilteredElements(filter.IsSatisfiedBy());
        //        this.Commit();
        //
        //        entities.ToList()
        //            .ForEach(entity =>
        //            {
        //                var entityDto = this.EntityMapper.EntityMapping(entity);
        //                result.Add(entityDto);
        //            });
        //
        //
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }          
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="specificationDto"></param>
        /// <returns></returns>
        public override IEnumerable<ComponentDto> GetFiltered(SpecificationDto specificationDto)
        {
            #region Preconditions
            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(
                                    specificationDto,
                                    string.Format(
                                                  FrameworkResource.EspecificationDataTransferObjectIsNull,
                                                  "Component"));
            #endregion

            List<ComponentDto> result = new List<ComponentDto>(0);
            try
            {
                // Obtenemos las entidades aplicando la especificación.
                ISpecification<Component> filter = specificationDto.ToSpecification<Component>();
                IEnumerable<Component> entities = EntityRepository.GetFilteredElements(filter.IsSatisfiedBy());

                // Mapeamos los datos.
                entities.ToList()
                        .ForEach(entity =>
                        {
                            var entityDto = this.EntityMapper.EntityMapping(entity);
                            result.Add(entityDto);
                        });

                // Confirmamos la transacción.
                this.Commit();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Devolver el resultado.
            return result;
        }

#endregion

        #region Private Duplicated data for precondition methods
        #endregion

        #region internal methods to help create service to map collections froms targets relationships

            /// <summary>
            /// Método encargado de obtener una <see cref="Component"/> a partir 
            /// de su identificador.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <param name="componentId">
            /// Parámetro que indica el identificador único de la entidad a obtener.
            /// </param>
            /// <returns>
            /// Devuelve la entidad <see cref="Component"/> según el identificador.
            /// </returns>
            internal Component GetComponentById(Int32 componentId)
            {
// TODO, completar este metodo y cambiar los parametros añadiendo la entidad sobre la que se aplica.
                //// Unidad de trabajo para el acceso a datos.
                //using (IAdapter unitOfWork = Manager.DefaultController.CreateTransactional())
                //{
                    //// Buscamos la entidad por el Id.
                    //ComponentRepository componentRepository = this.ChildrenRepositoryFactory.Create(unitOfWork);
                    //Component component = componentRepository.GetById(componentId);
                    //// Validamos que exista la entidad.
                    //Guard.ArgumentIsNotNull(
                                            //component,
                                            //string.Format(
                                                          //CoreResources.Neutral.NoHayDatosPorId,
                                                          //CommonResources.ComponentAlias));
//
                    //// Confirmamos la transacción.
                    //unitOfWork.CommitTransaction();
                    //// Devolvemos la respuesta.
                    //return component;
                //}
                return null;
            } // GetComponentById

        #endregion


        #region update
        // ServiceUpdateMethod.tt
        /// <summary>
        /// Actualiza una determinada entidad Component.
        /// </summary>
        /// <param name="componentDto">
        /// DTO que contiene la información de la entidad que se va a actualizar.
        /// </param>
        /// <returns>
        /// Es <b>true</b> si la actualización ha sido correcta; en caso contrario <b>false</b>.
        /// </returns>
        public override bool Update(ComponentDto componentDto)
        {
            #region preconditions
            // Comprobar el DTO de entrada. 
            Guard.ArgumentIsNotNull(
                                    componentDto,
                                    string.Format(
                                                  FrameworkResource.DataTransferObjectIsNull,
                                                  "Component"));
            // en una actualización no comprobamos los campos mandatory.
            #endregion            

            try
            {
                // Obtener y comprobar validez de la inserción a modificar.
                Component entity2Update = this.EntityRepository.GetFilteredElements(t => t.Id == componentDto.Id).Single();
                Guard.ArgumentIsNotNull(
                                        entity2Update,
                                        string.Format(
                                                        FrameworkResource.CanNotUpdateInexistenceEntity,
                                                        "Component"));
                // Comprobar duplicidades;

                    // Actualización de la entidad.
                    entity2Update.Name = componentDto.Name;
                    entity2Update.PartNumber = componentDto.PartNumber;
                    entity2Update.Description = componentDto.Description;
                    // .en Updating properties that comes from parent relationships
                    // .es Actualizamos las propiedades que provienen the relaciones parentales.
                    if (componentDto.Parent != null && !componentDto.Parent.IsTransient() /*&& entity2Update.Parent.Id != componentDto.Parent.Id*/)
                    {
                        IComponentRepository repocomponent = ApplicationLayer.IocContainer.Resolve<IComponentRepository>();//**
                        Component component = repocomponent.GetById(componentDto.Parent.Id);
                        entity2Update.SetParent(component);
                    }
                    else if(componentDto.Parent == null)
                    {
                        entity2Update.SetParent(null);
                    }

                // igualmente hemos de mapear las entidades emparentadas.

                if (!entity2Update.CanBeSaved())
                {
                    return false;
                }

                this.EntityRepository.Modify(entity2Update);
                this.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Devolvemos el resultado.
            return true;
        }
        #endregion

        #region Add Remove update properties from target relationships
        // Acontinuación escribimos los métodos de las propiedades que provienen de relaciones con otras entidades objetos valor o enumerados y son coleccion.

        /// <summary>
        /// Función encargada de la añadir a la entidad Component una instancia de la propiedad Children de tipo Component
        /// </summary>
        /// <param name="childrenDto"> de tipo Component</param>
        /// <returns>
        /// Devuelve <c>True</c> si se ha añadido correctamente.
        /// y <c>False</c> en caso contrario.
        /// </returns>
        public bool AddChildren(ComponentDto childrenDto)
        {
            // TODO: falta completar este metodo
            return false;
        }

        /// <summary>
        /// Función encargada de borrar de la entidad Component una instancia de la colección Children de tipo Component
        /// </summary>
        /// <param name="childrenDto"> de tipo Component</param>
        /// <returns>
        /// Devuelve <c>True</c> si se ha añadido correctamente.
        /// y <c>False</c> en caso contrario.
        /// </returns>
        public bool RemoveChildren(ComponentDto childrenDto)
        {
            // TODO: falta completar este metodo
            return false;
        }

        /// <summary>
        /// Función encargada de actualizar de la entidad Component una instancia de la colección Children de tipo Component
        /// </summary>
        /// <param name="childrenDto"> de tipo Component</param>
        /// <returns>
        /// Devuelve <c>True</c> si se ha añadido correctamente.
        /// y <c>False</c> en caso contrario.
        /// </returns>
        public bool UpdateChildren(ComponentDto childrenDto)
        {
            // TODO: falta completar este metodo
            return false;
        }


        #endregion

    } // class Component 

} //  Needel.Common.Application

