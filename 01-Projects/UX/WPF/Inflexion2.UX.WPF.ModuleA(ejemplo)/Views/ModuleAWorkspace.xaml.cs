using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Inflexion.Framework.UX.WPF.ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ModuleView.xaml
    /// </summary>
    public partial class ModuleAWorkspace : UserControl, IRegionMemberLifetime
    {
        IRegionManager TheRegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

        #region Constructor

        public ModuleAWorkspace()
        {
            InitializeComponent();
            button1.Click += NextViewButton_Click;
        }

        #endregion

        #region IRegionMemberLifetime Members

        public bool KeepAlive
        {
            get { return false; }
        }

        #endregion

        #region handlers
        void NextViewButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TheRegionManager.RequestNavigate
            (
                "WorkspaceRegion",
                new System.Uri("ModuleAWorkSpaceView2", System.UriKind.Relative),
                PostNavigationCallback
            );
        }

        void PostNavigationCallback(NavigationResult navigationResult)
        {
            if (navigationResult.Result == true)
                System.Windows.MessageBox.Show("Navigation Successful");
            else
                System.Windows.MessageBox.Show("Navigation Failed");
        }
        #endregion

    }
}
