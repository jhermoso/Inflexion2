using System.Windows.Controls;

// para soportar la navegación con parametros

namespace Inflexion.Framework.UX.WPF.ModuleA.Views
{

    using Inflexion.Framework.UX.WPF.ModuleA.ViewModels;
    /// <summary>
    /// Lógica de interacción para ModuleAWorkSpaceView2.xaml
    /// </summary>
    public partial class ModuleAWorkSpaceView2 : UserControl //, INavigationAware //codigo de ejemplo: la interface de InavigationAware se implementa para navegar a esta página cuando se utiliza codebehinde y no mvvm
    {
        public ModuleAWorkSpaceView2(ModuleAWorkSpaceViewModel2 ViewModel)
        {
            InitializeComponent();
            this.DataContext = ViewModel;
        }

        // codigo de ejemplo con codebehinde de la funcionalidad de navegación con parametros
        // este código se ha trasladado al correspondiente ModelView de la pagina para implementar el patrón MVVM
        //#region INavigationAware Members

        //public bool IsNavigationTarget(NavigationContext navigationContext)
        //{
        //    return true;
        //}

        //public void OnNavigatedTo(NavigationContext navigationContext)
        //{
        //    string ParametroRecibido= navigationContext.Parameters["TheText"];
        //    this.ReceptionTextBox.Text = ParametroRecibido;
        //    System.Windows.MessageBox.Show( String.Format("El parametro recibido es :/{0}/", ParametroRecibido));
        //}

        //public void OnNavigatedFrom(NavigationContext navigationContext)
        //{
        //    //throw new NotImplementedException();
        //}

        //#endregion

    }
}
