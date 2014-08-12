

namespace NHexample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using NHibernate;
    using FluentNHibernate;
    using Microsoft.Practices.Unity;
    using Inflexion2.Domain;
    using Inflexion2;
    using Inflexion2.Infrastructure;
    using Inflexion2.Data;
    using Inflexion2.Security;
    using System.Configuration;

    class NhSqlTest
    {
        PerLifeTimeManager unitOfWorkPerTestLifeTimeManager = new PerLifeTimeManager();
        PerLifeTimeManager sessionPerTestLifeTimeManager = new PerLifeTimeManager();
        UnityContainer unityContainer;
        public void starter()
        {

            this.unityContainer = new UnityContainer();
            ServiceLocator.Initialize(
                (x, y) => this.unityContainer.RegisterType(x, y),
                (x, y) => this.unityContainer.RegisterInstance(x, y),
                (x) => { return unityContainer.Resolve(x); },
                (x) => { return unityContainer.ResolveAll(x); });

            NHibernateUnitOfWorkFactory<int> ctxFactory = this.CreateNHContextFactory();
 
            if (!ctxFactory.DatabaseExists())
            {
                ctxFactory.CreateDatabase();
            }

            ctxFactory.ValidateDatabaseSchema();

            NHibernate.ISessionFactory sessionFactory = ctxFactory.Create();

            this.unityContainer.RegisterInstance<NHibernate.ISessionFactory>(sessionFactory);           
            this.unityContainer.RegisterInstance<IDatabaseManager>(ctxFactory);

            this.unityContainer.RegisterType<ISession, ISession>(this.sessionPerTestLifeTimeManager, new InjectionFactory((c) =>
            {
                ISession session = sessionFactory.OpenSession();
                session.Transaction.Begin();
                
                return session;
            }));

            this.unityContainer.RegisterType<IUnitOfWork, NHibernateUnitOfWork>(this.unitOfWorkPerTestLifeTimeManager);

            // Repositories
            this.unityContainer.RegisterType<IEntityARepository, EntityANHRepository>(new PerResolveLifetimeManager());
            this.unityContainer.RegisterType<IEntityBRepository, EntityBNHRepository>(new PerResolveLifetimeManager());

            ApplicationContext.User =
                new CorePrincipal(new CoreIdentity("cmendible", "hexa.auth", "cmendible@gmail.com"), new string[] { });

            // comienzan las operaciones
            // añadimos una entidad
            var entityA = new EntityA();
            entityA.Name = "Martin4";

            var repo = this.unityContainer.Resolve<IEntityARepository>();
            repo.Add(entityA);

            //this.Commit();
            // al contrario que en ef aqui no tenemos commint
            // añadimos 2 entidades y su relación
            var a = new EntityA();
            a.Name = "willi4";

            var b = new EntityB();
            b.Name = "matematicas";

            a.AddB(b);

            var repoA = this.unityContainer.Resolve<IEntityARepository>();
            var repoB = this.unityContainer.Resolve<IEntityBRepository>();

            repoB.Add(b);
            repoA.Add(a);
            this.RollBack();

/////////////////////////////////////////////////////////////////////////////////////////////


            IUnitOfWork unitOfWork = this.unityContainer.Resolve<IUnitOfWork>();
            unitOfWork.Dispose();

            this.unitOfWorkPerTestLifeTimeManager.RemoveValue();
            this.sessionPerTestLifeTimeManager.RemoveValue();

        }

        protected virtual NHibernateUnitOfWorkFactory<int> CreateNHContextFactory()
        {
            return new NHibernateUnitOfWorkFactory<int>(DbProvider.MsSqlProvider, this.ConnectionString(), string.Empty, new Assembly[] { Assembly.GetExecutingAssembly() });
        }

        protected virtual string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Sql.Connection"].ConnectionString;
        }

        private EntityA _Add_EntityA()
        {
            var entityA = new EntityA();
            entityA.Name = "Martin";

            var repo = this.unityContainer.Resolve<IEntityARepository>();
            repo.Add(entityA);

           // this.Commit();

            return entityA;
        }

        public void Commit()
        {
            IUnitOfWork unitOfWork = this.unityContainer.Resolve<IUnitOfWork>();
            unitOfWork.Commit();
        }
        public void RollBack()
        {
            IUnitOfWork unitOfWork = this.unityContainer.Resolve<IUnitOfWork>();
            unitOfWork.RollbackChanges();
        }
    }
}
