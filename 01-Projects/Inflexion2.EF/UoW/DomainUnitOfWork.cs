using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2.Domain;

namespace Inflexion2.Domain
{
    public class DomainUnitOfWork : RootAggregateContext
    {
        public DomainUnitOfWork(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
        }

        protected virtual void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder, System.Type TEntity)
        {
            base.OnModelCreating(modelBuilder);           
            modelBuilder.Configurations.AddFromAssembly(TEntity.Assembly);
        }
    }
}
