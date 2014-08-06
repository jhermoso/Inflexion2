using System;
using System.Windows.Controls;
using Inflexion.Framework.UX.WPF.Comms;
//using ComsEventAgregator;               // para el paso de parametros con el agregador de eventos
using Inflexion.Framework.UX.WPF.Common.Events;           // para el paso de parametros con el agregador de eventos
using Microsoft.Practices.Prism.Events; // para el paso de parametros con el agregador de eventos
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Inflexion.Framework.UX.WPF.ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ModuleANavigator.xaml
    /// </summary>
    public partial class ModuleANavigator : UserControl, IRegionMemberLifetime
    {
        IRegionManager TheRegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
        int i = 0;

        public Inflexion.Framework.UX.WPF.Comms.IStringCopyService TheStringCopyService { private get; set; } // esta propiedad solo es relevante para el ejemplo de comunicación entre módulos con un servicio
        // todavia nos falta resolver el que la interface se mapea con la implementación de la clase que contiene el shell
        // en mef esto se hace con lo atributos de export e import en unity tenemos que registrar el mapeado de la interface con la clase implementada.

        // para el paso de parametros con el agregador de eventos
        public IEventAggregator TheEventAggregator;

        #region Constructor

        public ModuleANavigator()
        {
            InitializeComponent();
            button1.Click += NextViewButton_Click;
            button2.Click += new System.Windows.RoutedEventHandler(InjectViewButton_Click);
            button4.Click += VaciarRegion_Click;
            TheCopyButton.Click += NavConParametros_Click; // botón de navegación con paso de parametros
            LoadViewForeingModule.Click += LoadModuleBView_Click;

            CopyButton.Click += CopyButton_Click;
            buttonDataEventAgregator.Click += new System.Windows.RoutedEventHandler(EventAgregatorCopy_Click); // paso de datos con event agregator
        }

        #endregion

        #region IRegionMemberLifetime Members

        public bool KeepAlive
        {
            get { return false; }
        }

        #endregion

        #region handlers para la visualiazación de la vista 2
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

        #region handlers para la injección de la vista 2
        void InjectViewButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            IRegion region = TheRegionManager.Regions["WorkspaceRegion"];

            // View Injection
            region.Add
             (
                new TextBlock
                {
                    Text = "Hello" + ++i,
                    FontSize = 20,
                    Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue)
                }

            );
            //region.Add(new ModuleAWorkSpaceView2());
        }
        #endregion

        #region paso de parametros a una vista

        void NavConParametros_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Parametro1.Text == null)
                Parametro1.Text = "";

            // navigate passing the paramter "TheText" 
            TheRegionManager.RequestNavigate
            (
                "WorkspaceRegion",
                new Uri("ModuleAWorkSpaceView2?TheText=" + Parametro1.Text, UriKind.Relative),
                a => { }
            );
        }



        #endregion

        #region Vaciar la región de la vista actual
        void VaciarRegion_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vistasActivas = this.TheRegionManager.Regions["WorkspaceRegion"].ActiveViews;
            foreach (object vista in vistasActivas)
            {
                this.TheRegionManager.Regions["WorkspaceRegion"].Deactivate(vista);
                // this.TheRegionManager.Regions["WorkspaceRegion"].Remove(vista);
            }

        }
        #endregion

        #region Carga de una vista de otro modulo
        void LoadModuleBView_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            TheRegionManager.RequestNavigate
            (
                "WorkspaceRegion",
                new System.Uri("ModuleBWorkspace", System.UriKind.Relative),
                PostNavigationCallback
            );
        }

        #endregion

        #region Comunicación entre modulos utilizando un servicio basado en un evento

        void CopyButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Enviamos el texto utilizanod el servicio
            // obtenenos el contenedor
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

            TheStringCopyService = (IStringCopyService)container.Resolve(typeof(IStringCopyService));
            TheStringCopyService.Copy(Parametro1.Text);
        }
        #endregion

        #region paso de pararametros con event agregator
        void EventAgregatorCopy_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            TheEventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            // get a reference to the event from 
            // the event aggregator
            CompositePresentationEvent<MyCopyData> myCopyEvent =
                TheEventAggregator.GetEvent<MyCopyDataAddedEvent>();

            // get the data text from TheTextToCopyTextBox TextBox control
            MyCopyData copyData = new MyCopyData
            {
                CopyString = Parametro1.Text
            };

            //publish data via event aggregator
            myCopyEvent.Publish(copyData);
        }

        #endregion
    }
}
