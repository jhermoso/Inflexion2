

namespace Inflexion2.Application
{
    #region usings
    using AutoMapper.Configuration;
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
    using System.Linq.Expressions;
    #endregion

    /// <summary>
    /// .es Clase base para los servicios de aplicación de un bounded context con entityFramework 
    /// </summary>
    public class EfValueObjectApplicationServicesBase<TDto, TValueObject> : IEfValueObjectApplicationServiceBase<TDto, TValueObject>
        where TDto : BaseValueObjectDataTransferObject
        where TValueObject : ValueObject<TValueObject>, IValueObject, IEquatable<TValueObject>
    {
        #region Fields

        /// <summary>
        /// .es Referencia al mapeador de la entidad Component.
        /// </summary>
        protected internal IDataValueObjectMapper<TDto, TValueObject> ValueObjectMapper;

        /// <summary>
        /// .en this field has to be initialize inside the constructor of the derived real entity with his own repository.
        /// </summary>
        protected internal IValueObjectRepository<TValueObject> ValueObjectRepository;

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
        protected EfValueObjectApplicationServicesBase() : base()
        {
            
        }

        #endregion

        #region Create Service
        /// <summary>
        /// .en Function in charge to create a Value Object of type <typeparamref name="TValueObject"/>.
        /// .es Función encargada de la creación de una entidad de tipo <typeparamref name="TValueObject"/>.
        /// </summary>
        /// <param name="dto"><typeparamref name="TDto"/></param>
        public virtual TDto Create(TDto dto)
        {
            #region Preconditions
            // Comprobar el DTO de entrada.
            Guard.ArgumentIsNotNull(dto,
                                    string.Format(FrameworkResource.DataTransferObjectIsNull,
                                                  FrameworkResource.ArgumentCantBeNull));

            // Comprobar los campos mandatory dentro del DTO.
            #endregion

            try
            {
               TValueObject valueObject = AutoFactory(dto);
               this.ValueObjectRepository.Add(valueObject);
               this.Commit();

               return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Service Delete

        /// <summary>
        /// .es Elimina una determinada entidad Address.
        /// </summary>
        /// <param name="dto">
        /// Identificador de la entidad que se va a eliminar.
        /// </param>
        /// <returns>
        /// Es <b>true</b> si la eliminación ha sido correcta; en caso contrario <b>false</b>.
        /// </returns>
        public virtual bool Delete(TDto dto)
        {
            TValueObject valueObject = AutoFactory(dto);
            try
            {
                this.ValueObjectRepository.Remove(valueObject);
                this.Commit();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }



        /// <summary>
        /// .es Elimina Los objetos valor seleccionados en el array de entrada.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns>. Es devuelve los objectos valor que no se han podido borrar</returns>
        public virtual IEnumerable<TDto> Delete(IEnumerable<TDto> dtos)
        {
            List<TDto> dtosResult = new List<TDto>();

            foreach (var valueObj in dtos)
            {
                if (!Delete(valueObj))
                {
                    dtosResult.Add(valueObj);
                }
            }

            return dtosResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specificationDto"></param>
        /// <returns></returns>
        public virtual IEnumerable<TDto> Delete(SpecificationDto specificationDto)
        {
            var dtos2Delete = this.GetFiltered(specificationDto);
            
            var errorEntitiesdeleting = this.Delete(dtos2Delete);

            return errorEntitiesdeleting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TDto> DeleteAll()
        {
            try
            {
                var resultValueObjects = ValueObjectRepository.RemoveAll();
                this.Commit();
                var dtosResult = InternalMappingCollection(resultValueObjects);
                return dtosResult;
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
                var valueObjects = ValueObjectRepository.GetAll();
                this.Commit();

                var dtosResult = InternalMappingCollection(valueObjects);
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
        /// <param name="dto">.es Entidad a evitar.</param>
        /// <returns></returns>
        public virtual IEnumerable<TDto> GetAllExceptThis(TDto dto)
        {
            try
            {
                TValueObject valueObject = AutoFactory(dto);
                var valueObjects = ValueObjectRepository.GetAllExceptThis(valueObject);
                this.Commit();

                var dtosResult = InternalMappingCollection(valueObjects);
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
        ///// <param name="valueObjects"></param>
        ///// <returns></returns>
        //public virtual IEnumerable<TValueObject> GetSelectedThese(IEnumerable<TValueObject> valueObjects)
        //{
        //    try
        //    {
        //        var valueObjectsResult = ValueObjectRepository.GetSelectedThese(valueObjects);
        //        //var dtosResult = InternalMappingCollection(valueObjectsResult);
        //        this.Commit();
        //        return valueObjectsResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public virtual IEnumerable<TDto> GetAllExceptThese(IEnumerable<TDto> dtos)
        {
            List<TValueObject> avoidedValueObjs = new List<TValueObject>();
            try
            {
                foreach (var item in dtos)
                {
                    var va = AutoFactory(item);
                    avoidedValueObjs.Add(va);
                }

                var resultValueObjects = ValueObjectRepository.GetAllExceptThese(avoidedValueObjs);
                this.Commit();

                var dtosResult = InternalMappingCollection(resultValueObjects);
                return dtosResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region service GetByDto
        /// <summary>
        /// .es Comprueba que el objeto valor existe.
        /// </summary>
        /// <returns>
        /// el objeto valor resultante es nulo si no se encuentra.
        /// </returns>
        public virtual TDto GetByDto(TDto dto)
        {
            TValueObject valueObject = AutoFactory(dto);
            TDto checkedDto = null;

            try
            {
                var valueObj = this.ValueObjectRepository.GetFilteredElements(u => u.Equals(valueObject)).First();
                if (valueObj != null) checkedDto = dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Commit();
            }

            return checkedDto;
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
                ISpecification<TValueObject> filter =
                    specificationDto.ToSpecification<TValueObject>();

                PagedElements<TValueObject> valueObjs =
                    this.ValueObjectRepository.GetPagedElements(
                                      specificationDto.PageIndex,
                                      specificationDto.PageSize,
                                      filter.IsSatisfiedBy(),
                                                        valueObj => true,
                                                        true);
                totalElements = valueObjs.TotalElements;
                dtosResult = InternalMappingCollection(valueObjs).ToList();
                this.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new PagedElements<TDto>(dtosResult, totalElements);
        }


        //public virtual IEnumerable<TValueObject> GetFilteredValueObjects(SpecificationDto specificationDto)
        //{
        //    #region Preconditions
        //    Guard.ArgumentIsNotNull(
        //                            specificationDto,
        //                            string.Format(
        //                                          FrameworkResource.EspecificationDataTransferObjectIsNull,
        //                                          "Address"));
        //    #endregion

        //    try
        //    {
        //        ISpecification<TValueObject> filter = specificationDto.ToSpecification<TValueObject>();
        //        IEnumerable<TValueObject> valueObjects = this.ValueObjectRepository.GetFilteredElements(filter.IsSatisfiedBy());

        //        this.Commit();
        //        return valueObjects;
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
                ISpecification<TValueObject> filter = specificationDto.ToSpecification<TValueObject>();
                IEnumerable<TValueObject> valueObjects = this.ValueObjectRepository.GetFilteredElements(filter.IsSatisfiedBy());
                this.Commit();

                var dtosResult = InternalMappingCollection(valueObjects);
                return dtosResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        private IEnumerable<TDto> InternalMappingCollection(IEnumerable<TValueObject> valueObjects)
        {
            // list new constructor (int32) initial size http://msdn.microsoft.com/en-us/library/dw8e0z9z(v=vs.110).aspx
            var dtosResult = new List<TDto>(0);

            valueObjects.ToList()
                    .ForEach((Action<TValueObject>)(entity =>
                    {
                        var entityDto = this.ValueObjectMapper.ValueObjectMapping(entity);
                        dtosResult.Add((TDto)entityDto);
                    }));

            return dtosResult;
        }

        private static void AutoMap(TDto sourceDto, TValueObject valueObjectTarget)
        {      
            if (AutoMapper.Mapper.FindTypeMapFor<TDto, TValueObject>() == null)
                AutoMapper.Mapper.CreateMap<TDto, TValueObject>();
            AutoMapper.Mapper.Map(sourceDto, valueObjectTarget);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        internal protected static TValueObject AutoFactory(TDto dto)
        {
            var valueObject = (TValueObject)Activator.CreateInstance(typeof(TValueObject));
            AutoMap(dto, valueObject);
            return valueObject;
        }

        #endregion
    }
}
