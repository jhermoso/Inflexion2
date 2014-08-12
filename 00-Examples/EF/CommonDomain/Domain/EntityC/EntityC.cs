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
    public class EntityC : Entity<EntityC, int>, IEntityC
    {
        [Required]
        public virtual string Name { get; set; }

        private EntityA fatherEntityA;
        public virtual EntityA FatherEntityA
        {
            get
            {
                return fatherEntityA;
            }
            set
            {
                fatherEntityA = value;   
            }
        }

        private EntityC()
            : base()
        {

        }

        protected internal EntityC(EntityA father, string name)
            : this()
        {
            // Comprobamos el parámetro de entrada.
            Guard.ArgumentIsNotNull(
                                    father,
                                    string.Format(
                                                    Inflexion2.Resources.Framework.PropertyRequired,
                                                    "Father", "Entity C") // usar un fichero de recursos para el dominio de negocio Company.Product.BoundedContext.Resources.Business.CategoriaAlias
                                                 );
            Guard.ArgumentIsNotNull(
                                    name,
                                    string.Format(
                                                    Inflexion2.Resources.Framework.PropertyRequired,
                                                    "Name", "Entity C") // usar un fichero de recursos para el dominio de negocio Company.Product.BoundedContext.Resources.Business.CategoriaAlias
                                                 );

            this.fatherEntityA = father;
            this.Name = name;
            father.AddC(this);// al construir la entidad compuesta la añadimos a su padre
        }



    }


}
