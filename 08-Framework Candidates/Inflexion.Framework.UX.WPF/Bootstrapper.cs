using System.Windows;
using Microsoft.Practices.Prism.Modularity;


namespace Inflexion.Framework.UX.WPF.Shell
{
    using Inflexion.Framework.UX.WPF.Shell.Views;
    using Microsoft.Practices.Prism;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.UnityExtensions;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Windows.Controls.Ribbon;
    using PrismRibbonAdapter;

    public class Bootstrapper : UnityBootstrapper
    {
        #region Method Overrides

        /// <summary>
        /// Proporciona el contenido del catalogo de módulos.
        /// </summary>
        /// <returns>un nuevo Module Catalog.</returns>
        /// <remarks>
        /// Este metodo usa el metodo de descubrimiento de modulos para "rellenar" el catalogo de modulos
        /// Esto implica establecer un evento de postcompilación en las propiedades del proyecto que copie 
        /// los ensamblados obtenidos en la compilación del mismo hasta el directorio donde le decimos que podra 
        /// encontrar dichos modulos.
        /// </remarks>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            var moduleCatalog = new DirectoryModuleCatalog();
            moduleCatalog.ModulePath = @".\Modules";
            return moduleCatalog;
        }

        /// <summary>
        /// Configuramos La región que por defecto adapta el mapeado a utilizar en la aplicación.
        /// Esto significa que mapeamos los controles de usuario definidos en xaml para ser 
        /// albergados en una región y registrarlos de forma automática. 
        /// </summary>
        /// <returns>La instancia de RegionAdapterMappings que contiene todo el mapeado.</returns>
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            // invocamos el metodo base
            var mappings = base.ConfigureRegionAdapterMappings();
            if (mappings == null) return null;

            // añadimos nuestros mappings 
            var ribbonRegionAdapter = ServiceLocator.Current.GetInstance<RibbonRegionAdapter>();
            mappings.RegisterMapping(typeof(Ribbon), ribbonRegionAdapter); // Asociamos el tipo "Ribbon" a la región definida en el Shell como RibbonRegionAdapter

            // valor de retorno con el mapeado de la region de ribbon.
            return mappings;
        }

        /// <summary>
        /// este metodo instancia la ventana de Shell.
        /// </summary>
        /// <returns>A new ShellWindow window.</returns>
        protected override DependencyObject CreateShell()
        {
            // Este metodo establece el UnityBootstrapper. 
            // La propiedad Shell obtiene el valor de la ventana ShellWindow
            // que ha sido definida dentro de la carpeta de views en Xaml.
            // es conveniente observar que la base de UnityBootstrapper esta asociado una instancia de 
            // Region manager en la nueva ventana de Shell.

            return new ShellWindow();
        }

        /// <summary>
        /// Una vez instanciado el shell lo visulizamos
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();



        }

        #endregion
    }
}