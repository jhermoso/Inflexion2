﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="User" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " ModuleNavigationVMCT2.tt" with "public class ModuleNavigationVMCT2 : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "ModuleNavigationVMCT2.tt" con "public class ModuleNavigationVMCT2 : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.FrontEnd.WpfModule
{
    #region usings
    using System.Windows.Input;
    using Inflexion2.UX.WPF.MVVM;
    using Inflexion2.UX.WPF.MVVM.Commands;
    using Inflexion2.UX.WPF.MVVM.ViewModels;
    #endregion

    /// <summary>
    /// navigation viewmodel for the bounded context Common .
    /// </summary>
    public partial class CommonModuleNavigationViewModel : NavigationViewModel
    {

        #region Private Methods
        /// <summary>
        /// Inicializa el modelo de vista.
        /// </summary>
        private void Initialize()
        {
            //this.CommonView = new NavigationCommand<CommonModuleNavigationViewModel>(
                //this, RegionNames.ToolbarRegion, typeof(CommonRibbonTab).FullName);
            this.ShowAppSettingView = new NavigationCommand<CommonModuleNavigationViewModel>(
                this, RegionNames.WorkspaceRegion, typeof(AppSettingQueryView).FullName);

            this.ShowDepartmentView = new NavigationCommand<CommonModuleNavigationViewModel>(
                this, RegionNames.WorkspaceRegion, typeof(DepartmentQueryView).FullName);

            this.ShowComponentView = new NavigationCommand<CommonModuleNavigationViewModel>(
                this, RegionNames.WorkspaceRegion, typeof(ComponentQueryView).FullName);

            this.ShowTeacherView = new NavigationCommand<CommonModuleNavigationViewModel>(
                this, RegionNames.WorkspaceRegion, typeof(TeacherQueryView).FullName);

            this.ShowStudentView = new NavigationCommand<CommonModuleNavigationViewModel>(
                this, RegionNames.WorkspaceRegion, typeof(StudentQueryView).FullName);

            this.ShowGraphNodeView = new NavigationCommand<CommonModuleNavigationViewModel>(
                this, RegionNames.WorkspaceRegion, typeof(GraphNodeQueryView).FullName);

            this.ShowEntityMView = new NavigationCommand<CommonModuleNavigationViewModel>(
                this, RegionNames.WorkspaceRegion, typeof(EntityMQueryView).FullName);

            this.ShowMNZView = new NavigationCommand<CommonModuleNavigationViewModel>(
                this, RegionNames.WorkspaceRegion, typeof(MNZQueryView).FullName);

            this.ShowEntityNView = new NavigationCommand<CommonModuleNavigationViewModel>(
                this, RegionNames.WorkspaceRegion, typeof(EntityNQueryView).FullName);

            this.ShowEntityZView = new NavigationCommand<CommonModuleNavigationViewModel>(
                this, RegionNames.WorkspaceRegion, typeof(EntityZQueryView).FullName);

        }// end initialize
        #endregion
    }// end class
}// end namespace