//----------------------------------------------------------------------------------------------
// <copyright file="PagingExtensions.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;


    /// <summary>
    /// .es Conjunto de métodos estaticos de paginación con devolución de colecciones inenumerable o iqueryable
    /// </summary>
    public static class PagingExtensions
    {
        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            //Guard.Against<ArgumentException>(pageNumber <= 0, "pageNumber");
            Contract.Requires<ArgumentException>(pageNumber <= 0, "pageNumber");

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IEnumerable<T> Page<T>(this IEnumerable<T> query, int pageNumber, int pageSize)
        {
            //Guard.Against<ArgumentException>(pageNumber <= 0, "pageNumber");
            Contract.Requires<ArgumentException>(pageNumber <= 0, "pageNumber");

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}