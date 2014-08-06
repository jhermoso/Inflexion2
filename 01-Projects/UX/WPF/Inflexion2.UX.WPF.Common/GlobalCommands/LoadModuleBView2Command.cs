namespace Inflexion2.UX.WPF.Common.GlobalCommands
{
    using Microsoft.Practices.Prism.Commands; // este namespace necesita del ensemblado presentation core para poder implementar la interface ICommand
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    public class LoadModuleBView2Command
    {
        private readonly LoadModuleBView2globalCommandProxy comandProxi;
        public System.Windows.Input.ICommand LoadView2Command { get; private set; }


        public LoadModuleBView2Command(LoadModuleBView2globalCommandProxy comandProxi)
        {
            this.comandProxi = comandProxi;
            this.LoadView2Command = new DelegateCommand(this.Ejecutar);
            this.comandProxi.Loadview2Comando.RegisterCommand(this.LoadView2Command); //publicamos globalmente el comanndo para poder acceder desde otros modulos

        }

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
    }
}
