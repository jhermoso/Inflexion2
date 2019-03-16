

namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [Serializable]
    class EFEntityAggregate<TEntityParent, TEntityChildren, TIdentifier>
        where TEntityParent : Entity<TEntityParent, TIdentifier>,  IEntity<TIdentifier>
        where TEntityChildren : Entity<TEntityParent, TIdentifier>, IEntity<TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {

        public TEntityParent AddChild(  this TEntityParent parent, TEntityChildren child)
        {
            return parent;
        }
    }
}
