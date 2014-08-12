using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration.Configuration;
using Inflexion2.Domain;
using CommonDomain;

namespace EFInfrastructure
{
    public class EntityBConfiguration : EntityConfiguration<EntityB,int>
    {
        public EntityBConfiguration()
        {
            this.Property(h => h.Name);
        }
    }
}
