using System;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Inflexion2.Application;

using Inflexion2.Domain;
using Inflexion2.Data;

using EFexample;
using EFApplication;
using EFInfrastructure;


namespace EFApplication.Services
{
    public class BoundedContestEfApplicationServiceBase : 
        Inflexion2.Application.EfApplicationServiceBase
    {
        protected BoundedContestEfApplicationServiceBase(): base()
        {

            // Context Factory
            //RootAggregateFrameworkUnitOfWorkFactory<BootstrapUnitOfWork> ctxFactory = new RootAggregateFrameworkUnitOfWorkFactory<MyDomainUnitOfWork>(this.ConnectionString());

            //ctxFactory.ValidateDatabaseSchema();

            //this.unityContainer.RegisterInstance<IDatabaseManager>(ctxFactory);

            //this.unityContainer.RegisterType<DbContext, BootstrapUnitOfWork>(this.contextPerTestLifeTimeManager, new InjectionConstructor(this.ConnectionString()));

            //this.unityContainer.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>(this.unitOfWorkPerTestLifeTimeManager);

        }


    }
}
