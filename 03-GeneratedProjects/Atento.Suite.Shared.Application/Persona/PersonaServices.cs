﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Persona" company="Atento">
//     Copyright (c) 2016. Atento. All Rights Reserved.
//     Copyright (c) 2016. Atento. Todos los derechos reservados.
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

namespace Atento.Suite.Shared.Application
{


    #region usings 

    using System;
    using System.Collections.Generic;
    using System.Linq;
    //using System.Linq.Expressions;
    using System.Text;
    using System.Globalization;
    using System.Reflection;
    using System.Data.Entity;
    using System.Configuration;

    using Microsoft.Practices.Unity;

    using Inflexion2.Domain;
    using Inflexion2.Application;
    using Inflexion2.Application.DataTransfer.Core;
    using Inflexion2;
    using Inflexion2.Domain.Specification;
    using Inflexion2.Logging;
    using Inflexion2.Data;
    using Inflexion2.Resources;

    using Atento.Suite.Shared.Application.Dtos;
    using Atento.Suite.Shared.Application;    
    using Atento.Suite.Shared.Domain;
    using Atento.Suite.Shared.Infrastructure;
    using Atento.Suite.Shared.Infrastructure.Resources;
// Shared

    using System.ComponentModel.DataAnnotations;
    using System.Collections.ObjectModel;
    #endregion

    /// <summary>
    /// Representa los servicios de administración de la entidad Persona.
    /// </summary>
    /// <remarks>
    /// Crea un objeto <see cref="Persona".
    /// </remarks>
    public partial class PersonaServices : Atento.Suite.Shared.Application.EfApplicationServiceBase, IPersonaServices
    {

        #region Fields
        /// <summary>
        /// Referencia al mapeador de la entidad Persona.
        /// </summary>
        private readonly IPersonaMapper personaMapper;

        // <summary>
        // Referencia a la factoría de repositorios de la entidad Persona.
        // </summary>
        //private readonly PersonaRepositoryFactory personaRepositoryFactory;

        #endregion

        #region Constructors
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:Persona>Service"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:PersonaServices"/>.
        /// </remarks>
        public PersonaServices() : base()
        {
    
            this.unityContainer.RegisterType<DbContext, BootstrapUnitOfWork>(this.contextPerTestLifeTimeManager, new InjectionConstructor(this.connString));

            // registramos el repositorio de la entidad
            this.unityContainer.RegisterType<IPersonaRepository, PersonaRepository>(new PerResolveLifetimeManager());
  
            this.personaMapper = new PersonaMapper();
        }

        #endregion


        #region Private Properties
        /// <summary>
        /// Obtiene la referencia al mapeador de la entidad <see cref="T:IPersona"/>.
        /// </summary>
        private IPersonaMapper PersonaMapper
        {
            get { return this.personaMapper; }
        }

        // <summary>
        // Obtiene la referencia a la factoría de repositorios de la entidad <see cref="T:Persona"/>.
        // </summary>
        //private PersonaRepositoryFactory PersonaRepositoryFactory
        //{
            //get { return this.personaRepositoryFactory; }
        //}

        #endregion

        #region Create Method
        // from template Application\UpdateBase\I2ServiceRegionCreateMethod.tt

        /// <summary>
        /// Crea una entidad Persona.
        /// </summary>
        /// <param name="personaDto">
        /// DTO que contiene la información para crear la entidad.
        /// </param>
        /// <returns>
        /// El identificador de la entidad creada.
        /// </returns>
        public int Create(PersonaDto personaDto)
        {

            #region Preconditions

            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(
                                    personaDto,
                                    string.Format(
                                                    Inflexion2.Resources.Framework.DataTransferObjectIsNull,
                                                    SharedNeutral.PersonaAlias));
            // Comprobar los campos mandatory dentro del DTO.
            Guard.ArgumentNotNullOrEmpty(
                                        personaDto.Nombre,
                                        string.Format(
                                                        Inflexion2.Resources.Framework.PropertyRequired,
                                                        SharedNeutral.Persona_NombreAlias, 
                                                        SharedNeutral.PersonaAlias)
                                        );

            #endregion

            // el dto debe corresponder a un transient el id debe tener el valor por defecto
            Guard.Against<ArgumentException>(personaDto.Id != default(Int32),                                    
                                                    string.Format(
                                                                Inflexion2.Resources.Framework.IsNotTransient,
                                                                SharedNeutral.PersonaAlias
                                                                    )
                                            );

            Persona persona = PersonaFactory.Create(personaDto.Nombre); 
               persona.BooleanField = personaDto.BooleanField;
               persona.DatetimeField = personaDto.DatetimeField;
               persona.ByteField = personaDto.ByteField;
               persona.GuidField = personaDto.GuidField;
               persona.DecimalField = personaDto.DecimalField;
               persona.DobleField = personaDto.DobleField;
               persona.FloatField = personaDto.FloatField;
               persona.IntField = personaDto.IntField;
               persona.LongField = personaDto.LongField;
               persona.DateTimeOffsetField = personaDto.DateTimeOffsetField;
               persona.ShortField = personaDto.ShortField;
               persona.TimeSpanField = personaDto.TimeSpanField;
               persona.Int16Field = personaDto.Int16Field;
               persona.Int32Field = personaDto.Int32Field;
               persona.Int64Field = personaDto.Int64Field;
            IPersonaRepository repo = this.unityContainer.Resolve<IPersonaRepository>();
            repo.Add(persona);
            this.Commit();

            return persona.Id; 
        }
        #endregion

        #region Service Delete
        /// <summary>
        /// Elimina una determinada entidad Persona.
        /// </summary>
        /// <param name="id">
        /// Identificador de la entidad que se va a eliminar.
        /// </param>
        /// <returns>
        /// Es <b>true</b> si la eliminación ha sido correcta; en caso contrario <b>false</b>.
        /// </returns>
        public bool Delete(int id)
        {
            IPersonaRepository repo = this.unityContainer.Resolve<IPersonaRepository>();
            IEnumerable<Persona> results = repo.GetFilteredElements(u => u.Id == id);
            Persona persona2Delete = results.First();

            if (!persona2Delete.CanBeDeleted())
            {
                return false;
            }
            repo.Remove(persona2Delete);
            this.Commit();

            return true;
        }
        #endregion


        #region GetAll Method
        /// <summary>
        /// Recupera todas las entidades Persona.
        /// </summary>
        /// <returns>
        /// Todas las entidades Persona.
        /// </returns>
        public IEnumerable<PersonaDto> GetAll()
        {
            // .en answer variable
            // .es Variable de respuesta.
            // list new cosntructor (int32) initial size http://msdn.microsoft.com/en-us/library/dw8e0z9z(v=vs.110).aspx
            var result = new List<PersonaDto>(0);

            try
            {
                IPersonaRepository repo = this.unityContainer.Resolve<IPersonaRepository>();
                var entities = repo.GetAll();
                // Mapeamos los datos.
                entities.ToList()
                        .ForEach(entity =>
                        {
                            var entityDto = this.PersonaMapper.EntityMapping(entity);
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
        #endregion


        #region service GetById
        /// <summary>
        /// Recupera una entidad Persona mediante su identificador correspondiente.
        /// </summary>
        /// <param name="id">
        /// Identificador de la entidad que se va a recuperar.
        /// </param>
        /// <returns>
        /// La entidad Persona recuperada o valor nulo si no se encuentra.
        /// </returns>
        public PersonaDto GetById(Int32 entityBId)
        {
            // Variable de respuesta.
            PersonaDto entityDto = null;

            try
            {               
                IPersonaRepository repo = this.unityContainer.Resolve<IPersonaRepository>();

                // Obtener y comprobar la entidad.
                //ISpecification<Persona> spec = new DirectSpecification<Persona>(t => t.Id == entityBId);
                var temp = repo.GetFilteredElements(t => t.Id == entityBId);
                //string s = string.Format(Inflexion2.Resources.Framework.NoDataById, "Persona", entityBId);

                //Guard.ArgumentIsNotNull( entity, s );

                if (temp.Count() > 0)
                {
                    Persona entity = temp.Single();
                    // Mapeamos los datos.
                    entityDto = this.PersonaMapper.EntityMapping(entity);
                }
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
        /// Recupera una lista paginada de entidades Persona, según la especificación indicada.
        /// </summary>
        /// <param name="specificationDto">
        /// Especificación que se va a aplicar.
        /// </param>
        /// <returns>
        /// La lista paginada de entidades 'Persona', según la especificación indicada.
        /// </returns>
        public PagedElements<PersonaDto> GetPaged(SpecificationDto specificationDto)
        {
            #region Preconditions
            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(
                                    specificationDto,
                                    string.Format(
                                                  Inflexion2.Resources.Framework.EspecificationDataTransferObjectIsNull,
                                                  "Persona")); 
            #endregion
            List<PersonaDto> result = new List<PersonaDto>(0);
            int totalElements = 0;

            try
            {
                // Creamos el repositorio de la entidad.
                IPersonaRepository repo = this.unityContainer.Resolve<IPersonaRepository>();

                // Obtenemos las entidades aplicando la especificación.
                ISpecification<Persona> filter =
                    specificationDto.ToSpecification<Persona>();

                PagedElements<Persona> entities =
                    repo.GetPagedElements(
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
                                var entityDto = this.personaMapper.EntityMapping(entity);
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
            return new PagedElements<PersonaDto>(result, totalElements);
        }
#endregion

        #region Private Duplicated data for precondition methods
        #endregion



        #region update
        // ServiceUpdateMethod.tt
        /// <summary>
        /// Actualiza una determinada entidad Persona.
        /// </summary>
        /// <param name="personaDto">
        /// DTO que contiene la información de la entidad que se va a actualizar.
        /// </param>
        /// <returns>
        /// Es <b>true</b> si la actualización ha sido correcta; en caso contrario <b>false</b>.
        /// </returns>
        public bool Update(PersonaDto personaDto)
        {
            #region preconditions
            // Comprobar el DTO de entrada. 
            Guard.ArgumentIsNotNull(
                                    personaDto,
                                    string.Format(
                                                  Inflexion2.Resources.Framework.DataTransferObjectIsNull,
                                                  "Persona"));
            // en una actualización no comprobamos los campos mandatory.
            #endregion            

            try
            {
                // Creamos el repositorio de la entidad.
                IPersonaRepository repo = this.unityContainer.Resolve<IPersonaRepository>();

                // Obtener y comprobar validez de la inserción a modificar.
               Persona entity2Update = repo.GetFilteredElements(t => t.Id == personaDto.Id).Single();
                Guard.ArgumentIsNotNull(
                                        entity2Update,
                                        string.Format(
                                                        Inflexion2.Resources.Framework.CanNotUpdateInexistenceEntity,
                                                        "Persona"));
                // Comprobar duplicidades;

                    // Actualización de la entidad.
                    // Datos mandatory
                    entity2Update.Nombre = personaDto.Nombre;

                    // asignación de Datos no mandatory con ciclo de vida variable, no se incluyen aquellas propiedaes constantes o derivadas
                    entity2Update.BooleanField = personaDto.BooleanField; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.DatetimeField = personaDto.DatetimeField; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.ByteField = personaDto.ByteField; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.GuidField = personaDto.GuidField; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.DecimalField = personaDto.DecimalField; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.DobleField = personaDto.DobleField; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.FloatField = personaDto.FloatField; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.IntField = personaDto.IntField; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.LongField = personaDto.LongField; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.DateTimeOffsetField = personaDto.DateTimeOffsetField; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.ShortField = personaDto.ShortField; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.TimeSpanField = personaDto.TimeSpanField; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.Int16Field = personaDto.Int16Field; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.Int32Field = personaDto.Int32Field; // property.AutoProperty = True; property.OnlyGetProperty = False
                    entity2Update.Int64Field = personaDto.Int64Field; // property.AutoProperty = True; property.OnlyGetProperty = False

                // igualmente hemos de mapear las entidades emparentadas.
                if (!entity2Update.CanBeSaved())
                {
                    return false;
                }
                repo.Modify(entity2Update);

                // Confirmamos la transacción.
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


        #endregion


    } // class Persona 

} //  Atento.Suite.Shared.Application

