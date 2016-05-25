// -----------------------------------------------------------------------
// <copyright file="IModalDialogService.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;

    public interface INavigationService
    {
        void NavigateTo(string region, string view, IDictionary<string, string> parameters);
        void NavigateToWorkSpace(string view, int id);
        void NavigateToWorkSpace(string view, IDictionary<string, string> parameters);
    }
}
