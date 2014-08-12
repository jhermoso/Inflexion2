using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2.Domain;
using System.ComponentModel.DataAnnotations;

namespace CommonDomain
{

    public interface IEntityB : IAggregateRoot<IEntityB, int>
    {
        [Required]
        string Name { get; }

        [ChildrenRelationshipDeleteBehavior(Delete.Cascade)]
        ICollection<EntityA> EntitiesofA { get; }

        void AddB(EntityA b);

    }


}
