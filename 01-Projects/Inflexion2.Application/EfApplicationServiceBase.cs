

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
        public UnityContainer unityContainer;
        protected string connString = null;
        protected RootAggregateFrameworkUnitOfWorkFactory<DomainUnitOfWork> ctxFactory = null;

        protected EfApplicationServiceBase()
        {
            this.unityContainer = new UnityContainer();

            ServiceLocator.Initialize(
                (x, y) => this.unityContainer.RegisterType(x, y),
                (x, y) => this.unityContainer.RegisterInstance(x, y),
                (x) => { return this.unityContainer.Resolve(x); },
                (x) => { return this.unityContainer.ResolveAll(x); });

            // Context Factory
            this.connString = this.ConnectionString();
            ctxFactory = new RootAggregateFrameworkUnitOfWorkFactory<DomainUnitOfWork>(this.connString);//1

            ctxFactory.ValidateDatabaseSchema();//1

            this.unityContainer.RegisterInstance<IDatabaseManager>(ctxFactory);//1

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
