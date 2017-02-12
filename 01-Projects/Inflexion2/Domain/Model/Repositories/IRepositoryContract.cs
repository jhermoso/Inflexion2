namespace Inflexion2.Domain
{
    using Specification;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq.Expressions;

    [ContractClassFor(typeof(IRepository<,>))]
    abstract class IRepositoryContract<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier>
    where TEntity : class, IAggregateRoot<TEntity, TIdentifier>, IEntity<TIdentifier>
    where TIdentifier : IComparable<TIdentifier>, IEquatable<TIdentifier>
    {
        public void Add(TEntity entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null, "entity");
        }

        public void Attach(TEntity entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null, "entity");
        }

        public abstract IEnumerable<TEntity> GetAll();

        public IEnumerable<TEntity> GetBySpec(ISpecification<TEntity> specification)
        {
            Contract.Requires<ArgumentNullException>(specification != null, "specification");
            return null; // fake implementation
        }

        public IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter)
        {
            Contract.Requires<ArgumentNullException>(filter != null, "filter");
            return null; // fake implementation
        }

        public IEnumerable<TEntity> GetFilteredElements<S>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, S>> orderByExpression, bool ascending = true)
        {
            Contract.Requires<ArgumentNullException>(filter != null, "filter");
            Contract.Requires<ArgumentNullException>(orderByExpression != null, "orderByExpression");
            return null; // fake implementation
        }

        public PagedElements<TEntity> GetPagedElements(int pageIndex, int pageCount, ISpecification<TEntity> specification, IOrderBySpecification<TEntity> orderBySpecification)
        {
            Contract.Requires<ArgumentException>(pageIndex >= 0, "pageIndex");
            Contract.Requires<ArgumentException>(pageCount > 0, "pageSize");
            Contract.Requires<ArgumentNullException>(specification != null, "specification");
            Contract.Requires<ArgumentNullException>(orderBySpecification != null, "orderBySpecification");
            return null; // fake implementation
        }

        public PagedElements<TEntity> GetPagedElements<S>(int pageIndex, int pageCount, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, S>> orderByExpression, bool ascending = true)
        {
            Contract.Requires<ArgumentException>(pageIndex >= 0, "pageIndex");
            Contract.Requires<ArgumentException>(pageCount > 0, "pageSize");
            Contract.Requires<ArgumentNullException>(filter != null, "filter");
            Contract.Requires<ArgumentNullException>(orderByExpression != null, "orderByExpression");
            return null; // fake implementation
        }

        public void Modify(TEntity entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null, "entity");
        }

        public void Remove(TEntity entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null, "entity");
        }
    }
}
