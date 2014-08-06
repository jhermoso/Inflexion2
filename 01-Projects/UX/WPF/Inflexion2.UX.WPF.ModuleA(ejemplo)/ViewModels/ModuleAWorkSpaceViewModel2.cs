namespace Inflexion.Framework.UX.WPF.ModuleA.ViewModels
{
    using System;
    using Inflexion.Framework.UX.WPF.Common.GlobalCommands;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    public class ModuleAWorkSpaceViewModel2 : Inflexion.Framework.UX.WPF.Common.BaseClasses.ViewModelBase, INavigationAware // System.ComponentModel.INotifyPropertyChanged, esta no es necesario al heredar de ViewModelBase
    {
        private readonly LoadModuleBView2globalCommandProxy comandProxi;

        private string _RecepcionDato; // Esta propiedad actua como nuestro model para asociarlo por el datacontext al textbox de la vista que refleja el parámetro pasado.
        public string RecepcionDato
        {
            get
            {
                return _RecepcionDato;
            }
            set
            {
                base.RaisePropertyChangingEvent("RecepcionDato");
                _RecepcionDato = value;
                base.RaisePropertyChangedEvent("IsChecked");
            }
        }

        // 
        /// En el constructor de la clase instanciamos los CommandDelegate que vamos a asociar a nuestro viewmodel.
        // 
        public ModuleAWorkSpaceViewModel2(LoadModuleBView2globalCommandProxy comandProxi)
        {
            this.comandProxi = comandProxi;
            this.LoadView2Command = new DelegateCommand(this.Ejecutar);
            this.comandProxi.Loadview2Comando.RegisterCommand(this.LoadView2Command); //publicamos globalmente el comanndo para poder acceder desde otros modulos

        }





        #region INavigationAware Members

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            string ParametroRecibido = navigationContext.Parameters["TheText"];
            // ReceptionTextBox.Text = ParametroRecibido; // este codigo es para una implantación con codebehinde
            RecepcionDato = ParametroRecibido;
            System.Windows.MessageBox.Show(String.Format("El parametro recibido es :/{0}/", ParametroRecibido));
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #endregion


        #region Command Navegación a la vista 2 del módulo a con parametros

        public System.Windows.Input.ICommand LoadView2Command { get; private set; }


        private void Ejecutar()
        {
            System.Windows.MessageBox.Show("entramos en ejecutar");
            //this.OnExecuted(new Microsoft.Practices.Prism.Events.DataEventArgs<ModuleAWorkSpaceViewModel2>(this));
            IRegionManager TheRegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            TheRegionManager.RequestNavigate
                (
                    "WorkspaceRegion",
                    new System.Uri("ModuleAWorkSpaceView2", System.UriKind.Relative),
                    PostNavigationCallback
                );
        }

        private bool PuedeEjecutar()
        {
            return true;
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
