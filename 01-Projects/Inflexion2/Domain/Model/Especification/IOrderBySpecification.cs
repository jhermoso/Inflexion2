//----------------------------------------------------------------------------------------------
// <copyright file="IOrderBySpecification.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain.Specification
{
    using System;
    using System.Linq;

    /// <summary>
    /// Base contract for Specification pattern, for more information
    /// about this pattern see http://martinfowler.com/apsupp/spec.pdf
    /// or http://en.wikipedia.org/wiki/Specification_pattern.
    /// This is really a variant implementation where we have added Linq and
    /// lambda expression into this pattern.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public interface IOrderBySpecification<TEntity>
    where TEntity : class
    {
        /// <summary>
        /// gets a sorted query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IOrderedQueryable<TEntity> ApplyOrderBy(IQueryable<TEntity> query);
    }

    /// <summary>
    /// extension
    /// </summary>
    public static class OrderBySpecificationExtensions
    {
        /// <summary>
        /// sort by specification
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public static IOrderedQueryable<TEntity> OrderBySpecification<TEntity>(
            this IQueryable<TEntity> query,
            IOrderBySpecification<TEntity> orderBy)
        where TEntity : class
        {
            Guard.Against<ArgumentNullException>(query == null, "query");
            Guard.Against<ArgumentNullException>(orderBy == null, "orderBy");

            return orderBy.ApplyOrderBy(query);
        }
    }
}