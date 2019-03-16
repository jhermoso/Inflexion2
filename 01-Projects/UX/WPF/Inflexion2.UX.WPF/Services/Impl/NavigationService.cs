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
    using Application;

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
        public void NavigateToWorkSpace<TIdentifier>(string view, TIdentifier id)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Id", id.ToString());
            this.NavigateTo(RegionNames.WorkspaceRegion, view, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TIdentifier"></typeparam>
        /// <param name="view"></param>
        /// <param name="id"></param>
        /// <param name="specification"></param>
        public void NavigateToWorkSpace<TIdentifier>(string view, TIdentifier id, SpecificationDto specification) where TIdentifier : IEquatable<TIdentifier>, IComparable<TIdentifier>
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Id", id.ToString());

            if (specification.CompositeFilter != null)
            {
               foreach (var filter in specification.CompositeFilter.Filters)
                {
                    parameters.Add(string.Format("filter;{0}", filter.Property), string.Format("{0};{1}", filter.Operator, filter.Value));
                }
            }
 
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
