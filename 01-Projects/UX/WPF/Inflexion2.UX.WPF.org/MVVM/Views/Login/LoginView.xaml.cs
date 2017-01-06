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
using System.Windows.Shapes;

namespace Inflexion2.UX.WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        /// <summary>
        /// default parameterless constructor for the view of Login.
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
        }

    }
}
