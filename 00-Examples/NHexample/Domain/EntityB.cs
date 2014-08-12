using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2.Domain;
using System.ComponentModel.DataAnnotations;

namespace NHexample
{
    [Serializable]
    public class EntityB : AggregateRoot<EntityB, int>
    {
        [Required]
        public virtual string Name { get; set; }

        private IList<EntityA> entitiesofA;
        public virtual ICollection<EntityA> EntitiesofA
        {
            get
            {
                return entitiesofA;
            }
        }
        // en el constructor vacio incializamos las colecciones con objeto de que puedan ser utilizadas
        public EntityB()
        {
            entitiesofA = new List<EntityA>();
        }

        public virtual void AddB(EntityA b)
        {
            this.entitiesofA.Add(b);
        }
    }


}
