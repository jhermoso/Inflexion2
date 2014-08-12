

namespace EFInfrastructure
{
    using System.Data.Entity;
    using Inflexion2.Domain;

    using CommonDomain;

    public class EntityARepository : EFRepository<EntityA, int>, IEntityARepository
    {
        public EntityARepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
