﻿//----------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Specification;

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
    public interface IRepository<TEntity, TIdentifier>
        where TEntity : class, IAggregateRoot<TEntity, TIdentifier>, IEntity<TIdentifier>
        where TIdentifier: IComparable<TIdentifier>, IEquatable<TIdentifier>
        {
            /// <summary>
            /// Add item into repository
            /// </summary>
            /// <param name="item">Item to add to repository</param>
            void Add(TEntity item);

            /// <summary>
            /// Attach entity to this repository.
            /// Attach is similar to add but the internal state
            /// for this object is not  mark as 'Added, Modifed or Deleted', submit changes
            /// in Unit Of Work don't send anything to storage
            /// </summary>
            /// <param name="item">Item to attach</param>
            void Attach(TEntity item);

            /// <summary>
            /// Get all elements of type {T} in repository
            /// </summary>
            /// <returns>List of selected elements</returns>
            IEnumerable<TEntity> GetAll();

            /// <summary>
            /// Get all elements of type {T} that matching a
            /// Specification <paramref name="specification"/>
            /// </summary>
            /// <param name="specification">Specification that result meet</param>
            /// <returns></returns>
            IEnumerable<TEntity> GetBySpec(ISpecification<TEntity> specification);

            /// <summary>
            /// Get  elements of type {T} in repository
            /// </summary>
            /// <param name="filter">Filter that each element do match</param>
            /// <returns>List of selected elements</returns>
            IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter);

            IEnumerable<TEntity> GetFilteredElements<S>(
                Expression<Func<TEntity, bool>> filter,
                Expression<Func<TEntity, S>> orderByExpression,
                bool ascending = true);

            PagedElements<TEntity> GetPagedElements<S>(
                int pageIndex,
                int pageCount,
                Expression<Func<TEntity, bool>> filter,
                Expression<Func<TEntity, S>> orderByExpression,
                bool ascending = true);

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
        }
}