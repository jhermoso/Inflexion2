// -----------------------------------------------------------------------
// <copyright file="IModalDialogService.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Services
{
    using Inflexion2.UX.WPF.MVVM;
    using Microsoft.Practices.Prism;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="INavigationService"/> implementation
    /// </summary>
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// <see cref="INavigationService.NavigateToWorkSpace(string, IDictionary{string, string})"/>
        /// </summary>
        /// <param name="region"></param>
        /// <param name="view"></param>
        /// <param name="parameters"></param>
        public void NavigateTo(string region, string view, IDictionary<string, string> parameters)
        {
            IRegionManager regionManger = ServiceLocator.Current.GetInstance<IRegionManager>();

            var uriQuery = new UriQuery();
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                uriQuery.Add(parameter.Key, parameter.Value);
            }

            Uri uri = new Uri(view + uriQuery.ToString(), UriKind.Relative);

            regionManger.RequestNavigate(region, uri);
        }

        /// <summary>
        /// <see cref="INavigationService.NavigateToWorkSpace(string, dynamic)"/>
        /// </summary>
        /// <param name="view"></param>
        /// <param name="id"></param>
        public void NavigateToWorkSpace(string view, dynamic id)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Id", id.ToString());
            this.NavigateTo(RegionNames.WorkspaceRegion, view, parameters);
        }

        /// <summary>
        /// <see cref="INavigationService.NavigateToWorkSpace(string, IDictionary{string, string})"/>
        /// </summary>
        /// <param name="view"></param>
        /// <param name="parameters"></param>
        public void NavigateToWorkSpace(string view, IDictionary<string, string> parameters)
        {
            this.NavigateTo(RegionNames.WorkspaceRegion, view, parameters);
        }
    }
}
