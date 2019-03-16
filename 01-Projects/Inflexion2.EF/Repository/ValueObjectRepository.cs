//----------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using Inflexion2.Domain.Specification;
    using Inflexion2.Logging;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;

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
    public class ValueObjectRepository<TValueObject>
    where TValueObject : ValueObject<TValueObject>, IValueObject, IComparable<TValueObject>, IEquatable<TValueObject>
    {
        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="entity">Item to add to repository</param>
        void Add(TValueObject entity)
        {

        }

        /// <summary>
        /// Attach entity to this repository.
        /// Attach is similar to add but the internal state
        /// for this object is not  mark as 'Added, Modifed or Deleted', submit changes
        /// in Unit Of Work don't send anything to storage
        /// </summary>
        /// <param name="entity">Item to attach</param>
        void Attach(TValueObject entity)
        {

        }

        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TValueObject> GetAll()
        {

        }

        /// <summary>
        /// Get all elements of type {T} that matching a
        /// Specification <paramref name="specification"/>
        /// </summary>
        /// <param name="specification">Specification that result meet</param>
        /// <returns></returns>
        IEnumerable<TValueObject> GetBySpec(ISpecification<TValueObject> specification)
        {

        }
        

        /// <summary>
        /// Get elements of type {T} in repository
        /// </summary>
        /// <param name="filter">Filter that each element do match</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TValueObject> GetFilteredElements(Expression<Func<TValueObject, bool>> filter)
        {

        }

        /// <summary>
        /// Get a collection of filtered and sorted elements of type {T} in repository by pages ascending or descending
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        IEnumerable<TValueObject> GetFilteredElements<S>(
            Expression<Func<TValueObject, bool>> filter,
            Expression<Func<TValueObject, S>> orderByExpression,
            bool ascending = true)
        {

        }
        

        /// <summary>
        /// Get a page  of filtered and sorted elements of type {T} in repository 
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="filter"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        PagedElements<TValueObject> GetPagedElements<S>(
            int pageIndex,
            int pageCount,
            Expression<Func<TValueObject, bool>> filter,
            Expression<Func<TValueObject, S>> orderByExpression,
            bool ascending = true)
        {

        }

        /// <summary>
        /// Get a page  of filtered and sorted elements of type {T} in repository 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="specification"></param>
        /// <param name="orderBySpecification"></param>
        /// <returns></returns>
        PagedElements<TValueObject> GetPagedElements(
            int pageIndex,
            int pageCount,
            ISpecification<TValueObject> specification,
            IOrderBySpecification<TValueObject> orderBySpecification)

        {

        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Remove(TValueObject item)
        {

        }
    }
}