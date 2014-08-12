using System.Windows.Controls; // este espacio de nombre pertenece al sdk de windows. que se encuentra en PresentationFramework
using Microsoft.Practices.Prism.Regions;
using Company.Product.Shared.UX.WPF.Module.ViewModels;

namespace Company.Product.Shared.UX.WPF.Module.Views
{
    /// <summary>
    /// Interaction logic for ModuleATaskButton.xaml
    /// </summary>
    [ViewSortHint("01")] // Este atributo nos permite ordenar los elementos que insertamos en una región. Es este caso sera el primero.
    public partial class ModuleATaskButton : UserControl
    {
        public ModuleATaskButton(ModuleATaskButtonViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
