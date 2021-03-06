﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Department" company="Company">
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
    /// Administration services of the entity Department.
    /// .es geenrado con la plantilla ServiceHeaderClass.tt
    /// Representa los servicios de administración de la entidad Department.
    /// </summary>
    /// <remarks>
    /// .en Create an object of type <see cref="Department"/>.
    /// .es Crea un objeto <see cref="Department"/>.
    ///  permanent guid = 
    /// </remarks>
    public partial class DepartmentServices : Inflexion2.Application.EfApplicationServicesBase<DepartmentDto, Department, Int32>, IDepartmentServices
    {

        #region Fields
        // Mappers of related entitites
        /// <summary>
        /// .en Reference to the mapper of entity user.
        /// .es Referencia a la factoría de repositorios de la entidad user.
        /// </summary>
        private readonly IUserMapper userMapper;
        #endregion

        #region Constructors
        /// <summary>
        /// .es Inicializa una nueva instancia de la clase <see cref="T:Department>Service"/>.
        /// </summary>
        /// <remarks>
        /// .es Constructor de la clase <see cref="T:DepartmentServices"/>.
        /// </remarks>
        public DepartmentServices() : base()
        {
            this.EntityMapper = new DepartmentMapper();
            this.userMapper = new UserMapper();
            this.EntityRepository = ApplicationLayer.IocContainer.Resolve<IDepartmentRepository>();
        }
        #endregion

        #region Create Method
        // from template Application\UpdateBase\I2ServiceRegionCreateMethod.tt

        /// <summary>
        /// Crea una entidad Department.
        /// </summary>
        /// <param name="departmentDto">
        /// DTO que contiene la información para crear la entidad.
        /// </param>
        /// <returns>
        /// El identificador de la entidad creada.
        /// </returns>
        public override Int32 Create(DepartmentDto departmentDto)
        {

            #region Preconditions

            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(
                                    departmentDto,
                                    string.Format(
                                                    FrameworkResource.DataTransferObjectIsNull,
                                                    CommonResources.DepartmentAlias));
            // Comprobar los campos mandatory dentro del DTO.
            Guard.ArgumentNotNullOrEmpty(
                                        departmentDto.Name,
                                        string.Format(
                                                        FrameworkResource.PropertyRequired,
                                                        CommonResources.Department_NameAlias, 
                                                        CommonResources.DepartmentAlias)
                                        );

            #endregion

            // .en the dto has to be transient, so the Id has to have a default value.
            // .es el dto debe corresponder a un transient por lo que el id debe tener el valor por defecto
            Guard.Against<ArgumentException>(departmentDto.Id != default(Int32),                                    
                                                    string.Format(
                                                                FrameworkResource.IsNotTransient,
                                                                CommonResources.DepartmentAlias
                                                                    )
                                            );

            var userDepartment = new System.Collections.Generic.List<User>();


            Department department = DepartmentFactory.Create
            (
                departmentDto.Name, departmentDto.Visible, departmentDto.CreationTime
            );//**
            department.Description = departmentDto.Description; // property.AutoProperty = True; property.OnlyGetProperty = False
            department.UpdateTime = departmentDto.UpdateTime; // property.AutoProperty = True; property.OnlyGetProperty = False
            this.EntityRepository.Add(department);
            this.Commit();

            return department.Id;
        }
        #endregion

        #region Service Delete

        /// <summary>
        /// .es Elimina una determinada entidad Department.
        /// </summary>
        /// <param name="id">
        /// Identificador de la entidad que se va a eliminar.
        /// </param>
        /// <returns>
        /// Es <b>true</b> si la eliminación ha sido correcta; en caso contrario <b>false</b>.
        /// </returns>
        public override bool Delete(Int32 id)
        {
             IEnumerable<Department> results = this.EntityRepository.GetFilteredElements(u => u.Id == id);
            Department department2Delete = results.First();
            if (!department2Delete.CanBeDeleted())
            {
                return false;
            }


            try
            {
                this.EntityRepository.Remove(department2Delete);
                this.Commit();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        /// <summary>
        /// .es Elimina las entidades Department seleccionadas por los ids del parametro.
        /// </summary>
        /// <param name="departmentIds"></param>
        /// <returns></returns>
        public override IEnumerable<Int32> Delete(IEnumerable<Int32> departmentIds)
        {
            foreach (var id in departmentIds)
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
        /// .es Recupera todas las entidades Department.
        /// </summary>
        /// <returns>
        /// Todas las entidades Department.
        /// </returns>
        public override IEnumerable<DepartmentDto> GetAll()
        {
            // .en answer variable
            // .es Variable de respuesta.
            // list new cosntructor (int32) initial size http://msdn.microsoft.com/en-us/library/dw8e0z9z(v=vs.110).aspx
            var result = new List<DepartmentDto>(0);

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
        /// .es Recupera todas las instancias de Department excepto la indicada por el parametro. 
        /// </summary>
        /// <param name="departmentId">.es Entidad a evitar.</param>
        /// <returns></returns>
        public override IEnumerable<DepartmentDto> GetAllExceptThis(Int32 departmentId)
        {
            try
            {
                List<DepartmentDto> result = new List<DepartmentDto>(0);

                 IEnumerable<Department> entities = this.EntityRepository.GetAllExceptThis(departmentId);

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
        /// <param name="departmentIds"></param>
        /// <returns></returns>
        public override IEnumerable<DepartmentDto> GetSelectedThese(IEnumerable<Int32> departmentIds)
        {
            try
            {
                List<DepartmentDto> result = new List<DepartmentDto>(0);

                IEnumerable<Department> entities = this.EntityRepository.GetSelectedThese(departmentIds);

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
        /// <param name="departmentIds"></param>
        /// <returns></returns>
        public override IEnumerable<DepartmentDto> GetAllExceptThese(IEnumerable<Int32> departmentIds )
        {
            IEnumerable<Department> entities;
            try
            {
                entities = this.EntityRepository.GetAllExceptThese(departmentIds);
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
        /// .es Recupera una entidad Department mediante su identificador correspondiente.
        /// </summary>
        /// <param name="id">
        /// .es Identificador de la entidad que se va a recuperar.
        /// </param>
        /// <returns>
        /// La entidad Department recuperada o valor nulo si no se encuentra.
        /// </returns>
        public override DepartmentDto GetById(Int32 id)
        {
            // Variable de respuesta.
            DepartmentDto entityDto = null;

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
        /// Recupera una lista paginada de entidades Department, según la especificación indicada.
        /// </summary>
        /// <param name="specificationDto">
        /// Especificación que se va a aplicar.
        /// </param>
        /// <returns>
        /// La lista paginada de entidades 'Department', según la especificación indicada.
        /// </returns>
        public override PagedElements<DepartmentDto> GetPaged(SpecificationDto specificationDto)
        {
            #region Preconditions
            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(
                                    specificationDto,
                                    string.Format(
                                                  FrameworkResource.EspecificationDataTransferObjectIsNull,
                                                  "Department")); 
            #endregion
            List<DepartmentDto> result = new List<DepartmentDto>(0);
            int totalElements = 0;

            try
            {
                // Obtenemos las entidades aplicando la especificación.
                ISpecification<Department> filter =
                    specificationDto.ToSpecification<Department>();

                PagedElements<Department> entities =
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
            return new PagedElements<DepartmentDto>(result, totalElements);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="specificationDto"></param>
        ///// <returns></returns>
        //public override IEnumerable<DepartmentDto> GetFilteredEntities(SpecificationDto specificationDto)
        //{
        //    #region Preconditions
        //    // Comprobar el DTO de entrada.
        //    Guard.ArgumentIsNotNull(
        //                            specificationDto,
        //                            string.Format(
        //                                          FrameworkResource.EspecificationDataTransferObjectIsNull,
        //                                          "Department"));
        //    #endregion
        //
        //    List<DepartmentDto> result = new List<DepartmentDto>(0);
        //    try
        //    {
        //        // Obtenemos las entidades aplicando la especificación.
        //        ISpecification<Department> filter = specificationDto.ToSpecification<Department>();
        //        IEnumerable<Department> entities = this.EntityRepository.GetFilteredElements(filter.IsSatisfiedBy());
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
        public override IEnumerable<DepartmentDto> GetFiltered(SpecificationDto specificationDto)
        {
            #region Preconditions
            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(
                                    specificationDto,
                                    string.Format(
                                                  FrameworkResource.EspecificationDataTransferObjectIsNull,
                                                  "Department"));
            #endregion

            List<DepartmentDto> result = new List<DepartmentDto>(0);
            try
            {
                // Obtenemos las entidades aplicando la especificación.
                ISpecification<Department> filter = specificationDto.ToSpecification<Department>();
                IEnumerable<Department> entities = EntityRepository.GetFilteredElements(filter.IsSatisfiedBy());

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
            /// Método encargado de obtener una <see cref="User"/> a partir 
            /// de su identificador.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <param name="userId">
            /// Parámetro que indica el identificador único de la entidad a obtener.
            /// </param>
            /// <returns>
            /// Devuelve la entidad <see cref="User"/> según el identificador.
            /// </returns>
            internal User GetUserById(Int32 userId)
            {
// TODO, completar este metodo y cambiar los parametros añadiendo la entidad sobre la que se aplica.
                //// Unidad de trabajo para el acceso a datos.
                //using (IAdapter unitOfWork = Manager.DefaultController.CreateTransactional())
                //{
                    //// Buscamos la entidad por el Id.
                    //UserRepository userRepository = this.UsersRepositoryFactory.Create(unitOfWork);
                    //User user = userRepository.GetById(userId);
                    //// Validamos que exista la entidad.
                    //Guard.ArgumentIsNotNull(
                                            //user,
                                            //string.Format(
                                                          //CoreResources.Neutral.NoHayDatosPorId,
                                                          //CommonResources.UserAlias));
//
                    //// Confirmamos la transacción.
                    //unitOfWork.CommitTransaction();
                    //// Devolvemos la respuesta.
                    //return user;
                //}
                return null;
            } // GetUserById

        #endregion


        #region update
        // ServiceUpdateMethod.tt
        /// <summary>
        /// Actualiza una determinada entidad Department.
        /// </summary>
        /// <param name="departmentDto">
        /// DTO que contiene la información de la entidad que se va a actualizar.
        /// </param>
        /// <returns>
        /// Es <b>true</b> si la actualización ha sido correcta; en caso contrario <b>false</b>.
        /// </returns>
        public override bool Update(DepartmentDto departmentDto)
        {
            #region preconditions
            // Comprobar el DTO de entrada. 
            Guard.ArgumentIsNotNull(
                                    departmentDto,
                                    string.Format(
                                                  FrameworkResource.DataTransferObjectIsNull,
                                                  "Department"));
            // en una actualización no comprobamos los campos mandatory.
            #endregion            

            try
            {
                // Obtener y comprobar validez de la inserción a modificar.
                Department entity2Update = this.EntityRepository.GetFilteredElements(t => t.Id == departmentDto.Id).Single();
                Guard.ArgumentIsNotNull(
                                        entity2Update,
                                        string.Format(
                                                        FrameworkResource.CanNotUpdateInexistenceEntity,
                                                        "Department"));
                // Comprobar duplicidades;

                    // Actualización de la entidad.
                    entity2Update.Name = departmentDto.Name;
                    entity2Update.Visible = departmentDto.Visible;
                    entity2Update.Description = departmentDto.Description;
                    entity2Update.CreationTime = departmentDto.CreationTime;
                    entity2Update.UpdateTime = departmentDto.UpdateTime;

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
        /// Función encargada de la añadir a la entidad Department una instancia de la propiedad Users de tipo Department
        /// </summary>
        /// <param name="usersDto"> de tipo User</param>
        /// <returns>
        /// Devuelve <c>True</c> si se ha añadido correctamente.
        /// y <c>False</c> en caso contrario.
        /// </returns>
        public bool AddUsers(UserDto usersDto)
        {
            // TODO: falta completar este metodo
            return false;
        }

        /// <summary>
        /// Función encargada de borrar de la entidad Department una instancia de la colección Users de tipo Department
        /// </summary>
        /// <param name="usersDto"> de tipo Department</param>
        /// <returns>
        /// Devuelve <c>True</c> si se ha añadido correctamente.
        /// y <c>False</c> en caso contrario.
        /// </returns>
        public bool RemoveUsers(UserDto usersDto)
        {
            // TODO: falta completar este metodo
            return false;
        }

        /// <summary>
        /// Función encargada de actualizar de la entidad Department una instancia de la colección Users de tipo Department
        /// </summary>
        /// <param name="usersDto"> de tipo Department</param>
        /// <returns>
        /// Devuelve <c>True</c> si se ha añadido correctamente.
        /// y <c>False</c> en caso contrario.
        /// </returns>
        public bool UpdateUsers(UserDto usersDto)
        {
            // TODO: falta completar este metodo
            return false;
        }


        #endregion

    } // class Department 

} //  Needel.Common.Application

