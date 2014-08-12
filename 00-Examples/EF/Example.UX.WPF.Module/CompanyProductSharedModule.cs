

namespace Company.Product.Shared.UX.WPF.Module
{

    using Company.Product.Shared.UX.WPF.Module.Views;
    using Inflexion.Framework.UX.Windows.MVVM;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Unity;
    

    public sealed class CompanyProductSharedModule : BaseModule
    {
        #region METHODS

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
                //this.UnityContainer.RegisterInstance<ITipoFranjaSelectedService>("TipoFranjaRecargos", new TipoFranjaSelectedService(), new ContainerControlledLifetimeManager());
                //this.UnityContainer.RegisterInstance<ITipoElementoSelectedService>("TipoElementoRecargos", new TipoElementoSelectedService(), new ContainerControlledLifetimeManager());


                // Registro de controles que han de estar siempre disponibles.
                //this.RegionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(ModuleATaskButton));    
 
                //this.RegionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ModuleATaskButton));    
                //this.RegionManager.RegisterViewWithRegion(RegionNames.WorkspaceRegion, typeof(ModuleATaskButton));    




                this.RegionManager.RegisterViewWithRegion(RegionNames.TaskbarRegion, typeof(CompanyProductModuleTaskbarView));
                //this.RegionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(CompanyProductModuleNavigationView));
                //this.RegionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ParrillaRibbonTabView));
                //this.RegionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(TarifasRibbonTabView));
                //this.RegionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(RecargosRibbonTabView));

                // Registro de controles disponibles bajo demanda.
                                                         
                this.UnityContainer.RegisterType<object, CompanyProductModuleNavigationView>(typeof(CompanyProductModuleNavigationView).FullName);

                //DESCONEXION
                //this.UnityContainer.RegisterType<object, DesconexionView>(typeof(DesconexionView).FullName);
                //this.UnityContainer.RegisterType<object, DesconexionQueryView>(typeof(DesconexionQueryView).FullName);

            }
        #endregion

    } //end class CompanyProductSharedModule
} //end namespace Company.Product.Shared.UX.WPF.Module
