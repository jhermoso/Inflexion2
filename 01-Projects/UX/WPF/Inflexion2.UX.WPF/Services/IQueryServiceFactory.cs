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
    /// TODO: Update summary.
    /// </summary>
    public interface IQueryServiceFactory
    {
        void RegisterInstance<TInterface, TService>()
            where TInterface : IQueryService
            where TService : TInterface;

        void RegisterInstance<TInterface, TService>(string serviceName)
            where TInterface : IQueryService
            where TService : TInterface;

        IQueryService GetInstance(string serviceName);

        TInterface GetInstance<TInterface>()
            where TInterface : IQueryService;
    }
}
