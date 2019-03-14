//----------------------------------------------------------------------------------------------
// <copyright file="IOrderBySpecification.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain.Specification
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;

    /// <summary>
    /// Base contract for Specification pattern, for more information
    /// about this pattern see http://martinfowler.com/apsupp/spec.pdf
    /// or http://en.wikipedia.org/wiki/Specification_pattern.
    /// This is really a variant implementation where we have added Linq and
    /// lambda expression into this pattern.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    [ContractClass(typeof(IOrderBySpecificationContract<>))]
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
}