using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2;
using Inflexion2.Domain;
using System.ComponentModel.DataAnnotations;

namespace CommonDomain
{
    [Serializable]
    public class EntityA : AggregateRoot<EntityA, int>, IEntityA
    {
        [Required]
        public virtual string Name { get; private set; }

        private EntityA()
            : base()
        {
            entitiesofB = new List<EntityB>();
            entitiesofC = new List<EntityC>();
        }

        protected internal EntityA(string name)
            : this()
        {
            // Comprobamos el parámetro de entrada.
            Guard.ArgumentIsNotNull(
                                    name,
                                    string.Format(
                                                    Inflexion2.Resources.Framework.PropertyRequired,
                                                    "Name", "Entity A") // usar un fichero de recursos para el dominio de negocio Company.Product.BoundedContext.Resources.Business.CategoriaAlias
                                                 );
            this.Name = name;
        }


        private IList<EntityB> entitiesofB;
        [ChildrenRelationshipDeleteBehavior(Delete.Cascade)]
        public virtual ICollection<EntityB> EntitiesofB
        {
            get
            {
                return entitiesofB;
            }
        }

        private IList<EntityC> entitiesofC;
        [ChildrenRelationshipDeleteBehavior(Delete.Restrict)]
        public virtual ICollection<EntityC> EntitiesofC
        {
            get
            {
                return entitiesofC;
            }
        }

        public virtual void AddB(EntityB b)
        {
            this.entitiesofB.Add(b);
        }

        public virtual void AddC(EntityC c)
        {
            this.entitiesofC.Add(c);
        }
    }


}
