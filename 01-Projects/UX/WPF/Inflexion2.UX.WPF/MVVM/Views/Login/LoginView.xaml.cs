

namespace Inflexion2.UX.WPF
{
    using System.Windows;
    using Inflexion2.UX.WPF.MVVM.ViewModels;
    using Inflexion2.UX.WPF.Helpers;
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        /// <summary>
        /// Esta propiedad es para salvar en la configuración del usuario el idioma seleccionado.
        /// </summary>
        public static DependencyProperty WindowLanguajeProperty;

        //private readonly WindowSettings windowSettings;

        /// <summary>
        /// default parameterless constructor for the view of Login.
        /// </summary>
        public LoginView()
        {
            
            //inicializacion de los settings para memorizar la posición de la ventana y la opcion preferida del lenguaje.
            //windowSettings = new WindowSettings(this);
            //WindowLanguajeProperty =
            //DependencyProperty.Register(
            //"WindowLanguaje", typeof(string), typeof(Inflexion2.UX.WPF.MVVM.Views.ShellWindow), /*ApplicationSettings Inflexion2.UX.WPF.MVVM.Views.ShellWindow registramos en los settings de la ventana principal*/
            //new FrameworkPropertyMetadata("0", FrameworkPropertyMetadataOptions.AffectsRender));



            InitializeComponent();
            this.DataContext = new LoginViewModel();

            //windowSettings.Settings.Add(
            //    new DependencyPropertySetting(this, WindowLanguajeProperty, WindowLanguaje));
        }

        /// <summary>
        /// Atributo para dar soporte a la propiedad de dependencia en la que almacenamos el lenguaje elegido
        /// </summary>
        public string WindowLanguaje
        {
            get { return (string)GetValue(WindowLanguajeProperty); }
            set { SetValue(WindowLanguajeProperty, value); }
        }
    }
}
