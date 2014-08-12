using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2.Domain;

namespace EFInfrastructure
{
    public class MyDomainUnitOfWork : DomainUnitOfWork
    {
        public MyDomainUnitOfWork(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.AddFromAssembly(typeof(EFexample.EntityAConfiguration).Assembly);
            base.OnModelCreating(modelBuilder, typeof(EntityAConfiguration));
        }
    }
}
