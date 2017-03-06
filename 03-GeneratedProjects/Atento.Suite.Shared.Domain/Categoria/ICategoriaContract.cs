
namespace Atento.Suite.Shared.Domain
{
    using Inflexion2.Domain;
    using Inflexion2.Domain.Specification;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Linq.Expressions;


    [ContractClassFor(typeof(ICategoria))]
    abstract class ICategoriaContract : ICategoria, Inflexion2.Domain.IAggregateRoot<ICategoria, Int32>
    {
        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual string Name
        {
            get;
            set;
        }

        public bool CanBeDeleted()
        {
            return true; // fake implementation
        }

        public bool CanBeSaved()
        {
            return true; // fake implementation
        }

        public int CompareTo(IEntity<int> other)
        {
            Contract.Requires<ArgumentNullException>(other != null, "CompareTo Argument can't be null");
            return 0; // fake implementation
        }

        public int CompareTo(object obj)
        {
            Contract.Requires<ArgumentNullException>(obj != null, "CompareTo Argument can't be null");
            return 0; // fake implementation
        }

        public bool Equals(IEntity<int> other)
        {
            return true; // fake implementation
        }

        public bool IsLogicalDelete()
        {
            return true; // fake implementation
        }

        public bool IsTransient()
        {
            return true; // fake implementation
        }

        #region invariants
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(Name != null);
        }

        #endregion
    }
}
