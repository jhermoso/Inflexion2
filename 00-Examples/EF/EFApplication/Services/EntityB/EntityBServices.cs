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
using EFApplication.Mappers;
using EFApplication.Dtos;

using EFInfrastructure;
using CommonDomain;
using Inflexion2.Data;

namespace EFApplication.Services
{
    public partial class EntityBServices : 
        EFApplication.Services.BoundedContestEfApplicationServiceBase, IEntityBServices
    {

        #region Fields

        /// <summary>
        /// Referencia al adaptador para el logging.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Referencia al mapeador de la entidad EntityB.
        /// </summary>
        private readonly IEntityBMapper entityBMapper;

        /// <summary>
        /// Referencia a la factoría de repositorios de la entidad Categoria.
        /// </summary>
        //private readonly ICategoriaRepositoryFactory categoriaRepositoryFactory;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor estático de la clase <see cref="T:Categoria>Service"/>.
        /// </summary>
        static EntityBServices()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:Categoria>Service"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:CategoriaServices"/>.
        /// </remarks>
        public EntityBServices(): 
            base()
        {
            this.unityContainer.RegisterType<DbContext, BootstrapUnitOfWork>(this.contextPerTestLifeTimeManager, new InjectionConstructor(this.connString));

            // registramos el repositorio de la entidad
            this.unityContainer.RegisterType<IEntityBRepository, EntityBRepository>(new PerResolveLifetimeManager());

            //logger = LoggerManager.GetLogger(GetType());
            //this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Created repository for type: {0}", typeof(EntityB).Name));
            this.entityBMapper = new EntityBMapper();
        }

        #endregion

        #region Private Properties
        /// <summary>
        /// Obtiene la referencia al mapeador de la entidad <see cref="T:IEntityB"/>.
        /// </summary>
        private IEntityBMapper EntityBMapper
        {
            get { return this.entityBMapper; }
        }

        #endregion

        #region methods crud
        //Int32 Create(EntityADto entityADto, UserContextDto userContextDto);// invocacion con identificación de usuario
        public int Create(EntityBDto entityBDto)
        {
            #region Preconditions

            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(
                                    entityBDto,
                                    string.Format(
                                                  Inflexion2.Resources.Framework.DataTransferObjectIsNull,
                                                  "Entity B")); //// usar un fichero de recursos para el dominio de negocio Company.Product.BoundedContext.Resources.Business.EntityBAlias

            // Comprobar los campos mandatory dentro del DTO.
            Guard.ArgumentNotNullOrEmpty(
                                            entityBDto.Name,
                                            string.Format(
                                                        Inflexion2.Resources.Framework.PropertyRequired,
                                                        "Name", "Entity B")); //// usar un fichero de recursos para el dominio de negocio Company.Product.BoundedContext.Resources.Business.EntityBNameAlias
            // el dto debe corresponder a un transient el id debe tener el valor por defecto
            //if (entityBDto.Id != default(int))
                Guard.Against<ArgumentException>(entityBDto.Id != default(int),
                                    
                                    string.Format(
                                                Inflexion2.Resources.Framework.IsNotTransient,
                                                "Entity B")); //// usar un fichero de recursos para el dominio de negocio Company.Product.BoundedContext.Resources.Business.EntityBNameAlias

            #endregion

            EntityB entityB = EntityBFactory.Create(entityBDto.Name);
            IEntityBRepository repo = this.unityContainer.Resolve<IEntityBRepository>();
            repo.Add(entityB);
            this.Commit();

            return entityB.Id;
        }

         //bool Delete(Int32 Entity1Id, UserContextDto userContextDto);// invocacion con identificación de usuario 
        public bool Delete(Int32 EntityBId)
        {

            #region Preconditions

            // Comprobar el DTO de entrada.
            if (EntityBId == default(int))
            {
                return false;
            }
            #endregion

            IEntityBRepository repo = this.unityContainer.Resolve<IEntityBRepository>();
            IEnumerable<EntityB> results = repo.GetFilteredElements(u => u.Id == EntityBId);
            EntityB entityB2Delete = results.First();

            if (!entityB2Delete.CanBeDeleted())
            {
                return false;
            }
            repo.Remove(entityB2Delete);
            this.Commit();

            return true;
        }

        //IEnumerable<EntityADto> GetAll(UserContextDto userContextDto);// invocación con identificación de usuario
        public IEnumerable<EntityBDto> GetAll()
        {
              // Variable de respuesta.
            List<EntityBDto> result = new List<EntityBDto>();
            try
            {
                IEntityBRepository repo = this.unityContainer.Resolve<IEntityBRepository>();
                var entities = repo.GetAll();
                // Mapeamos los datos.
                entities.ToList()
                        .ForEach(entity =>
                        {
                            var entityDto = this.EntityBMapper.EntityMapping(entity);
                            result.Add(entityDto);
                        });

                // Confirmamos la transacción.
                this.Commit();
            }
            catch (Exception ex)
            {
                // Escribir en el Log.
                //logger.Error(ex.Message, ex);
                throw ex;
            }
           
            return result;
        }

        //PagedElements<Entity1Dto> GetPaged(SpecificationDto specificationDto, UserContextDto userContextDto);
        public PagedElements<EntityBDto> GetPaged(SpecificationDto specificationDto)
        {
            #region Preconditions

            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(
                                    specificationDto,
                                    string.Format(
                                                  Inflexion2.Resources.Framework.EspecificationDataTransferObjectIsNull,
                                                  "Entity B")); //// usar un fichero de recursos para el dominio de negocio Company.Product.BoundedContext.Resources.Business.EntityBAlias
            #endregion
            List<EntityBDto> result = new List<EntityBDto>(0);
            int totalElements = 0;

            try
            {
                // Creamos el repositorio de la entidad.
                IEntityBRepository repo = this.unityContainer.Resolve<IEntityBRepository>();

                // Obtenemos las entidades aplicando la especificación.
                ISpecification<EntityB> filter = specificationDto.ToSpecification<EntityB>();

                PagedElements<EntityB> entities = 
                    repo.GetPagedElements(                                      
                                      specificationDto.PageIndex,
                                      specificationDto.PageSize,
                                      filter.IsSatisfiedBy(),
                                      entity => entity.Id,
                                      true);
                totalElements = entities.TotalElements;
                // Mapeamos los datos.
                entities.ToList().ForEach(entity =>
                                  {
                                      var entityDto = this.EntityBMapper.EntityMapping(entity);
                                      result.Add(entityDto);
                                  });

                // Confirmamos la transacción.
                this.Commit();

            }
            catch (Exception ex)
            {
                // Escribir en el Log.
                //logger.Error(ex.Message, ex);
                throw ex;
            }

            // Devolver el resultado.
            return new PagedElements<EntityBDto>(result, totalElements);
        }

        //EntityADto GetById(Int32 entityAId, UserContextDto userContextDto);
        public EntityBDto GetById(Int32 entityBId)
        {
            // Variable de respuesta.
            EntityBDto entityDto = null;

            try
            {
                
                IEntityBRepository repo = this.unityContainer.Resolve<IEntityBRepository>();

                    // Obtener y comprobar la entidad.
                //ISpecification<EntityB> spec = new DirectSpecification<EntityB>(t => t.Id == entityBId);
                EntityB entity = repo.GetFilteredElements(t => t.Id == entityBId).Single();
                string s = string.Format(Inflexion2.Resources.Framework.NoDataById, "Entity B", entityBId);
                if (s == null) 
                    s = "";
                Guard.ArgumentIsNotNull( entity, s );

                    // Mapeamos los datos.
                    entityDto = this.EntityBMapper.EntityMapping(entity);

                    // Confirmamos la transacción.
                    this.Commit();
                
            }
            catch (Exception ex)
            {
                // Escribimos en el Log.
                logger.Error(ex.Message, ex);
                throw ex;
            }

            // Devolvemos el resultado.
            return entityDto;
        }

        //bool Update(EntityADto entity1Dto, UserContextDto userContextDto);
        public bool Update(EntityBDto entityBDto)
        {
            #region preconditions
            // Comprobar el DTO de entrada. 
            Guard.ArgumentIsNotNull(
                                    entityBDto,
                                    string.Format(
                                                  Inflexion2.Resources.Framework.DataTransferObjectIsNull,
                                                  "Entity B"));
            // comprobamos los campos mandatory ¿EN UNA ACTUALIZACIÓN TAMBIEN?
            Guard.ArgumentNotNullOrEmpty(
                                            entityBDto.Name,
                                            string.Format(
                                                        Inflexion2.Resources.Framework.PropertyRequired,
                                                        "Entity B"));
            #endregion

            try
            {
                IEntityBRepository repo = this.unityContainer.Resolve<IEntityBRepository>();

                // Obtener y comprobar la entidad.
                //ISpecification<EntityB> spec = new DirectSpecification<EntityB>(t => t.Id == entityBDto.Id);
                EntityB entity2Update = repo.GetFilteredElements(t => t.Id == entityBDto.Id).Single();
                Guard.ArgumentIsNotNull(
                                        entity2Update,
                                        string.Format(
                                                        Inflexion2.Resources.Framework.CanNotUpdateInexistenceEntity,
                                                        "Entity B"));
                // Mapeamos los datos, teniendo encuenta que el id lo hemos recuperado y comprobado 
                // ademas comprobamos que valores han sido modificados
                if (entity2Update.Name != entityBDto.Name) 
                {
                   entity2Update.Name = entityBDto.Name;
                   // opcion a trazar las modificaciones
                }   
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
                // Escribimos en el Log.
                //logger.Error(ex.Message, ex);
                throw ex;
            }

            // Devolvemos el resultado.
            return true;
        }

        #endregion

        #region methods entity
        #endregion

        //protected virtual string ConnectionString()
        //{
        //    return ConfigurationManager.ConnectionStrings["Sql.Connection"].ConnectionString;
        //}

        //public void Commit()
        //{
        //    IUnitOfWork unitOfWork = this.unityContainer.Resolve<IUnitOfWork>();
        //    unitOfWork.Commit();
        //}
    }
}
