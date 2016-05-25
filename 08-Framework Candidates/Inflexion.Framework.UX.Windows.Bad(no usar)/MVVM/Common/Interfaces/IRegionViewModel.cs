// -----------------------------------------------------------------------
// <copyright file="IRegionViewModel.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM
{
    using Microsoft.Practices.Prism;
    using Microsoft.Practices.Prism.Regions;

    /// <summary>
    /// Interfaz para las clases modelo de vista (MVVM) que utilizan regiones Prism.
    /// </summary>
    public interface IRegionViewModel : IActiveAware, INavigationAware, IRegionMemberLifetime
    {

    }
}