// -----------------------------------------------------------------------
// <copyright file="IModalDialogService.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Prism;
    using Microsoft.Practices.Prism.Regions;

    using Inflexion2.UX.WPF.MVVM;

    public class NavigationService : INavigationService
    {
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

        public void NavigateToWorkSpace(string view, dynamic id)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Id", id.ToString());
            this.NavigateTo(RegionNames.WorkspaceRegion, view, parameters);
        }

        public void NavigateToWorkSpace(string view, IDictionary<string, string> parameters)
        {
            this.NavigateTo(RegionNames.WorkspaceRegion, view, parameters);
        }
    }
}
