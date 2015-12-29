using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;
using Inflexion.Framework.UX.WPF.ModuleA.ViewModels;

namespace Inflexion.Framework.UX.WPF.ModuleA.Views
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
