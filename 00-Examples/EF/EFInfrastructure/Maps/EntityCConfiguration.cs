using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration.Configuration;
using Inflexion2.Domain;
using CommonDomain;

namespace EFInfrastructure
{
    public class EntityCConfiguration : EntityConfiguration<EntityC,int>
    {
        public EntityCConfiguration()
        {
            this.Property(h => h.Name);
            this.HasRequired(h => h.FatherEntityA).WithMany(h => h.EntitiesofC);
        }
    }
}
