//----------------------------------------------------------------------------------------------
// <copyright file="BaseRepository.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using Logging;
    using Specification;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// .en Default base class for repositories. This generic repository
    /// is a default implementation of <see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/>
    /// and the specific repositories for every ORM (nhibernate, entity framework, other ) inherit from this base class 
    /// calling to their own functions. For example from this class inherit EfRepository which overrite the  generic abstract members of this base class to use the EF memebers.
    /// Why to do that, and don't use EF directly becouse in this case is possible to write the logic decopled from the technology EF, NH etc.
    /// </summary>
    /// <typeparam name="TEntity">Type of elements in repostory</typeparam>
    /// <typeparam name="TIdentifier">identifier</typeparam>
    public abstract class BaseRepository<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier>
        where TEntity : AggregateRoot<TEntity, TIdentifier>, IAggregateRoot<TEntity, TIdentifier>, IEntity<TIdentifier>
        where TIdentifier : IComparable<TIdentifier>, IEquatable<TIdentifier>
    {
        private readonly ILogger logger;

        /// <summary>
        /// Default constructor for GenericRepository
        /// </summary>
        // <param name="traceManager">Trace Manager dependency</param>
        // <param name="context">A context for this repository</param>
        protected BaseRepository()
        {
            this.logger = LoggerManager.GetLogger(GetType());
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Created repository for type: {0}", typeof(TEntity).Name));
        }

        /// <summary>
        /// loger instance for tracing porpouses
        /// </summary>
        protected ILogger Logger
        {
            get
            {
                return this.logger;
            }
        }

        /// <summary>
        /// <see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/>
        /// </summary>
        /// <param name="entity"><see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/></param>
        public virtual void Add(TEntity entity)
        {
            //Guard.IsNotNull(entity, "entity");
            //Contract.Requires<ArgumentNullException>(entity != null, "entity");

            this.InternalAdd(entity);

            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Added a {0} entity", typeof(TEntity).Name));
        }

        /// <summary>
        /// <see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/>
        /// </summary>
        /// <param name="entity"><see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/></param>
        public void Attach(TEntity entity)
        {
            //Guard.IsNotNull(entity, "entity");
            //Contract.Requires<ArgumentNullException>(entity != null, "entity");
            this.InternalAttach(entity);

            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Attached {0} to context", typeof(TEntity).Name));
        }

        /// <summary>
        /// <see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/>
        /// </summary>
        /// <returns><see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return this.Query().ToList();
        }

        /// <summary>
        /// <see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/>
        /// </summary>
        /// <param name="specification"><see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/></param>
        /// <returns><see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/></returns>
        public IEnumerable<TEntity> GetBySpec(ISpecification<TEntity> specification)
        {
            //Guard.IsNotNull(specification, "specification");
            //Contract.Requires<ArgumentNullException>(specification != null, "specification");
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Getting {0} by specification", typeof(TEntity).Name));

            return (this.Query()
                    .Where(specification.IsSatisfiedBy()))
                    .ToList();
        }

        /// <summary>
        /// <see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/>
        /// </summary>
        /// <param name="filter"><see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/></param>
        /// <returns><see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/></returns>b
        public IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter)
        {
            // checking query arguments
            //Guard.IsNotNull(filter, "filter");
            //Contract.Requires<ArgumentNullException>(filter != null, "filter");
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Getting filtered elements {0} with filer: {1}", typeof(TEntity).Name, filter.ToString()));

            // Create IObjectSet and perform query
            return this.Query()
                   .Where(filter)
                   .ToList();
        }

        /// <summary>
        /// <see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/>
        /// </summary>
        /// <param name="filter"><see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/></param>
        /// <param name="orderByExpression"><see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/></param>
        /// <param name="ascending"><see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/></param>
        /// <returns><see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/></returns>
        public IEnumerable<TEntity> GetFilteredElements<S>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, S>> orderByExpression,
            bool ascending = true)
        {
            // Checking query arguments
            //Guard.IsNotNull(filter, "filter");
            //Guard.IsNotNull(orderByExpression, "orderByExpression");
            //Contract.Requires<ArgumentNullException>(filter != null, "filter");
            //Contract.Requires<ArgumentNullException>(orderByExpression != null, "orderByExpression");

            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Getting filtered elements {0} with filter: {1}", typeof(TEntity).Name, filter.ToString()));

            // Create IObjectSet for this type and perform query
            var objectSet = this.Query();

            return ascending ? objectSet.Where(filter)
                                       .OrderBy(orderByExpression)
                                       .ToList()
                             : objectSet.Where(filter)
                                        .OrderByDescending(orderByExpression)
                                        .ToList();
        }


        /// <summary>
        /// Get a filtered sorted paged collection of enties ascending or descending
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        public PagedElements<TEntity> GetPagedElements<S>(
            int pageIndex,
            int pageSize,
            Expression<Func<TEntity, bool>> filter, 
            Expression<Func<TEntity, S>> orderByExpression,
            bool ascending = true)
        {
            // checking arguments for this query
            //Guard.Against<ArgumentException>(pageIndex < 0, "pageIndex");
            //Guard.Against<ArgumentException>(pageSize <= 0, "pageSize");
            //Guard.IsNotNull(orderByExpression, "orderByExpression");
            //Guard.IsNotNull(filter, "filter");

            //Contract.Requires<ArgumentException>(pageIndex >= 0, "pageIndex");
            //Contract.Requires<ArgumentException>(pageSize > 0, "pageSize");
            //Contract.Requires<ArgumentNullException>(filter != null, "filter");
            //Contract.Requires<ArgumentNullException>(orderByExpression != null, "orderByExpression");

            this.logger.Debug(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Getting paged elements {0}, pageIndex: {1}, pageSize {2}, oderBy {3}",
                    typeof(TEntity).Name,
                    pageIndex,
                    pageSize,
                    orderByExpression.ToString()));

            var objectSet = this.Query();

            IQueryable<TEntity> query = objectSet.Where(filter);
            int total = query.Count();

            return ascending
                   ? new PagedElements<TEntity>(
                                                   query.OrderBy(orderByExpression)
                                                   .Skip(pageIndex * pageSize)
                                                   .Take(pageSize)
                                                   .ToList(),
                                                   total)
                   : new PagedElements<TEntity>(
                                                   query.OrderByDescending(orderByExpression)
                                                   .Skip(pageIndex * pageSize)
                                                   .Take(pageSize)
                                                   .ToList(),
                                                   total);
        }

        /// <summary>
        ///  Get a filtered sorted paged collection of enties
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="specification"></param>
        /// <param name="orderBySpecification"></param>
        /// <returns></returns>
        public PagedElements<TEntity> GetPagedElements(
            int pageIndex,
            int pageSize,
            ISpecification<TEntity> specification,
            IOrderBySpecification<TEntity> orderBySpecification
            )
        {
            //// checking arguments for this query
            //Guard.Against<ArgumentException>(pageIndex < 0, "pageIndex");
            //Guard.Against<ArgumentException>(pageSize <= 0, "pageSize");
            //Guard.IsNotNull(orderBySpecification, "orderBySpecification");
            //Guard.IsNotNull(specification, "specification");

            //Contract.Requires<ArgumentException>(pageIndex >= 0, "pageIndex");
            //Contract.Requires<ArgumentException>(pageSize > 0, "pageSize");
            //Contract.Requires<ArgumentNullException>(specification != null, "specification");
            //Contract.Requires<ArgumentNullException>(orderBySpecification != null, "orderBySpecification");

            this.logger.Debug(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Getting paged elements {0}, pageIndex: {1}, pageSize {2}, oderBy {3}",
                    typeof(TEntity).Name,
                    pageIndex,
                    pageSize,
                    orderBySpecification.ToString()));

            // Create associated IObjectSet and perform query
            var objectSet = this.Query();

            IQueryable<TEntity> query = objectSet.Where(specification.IsSatisfiedBy());
            int total = query.Count();

            return new PagedElements<TEntity>(
                       query
                       .OrderBySpecification(orderBySpecification)
                       .Skip(pageIndex * pageSize)
                       .Take(pageSize)
                       .ToList(),
                       total);
        }

        /// <summary>
        /// modify entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Modify(TEntity entity)
        {
            //Guard.IsNotNull(entity, "entity");
            //Contract.Requires<ArgumentNullException>(entity != null, "entity");
            this.InternalModify(entity);

            this.logger.Info(string.Format(CultureInfo.InvariantCulture, "Applied changes to: {0}", typeof(TEntity).Name));
        }

        /// <summary>
        /// <see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/>
        /// </summary>
        /// <param name="entity"><see cref="Inflexion2.Domain.IRepository{TEntity, TIdentifier}"/></param>
        public virtual void Remove(TEntity entity)
        {
            // check entity
            //Guard.IsNotNull(entity, "entity");
            //Contract.Requires<ArgumentNullException>(entity != null, "entity");
            this.InternalRemove(entity);

            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Deleted a {0} entity", typeof(TEntity).Name));
        }

        /// <summary>
        /// method to be over writed to add operations
        /// </summary>
        /// <param name="entity"></param>
        protected abstract void InternalAdd(TEntity entity);

        /// <summary>
        /// method to be over writed to attach operations
        /// </summary>
        /// <param name="entity"></param>
        protected abstract void InternalAttach(TEntity entity);

        /// <summary>
        /// method to be over writed to modify operations
        /// </summary>
        /// <param name="entity"></param>
        protected abstract void InternalModify(TEntity entity);

        /// <summary>
        /// method to be over writed to remove operations
        /// </summary>
        /// <param name="entity"></param>
        protected abstract void InternalRemove(TEntity entity);

        /// <summary>
        /// method to write to query operations
        /// </summary>
        /// <returns></returns>
        protected abstract IQueryable<TEntity> Query();

    }
}