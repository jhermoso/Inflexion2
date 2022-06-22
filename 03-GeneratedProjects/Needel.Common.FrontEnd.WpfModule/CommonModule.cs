﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="User" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " PrismModuleCT.tt" with "public class PrismModuleCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "PrismModuleCT.tt" con "public class PrismModuleCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.FrontEnd.WpfModule
{

    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Unity;

    using Inflexion2.UX.WPF.MVVM;
    using Inflexion2.UX.WPF.Services;

    using Inflexion2.Resources;
    using Needel.Common.Domain.Data;
    using Needel.Common.Infrastructure.Resources;
    #endregion

    /// <summary>
    /// .en class module implementation. 
    /// This implementation become the compiled dll of this project on a module dynamically loaded by the 
    /// main programm.
    /// .es implementación de la clases "module". Esta implementación convierte la ddl de la compilación 
    /// de este proyecto en un modulo que puede ser cargado por el programa principal de forma dinamica. 
    /// (en tiempo de ejecución)
    /// </summary>
    public sealed class CommonModule : Inflexion2.UX.WPF.MVVM.BaseModule
    {
        #region Imodule & Basemodule Implementation
        /// <summary>
        /// .en module initialization.
        /// .es Inicializa el módulo.
        /// </summary>
        /// <remarks>
        /// .en Register the controls whose has to be always available
        /// with iregionmanager of Prism and the controls whose has to available on demand
        /// with the inyection unity container. The controls on-demand will be loaded when
        /// the method IregionManager.RequestNavigate() would be executed.
        /// 
        /// .es Registramos los controles que han de estar siempre disponibles
        /// con el gestor de regiones Prism (IRegionManager), y los controles que
        /// han de solicitarse (bajo demanda) con el contenedor de inyección de
        /// dependencias Unity.  Los controles bajo demanda serán cargados cuando
        /// se invoque el método "IregionManager.RequestNavigate()".
        /// </remarks>
        public override void Initialize()
        {
            // .en registering of controls always available
            // .es Registro de controles que han de estar siempre disponibles.
            this.RegionManager.RegisterViewWithRegion(RegionNames.TaskbarRegion, typeof(CommonModuleTaskBarView));

            // .en registering of controls available on-demand.
            // .es Registro de controles disponibles bajo demanda.
            this.UnityContainer.RegisterType<object, CommonModuleNavigationView>(typeof(CommonModuleNavigationView).FullName);
            this.UnityContainer.RegisterType<object, CommonModuleRibbonTab>(typeof(CommonModuleRibbonTab).FullName);
            
            // .en Registering by entities. 
            // .es Registro por entidades.
            this.UnityContainer.RegisterType<object, UserView>(typeof(UserView).FullName);
            this.UnityContainer.RegisterType<object, UserQueryView>(typeof(UserQueryView).FullName);         

            this.UnityContainer.RegisterType<object, AppSettingView>(typeof(AppSettingView).FullName);
            this.UnityContainer.RegisterType<object, AppSettingQueryView>(typeof(AppSettingQueryView).FullName);         

            this.UnityContainer.RegisterType<object, DepartmentView>(typeof(DepartmentView).FullName);
            this.UnityContainer.RegisterType<object, DepartmentQueryView>(typeof(DepartmentQueryView).FullName);         

            this.UnityContainer.RegisterType<object, AddressView>(typeof(AddressView).FullName);
            this.UnityContainer.RegisterType<object, AddressQueryView>(typeof(AddressQueryView).FullName);         

            this.UnityContainer.RegisterType<object, ComponentView>(typeof(ComponentView).FullName);
            this.UnityContainer.RegisterType<object, ComponentQueryView>(typeof(ComponentQueryView).FullName);         

            this.UnityContainer.RegisterType<object, TeacherView>(typeof(TeacherView).FullName);
            this.UnityContainer.RegisterType<object, TeacherQueryView>(typeof(TeacherQueryView).FullName);         

            this.UnityContainer.RegisterType<object, StudentView>(typeof(StudentView).FullName);
            this.UnityContainer.RegisterType<object, StudentQueryView>(typeof(StudentQueryView).FullName);         

            this.UnityContainer.RegisterType<object, GraphNodeView>(typeof(GraphNodeView).FullName);
            this.UnityContainer.RegisterType<object, GraphNodeQueryView>(typeof(GraphNodeQueryView).FullName);         

            this.UnityContainer.RegisterType<object, EntityMView>(typeof(EntityMView).FullName);
            this.UnityContainer.RegisterType<object, EntityMQueryView>(typeof(EntityMQueryView).FullName);         

            this.UnityContainer.RegisterType<object, MNZView>(typeof(MNZView).FullName);
            this.UnityContainer.RegisterType<object, MNZQueryView>(typeof(MNZQueryView).FullName);         

            this.UnityContainer.RegisterType<object, EntityNView>(typeof(EntityNView).FullName);
            this.UnityContainer.RegisterType<object, EntityNQueryView>(typeof(EntityNQueryView).FullName);         

            this.UnityContainer.RegisterType<object, EntityZView>(typeof(EntityZView).FullName);
            this.UnityContainer.RegisterType<object, EntityZQueryView>(typeof(EntityZQueryView).FullName);         

        }
        #endregion
    } // end class 
} // end namespace