

namespace Inflexion2.Application
{
    #region usings
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;

    using Microsoft.Practices.Unity;
    using Inflexion2;
    using Inflexion2.Domain;
    using Inflexion2.Data;
    using Resources;
    using Domain.Specification;
    #endregion

    /// <summary>
    /// .es Clase base para los servicios de aplicación de un bounded context con entityFramework 
    /// </summary>
    public class EfApplicationServicesBase<TDto, TEntity, TIdentifier>  : IEfApplicationServiceBase<TDto, TEntity, TIdentifier>//: IEntityMapper<TDataTransferObject, TEntity, TIdentifier> //,IDataMapper<TDataTransferObject, TEntity, TIdentifier>
        where TDto : class, IEntityDataTransferObject<TIdentifier> , IDataTransferObject
        where TEntity : class, Inflexion2.Domain.IEntity<TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Fields

        /// <summary>
        /// .es Referencia al mapeador de la entidad Component.
        /// </summary>
        protected internal IDataEntityMapper<TDto, TEntity, TIdentifier> EntityMapper;

        /// <summary>
        /// .en this field has to be initialize inside the constructor of the derived real entity with his own repository.
        /// </summary>
        protected internal IRepository<TEntity, TIdentifier> EntityRepository;

        /// <summary>
        /// .es referencia a la unidad de trabajo
        /// </summary>
        protected internal IUnitOfWork unitOfWork;

        #endregion


        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:Component>Service"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:ComponentServices"/>.
        /// </remarks>
        protected EfApplicationServicesBase() : base()
        {
            //TODO: incluir aqui un mapper generico
        }

        #endregion

        #region Create Service
        /// <summary>
        /// .en Function in charge to create an entity of type <typeparamref name="TEntity"/>.
        /// .es Función encargada de la creación de una entidad de tipo <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="dto"><typeparamref name="TDto"/></param>
        /// <returns><typeparamref name="TIdentifier"/> of the new <typeparamref name="TEntity"/>.</returns>
        public virtual TIdentifier Create(TDto dto)
        {
            #region Preconditions
            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(dto,
                                    string.Format(FrameworkResource.DataTransferObjectIsNull,
                                                  FrameworkResource.ArgumentCantBeNull));

            // .en the dto has to be transient, so the Id has to have a default value.
            // .es el dto debe corresponder a un transient por lo que el id debe tener el valor por defecto
            Guard.Against<ArgumentException>(!dto.Id.Equals(default(TIdentifier)),
                                        string.Format(FrameworkResource.IsNotTransient, null));

            // Comprobar los campos mandatory dentro del DTO.
            #endregion

            return default(TIdentifier); //fake implementation
        }
        #endregion

        #region Service Delete

        /// <summary>
        /// .es Elimina una determinada entidad Address.
        /// </summary>
        /// <param name="id">
        /// Identificador de la entidad que se va a eliminar.
        /// </param>
        /// <returns>
        /// Es <b>true</b> si la eliminación ha sido correcta; en caso contrario <b>false</b>.
        /// </returns>
        public virtual  bool Delete(TIdentifier id)
        {
            // .en the dto has to be transient, so the Id has to have a default value.
            // .es el dto debe corresponder a un transient por lo que el id debe tener el valor por defecto
            Guard.Against<ArgumentException>(!id.Equals(default(TIdentifier)),
                                        string.Format(FrameworkResource.IsNotTransient, null));

            var result = EntityRepository.GetById(id);

            try
            {
                EntityRepository.Remove(result);
                this.Commit();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        /// <summary>
        /// .es Elimina las entidades Address seleccionadas por los ids del parametro.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public virtual IEnumerable<TIdentifier> Delete(IEnumerable<TIdentifier> ids)
        {

            if (ids != null)
            foreach (var id in ids.Where(c => !c.Equals(default(TIdentifier))))
            {
                if (!Delete(id))
                {
                    yield return (id);
                }
            }
        }

        public virtual IEnumerable<TIdentifier> Delete(IEnumerable<TDto> dtos)
        {
            if (dtos != null)
                foreach (var dto in dtos.Where(c => !c.Id.Equals(default(TIdentifier))))
                {
                    if (!Delete(dto.Id))
                    {
                        yield return (dto.Id);
                    }
                }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specificationDto"></param>
        /// <returns></returns>
        public virtual IEnumerable<TIdentifier> Delete(SpecificationDto specificationDto)
        {
            var idsEntities2Delete = this.GetFilteredEntities(specificationDto).Select(c => c.Id).ToArray();

            var errorEntitiesdeleting = this.Delete(idsEntities2Delete);

            return errorEntitiesdeleting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TIdentifier> DeleteAll()
        {
            try
            {
                var entities = EntityRepository.RemoveAll();
                this.Commit();
                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }

        #endregion

        #region GetAll Method
        /// <summary>
        /// .es Recupera todas las entidades Address.
        /// </summary>
        /// <returns>
        /// Todas las entidades Address.
        /// </returns>
        public virtual IEnumerable<TDto> GetAll()
        {
            try
            {
                var entities = EntityRepository.GetAll();
                var dtosResult = InternalMappingCollection(entities);
                this.Commit();
                return dtosResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// .es Recupera todas las entidades excepto la indicada por el parametro. 
        /// </summary>
        /// <param name="id">.es Entidad a evitar.</param>
        /// <returns></returns>
        public virtual IEnumerable<TDto> GetAllExceptThis(TIdentifier id)
        {
            try
            {
                var entities = EntityRepository.GetAllExceptThis(id);
                var dtosResult = InternalMappingCollection(entities);
                this.Commit();
                return dtosResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public virtual IEnumerable<TDto> GetSelectedThese(IEnumerable<TIdentifier> ids)
        {
            try
            {
                IEnumerable<TEntity> entities;
                IEnumerable<TIdentifier> noTransientIds = null;
                if (ids != null)
                {
                    noTransientIds = ids.Where(c => !c.Equals(default(TIdentifier)));
                }

                if (noTransientIds != null && noTransientIds.Any())
                {
                    entities = EntityRepository.GetSelectedThese(ids);
                }
                else
                {
                    return null;
                }
 
                var dtosResult = InternalMappingCollection(entities);
                this.Commit();
                return dtosResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public virtual IEnumerable<TDto> GetAllExceptThese(IEnumerable<TIdentifier> ids)
        {
            try
            {
                IEnumerable<TEntity> entities;
                IEnumerable<TIdentifier> noTransientIds = null;
                if (ids != null)
                {
                    noTransientIds = ids.Where(c => !c.Equals(default(TIdentifier)));
                }
                
                if (noTransientIds != null && noTransientIds.Any())
                {
                    entities = EntityRepository.GetAllExceptThese(ids);      
                }
                else
                {
                    entities = EntityRepository.GetAll();
                }

                var dtosResult = InternalMappingCollection(entities);
                this.Commit();
                return dtosResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public IEnumerable<TDto> GetAllExceptIdAndRelated(TIdentifier id)
        //{
        //    try
        //    {
        //        List<TDto> result = new List<TDto>(0);

        //        // Creamos el repositorio de la entidad.
        //        IEnumerable<TEntity> entities = EntityRepository.GetAllExceptIdAndRelated(id);

        //        // Mapeamos los datos.
        //        entities.ToList()
        //                .ForEach(entity =>
        //                {
        //                    var entityDto = this.graphNodeMapper.EntityMapping(entity);
        //                    result.Add(entityDto);
        //                });

        //        // Confirmamos la transacción.
        //        this.Commit();

        //        // Devolver el resultado.
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

        #region service GetById
        /// <summary>
        /// .es Recupera una entidad Address mediante su identificador correspondiente.
        /// </summary>
        /// <param name="id">
        /// .es Identificador de la entidad que se va a recuperar.
        /// </param>
        /// <returns>
        /// La entidad Address recuperada o valor nulo si no se encuentra.
        /// </returns>
        public virtual TDto GetById(TIdentifier id)
        {
            TDto entityDto = null;

            try
            {
                var entity = EntityRepository.GetAggregateById(id); //TODO: call async
                entityDto = this.EntityMapper.EntityMapping(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Commit();
            }

            return entityDto;
        }
        #endregion

        #region Service GetPaged

        /// <summary>
        /// Recupera una lista paginada de entidades según la especificación indicada.
        /// </summary>
        /// <param name="specificationDto">
        /// Especificación que se va a aplicar.
        /// </param>
        /// <returns>
        /// La lista paginada de entidades según la especificación indicada.
        /// </returns>
        public virtual PagedElements<TDto> GetPaged(SpecificationDto specificationDto)
        {
            #region Preconditions
            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(
                                    specificationDto,
                                    string.Format(
                                                  FrameworkResource.EspecificationDataTransferObjectIsNull,
                                                  "Address"));
            #endregion

            List<TDto> dtosResult = null;
            int totalElements = 0;

            try
            {
                // traducimos el specification dto a una especificación.
                ISpecification<TEntity> filter =
                    specificationDto.ToSpecification<TEntity>();

                PagedElements<TEntity> entities =
                    this.EntityRepository.GetPagedElements(
                                      specificationDto.PageIndex,
                                      specificationDto.PageSize,
                                      filter.IsSatisfiedBy(),
                                                        entity => entity.Id,
                                                        true);
                totalElements = entities.TotalElements;
                dtosResult = InternalMappingCollection(entities);
                this.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new PagedElements<TDto>(dtosResult, totalElements);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specificationDto"></param>
        /// <returns></returns>
        public virtual IEnumerable<TDto> GetFilteredEntities(SpecificationDto specificationDto)
        {
            #region Preconditions
            Guard.ArgumentIsNotNull(
                                    specificationDto,
                                    string.Format(
                                                  FrameworkResource.EspecificationDataTransferObjectIsNull,
                                                  "Address"));
            #endregion

            try
            {
                ISpecification<TEntity> filter = specificationDto.ToSpecification<TEntity>();
                IEnumerable<TEntity> entities = this.EntityRepository.GetFilteredElements(filter.IsSatisfiedBy());
                var dtosResult = InternalMappingCollection(entities);
                this.Commit();
                return dtosResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="specificationDto"></param>
        /// <returns></returns>
        public virtual IEnumerable<TDto> GetFiltered(SpecificationDto specificationDto)
        {
            #region Preconditions
            Guard.ArgumentIsNotNull(
                                    specificationDto,
                                    string.Format(
                                                  FrameworkResource.EspecificationDataTransferObjectIsNull,
                                                  "Address"));
            #endregion

            try
            {
                ISpecification<TEntity> filter = specificationDto.ToSpecification<TEntity>();
                IEnumerable<TEntity> entities = this.EntityRepository.GetFilteredElements(filter.IsSatisfiedBy());
                var dtosResult = InternalMappingCollection(entities);
                this.Commit();
                return dtosResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region update
        // ServiceUpdateMethod.tt
        /// <summary>
        /// Actualiza una determinada entidad Address.
        /// </summary>
        /// <param name="dto">
        /// DTO que contiene la información de la entidad que se va a actualizar.
        /// </param>
        /// <returns>
        /// Es <b>true</b> si la actualización ha sido correcta; en caso contrario <b>false</b>.
        /// </returns>
        public virtual bool Update(TDto dto)
        {
            #region preconditions
            // Comprobar el DTO de entrada. 
            Guard.ArgumentIsNotNull(
                                    dto,
                                    string.Format(
                                                  FrameworkResource.DataTransferObjectIsNull,
                                                  "Address"));

            Guard.Against<ArgumentException>(!dto.Id.Equals(default(TIdentifier)),
                            string.Format(FrameworkResource.IsNotTransient, null));
            // en una actualización no deberia ser necesario comprobar los campos mandatory.
            #endregion            

            try
            {
                // Obtener y comprobar validez de la inserción a modificar.
                TEntity entity2Update = this.EntityRepository.GetFilteredElements(t => t.Id.Equals(dto.Id)).Single();
                Guard.ArgumentIsNotNull(
                                        entity2Update,
                                        string.Format(
                                                        FrameworkResource.CanNotUpdateInexistenceEntity,
                                                        "Entity"));

                // Actualización de la entidad.
                var entityType = typeof(TEntity);
                var dtoPublicProperties = typeof(TDto).GetProperties();

                foreach (var propertyInfo in dtoPublicProperties)
                {
                    var propertyName = propertyInfo.PropertyType.Name;
                    var indexedProperties = propertyInfo.GetIndexParameters();
                    if (indexedProperties.Length == 0 )
                    {
                        dynamic newPropertyValue = propertyInfo.GetValue(dto, null);
                        dynamic oldPropertyValue = entityType.GetProperty(propertyInfo.PropertyType.Name).GetValue(entity2Update, null);
                        if (!oldPropertyValue.Equals(newPropertyValue))
                        {
                            entityType.GetProperty(propertyInfo.PropertyType.Name).SetValue(entity2Update, newPropertyValue, null);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < indexedProperties.Length; i++)
                        {
                            var index = new Object[] { i };
                            dynamic newPropertyValue = propertyInfo.GetValue(dto, index);
                            dynamic oldPropertyValue = entityType.GetProperty(propertyInfo.PropertyType.Name).GetValue(entity2Update, index);
                            if (!oldPropertyValue.Equals(newPropertyValue))
                            {
                                entityType.GetProperty(propertyInfo.PropertyType.Name).SetValue(entity2Update, newPropertyValue, index);
                            }
                        }
                    }
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

        #region private methods
        /// <summary>
        /// adapter of commit operation independent form the ORM
        /// </summary>
        protected internal void Commit()
        {
            if (unitOfWork == null) unitOfWork = ApplicationLayer.IocContainer.Resolve<IUnitOfWork>();
            unitOfWork.Commit();
        }

        private List<TDto> InternalMappingCollection(IEnumerable<TEntity> entities)
        {
            // list new constructor (int32) initial size http://msdn.microsoft.com/en-us/library/dw8e0z9z(v=vs.110).aspx
            var dtosResult = new List<TDto>(0);

            entities.ToList()
                    .ForEach((Action<TEntity>)(entity =>
                    {
                        var entityDto = this.EntityMapper.EntityMapping(entity);
                        dtosResult.Add((TDto)entityDto);
                    }));

            return dtosResult;
        }

        #endregion
    }
}
