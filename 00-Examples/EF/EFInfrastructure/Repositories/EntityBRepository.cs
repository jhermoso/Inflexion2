using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using Inflexion2.Domain;

using CommonDomain;

namespace EFInfrastructure
{
    public class EntityBRepository : EFRepository<EntityB, int>, IEntityBRepository
    {
        public EntityBRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
