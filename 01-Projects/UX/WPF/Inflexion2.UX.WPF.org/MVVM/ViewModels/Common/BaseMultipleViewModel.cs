// -----------------------------------------------------------------------
// <copyright file="ObservableObject.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Windows;
    using Microsoft.Practices.ServiceLocation;
    using MvvmValidation;

    using Inflexion2.UX.WPF.Services;
    using System.Collections.Generic;

    /// <summary>
    /// Clase base para cualquier tipo que deba proporcionar notificaciones de cambio de propiedad.
    /// </summary>
    public abstract class BaseMultipleViewModel: BaseViewModel, INotifyPropertyChanged, INotifyPropertyChanging, IDataErrorInfo
    {
        #region fields

        /// <summary>
        /// Indica el nombre de la región donde se va a mostrar la vista.
        /// </summary>
        public readonly string RegionName { get; set; }

        /// <summary>
        /// Indica el nombre de la vista que se va a mostrar.
        /// </summary>
        public readonly string ViewName { get; set; }

        #endregion


        #region Constructors

        public BaseMultipleViewModel(string regionName, string viewName)
            : base()
        {
            this.RegionName = regionName;
            this.ViewName = viewName;
        }

        #endregion


        #region Properties

 

        #endregion

    }
}
