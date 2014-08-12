using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using Inflexion2.Domain;
using Inflexion2;
using Inflexion2.Infrastructure;
using Inflexion2.Data;
using Inflexion2.Security;
using System.Configuration;

using CommonDomain;
using EFInfrastructure;

namespace EFexample
{
    class EfSqlTest
    {
         PerLifeTimeManager unitOfWorkPerTestLifeTimeManager = new PerLifeTimeManager();
         PerLifeTimeManager contextPerTestLifeTimeManager = new PerLifeTimeManager();
         UnityContainer unityContainer;
         string connString = null;

        public void starter()
        {
            this.unityContainer = new UnityContainer();

            ServiceLocator.Initialize(
                (x, y) => this.unityContainer.RegisterType(x, y),
                (x, y) => this.unityContainer.RegisterInstance(x, y),
                (x) => { return this.unityContainer.Resolve(x); },
                (x) => { return this.unityContainer.ResolveAll(x); });

            // Context Factory
            connString = this.ConnectionString();
            RootAggregateFrameworkUnitOfWorkFactory<MyDomainUnitOfWork> ctxFactory = new RootAggregateFrameworkUnitOfWorkFactory<MyDomainUnitOfWork>(connString);

            if (!ctxFactory.DatabaseExists())
            {
                ctxFactory.CreateDatabase();
            }

            ctxFactory.ValidateDatabaseSchema();

            this.unityContainer.RegisterInstance<IDatabaseManager>(ctxFactory);

            this.unityContainer.RegisterType<DbContext, MyDomainUnitOfWork>(this.contextPerTestLifeTimeManager, new InjectionConstructor(connString));

            this.unityContainer.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>(this.unitOfWorkPerTestLifeTimeManager);

            // Repositories
            this.unityContainer.RegisterType<IEntityARepository, EntityARepository>(new PerResolveLifetimeManager());
            this.unityContainer.RegisterType<IEntityBRepository, EntityBRepository>(new PerResolveLifetimeManager());

            ApplicationContext.User = new CorePrincipal(new CoreIdentity("cmendible", "hexa.auth", "cmendible@gmail.com"), new string[] { });
 
            // comienzan las operaciones
            // añadimos una entidad
            // metodo sin factoria y con constructor publico
            //var entityA = new EntityA();
            // entityA.Name = "Martin";
           // metodo con factoriay y constructor interno
            IEntityA entityA = EntityAFactory.Create("Martin");
           

            entityA.CanBeDeleted();

            IEntityARepository repo = this.unityContainer.Resolve<IEntityARepository>();
            repo.Add((EntityA)entityA);


            this.Commit();
            entityA.CanBeDeleted();

            // añadimos 2 entidades y su relación
            var a = EntityAFactory.Create("Willi");

            var b = EntityBFactory.Create("matematicas");
   

            a.AddB(b);

            IEntityARepository repoA = this.unityContainer.Resolve<IEntityARepository>();
            IEntityBRepository repoB = this.unityContainer.Resolve<IEntityBRepository>();

            repoB.Add((EntityB) b);
            repoA.Add((EntityA)a);
            
            this.Commit();


            //añadimos una entidad c dependiente de entidad a la primera entidad a

            EntityA padre = repoA.GetFilteredElements(e => e.Id == 1).FirstOrDefault();
            EntityC hijo = EntityCFactory.Create(padre, "hijo");
          
            this.Commit();

            padre = repoA.GetFilteredElements(e => e.Id == 1).FirstOrDefault();
            padre.CanBeDeleted();
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

        private IEntityA _Add_EntityA()
        {
            var entityA = EntityAFactory.Create("Santi");


            IEntityARepository repo = this.unityContainer.Resolve<IEntityARepository>();
            repo.Add((EntityA)entityA);

            this.Commit();

            return entityA;
        }
    }
}
