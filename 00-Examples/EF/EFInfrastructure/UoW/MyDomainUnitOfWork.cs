using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2.Domain;

namespace EFInfrastructure
{
    /// <summary>
    /// class to implement the Unit of Work 
    /// </summary>
    public class BootstrapUnitOfWork : DomainUnitOfWork
    {
        /// <summary>
        /// constructor MyDomainUnitOfWork
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public BootstrapUnitOfWork(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
        }
        /// <summary>
        /// .es añadimos todos los ficheros de configuración del ensamblado de la entidad que pasamos.
        /// .en add all configuration files from the assembly where is located the entity in the second parameter.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.AddFromAssembly(typeof(EFexample.EntityAConfiguration).Assembly);
            base.OnModelCreating(modelBuilder, typeof(EntityAConfiguration));
        }
    }
}
