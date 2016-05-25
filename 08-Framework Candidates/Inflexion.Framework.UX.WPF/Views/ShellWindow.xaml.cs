using Microsoft.Windows.Controls.Ribbon;

using Microsoft.Practices.Prism.Regions; // para el envio de datos atraves de regionContext a los modulos
using Microsoft.Practices.ServiceLocation;

namespace Inflexion.Framework.UX.WPF.Shell.Views
{
    /// <summary>
    /// Logiva de interacción para la vista del shell ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : RibbonWindow
    {
        // public IRegionManager TheRegionManager { private get; set; } //mef
        IRegionManager TheRegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

        public ShellWindow()
        {

            InitializeComponent();

            // Insertar el codigo que se necesite en la creació del objeto en este punto.

            SendParamRegionContext.Click += new System.Windows.RoutedEventHandler(SendParamRegionContext_Click);
        }

        void SendParamRegionContext_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // get the region context from the region defining control
            Microsoft.Practices.Prism.ObservableObject<object> regionContext =
                RegionContext.GetObservableContext(WorkspaceRegion);

            // set the region context's value to the string we want to copy
            regionContext.Value = ShellParameter1.Text;
        }
    }
}
