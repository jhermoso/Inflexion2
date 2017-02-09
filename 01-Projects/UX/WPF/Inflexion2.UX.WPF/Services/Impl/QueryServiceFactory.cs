// -----------------------------------------------------------------------
// <copyright file="IComboBoxService.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// IQueryServiceFactory implemetation <see cref="IQueryServiceFactory"/>
    /// </summary>
    public class QueryServiceFactory : IQueryServiceFactory
    {
        private static IDictionary<string, Type> registeredTypes = new Dictionary<string, Type>();

        /// <summary>
        /// <see cref="IQueryServiceFactory.RegisterInstance{TInterface, TService}()"/>
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TService"></typeparam>
        public void RegisterInstance<TInterface, TService>()
            where TInterface : IQueryService
            where TService : TInterface
        {
            string serviceName = typeof(TInterface).FullName;

            RegisterInstance<TInterface, TService>(serviceName);
        }

        /// <summary>
        /// <see cref="IQueryServiceFactory.RegisterInstance{TInterface, TService}(string) "/>
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TService"></typeparam>
        /// <param name="serviceName"></param>
        public void RegisterInstance<TInterface, TService>(string serviceName)
            where TInterface : IQueryService
            where TService : TInterface
        {
            string lowerCaseServiceName = serviceName.ToLower();

            if (registeredTypes.ContainsKey(lowerCaseServiceName))
            {
                throw new ApplicationException();
            }

            registeredTypes.Add(lowerCaseServiceName, typeof(TService));
            IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            unityContainer.RegisterType<TInterface, TService>(lowerCaseServiceName);
        }

        /// <summary>
        /// <see cref="IQueryServiceFactory.GetInstance(string) "/>
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public IQueryService GetInstance(string serviceName)
        {
            string lowerCaseServiceName = serviceName.ToLower();

            if (!registeredTypes.ContainsKey(lowerCaseServiceName))
            {
                throw new ApplicationException();
            }

            Type type = registeredTypes[lowerCaseServiceName];
            IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            return unityContainer.Resolve(type, lowerCaseServiceName) as IQueryService;
        }

        /// <summary>
        /// <see cref="IQueryServiceFactory.GetInstance{TInterface}"/>
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        public TInterface GetInstance<TInterface>()
            where TInterface : IQueryService
        {
            string serviceName = typeof(TInterface).FullName;

            return (TInterface)GetInstance(serviceName);
        }
    }
}
