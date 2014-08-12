using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2.Domain;
using System.ComponentModel.DataAnnotations;

namespace CommonDomain
{

    public interface IEntityA : IAggregateRoot<IEntityA, int>, IEntity<int>
    {
        [Required]
        string Name { get; }

        [ChildrenRelationshipDeleteBehavior(Delete.Cascade)]
        ICollection<EntityB> EntitiesofB { get; }

        [ChildrenRelationshipDeleteBehavior(Delete.Restrict)]
        ICollection<EntityC> EntitiesofC { get; }

        void AddB(EntityB b);

        void AddC(EntityC c);
    }


}
