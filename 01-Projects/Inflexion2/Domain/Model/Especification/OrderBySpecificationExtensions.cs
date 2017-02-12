using System;
namespace Inflexion2.Domain.Specification
{
    using System.Diagnostics.Contracts;
    using System.Linq;

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
            Contract.Requires<ArgumentNullException>(query != null);
            Contract.Requires<ArgumentNullException>(orderBy != null);

            return orderBy.ApplyOrderBy(query);
        }
    }
}
