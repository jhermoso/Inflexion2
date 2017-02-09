// -----------------------------------------------------------------------
// <copyright file="IModalDialogService.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Services
{
    using System.Collections.Generic;

    /// <summary>
    /// navigation services with regions and views
    /// </summary>
    public interface INavigationService

    {
        /// <summary>
        /// open or focus a view in a region
        /// </summary>
        /// <param name="region"></param>
        /// <param name="view"></param>
        /// <param name="parameters"></param>
        void NavigateTo(string region, string view, IDictionary<string, string> parameters);

        /// <summary>
        /// open a view with a dynamic id entity
        /// </summary>
        /// <param name="view"></param>
        /// <param name="id"></param>
        void NavigateToWorkSpace(string view, dynamic id);

        /// <summary>
        /// open a view with parameters
        /// </summary>
        /// <param name="view"></param>
        /// <param name="parameters"></param>
        void NavigateToWorkSpace(string view, IDictionary<string, string> parameters);
    }
}
