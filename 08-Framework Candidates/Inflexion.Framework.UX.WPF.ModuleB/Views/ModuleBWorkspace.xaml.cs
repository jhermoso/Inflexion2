using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Inflexion.Framework.UX.WPF.Common.Events;

using Microsoft.Practices.Prism.Events; // para la comunicación de datos atraves de un agregador de eventos
//using ComsEventAgregator;
using Inflexion.Framework.UX.WPF.Comms; // para la comunicación de datos atraves de un servicio


using System.ComponentModel.Composition; // para la comunicación de datos a traves del RegionContext

namespace Inflexion.Framework.UX.WPF.ModuleB.Views
{
    /// <summary>
    /// Logica de interacción para ModuleView.xaml
    /// </summary>
    public partial class ModuleBWorkspace : UserControl, IRegionMemberLifetime
    {
        #region Constructor

        // Para el paso de datos con el agregador de eventos
        // private Microsoft.Practices.Prism.Events.IEventAggregator eventAgregador ;
         private SubscriptionToken subscriptionToken;


        public ModuleBWorkspace(IStringCopyService stringCopyService)/*IEventAggregator eventAggregator*/
        {

            // código exclusivo para la recepción de un string a traves de un agregador de eventos.
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
           // eventAggregator.GetEvent<MyCopyDataAddedEvent>().Subscribe(OnCopyDataReceived, ThreadOption.UIThread);

            var evento = eventAggregator.GetEvent<MyCopyDataAddedEvent>();
            if (subscriptionToken != null)
            {
                evento.Unsubscribe(subscriptionToken);
            }
            subscriptionToken = evento.Subscribe(OnCopyDataReceived, ThreadOption.UIThread, true);

            InitializeComponent();

            //código exclusivo para recepción de un string a traves de un servicio compartido
            stringCopyService.CopyStringEvent += TheStringCopyService_CopyStringEvent;

            //código exclusivo para la recepción de datos atraves del regioncontext.
            // get the region context from the current view 
            // (which is plugged into the region)
            Microsoft.Practices.Prism.ObservableObject<object> regionContexto =
                RegionContext.GetObservableContext(this);

            // set an event handler to run when PropertyChanged event is fired
            regionContexto.PropertyChanged += regionContext_PropertyChanged;

        }

        //public ModuleBWorkspace(IEventAggregator eventAggregator)
        //{
        //    InitializeComponent();

        //    // código exclusivo para la recepción de un string a traves de un agregador de eventos.
        //    eventAggregator.
        //       GetEvent<CompositePresentationEvent<MyCopyData>>().
        //       Subscribe(OnCopyDataReceived);
        //}


        #endregion

        #region IRegionMemberLifetime Members

        public bool KeepAlive
        {
            get { return false; }
        }

        #endregion

        #region paso de datos a traves de servicio común

        void TheStringCopyService_CopyStringEvent(string copiedString)
        {
            recepcion.Text = copiedString;
        }
        #endregion

        #region Paso de parametros a traves de agregador de eventos
        // es obligatorio que sea publico!
        public void OnCopyDataReceived(MyCopyData copyData)
        {
            this.recepcion.Text = copyData.CopyString;
        }
        #endregion

        #region Paso de parametros desde el shel con RegionContext
        void regionContext_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // if region context's Value property changed assing the text block's text property
            // the value from region context's Value property
            if (e.PropertyName == "Value")
            {
                Microsoft.Practices.Prism.ObservableObject<object> obj = (Microsoft.Practices.Prism.ObservableObject<object>)sender;

                recepcion.Text = (string)obj.Value;
            }
        }
        #endregion
    }
}
