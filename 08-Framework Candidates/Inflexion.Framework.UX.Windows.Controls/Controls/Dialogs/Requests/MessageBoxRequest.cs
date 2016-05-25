// -----------------------------------------------------------------------
// <copyright file="MessageBoxInteractionRequest.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls.Dialogs
{
    using System;
    using System.Windows;
    using Inflexion.Framework.UX.Windows.Controls.Dialogs;
    using Inflexion.Framework.UX.Windows.MVVM.Dialogs;

    /// <summary>
    /// Clase empleada para suministrar datos desde el ViewModel hacia la vista
    /// </summary>
    public class MessageBoxRequest : IBaseDialogRequest<MessageBoxResult>
    {
        /// <summary>
        /// Ocurre cuando se llama al método Raise.
        /// </summary>
        public event EventHandler<BaseDialogRequestEventArgs<MessageBoxResult>> Raised;

        /// <summary>
        /// Eleva la entidad especificada.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje.</param>
        /// <param name="buttons">Los botones que debe mostrar el diálogo.</param>
        /// <param name="icon">El icono que debe mostrar el diálogo.</param>
        /// <param name="defaultResult">El resultado por defecto que debe devolver el diálogo.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public void Raise(MessageBoxResult entity, string windowTitle, string message, MessageBoxButton buttons, MessageBoxImage icon, MessageBoxResult defaultResult, Action<MessageBoxResult> callback, Action cancelCallback)
        {
            this.Raised(this, new MessageBoxRequestEventArgs(entity, windowTitle, message, buttons, icon, defaultResult, callback, cancelCallback));
        }

        /// <summary>
        /// Eleva la entidad especificada.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje.</param>
        /// <param name="buttons">Los botones que debe mostrar el diálogo.</param>
        /// <param name="icon">El icono que debe mostrar el diálogo.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public void Raise(MessageBoxResult entity, string windowTitle, string message, MessageBoxButton buttons, MessageBoxImage icon, Action<MessageBoxResult> callback, Action cancelCallback)
        {
            this.Raised(this, new MessageBoxRequestEventArgs(entity, windowTitle, message, buttons, icon, MessageBoxResult.None, callback, cancelCallback));
        }

        /// <summary>
        /// Eleva la entidad especificada.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje.</param>
        /// <param name="buttons">Los botones que debe mostrar el diálogo.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public void Raise(MessageBoxResult entity, string windowTitle, string message, MessageBoxButton buttons, Action<MessageBoxResult> callback, Action cancelCallback)
        {
            this.Raised(this, new MessageBoxRequestEventArgs(entity, windowTitle, message, buttons, MessageBoxImage.None, MessageBoxResult.None, callback, cancelCallback));
        }

        /// <summary>
        /// Eleva la entidad especificada.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public void Raise(MessageBoxResult entity, string windowTitle, string message, Action<MessageBoxResult> callback, Action cancelCallback)
        {
            this.Raised(this, new MessageBoxRequestEventArgs(entity, windowTitle, message, MessageBoxButton.OKCancel, MessageBoxImage.None, MessageBoxResult.None, callback, cancelCallback));
        }
    }
}
