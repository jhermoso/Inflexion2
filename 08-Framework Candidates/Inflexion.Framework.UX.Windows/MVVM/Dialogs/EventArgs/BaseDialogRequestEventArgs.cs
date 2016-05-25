// -----------------------------------------------------------------------
// <copyright file="GenericInteractionRequestEventArgs.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.Dialogs
{
    using System;

    /// <summary>
    /// EventArgs para una solicitud de interacción.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad de la solicitud de interacción.</typeparam>
    public class BaseDialogRequestEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Inicia una nueva instancia de la clase <see cref="BaseDialogRequestEventArgs&lt;T&gt;"/>.
        /// </summary>
        /// <param name="entity">La entidad a trabajar.</param>
        /// <param name="callback">El callback a llamar si se pulsa Ok.</param>
        /// <param name="cancelCallback">El callback a llamar si se pulsa Cancel.</param>
        public BaseDialogRequestEventArgs(T entity, Action<T> callback, Action cancelCallback)
        {
            this.CancelCallback = cancelCallback;
            this.Callback = callback;
            this.Entity = entity;
        }

        /// <summary>
        /// Obtiene el callback para la acción de cancelar.
        /// </summary>
        public Action CancelCallback { get; private set; }

        /// <summary>
        /// Obtiene el callback para la acción de Ok.
        /// </summary>
        public Action<T> Callback { get; private set; }

        /// <summary>
        /// Obtiene la entidad.
        /// </summary>
        public T Entity { get; private set; }
    }
}
