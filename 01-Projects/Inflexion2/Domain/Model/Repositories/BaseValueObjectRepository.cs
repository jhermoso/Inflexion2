//----------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using Inflexion2.Logging;
    using Inflexion2.Domain.Specification;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Linq;

    /// <summary>
    /// Base interface for implement a "Repository Pattern", for
    /// more information about this pattern see http://martinfowler.com/eaaCatalog/repository.html
    /// or http://blogs.msdn.com/adonet/archive/2009/06/16/using-repository-and-unit-of-work-patterns-with-entity-framework-4-0.aspx
    /// </summary>
    /// <remarks>
    /// Indeed, one might think that IObjectSet is already a generic repository and therefore
    /// would not need this item. Using this interface allows us to ensure the persistence
    /// of ignorance within our domain model
    /// </remarks>
    /// <typeparam name="TValueObject">Type of entity for this repository </typeparam>
    //[ContractClass(typeof(IValueObjectRepositoryContract<,>))]
    public abstract class BaseValueObjectRepository<TValueObject> : IValueObjectRepository<TValueObject>
    where TValueObject : ValueObject<TValueObject>, IValueObject, /*IComparable<TValueObject>,*/ IEquatable<TValueObject>
    {
        private readonly ILogger logger;

        /// <summary>
        /// 
        /// </summary>
        protected BaseValueObjectRepository()
        {
            this.logger = LogManager.GetLogger(GetType());
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Created repository for type: {0}", typeof(TValueObject).Name));
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
        /// Add item into repository
        /// </summary>
        /// <param name="valueObject">Item to add to repository</param>
        public void Add(TValueObject valueObject)
        {
            this.InternalAdd(valueObject);

            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Added a {0} entity", typeof(TValueObject).Name));
        }

        /// <summary>
        /// Attach entity to this repository.
        /// Attach is similar to add but the internal state
        /// for this object is not  mark as 'Added, Modifed or Deleted', submit changes
        /// in Unit Of Work don't send anything to storage
        /// </summary>
        /// <param name="valueObject">Item to attach</param>
        public void Attach(TValueObject valueObject)
        {
            this.InternalAttach(valueObject);

            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Attached {0} to context", typeof(TValueObject).Name));
        }

        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        public IEnumerable<TValueObject> GetAll()
        {
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Get all from entity {0}.", typeof(TValueObject).Name));
            return this.Query().ToList();
        }

        public IEnumerable<TValueObject> GetAllExceptThis(TValueObject valueObject)
        {
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Get all from entity {0}.", typeof(TValueObject).Name));
            return this.Query().Where(c => c != valueObject).ToList();
        }

        public IEnumerable<TValueObject> GetAllExceptThese(IEnumerable<TValueObject> valueObjects)
        {
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Get all from entity {0}.", typeof(TValueObject).Name));
            var arrayVO = valueObjects.ToArray();
            return this.Query().Where(c => !arrayVO.Contains(c)).ToList();
        }

        public IEnumerable<TValueObject> GetAllExceptThese(TValueObject[] valueObjects)
        {
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Get all from entity {0}.", typeof(TValueObject).Name));

            return this.Query().Where(c => !valueObjects.Contains(c)).ToList();
        }

        /// <summary>
        /// Get all elements of type {T} that matching a
        /// Specification <paramref name="specification"/>
        /// </summary>
        /// <param name="specification">Specification that result meet</param>
        /// <returns></returns>
        public IEnumerable<TValueObject> GetBySpec(ISpecification<TValueObject> specification)
        {
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Getting {0} by specification", typeof(TValueObject).Name));

            return (this.Query()
                    .Where(specification.IsSatisfiedBy()))
                    .ToList();
        }

        /// <summary>
        /// Get elements of type {T} in repository
        /// </summary>
        /// <param name="filter">Filter that each element do match</param>
        /// <returns>List of selected elements</returns>
        public IEnumerable<TValueObject> GetFilteredElements(Expression<Func<TValueObject, bool>> filter)
        {
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Getting filtered elements {0} with filer: {1}", typeof(TValueObject).Name, filter.ToString()));

            // Create IObjectSet and perform query
            return this.Query()
                   .Where(filter)
                   .ToList();
        }

        /// <summary>
        /// Get a collection of filtered and sorted elements of type {T} in repository by pages ascending or descending
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        public IEnumerable<TValueObject> GetFilteredElements<S>(
            Expression<Func<TValueObject, bool>> filter,
            Expression<Func<TValueObject, S>> orderByExpression,
            bool ascending = true)
        {
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Getting filtered elements {0} with filter: {1}", typeof(TValueObject).Name, filter.ToString()));

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
        /// Get a page  of filtered and sorted elements of type {T} in repository 
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        public virtual PagedElements<TValueObject> GetPagedElements<S>(
            int pageIndex,
            int pageSize,
            Expression<Func<TValueObject, bool>> filter,
            Expression<Func<TValueObject, S>> orderByExpression,
            bool ascending = true)
        {
            this.logger.Debug(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Getting paged elements {0}, pageIndex: {1}, pageSize {2}, oderBy {3}",
                    typeof(TValueObject).Name,
                    pageIndex,
                    pageSize,
                    orderByExpression != null? orderByExpression.ToString() :String.Empty));

            var objectSet = this.Query();

            IQueryable<TValueObject> query = objectSet.Where(filter);
            int total = query != null? query.Count() : 0 ;

            if (orderByExpression != null)
            {
                var temp = (ascending) ?  new PagedElements<TValueObject>( query.OrderBy(orderByExpression)
                                                    .Skip(pageIndex * pageSize)
                                                    .Take(pageSize)
                                                    .ToList(),
                                                    total)

                                        : new PagedElements<TValueObject>(
                                                   query.OrderByDescending(orderByExpression)
                                                   .Skip(pageIndex * pageSize)
                                                   .Take(pageSize)
                                                   .ToList(),
                                                   total);
                return temp;
            }

            return new PagedElements<TValueObject>(
                                                   query
                                                   .Skip(pageIndex * pageSize)
                                                   .Take(pageSize)
                                                   .ToList(),
                                                   total);
        }

        /// <summary>
        /// Get a page  of filtered and sorted elements of type {T} in repository 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="specification"></param>
        /// <param name="orderBySpecification"></param>
        /// <returns></returns>
        public virtual PagedElements<TValueObject> GetPagedElements(
            int pageIndex,
            int pageSize,
            ISpecification<TValueObject> specification,
            IOrderBySpecification<TValueObject> orderBySpecification)
        {
            this.logger.Debug(
                            string.Format(
                                CultureInfo.InvariantCulture,
                                "Getting paged elements {0}, pageIndex: {1}, pageSize {2}, oderBy {3}",
                                typeof(TValueObject).Name,
                                pageIndex,
                                pageSize,
                                orderBySpecification.ToString()));

            // Create associated IObjectSet and perform query
            var objectSet = this.Query();

            IQueryable<TValueObject> query = objectSet.Where(specification.IsSatisfiedBy());
            int total = query != null ? query.Count() : 0;

            return new PagedElements<TValueObject>(
                       query
                       .OrderBySpecification(orderBySpecification)
                       .Skip(pageIndex * pageSize)
                       .Take(pageSize)
                       .ToList(),
                       total);
        }


        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="valueObject">Item to delete</param>
        public virtual void Remove(TValueObject valueObject)
        {
            this.InternalRemove(valueObject);

            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Deleted a {0} Value Object", typeof(TValueObject).Name));
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<TValueObject> RemoveAll()
        {
            var allValueObjects = this.GetAll();
            List<TValueObject> result = new List<TValueObject>();
            foreach (var valueObject in allValueObjects)
            {
                try
                {
                    this.Remove(valueObject);
                }
                catch (Exception)
                {
                    result.Add(valueObject);
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueObjectsToDelete"></param>
        public virtual IEnumerable<TValueObject> RemoveAll(IEnumerable<TValueObject> valueObjectsToDelete)
        {
            List<TValueObject> result = new List<TValueObject>();
            foreach (var valueObject in valueObjectsToDelete)
            {
                try
                {
                    this.Remove(valueObject);
                }
                catch (Exception)
                {
                    result.Add(valueObject);
                }
            }

            return result;
        }

        /// <summary>
        /// method to be over writed to add operations
        /// </summary>
        /// <param name="valueObject"></param>
        protected abstract void InternalAdd(TValueObject valueObject);

        /// <summary>
        /// method to be over writed to attach operations
        /// </summary>
        /// <param name="valueObject"></param>
        protected abstract void InternalAttach(TValueObject valueObject);

        /// <summary>
        /// method to be over writed to modify operations
        /// </summary>
        /// <param name="valueObject"></param>
        protected abstract void InternalModify(TValueObject valueObject);

        /// <summary>
        /// method to be over writed to remove operations
        /// </summary>
        /// <param name="valueObject"></param>
        protected abstract void InternalRemove(TValueObject valueObject);

        /// <summary>
        /// method to write to query operations
        /// </summary>
        /// <returns></returns>
        protected abstract IQueryable<TValueObject> Query();

    }
}