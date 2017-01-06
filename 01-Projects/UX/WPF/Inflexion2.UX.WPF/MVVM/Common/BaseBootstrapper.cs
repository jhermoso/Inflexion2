// -----------------------------------------------------------------------
// <copyright file="BaseBootstrapper.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM
{
    #region Imports

    using AvalonDock;
    using AvalonDock.Layout;
    using Inflexion2.UX.WPF.MVVM.Adapters;
    using Inflexion2.UX.WPF.MVVM.Views;
    using Inflexion2.UX.WPF.Security;
    using Inflexion2.UX.WPF.Services;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.UnityExtensions;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Windows.Controls.Ribbon;
    using System;
    using System.Diagnostics;
    using System.Globalization;
    //using Telerik.Windows.Controls;
    //using Inflexion.Framework.Application.Security.Data.Base; //TODO: Descomentar al meter seguridad con nuevo naming
    using System.ServiceModel;
    using System.Threading;
    using System.Windows;
    using System.Windows.Threading;

    #endregion

    /// <summary>
    /// Clase base de programa previo (arranque Prism).
    /// </summary>
    public abstract class BaseBootstrapper : UnityBootstrapper
    {
        #region Fields

        /// <summary>
        /// Filtro de búsqueda de módulos.
        /// </summary>
        private readonly string moduleSearchFilter;

        /// <summary>
        /// Ruta de búsqueda de módulos.
        /// </summary>
        private readonly string moduleSearchPath;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:BootstrapperBase"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:BootstrapperBase"/>.
        /// <para>
        /// La ruta de búsqueda de módulos por defecto es la ruta del directorio
        /// donde se encuentra el ejecutable de la aplicación.
        /// </para>
        /// <para>
        /// El filtro de búsqueda de módulos por defecto es "*.dll".
        /// </para>
        /// </remarks>
        protected BaseBootstrapper()
            : this(string.Empty, string.Empty)
        {
            
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:BootstrapperBase"/>.
        /// </summary>
        /// <param name="searchFilter">
        /// Filtro de búsqueda de módulos.
        /// </param>
        /// <param name="searchPath">
        /// Ruta de búsqueda de módulos.
        /// </param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:BootstrapperBase"/>.
        /// </remarks>
        protected BaseBootstrapper(string searchFilter, string searchPath)
        {
            this.moduleSearchFilter = searchFilter;
            this.moduleSearchPath = searchPath;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene el filtro de búsqueda de módulos.
        /// </summary>
        /// <value>
        /// Cadena que contiene el filtro de búsqueda de módulos.
        /// </value>
        private string ModuleSearchFilter
        {
            get { return this.moduleSearchFilter; }
        }

        /// <summary>
        /// Obtiene la ruta de búsqueda de módulos.
        /// </summary>
        /// <value>
        /// Cadena que contiene la ruta de búsqueda de módulos.
        /// </value>
        private string ModuleSearchPath
        {
            get { return this.moduleSearchPath; }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Configura las asignaciones para el adaptador de región por defecto.
        /// </summary>
        /// <returns>
        /// Asignaciones configuradas para el adaptador de región por defecto.
        /// </returns>
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var regionAdapterMappings = base.ConfigureRegionAdapterMappings();
            if (regionAdapterMappings != null)
            {
                // Configurar el adaptador de región para Ribbon.
                var ribbonRegionAdapter = ServiceLocator.Current.GetInstance<RibbonRegionAdapter>();
                regionAdapterMappings.RegisterMapping(typeof(Ribbon), ribbonRegionAdapter);

                regionAdapterMappings.RegisterMapping(typeof(LayoutAnchorable), new AnchorableRegionAdapter(ServiceLocator.Current.GetInstance<RegionBehaviorFactory>()));
                regionAdapterMappings.RegisterMapping(typeof(DockingManager), new DockingManagerRegionAdapter(ServiceLocator.Current.GetInstance<RegionBehaviorFactory>()));
            }

            return regionAdapterMappings;
        }

        /// <summary>
        /// Configura el catálogo de módulos.
        /// </summary>
        /// <returns>
        /// Catálogo de módulos configurado.
        /// </returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            var moduleCatalog = new FilteredDirectoryModuleCatalog();

            // Utilizar el filtro de búsqueda de módulos si procede.
            if (!string.IsNullOrWhiteSpace(this.ModuleSearchFilter))
            {
                moduleCatalog.Filter = this.ModuleSearchFilter;
            }

            // Utilizar la ruta de búsqueda de módulos si procede.
            if (!string.IsNullOrWhiteSpace(this.ModuleSearchPath))
            {
                moduleCatalog.ModulePath = this.ModuleSearchPath;
            }

            return moduleCatalog;
        }

        /// <summary>
        /// Crea la ventana principal de aplicación.
        /// </summary>
        /// <returns>
        /// Instancia creada de la ventana principal de aplicación.
        /// </returns>
        protected override DependencyObject CreateShell()
        {
            var shell = new ShellWindow();

            return shell;
        }

        /// <summary>
        /// Inicializa la ventana principal de aplicación.
        /// </summary>
        protected override void InitializeShell()
        {
            // Configuración para Telerik
            //StyleManager.ApplicationTheme = new Windows8Theme();

            //Windows8Colors.PaletteInstance.MainColor = Colors.White;
            //Windows8Colors.PaletteInstance.AccentColor = Colors.Gray;
            //Windows8Colors.PaletteInstance.BasicColor = Colors.DarkGray;
            //Windows8Colors.PaletteInstance.StrongColor = (Color)ColorConverter.ConvertFromString("#999999");
            //Windows8Colors.PaletteInstance.MarkerColor = (Color)ColorConverter.ConvertFromString("#5C5C5C");
            //Windows8Colors.PaletteInstance.ValidationColor = Colors.Red;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("es");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");

            base.InitializeShell();

            var shell = this.Shell as Window;
            if (shell != null)
            {
                var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
                regionManager.RegisterViewWithRegion(RegionNames.WorkspaceRegion, typeof(Inflexion2.UX.WPF.MVVM.Views.Presentation.PresentationView));
                Application.Current.MainWindow = shell;
                shell.Show();
            }
        }

        /// <summary>
        /// execution of bootstrapper
        /// </summary>
        /// <param name="runWithDefaultConfiguration"></param>
        public override void Run(bool runWithDefaultConfiguration)
        {
            AccessBehavior.Provider = new AccessLevelProvider();

            if (Debugger.IsAttached)
            {
                BindingListener.SetTrace();
            }

            Application.Current.DispatcherUnhandledException +=
                new DispatcherUnhandledExceptionEventHandler(
                    this.OnAppDispatcherUnhandledException);

            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            // Authenticate the current user and set the default principal
            LoginView auth = new LoginView();
            auth.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bool? dialogResult = auth.ShowDialog();

            // deal with the results
            if (dialogResult.HasValue && dialogResult.Value)
            {
                //AppDomain.CurrentDomain.SetThreadPrincipal(auth.NewPrincipal);
                base.Run(runWithDefaultConfiguration);
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            }
            else
            {
                Application.Current.Shutdown(-1);
            }
        }

        private void OnAppDispatcherUnhandledException(
            object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            IMessageBoxService messageBoxService = ServiceLocator.Current.GetInstance<IMessageBoxService>();

            FaultException<Inflexion2.UX.WPF.Fault.ValidationException> validationException = e.Exception as FaultException<Inflexion2.UX.WPF.Fault.ValidationException>;
            if (validationException != null)
            {
                // Mostramos el error
                string validationMessage = string.Empty;
                foreach (var error in validationException.Detail.ValidationErrors)
                {
                    validationMessage = validationMessage + error + Environment.NewLine;
                }

                // Mostramos el mensaje.
                messageBoxService.Show(
                                            validationMessage,
                                            System.Windows.Application.Current.MainWindow.Title,
                                            System.Windows.MessageBoxButton.OK,
                                            System.Windows.MessageBoxImage.Error);

                e.Handled = true;
                return;
            }

            FaultException<Inflexion2.UX.WPF.Fault.InternalException> faultObject = e.Exception as FaultException<Inflexion2.UX.WPF.Fault.InternalException>;
            if (faultObject != null)
            {
                // Mostramos el mensaje.
                messageBoxService.Show(
                                            faultObject.Detail.Reason,
                                            System.Windows.Application.Current.MainWindow.Title,
                                            System.Windows.MessageBoxButton.OK,
                                            System.Windows.MessageBoxImage.Error);

                e.Handled = true;
                return;
            }

            string message = "UNHANDLED EXCEPTION: " +
                Environment.NewLine +
                Environment.NewLine +
                e.Exception.GetType().Name +
                Environment.NewLine +
                Environment.NewLine +
                e.Exception.Message;

            // Mostramos el mensaje.
            messageBoxService.Show(
                                        message,
                                        System.Windows.Application.Current.MainWindow.Title,
                                        System.Windows.MessageBoxButton.OK,
                                        System.Windows.MessageBoxImage.Error);
            e.Handled = true;

            //Application.Current.Shutdown(-1);
        }

        #endregion
    }
}