
namespace Inflexion2.Application
{
    #region usings
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

    #endregion


    /// <summary>
    /// Host e inicializacion del contenedor de IOC
    /// </summary>
    public static class ApplicationLayer
    {
        //#region fields
        /// <summary>
        /// ciclo de vida para la unidad de trabajo
        /// </summary>
        public static Inflexion2.Application.PerLifeTimeManager UnitOfWorkPerTestLifeTimeManager = new Inflexion2.Application.PerLifeTimeManager();

        /// <summary>
        /// ciclo de vida para el contexto
        /// </summary>
        public static Inflexion2.Application.PerLifeTimeManager ContextPerTestLifeTimeManager = new Inflexion2.Application.PerLifeTimeManager();
        //#endregion
        #region fields
        private static IUnityContainer iocContainer;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static IUnityContainer IocContainer
        {
            get
            {
                if (iocContainer == null) iocContainer = new UnityContainer();
                return iocContainer;
            }
        }

        /// <summary>
        /// Initialize the IoC container to allow the registering of types and objects.
        /// </summary>
        public static void ContainerInit()
        {
            ServiceLocator.Initialize(
                (x, y) => IocContainer.RegisterType(x, y),
                (x, y) => IocContainer.RegisterInstance(x, y),
                (x) => { return IocContainer.Resolve(x); },
                (x) => { return IocContainer.ResolveAll(x); });

        }
    }
}
