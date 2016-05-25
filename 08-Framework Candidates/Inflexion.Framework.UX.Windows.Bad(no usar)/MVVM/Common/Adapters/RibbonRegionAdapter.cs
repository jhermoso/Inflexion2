// -----------------------------------------------------------------------
// <copyright file="RibbonRegionAdapter.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.Adapters
{
    using System.Collections.Specialized;
    using System.Windows;

    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Windows.Controls.Ribbon;

    /// <summary>
    /// Adaptador que habilita el uso del control Ribbon como una región Prism.
    /// </summary>
    public class RibbonRegionAdapter : RegionAdapterBase<Ribbon>
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:RibbonRegionAdapter"/>.
        /// </summary>
        /// <param name="behaviorFactory">
        /// Permite el registro de la configuración por defecto de los comportamientos de la región.
        /// </param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:RibbonRegionAdapter"/>.
        /// </remarks>
        public RibbonRegionAdapter(IRegionBehaviorFactory behaviorFactory)
            : base(behaviorFactory)
        {

        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Adapta un control WPF para servir como una región Prism.
        /// </summary>
        /// <param name="region">
        /// La nueva región que se utiliza.
        /// </param>
        /// <param name="regionTarget">
        /// El control WPF que se va a adaptar.
        /// </param>
        protected override void Adapt(IRegion region, Ribbon regionTarget)
        {
            region.Views.CollectionChanged += (sender, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (FrameworkElement element in e.NewItems)
                        {
                            regionTarget.Items.Add(element);
                        }
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        foreach (UIElement elementLoopVariable in e.OldItems)
                        {
                            var element = elementLoopVariable;
                            if (regionTarget.Items.Contains(element))
                            {
                                regionTarget.Items.Remove(element);
                            }
                        }
                        break;
                }
            };
        }

        /// <summary>
        /// Crea una región.
        /// </summary>
        /// <returns>
        /// La región creada.
        /// </returns>
        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }

        #endregion
    }
}