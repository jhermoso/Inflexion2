//----------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using Inflexion2.Domain.Specification;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
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
    /// <typeparam name="TEntity">Type of entity for this repository </typeparam>
    /// <typeparam name="TIdentifier">Type of identity for this repository </typeparam>
    [ContractClass(typeof(IRepositoryContract<,>))]
    public interface IRepository<TEntity, TIdentifier>
    where TEntity : class, Inflexion2.Domain.IEntity<TIdentifier>
    where TIdentifier: System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="entity">Item to add to repository</param>
        void Add(TEntity entity);

        /// <summary>
        /// Attach entity to this repository.
        /// Attach is similar to add but the internal state
        /// for this object is not  mark as 'Added, Modifed or Deleted', submit changes
        /// in Unit Of Work don't send anything to storage
        /// </summary>
        /// <param name="entity">Item to attach</param>
        void Attach(TEntity entity);

        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetAll();


        /// <summary>
        /// Get one element of type {T} in repository by his Id
        /// </summary>
        /// <returns> the selected element</returns>
        TEntity GetById(TIdentifier id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetAggregateById(TIdentifier id);

        /// <summary>
        /// Dynamic get by identity including the fields with the name in the array string
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        TEntity GetByIdIncluding(TIdentifier id, string[] includes = null);

        /// <summary>
        /// Get all elements of type {T} except those with the id parameter
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllExceptThis(TIdentifier ids);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllExceptThese(IEnumerable<TIdentifier> ids);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetSelectedThese(IEnumerable<TIdentifier> ids);

        /// <summary>
        /// Get all elements of type {T} that matching a
        /// Specification <paramref name="specification"/>
        /// </summary>
        /// <param name="specification">Specification that result meet</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetBySpec(ISpecification<TEntity> specification);

        /// <summary>
        /// Get elements of type {T} in repository
        /// </summary>
        /// <param name="filter">Filter that each element do match</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Get a collection of filtered and sorted elements of type {T} in repository by pages ascending or descending
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetFilteredElements<S>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, S>> orderByExpression,
            bool ascending = true);

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
        PagedElements<TEntity> GetPagedElements<S>(
            int pageIndex,
            int pageCount,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, S>> orderByExpression,
            bool ascending = true);

        /// <summary>
        /// Get a page  of filtered and sorted elements of type {T} in repository 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="specification"></param>
        /// <param name="orderBySpecification"></param>
        /// <returns></returns>
        PagedElements<TEntity> GetPagedElements(
            int pageIndex,
            int pageCount,
            ISpecification<TEntity> specification,
            IOrderBySpecification<TEntity> orderBySpecification);

        /// <summary>
        /// Sets modified entity into the repository.
        /// When calling Commit() method in UnitOfWork
        /// these changes will be saved into the storage
        /// <remarks>
        /// Internally this method always calls Repository.Attach() and Context.SetChanges()
        /// </remarks>
        /// </summary>
        /// <param name="item">Item with changes</param>
        void Modify(TEntity item);

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Remove(TEntity item);

        /// <summary>
        /// Delete item by identity
        /// </summary>
        /// <param name="id">Item to delete</param>
        void Remove(TIdentifier id);

        /// <summary>
        /// Remove all items
        /// </summary>
        /// <returns></returns>
        IEnumerable<TIdentifier> RemoveAll();
    }
}