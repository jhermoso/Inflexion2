// -----------------------------------------------------------------------
// <copyright file="MessageBoxInteractionViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls.Dialogs.ViewModels
{
    using System.Windows;
    using System.Windows.Input;
    using Inflexion.Framework.UX.Windows.MVVM.ViewModels.Dialogs;

    /// <summary>
    /// Clase de ViewModel para el diálogo de MessageBox
    /// </summary>
    public class MessageBoxViewModel : BaseDialogViewModel<MessageBoxResult>
    {
        /// <summary>
        /// Backing field para WindowTitle
        /// </summary>
        private string windowTitle;

        /// <summary>
        /// Backing field para Message
        /// </summary>
        private string message;

        /// <summary>
        /// Backing field para Buttons
        /// </summary>
        private MessageBoxButton buttons;

        /// <summary>
        /// Backing field para Icon
        /// </summary>
        private MessageBoxImage icon;

        /// <summary>
        /// Backing field para DefaultResult
        /// </summary>
        private MessageBoxResult defaultResult;

        /// <summary>
        /// Obtiene y establece el botón Yes.
        /// </summary>
        /// <value>
        /// El botón Yes.
        /// </value>
        public ICommand YesCommand { get; set; }

        /// <summary>
        /// Obtiene y establece el botón No.
        /// </summary>
        /// <value>
        /// El botón No.
        /// </value>
        public ICommand NoCommand { get; set; }

        /// <summary>
        /// Obtiene y establece el botón Ok.
        /// </summary>
        /// <value>
        /// El botón Ok.
        /// </value>
        public ICommand OkCommand { get; set; }

        /// <summary>
        /// Obtiene y establece el botón Cancel.
        /// </summary>
        /// <value>
        /// El botón Cancel.
        /// </value>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Obtiene y establece el título de la ventana.
        /// </summary>
        /// <value>
        /// El titulo de la ventana.
        /// </value>
        public string WindowTitle
        {
            get
            {
                return this.windowTitle;
            }

            set
            {
                this.windowTitle = value;
                this.RaisePropertyChanged(() => WindowTitle);
            }
        }

        /// <summary>
        /// Obtiene y establece el mensaje de la ventana.
        /// </summary>
        /// <value>
        /// El mensaje de la ventana.
        /// </value>
        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
                this.RaisePropertyChanged(() => Message);
            }
        }

        /// <summary>
        /// Obtiene o establece los botones de la pantalla.
        /// </summary>
        /// <value>
        /// Los botones.
        /// </value>
        public MessageBoxButton Buttons 
        {
            get
            {
                return this.buttons;
            }

            set
            {
                this.buttons = value;
                this.RaisePropertyChanged(() => this.Buttons);
                this.RaisePropertyChanged(() => this.ShowAccept);
                this.RaisePropertyChanged(() => this.ShowCancel);
                this.RaisePropertyChanged(() => this.ShowNo);
                this.RaisePropertyChanged(() => this.ShowYes);
            }
        }

        /// <summary>
        /// Obtiene o establece el icono de la pantalla.
        /// </summary>
        /// <value>
        /// El icono.
        /// </value>
        public MessageBoxImage Icon 
        {
            get
            {
                return this.icon;
            }

            set
            {
                this.icon = value;
                this.RaisePropertyChanged(() => this.Icon);
            }
        }

        /// <summary>
        /// Obtiene o establece el resultado por defecto de la pantalla.
        /// </summary>
        /// <value>
        /// El resultado por defecto.
        /// </value>
        public MessageBoxResult DefaultResult 
        {
            get
            {
                return this.defaultResult;
            }

            set
            {
                this.defaultResult = value;
                this.RaisePropertyChanged(() => this.DefaultResult);
            }
        }

        /// <summary>
        /// Obtiene un valor que indica si se debe mostrar el botón SI.
        /// </summary>
        /// <value>
        ///   <c>true</c> si se debe mostrar el botón SI; en caso contrario, <c>false</c>.
        /// </value>
        public bool ShowYes
        {
            get
            {
                return this.buttons == MessageBoxButton.YesNo || this.buttons == MessageBoxButton.YesNoCancel;
            }
        }

        /// <summary>
        /// Obtiene un valor que indica si se debe mostrar el botón NO.
        /// </summary>
        /// <value>
        ///   <c>true</c> si se debe mostrar el botón NO; en caso contrario, <c>false</c>.
        /// </value>
        public bool ShowNo
        {
            get
            {
                return this.buttons == MessageBoxButton.YesNo || this.buttons == MessageBoxButton.YesNoCancel;
            }
        }

        /// <summary>
        /// Obtiene un valor que indica si se debe mostrar el botón Aceptar.
        /// </summary>
        /// <value>
        ///   <c>true</c> si se debe mostrar el botón Aceptar; en caso contrario, <c>false</c>.
        /// </value>
        public bool ShowAccept
        {
            get
            {
                return this.buttons == MessageBoxButton.OK || this.buttons == MessageBoxButton.OKCancel;
            }
        }

        /// <summary>
        /// Obtiene un valor que indica si se debe mostrar el botón Cancelar.
        /// </summary>
        /// <value>
        ///   <c>true</c> si se debe mostrar el botón Cancelar; en caso contrario, <c>false</c>.
        /// </value>
        public bool ShowCancel
        {
            get
            {
                return this.buttons == MessageBoxButton.OKCancel || this.buttons == MessageBoxButton.YesNoCancel;
            }
        }
    } 
} 