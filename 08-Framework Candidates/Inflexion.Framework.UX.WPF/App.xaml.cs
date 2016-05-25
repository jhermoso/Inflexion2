namespace Inflexion.Framework.UX.WPF
{
    using System.Windows;
    using Inflexion.Framework.UX.WPF.Shell;

    /// <summary>
    /// lógica de interación para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configuración y arranque del Bootstrapper
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
