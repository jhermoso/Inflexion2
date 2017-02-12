namespace Inflexion2.Domain.Specification
{
    using Inflexion2.Domain;
    using Specification;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Linq.Expressions;

    [ContractClassFor(typeof(IOrderBySpecification<>))]
    abstract class IOrderBySpecificationContract<TEntity> : IOrderBySpecification<TEntity>
        where TEntity : class
    {
        public IOrderedQueryable<TEntity> ApplyOrderBy(IQueryable<TEntity> query)
        {
            Contract.Requires<ArgumentNullException>(query != null, "query");
            return null; //fake implementation
        }
    }
}
