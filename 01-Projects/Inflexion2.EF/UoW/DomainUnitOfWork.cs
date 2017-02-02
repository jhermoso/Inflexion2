using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2.Domain;

namespace Inflexion2.Domain
{
    /// <summary>
    /// unit of work for domain aggregate roots
    /// </summary>
    public class DomainUnitOfWork : RootAggregateContext
    {
        /// <summary>
        /// remember that if you don't pass any parameter to the database context which is the base class for 
        /// our RootAggregateContext EF will use by convention 
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public DomainUnitOfWork(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
        }
        /// <summary>
        /// DbModelBuilder is the main class by which you can configure domain classes. Configuration is done by using the DbModelBuilder API, which takes precedence over data annotations, which in turn takes precedence over the default conventions.
        /// 
        /// Fluent API configuration is applied as EF builds the model from your domain classes You can inject the configurations by overriding the DbContext class's OnModelCreating method
        /// http://www.entityframeworktutorial.net/
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="TEntity"></param>
        protected virtual void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder, System.Type TEntity)
        {
            base.OnModelCreating(modelBuilder);           
            modelBuilder.Configurations.AddFromAssembly(TEntity.Assembly);
        }
    }
}
