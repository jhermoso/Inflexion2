// -----------------------------------------------------------------------
// <copyright file="IRegionViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM
{
    using Microsoft.Practices.Prism;
    using Microsoft.Practices.Prism.Regions;

    /// <summary>
    /// Interfaz para las clases modelo de vista (MVVM) que utilizan regiones Prism.
    /// </summary>
    public interface IRegionViewModel : IActiveAware, INavigationAware, IRegionMemberLifetime
    {
        /// <summary>
        /// Method to be overrided in viewmodels and deactivate all the nested viewmodels 
        /// of usercontrols implemented to manage children realtionships that appears like 
        /// 
        /// </summary>
        void DeactivateChildrenCollections();
    }
}