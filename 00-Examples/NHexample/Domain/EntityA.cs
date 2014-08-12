using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2.Domain;
using System.ComponentModel.DataAnnotations;

namespace NHexample
{
    [Serializable]
    public class EntityA : AggregateRoot<EntityA, int>
    {
        [Required]
        public virtual string Name { get; set; }

        public EntityA()
        {
            entitiesofB = new List<EntityB>();
        }

        private IList<EntityB> entitiesofB;
        public virtual ICollection<EntityB> EntitiesofB
        {
            get
            {
                return entitiesofB;
            }
        }

        public virtual void AddB(EntityB b)
        {
            this.entitiesofB.Add(b);
        }
    }


}
