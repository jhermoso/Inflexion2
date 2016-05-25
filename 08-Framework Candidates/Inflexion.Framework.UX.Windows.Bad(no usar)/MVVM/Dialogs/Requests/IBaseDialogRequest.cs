// -----------------------------------------------------------------------
// <copyright file="IGenericInteractionRequest.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.Dialogs
{
    using System;

    /// <summary>
    /// Contrato de una solicitud de interacción genérica,
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad de la solicitud de interacción.</typeparam>
    public interface IBaseDialogRequest<T>
    {
        /// <summary>
        /// Ocurre cuando la solicitud de interacción es solicitada.
        /// </summary>
        event EventHandler<BaseDialogRequestEventArgs<T>> Raised;
    }
}
