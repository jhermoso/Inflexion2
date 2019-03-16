// -----------------------------------------------------------------------
// <copyright file="IModalDialogService.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Services
{
    using System;
    using System.Collections.Generic;
    using Application;

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
        void NavigateToWorkSpace<TIdentifier>(string view, TIdentifier id);

        /// <summary>
        /// open a view with parameters
        /// </summary>
        /// <param name="view"></param>
        /// <param name="parameters"></param>
        void NavigateToWorkSpace(string view, IDictionary<string, string> parameters);

        /// <summary>
        /// Open a view record with some specifications.
        /// this used to restrict the values of the new record.
        /// </summary>
        /// <typeparam name="TIdentifier"></typeparam>
        /// <param name="fullName"></param>
        /// <param name="id"></param>
        /// <param name="specification"></param>
        void NavigateToWorkSpace<TIdentifier>(string fullName, TIdentifier id, SpecificationDto specification) where TIdentifier : IEquatable<TIdentifier>, IComparable<TIdentifier>;
    }
}
