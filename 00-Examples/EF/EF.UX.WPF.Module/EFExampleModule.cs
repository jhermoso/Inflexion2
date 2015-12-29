using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

using Inflexion2.UX.WPF.MVVM;
using Inflexion2.UX.WPF.Services;
using EF.UX.WPF.Module.Prism;
using EF.UX.WPF.Module.Entities;

namespace EF.UX.WPF.Module
{
    public sealed class EFExampleModule : BaseModule
    {
        /// <summary>
        /// Inicializa el módulo.
        /// </summary>
        /// <remarks>
        /// Registramos los controles que han de estar siempre disponibles
        /// con el gestor de regiones Prism (IRegionManager), y los controles que
        /// han de solicitarse (bajo demanda) con el contenedor de inyección de
        /// dependencias Unity.  Los controles bajo demanda serán cargados cuando
        /// se invoque el método "IregionManager.RequestNavigate()".
        /// </remarks>
        public override void Initialize()
        {          

            // Registramos servicios de uso visual. 
            //this.UnityContainer.RegisterInstance<IEntitySelectedService>("EntityB", new EntityBSelectedService(), new ContainerControlledLifetimeManager());

            // Registro de controles que han de estar siempre disponibles.
            this.RegionManager.RegisterViewWithRegion(RegionNames.TaskbarRegion, typeof(EFExampleModuleTaskbarView));

             //Registro de controles disponibles bajo demanda.
            this.UnityContainer.RegisterType<object, EFExampleModuleNavigationView>(typeof(EFExampleModuleNavigationView).FullName);
            this.UnityContainer.RegisterType<object, ModuleARibbonTab>(typeof(ModuleARibbonTab).FullName);
             //registro por entidades
            this.UnityContainer.RegisterType<object, EntityBView>(typeof(EntityBView).FullName);
            this.UnityContainer.RegisterType<object, EntityBQueryView>(typeof(EntityBQueryView).FullName);



        }// end initialize()
    }// end class
}// end namespace
