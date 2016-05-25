using Microsoft.Practices.Prism.Regions;
using Microsoft.Windows.Controls.Ribbon;

namespace Inflexion.Framework.UX.WPF.ModuleA.Views
{
    /// <summary>
    /// logica de interacción para ModuleARibbonTab.xaml
    /// </summary>
    public partial class ModuleARibbonTab : RibbonTab, IRegionMemberLifetime
    {
        #region Constructor

        public ModuleARibbonTab()
        {
            InitializeComponent();
        }

        #endregion

        #region IRegionMemberLifetime Members

        public bool KeepAlive
        {
            get { return false; }
        }

        #endregion
    }
}
