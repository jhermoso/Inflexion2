using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration.Configuration;
using Inflexion2.Domain;

using CommonDomain;
namespace EFInfrastructure
{
    public class EntityAConfiguration : EntityConfiguration<EntityA,int>
    {
        public EntityAConfiguration()
        {
            this.Property(h => h.Name);

            this.HasMany<EntityB>(h => h.EntitiesofB)
            .WithMany(h => h.EntitiesofA).Map((c) =>
            {
                c.ToTable("EntityA_EntityB");
                c.MapLeftKey("EntityAUniqueId");
                c.MapRightKey("EntityBUniqueId");
            });

            this.HasMany<EntityC>(h => h.EntitiesofC);
        }
    }
}
