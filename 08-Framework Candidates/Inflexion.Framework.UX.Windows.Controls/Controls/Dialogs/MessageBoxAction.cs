// -----------------------------------------------------------------------
// <copyright file="MessageBoxInteractionAction.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls.Dialogs
{
    using System;
    using System.Windows;
    using Inflexion.Framework.UX.Windows.Controls.Dialogs;
    using Inflexion.Framework.UX.Windows.Controls.Dialogs.Views;
    using Inflexion.Framework.UX.Windows.MVVM.Dialogs;

    /// <summary>
    /// Clase base para la interacción con creación / edición de Corte Política
    /// </summary>
    public class MessageBoxAction : BaseDialogAction<MessageBoxResult>
    {
        /// <summary>
        /// Invoca el parámetro especificado.
        /// </summary>
        /// <param name="parameter">El parámetro.</param>
        protected override void Invoke(object parameter)
        {
            var args = parameter as MessageBoxRequestEventArgs;
            this.SetDialog(args.Entity, args.WindowTitle, args.Message, args.Buttons, args.Icon, args.DefaultResult, args.Callback, args.CancelCallback, null);
            this.Initialize();
        }

        /// <summary>
        /// Establece los datos del diálogo.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje para la ventana.</param>
        /// <param name="buttons">Los botones a mostrar en el diálogo.</param>
        /// <param name="icon">El icono a mostrar en el diálogo.</param>
        /// <param name="defaultResult">El resultado por defecto a devolver en el diálogo.</param>
        /// <param name="callback">El callback para la acción Ok.</param>
        /// <param name="cancelCallback">El callback para la acción Cancel.</param>
        /// <param name="element">El elemento de UI.</param>
        private void SetDialog(MessageBoxResult entity, string windowTitle, string message, MessageBoxButton buttons, MessageBoxImage icon, MessageBoxResult defaultResult, Action<MessageBoxResult> callback, Action cancelCallback, System.Windows.UIElement element)
        {
            base.SetDialog(entity, callback, cancelCallback, element);
            var d = this.Dialog as MessageBoxInteractionView;
            if (d != null) 
            {
                d.SetWindowTitle(windowTitle);
                d.SetMessage(message);
                d.SetButtons(buttons);
                d.SetIcon(icon);
                d.SetDefaultResult(defaultResult);
            }
        }
    }
}
