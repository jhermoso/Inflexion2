using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Inflexion.Framework.UX.Windows.MVVM.ViewModels;

namespace Inflexion.Framework.UX.Windows.MVVM.Views.Presentation
{
    /// <summary>
    /// Interaction logic for PresentationView.xaml
    /// </summary>
    public partial class PresentationView : UserControl
    {
        public PresentationView()
        {
            InitializeComponent();
            this.DataContext = new PresentationViewModel();
        }
    }
}
