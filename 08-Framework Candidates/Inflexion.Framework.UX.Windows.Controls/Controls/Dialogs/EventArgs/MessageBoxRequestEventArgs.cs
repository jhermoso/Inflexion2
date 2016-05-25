// -----------------------------------------------------------------------
// <copyright file="MessageBoxInteractionRequestEventArgs.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls.Dialogs
{
    using System;
    using System.Windows;
    using Inflexion.Framework.UX.Windows.MVVM.Dialogs;

    /// <summary>
    /// Clase que almacena los argumentos a elevar a la vista desde el ViewModel
    /// </summary>
    public class MessageBoxRequestEventArgs : BaseDialogRequestEventArgs<MessageBoxResult>
    {
        /// <summary>
        /// Inicia una nueva instancia de la clase <see cref="MessageBoxRequestEventArgs" />.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="title">El título de la ventana.</param>
        /// <param name="message">El mensaje a mostrar.</param>
        /// <param name="buttons">Enumerado con los botones a mostrar.</param>
        /// <param name="icon">La imagen a mostrar.</param>
        /// <param name="defaultResult">El resultado por defecto a mostrar.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public MessageBoxRequestEventArgs(MessageBoxResult entity, string title, string message, MessageBoxButton buttons, MessageBoxImage icon, MessageBoxResult defaultResult, Action<MessageBoxResult> callback, Action cancelCallback)
            : base(entity, callback, cancelCallback)
        {
            this.WindowTitle = title;
            this.Message = message;
            this.Buttons = buttons;
            this.Icon = icon;
            this.DefaultResult = defaultResult;
        }

        /// <summary>
        /// Obtiene el título de la ventana.
        /// </summary>
        /// <value>
        /// El título de la ventana.
        /// </value>
        public string WindowTitle { get; private set; }

        /// <summary>
        /// Obtiene el message de confirmación.
        /// </summary>
        /// <value>
        /// El mensaje.
        /// </value>
        public string Message { get; private set; }

        /// <summary>
        /// Obtiene los botones a mostrar en el diálogo.
        /// </summary>
        /// <value>
        /// Los botones.
        /// </value>
        public MessageBoxButton Buttons { get; private set; }

        /// <summary>
        /// Obtiene el icono a mostrar en el dilogo.
        /// </summary>
        /// <value>
        /// El icono.
        /// </value>
        public MessageBoxImage Icon { get; private set; }

        /// <summary>
        /// Obtiene el resultado por defecto que debe devolver el diálogo.
        /// </summary>
        /// <value>
        /// El resultado por defecto.
        /// </value>
        public MessageBoxResult DefaultResult { get; private set; }
    }
}
