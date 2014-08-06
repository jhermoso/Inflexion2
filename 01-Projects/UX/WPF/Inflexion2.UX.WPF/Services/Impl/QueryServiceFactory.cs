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
    /// TODO: Update summary.
    /// </summary>
    public class QueryServiceFactory : IQueryServiceFactory
    {
        private static IDictionary<string, Type> registeredTypes = new Dictionary<string, Type>();

        public void RegisterInstance<TInterface, TService>()
            where TInterface : IQueryService
            where TService : TInterface
        {
            string serviceName = typeof(TInterface).FullName;

            RegisterInstance<TInterface, TService>(serviceName);
        }

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

        public TInterface GetInstance<TInterface>()
            where TInterface : IQueryService
        {
            string serviceName = typeof(TInterface).FullName;

            return (TInterface)GetInstance(serviceName);
        }
    }
}
