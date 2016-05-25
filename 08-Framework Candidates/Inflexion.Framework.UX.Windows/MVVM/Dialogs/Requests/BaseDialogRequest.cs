// -----------------------------------------------------------------------
// <copyright file="GenericInteractionRequest.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.Dialogs
{
    using System;

    /// <summary>
    /// Clase que representa una solicitud de interacción que afecta a una entidad o tipo de datos.
    /// </summary>
    /// <typeparam name="T">El tipo de la entidad a trabajar.</typeparam>
    public class BaseDialogRequest<T> : IBaseDialogRequest<T>
    {
        /// <summary>
        /// Ocurre cuando la solicitud de interacción es levantada.
        /// </summary>
        public event EventHandler<BaseDialogRequestEventArgs<T>> Raised;

        /// <summary>
        /// Eleva la solicitud de interacción.
        /// </summary>
        /// <param name="entity">La entidad a trabajar.</param>
        /// <param name="callback">El callback para la acción Ok.</param>
        /// <param name="cancelCallback">El callback para la acción Cancel.</param>
        public void Raise(T entity, Action<T> callback, Action cancelCallback)
        {
            this.Raised(this, new BaseDialogRequestEventArgs<T>(entity, callback, cancelCallback));
        }
    }
}
