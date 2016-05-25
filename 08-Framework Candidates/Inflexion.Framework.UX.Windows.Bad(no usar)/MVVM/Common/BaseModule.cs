// -----------------------------------------------------------------------
// <copyright file="BaseModule.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM
{
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    using Inflexion.Framework.UX.Windows.Security;
    using Inflexion.Framework.UX.Windows.Services;

    /// <summary>
    /// Clase base de módulo Prism.
    /// </summary>
    public abstract class BaseModule : IModule
    {
        #region Fields

        /// <summary>
        /// Referencia al gestor de regiones Prism.
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// Referencia al contenedor de inyección de dependencias Unity.
        /// </summary>
        private readonly IUnityContainer unityContainer;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:BaseModule"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:BaseModule"/>.
        /// </remarks>
        protected BaseModule()
        {
            this.regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this.unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();

            this.unityContainer.RegisterType<IMessageBoxService, MessageBoxService>();
            this.unityContainer.RegisterType<INavigationService, NavigationService>();
            this.RegisterQueryServiceFactory();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene la referencia al gestor de regiones Prism.
        /// </summary>
        /// <value>
        /// Referencia al gestor de regiones Prism.
        /// </value>
        protected IRegionManager RegionManager
        {
            get { return this.regionManager; }
        }

        /// <summary>
        /// Obtiene la referencia al contenedor de inyección de dependencias Unity.
        /// </summary>
        /// <value>
        /// Referencia al contenedor de inyección de dependencias Unity.
        /// </value>
        protected IUnityContainer UnityContainer
        {
            get { return this.unityContainer; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Inicializa el módulo.
        /// </summary>
        /// <remarks>
        /// Se registrará en las clases derivadas los controles que han de estar siempre disponibles
        /// con el gestor de regiones Prism (IRegionManager), y los controles que han de solicitarse
        /// (bajo demanda) con el contenedor de inyección de dependencias Unity.  Los controles bajo
        /// demanda seran cargados cuando se invoque el metodo "IregionManager.RequestNavigate()".
        /// <para>
        /// Miembro de la interfaz <see cref="T:Microsoft.Practices.Prism.Modularity.IModule"/>.
        /// </para>
        /// </remarks>
        public virtual void Initialize()
        {

        }

        #endregion

        #region Private Methods

        private void RegisterQueryServiceFactory()
        {
            IUnityContainer container = this.unityContainer;
            IQueryServiceFactory comboBoxServiceFactory = new QueryServiceFactory();
            container.RegisterInstance<IQueryServiceFactory>(comboBoxServiceFactory);
            RegisterQueryServices(comboBoxServiceFactory);
        }

        protected virtual void RegisterQueryServices(IQueryServiceFactory comboBoxServiceFactory)
        {

        }

        #endregion

    }
}