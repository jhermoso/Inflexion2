

namespace Inflexion2.Application
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;

    using Microsoft.Practices.Unity;
    using Inflexion2;
    using Inflexion2.Domain;
    using Inflexion2.Data;


    /// <summary>
    /// .es Clase base para los servicios de aplicación de un bounded context con entityFramework 
    /// </summary>
    public class EfApplicationServiceBase
    {
        protected PerLifeTimeManager unitOfWorkPerTestLifeTimeManager = new PerLifeTimeManager();
        protected PerLifeTimeManager contextPerTestLifeTimeManager = new PerLifeTimeManager();
        protected UnityContainer unityContainer;

        protected EfApplicationServiceBase()
        {
            this.unityContainer = new UnityContainer();

            ServiceLocator.Initialize(
                (x, y) => this.unityContainer.RegisterType(x, y),
                (x, y) => this.unityContainer.RegisterInstance(x, y),
                (x) => { return this.unityContainer.Resolve(x); },
                (x) => { return this.unityContainer.ResolveAll(x); });

            // Context Factory
            RootAggregateFrameworkUnitOfWorkFactory<DomainUnitOfWork> ctxFactory = new RootAggregateFrameworkUnitOfWorkFactory<DomainUnitOfWork>(this.ConnectionString());

            ctxFactory.ValidateDatabaseSchema();

            this.unityContainer.RegisterInstance<IDatabaseManager>(ctxFactory);

            this.unityContainer.RegisterType<DbContext, DomainUnitOfWork>(this.contextPerTestLifeTimeManager, new InjectionConstructor(this.ConnectionString()));

            this.unityContainer.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>(this.unitOfWorkPerTestLifeTimeManager);

        }

        protected virtual string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Sql.Connection"].ConnectionString;
        }

        public void Commit()
        {
            IUnitOfWork unitOfWork = this.unityContainer.Resolve<IUnitOfWork>();
            unitOfWork.Commit();
        }

    }
}
