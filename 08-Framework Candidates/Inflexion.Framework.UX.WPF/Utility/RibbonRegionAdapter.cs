
namespace PrismRibbonAdapter
{
    using System.Collections.Specialized;
    using System.Windows;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Windows.Controls.Ribbon;


    /// <summary>
    /// Habilita el uso de un control Ribbon como una región de tipo Prism.
    /// </summary>
    /// <remarks> Para esta sección se aconseja consultar la la guia de desarrollo de  Microsoft Prism (Ver. 4), página. 189. Region Adapters
    /// Para exponer un control de interface usuario como una region , hemos de utilizar un adaptador de region. Los adaptadores de region 
    /// son responsables de crear una región y asociarla a un control
    /// </remarks>
    public class RibbonRegionAdapter : RegionAdapterBase<Ribbon> // Para crear la nueva region heredamos de la clase RegionAdapterBase<NuevoTipoDeControl>
    {
        /// <summary>
        /// Constructor por efecto.
        /// </summary>
        /// <param name="behaviorFactory"> habilita el registro y establece el RegionBehaviors por defecto.</param>
        public RibbonRegionAdapter(IRegionBehaviorFactory behaviorFactory)
            : base(behaviorFactory)
        {
        }

        /// <summary>
        /// Adapta a WPF el control para ser servido como una region Prism IRegion. 
        /// </summary>
        /// <param name="region">La nueva region que ha de cumplir la interface Iregion</param>
        /// <param name="regionTarget">el control WPF ha adaptar</param>
        /// <remarks> La construcción de este ejemplo es paralela a la proporcionada en la documentación de Prism.
        /// </remarks>
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

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
