using System;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;


namespace Inflexion.Framework.UX.WPF.ModuleA
{
    using Inflexion.Framework.UX.WPF.Comms; // ESTA REFERENCIA ES EXCLUSIVAMENTE PARA INCLUIR LA COMUNICACIÓN ENTRE MODULOS ATRAVES DE UN SERVICIO COMÚN 
    using Inflexion.Framework.UX.WPF.ModuleA.Views;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// clase de incialización para el Modulo A.
    /// </summary>
    public class ModuleA : IModule
    {
        #region IModule Members

        /// <summary>
        /// Inicializa el modulo.
        /// </summary>
        public void Initialize()
        {
            //todos los modulos heredan la interface de Imodule y tienen como propiedad una instancia de Region manager.
            // recordar que los miembros de Regionmanager son estáticos.

            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            /* Registramos siempre los controles que han de estar siempre disponibles con el Prism Region Manager, 
             * y los controles que han solicitarse (bajo demanda) con el contenedor de inyección de dependencias en este caso el de Unity.
             * Los controles bajo demanda seran cargados cuando invoquemos el metodo IregionManager.RequestNavigate() para cargar los controles.*/


            // Registramos el Task button con una region Prism 

            regionManager.RegisterViewWithRegion("TaskButtonRegion", typeof(ModuleATaskButton));
            //  regionManager.RegisterViewWithRegion("WorkspaceRegion", typeof(ModuleAWorkSpaceView2));

            /* Los objetos vista tienen que ser registrados con unity usando la sobrecarga que mostramos a acontinuación
             * Por defecto Unity resuelve los objetos vista como tipos de System.Object, Con esta sobrecarga mapeamos al tipo de vista correcta.
             * Consultar la guia de desarrollo de Prism pagina 120.
             */

            // Registramos el resto de los objetos vista con el contenedor de inyección de dependencias de Unity.
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterType<Object, ModuleARibbonTab>("ModuleARibbonTab");
            container.RegisterType<Object, ModuleANavigator>("ModuleANavigator");
            container.RegisterType<Object, ModuleAWorkspace>("ModuleAWorkspace");
            container.RegisterType<Object, ModuleAWorkSpaceView2>("ModuleAWorkSpaceView2");

            // inicializamos el servicio de comunicación entre módulos mediante el registro en el contenedor de unity.

            container.RegisterType<IStringCopyService, StringCopyServiceImpl>(new ContainerControlledLifetimeManager());
        }

        #endregion
    }
}
