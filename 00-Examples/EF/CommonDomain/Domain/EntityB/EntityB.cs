using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2.Domain;
using System.ComponentModel.DataAnnotations;

namespace CommonDomain
{
    [Serializable]
    public class EntityB : AggregateRoot<EntityB, int>, IEntityB
    {
        private string name;

        [Required]
        public virtual string Name { get; set; }
        

        private IList<EntityA> entitiesofA;

        [ChildrenRelationshipDeleteBehavior(Delete.Cascade)]
        public virtual ICollection<EntityA> EntitiesofA
        {
            get
            {
                return entitiesofA;
            }
        }
        /// <summary>
        /// constructor vacio inicializamos las colecciones con objeto de que puedan ser utilizadas
        /// </summary>

        private EntityB(): base()
        {
            entitiesofA = new List<EntityA>();
        }


        /// <summary>
        /// Constructor con parametros de propiedades requeridas
        /// </summary>
        /// <param name="name"></param>
        protected internal EntityB(string name)
            : this()
        {
            this.Name = name;
        }

 
        public virtual void AddB(EntityA b)
        {
            this.entitiesofA.Add(b);
        }
    }


}
