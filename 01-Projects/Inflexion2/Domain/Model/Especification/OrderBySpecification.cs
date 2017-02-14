﻿namespace Inflexion2.Domain.Specification
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// directions of sorting, ascending or descending
    /// </summary>
    public enum OrderDirection
    {
        /// <summary>
        /// Ascendign sorting
        /// </summary>
        Ascending,

        /// <summary>
        /// descending sorting
        /// </summary>
        Descending
    }

    /// <summary>
    /// sort implementation with an expresion tree
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class OrderBySpecification<TEntity> : IOrderBySpecification<TEntity>
        where TEntity : class
    {
        #region private fields
        private readonly Expression<Func<TEntity, object>> predicate;
        private readonly Expression<Func<TEntity, object>> predicate2;

        private bool descending;
        private bool descending2;
        #endregion

        #region constructors
        /// <summary>
        /// Default Constructor.
        /// Creates a new instance of the <see cref="Specification{TEntity}"/> instnace with the
        /// provided predicate expression.
        /// </summary>
        /// <param name="orderBy">A predicate that can be used to check entities that
        /// satisfy the specification.</param>
        /// <param name="descending">if set to <c>true</c> [descending] order will be used.</param>
        /// <param name="thenBy">The then by.</param>
        /// <param name="thenByDescending">if set to <c>true</c> [then by descending].</param>
        public OrderBySpecification(Expression<Func<TEntity, object>> orderBy, bool descending, Expression<Func<TEntity, object>> thenBy, bool thenByDescending)
        {
            //Guard.Against<ArgumentNullException>(orderBy == null, "Expected a non null expression as a predicate for the specification.");

            this.predicate = orderBy;
            this.descending = descending;
            this.predicate2 = thenBy;
            this.descending2 = thenByDescending;
        }

        /// <summary>
        /// Default Constructor.
        /// Creates a new instance of the <see cref="Specification{TEntity}"/> instnace with the
        /// provided predicate expression.
        /// </summary>
        /// <param name="orderBy">A predicate that can be used to check entities that
        /// satisfy the specification.</param>
        /// <param name="descending">if set to <c>true</c> [descending] order will be used.</param>
        /// <param name="thenBy">The then by.</param>
        public OrderBySpecification(Expression<Func<TEntity, object>> orderBy, bool descending, Expression<Func<TEntity, object>> thenBy)
        : this(orderBy, descending, thenBy, false)
        {
        }

        /// <summary>
        /// Default Constructor.
        /// Creates a new instance of the <see cref="Specification{TEntity}"/> instnace with the
        /// provided predicate expression.
        /// </summary>
        /// <param name="orderBy">A predicate that can be used to check entities that
        /// satisfy the specification.</param>
        /// <param name="thenBy">The then by.</param>
        public OrderBySpecification(Expression<Func<TEntity, object>> orderBy, Expression<Func<TEntity, object>> thenBy)
        : this(orderBy, false, thenBy, false)
        {
        }

        /// <summary>
        /// Default Constructor.
        /// Creates a new instance of the <see cref="Specification{TEntity}"/> instnace with the
        /// provided predicate expression.
        /// </summary>
        /// <param name="predicate">A predicate that can be used to check entities that
        /// satisfy the specification.</param>
        /// <param name="descending">if set to <c>true</c> [descending] order will be used.</param>
        public OrderBySpecification(Expression<Func<TEntity, object>> predicate, bool descending)
        : this(predicate, descending, null, false)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Specification{TEntity}"/> instnace with the
        /// provided predicate expression, with ascending order.
        /// </summary>
        /// <param name="predicate">A predicate that can be used to check entities that
        /// satisfy the specification.</param>
        public OrderBySpecification(Expression<Func<TEntity, object>> predicate)
        : this(predicate, false)
        {
        }
        #endregion

        #region properties
        /// <summary>
        /// get or sets the direction of sorting
        /// </summary>
        public OrderDirection Direction
        {
            get
            {
                return this.descending ? OrderDirection.Descending : OrderDirection.Ascending;
            }

            set
            {
                this.descending = (value == OrderDirection.Descending) ? true : false;
            }
        }

        /// <summary>
        /// second sorting option
        /// </summary>
        public OrderDirection ThenByDirection
        {
            get
            {
                return this.descending2 ? OrderDirection.Descending : OrderDirection.Ascending;
            }

            set
            {
                this.descending2 = (value == OrderDirection.Descending) ? true : false;
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// apply sorting
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IOrderedQueryable<TEntity> ApplyOrderBy(IQueryable<TEntity> query)
        {
            IOrderedQueryable<TEntity> ret = this.descending
                                             ? query.OrderByDescending(this.predicate)
                                             : query.OrderBy(this.predicate);

            if (this.predicate2 != null)
            {
                ret = this.descending2 ? ret.ThenByDescending(this.predicate2) : ret.ThenBy(this.predicate2);
            }

            return ret;
        }
        #endregion
    }
}