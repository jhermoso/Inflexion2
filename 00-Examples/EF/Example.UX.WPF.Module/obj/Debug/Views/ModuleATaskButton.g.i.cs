﻿#pragma checksum "..\..\..\Views\ModuleATaskButton.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A8C96B88D37BEE6CE010A746F93C3031"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FsTaskButton;
using Microsoft.Windows.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Company.Product.Shared.UX.WPF.Module.Views {
    
    
    /// <summary>
    /// ModuleATaskButton
    /// </summary>
    public partial class ModuleATaskButton : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 3 "..\..\..\Views\ModuleATaskButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Company.Product.Shared.UX.WPF.Module.Views.ModuleATaskButton ModuleATaskButtonView;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Views\ModuleATaskButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FsTaskButton.TaskButton TaskButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Company.Product.Shared.UX.WPF.Module;component/views/moduleataskbutton.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ModuleATaskButton.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ModuleATaskButtonView = ((Company.Product.Shared.UX.WPF.Module.Views.ModuleATaskButton)(target));
            return;
            case 2:
            this.TaskButton = ((FsTaskButton.TaskButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

