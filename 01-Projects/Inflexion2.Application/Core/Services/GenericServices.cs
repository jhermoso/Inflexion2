

namespace Inflexion2.Application
{
    using System.Collections.Generic;
    using System;
    using Inflexion2.Domain;
    using Inflexion2;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// base class for basic CRUD operations on one Root Aggregate
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdentifier"></typeparam>
    public class GenericServices<TDto, TEntity, TIdentifier> : IGenericServices<TDto, TEntity, TIdentifier> //: IServices
        where TDto : class, IDataTransferObject
        where TEntity : Inflexion2.Domain.IAggregateRoot<TEntity, TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Fields
        /// <summary>
        /// Referencia al mapeador de la entidad Persona.
        /// </summary>
        private readonly IDataEntityMapper<TDto, TEntity, TIdentifier> entityMapper;

        // <summary>
        // Referencia a la factoría de repositorios de la entidad Persona.
        // </summary>
        //private readonly PersonaRepositoryFactory personaRepositoryFactory;

        // <summary>
        // referencia a la unidad de trabajo
        // </summary>
        private IUnitOfWork unitOfWork;
        #endregion

        public bool Delete(TIdentifier Id)
        {
            IRepository<TEntity, TIdentifier> repo = ApplicationLayer.IocContainer.Resolve<IPersonaRepository>();
            IEnumerable<TEntity> results = repo.GetFilteredElements(u => u.Id == id);
            Persona persona2Delete = results.First();

            if (!persona2Delete.CanBeDeleted())
            {
                return false;
            }
            repo.Remove(persona2Delete);
            this.Commit();

            return true;
        }

        public IEnumerable<TDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public TDto GetById(TIdentifier Id)
        {
            throw new NotImplementedException();
        }

        public PagedElements<TDto> GetPaged(SpecificationDto specificationDto)
        {
            throw new NotImplementedException();
        }

        public bool Update(TDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
