// -----------------------------------------------------------------------
// <copyright file="MessageBoxInteractionView.xaml.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls.Dialogs.Views
{
    using System.Windows;
    using Inflexion.Framework.UX.Windows.Controls.Dialogs;
    using Inflexion.Framework.UX.Windows.Controls.Dialogs.ViewModels;
    using Inflexion.Framework.UX.Windows.MVVM.Dialogs;
    using Inflexion.Framework.UX.Windows.MVVM.ViewModels.Dialogs;
    using Inflexion.Framework.UX.Windows.MVVM.Views.Dialogs;
    using Microsoft.Practices.Prism.Commands;

    /// <summary>
    /// Lógica de interacción con MessageBoxInteractionView.xaml
    /// </summary>
    public partial class MessageBoxInteractionView : MessageBoxDialog,
        IBaseDialogView<MessageBoxResult>,
        IBaseDialogAdapter<MessageBoxResult>
    {
        /// <summary>
        /// Campo adapter encargado de enganchar el diálogo con su ViewModel
        /// </summary>
        private IBaseDialogAdapter<MessageBoxResult> adapter;

        /// <summary>
        /// Inicia una nueva instancia de la clase <see cref="ConfirmDeleteInteractionView" />.
        /// </summary>
        public MessageBoxInteractionView()
        {
            this.adapter = new BaseDialogAdapter<MessageBoxResult>(new MessageBoxViewModel());
            this.DataContext = ViewModel;

            this.ViewModel.CancelCommand = new DelegateCommand(Cancel);
            this.ViewModel.OkCommand = new DelegateCommand(Ok);
            this.ViewModel.YesCommand = new DelegateCommand(Yes);
            this.ViewModel.NoCommand = new DelegateCommand(No);

            this.InitializeComponent();
        }

        /// <summary>
        /// Inicializa el diálogo.
        /// </summary>
        public override void Initialize()
        {
            this.ViewModel.Initialize();
        }

        /// <summary>
        /// Acción para la pulsación de Ok.
        /// </summary>
        public override void Ok()
        {
            this.SetEntity(MessageBoxResult.OK);
            base.OnClose(new BaseDialogEventArgs(DialogResultType.OK));
        }

        /// <summary>
        /// Acción para la pulsación de Cancel.
        /// </summary>
        public override void Cancel()
        {
            this.SetEntity(MessageBoxResult.Cancel);
            base.Cancel();
        }

        /// <summary>
        /// Acción para la pulsación de Yes.
        /// </summary>
        public void Yes()
        {
            this.SetEntity(MessageBoxResult.Yes);
            base.OnClose(new BaseDialogEventArgs(DialogResultType.OK));
        }

        /// <summary>
        /// Acción para la pulsación de No.
        /// </summary>
        public void No()
        {
            this.SetEntity(MessageBoxResult.No);
            base.OnClose(new BaseDialogEventArgs(DialogResultType.OK));
        }

        /// <summary>
        /// Establece la entidad.
        /// </summary>
        /// <param name="entity">La entidad de tipo <see cref="CortePoliticaAppointment"/>.</param>
        public void SetEntity(MessageBoxResult entity)
        {
            this.ViewModel.SetEntity(entity);
        }

        /// <summary>
        /// Obtiene la entidad.
        /// </summary>
        /// <returns>La entidad de tipo <see cref="CortePoliticaAppointment"/>.</returns>
        public MessageBoxResult GetEntity()
        {
            return this.ViewModel.Entity;
        }

        /// <summary>
        /// Obtiene el ViewModel.
        /// </summary>
        /// <value>
        /// El ViewModel.
        /// </value>
        IBaseDialogViewModel<MessageBoxResult> IBaseDialogAdapter<MessageBoxResult>.ViewModel
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// Obtiene el ViewModel.
        /// </summary>
        /// <value>
        /// El ViewModel.
        /// </value>
        public MessageBoxViewModel ViewModel
        {
            get
            {
                return this.adapter.ViewModel as MessageBoxViewModel;
            }
        }

        /// <summary>
        /// Establece el título de la ventana.
        /// </summary>
        /// <param name="windowTitle">El título de la ventana.</param>
        public void SetWindowTitle(string windowTitle)
        {
            this.ViewModel.WindowTitle = windowTitle;
        }

        /// <summary>
        /// Establece el mensaje de la ventana.
        /// </summary>
        /// <param name="message">El mensaje.</param>
        public void SetMessage(string message)
        {
            this.ViewModel.Message = message;
        }

        /// <summary>
        /// Establece los botones de la ventana.
        /// </summary>
        /// <param name="buttons">Los botones.</param>
        internal void SetButtons(MessageBoxButton buttons)
        {
            this.ViewModel.Buttons = buttons;
        }

        /// <summary>
        /// Establece el icono de la ventana.
        /// </summary>
        /// <param name="icon">El icono.</param>
        internal void SetIcon(MessageBoxImage icon)
        {
            this.ViewModel.Icon = icon;
        }

        /// <summary>
        /// Establece el resultado por defecto de la pantalla.
        /// </summary>
        /// <param name="defaultResult">El resultado por defecto.</param>
        internal void SetDefaultResult(MessageBoxResult defaultResult)
        {
            this.ViewModel.DefaultResult = defaultResult;
        }
    }
}