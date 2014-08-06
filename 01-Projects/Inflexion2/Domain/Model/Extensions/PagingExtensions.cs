//----------------------------------------------------------------------------------------------
// <copyright file="PagingExtensions.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Inflexion2.Domain.Validation;


    /// <summary>
    /// .es Conjunto de métodos estaticos de paginación con devolución de colecciones inenumerable o iqueryable
    /// </summary>
    public static class PagingExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            Guard.Against<ArgumentException>(pageNumber <= 0, "pageNumber");

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public static IEnumerable<T> Page<T>(this IEnumerable<T> query, int pageNumber, int pageSize)
        {
            Guard.Against<ArgumentException>(pageNumber <= 0, "pageNumber");

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}