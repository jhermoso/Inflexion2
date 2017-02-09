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

    /// <summary>
    /// IQuery service Factory Interface
    /// </summary>
    public interface IQueryServiceFactory
    {
        /// <summary>
        /// Register an instance of query service 
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TService"></typeparam>
        void RegisterInstance<TInterface, TService>()
            where TInterface : IQueryService
            where TService : TInterface;

        /// <summary>
        /// REgister a query instace of a query service with a service name
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TService"></typeparam>
        /// <param name="serviceName"></param>
        void RegisterInstance<TInterface, TService>(string serviceName)
            where TInterface : IQueryService
            where TService : TInterface;

        /// <summary>
        /// Get the instance of the service name
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        IQueryService GetInstance(string serviceName);

        /// <summary>
        /// Get the instance of one interface
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        TInterface GetInstance<TInterface>()
            where TInterface : IQueryService;
    }
}
