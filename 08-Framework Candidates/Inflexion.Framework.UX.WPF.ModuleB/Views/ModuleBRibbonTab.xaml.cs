using Microsoft.Practices.Prism.Regions;
using Microsoft.Windows.Controls.Ribbon;

namespace Inflexion.Framework.UX.WPF.ModuleB.Views
{
    /// <summary>
    /// Interaction logic for ModuleBRibbonTab.xaml
    /// </summary>
    public partial class ModuleBRibbonTab : RibbonTab, IRegionMemberLifetime
    {
        #region Constructor

        public ModuleBRibbonTab()
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
