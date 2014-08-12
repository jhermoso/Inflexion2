using Microsoft.Practices.Prism.Regions;
using Microsoft.Windows.Controls.Ribbon;// assembly RibbonControlsLibrary

namespace EF.UX.WPF.Module.Prism
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
