// -----------------------------------------------------------------------
// <copyright file="QueryDialogRequest.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Controls.Dialogs
{
    using System;
    using System.Collections.Generic;
    using Inflexion2.UX.WPF.Controls.Dialogs;
    using Inflexion2.UX.WPF.MVVM.Dialogs;
    using Inflexion2.UX.WPF.Services;

    /// <summary>
    /// Clase empleada para suministrar datos desde el ViewModel hacia la vista
    /// </summary>
    public class QueryDialogRequest : IBaseDialogRequest<BaseKeyValueItem>
    {
        /// <summary>
        /// Ocurre cuando se llama al método Raise.
        /// </summary>
        public event EventHandler<BaseDialogRequestEventArgs<BaseKeyValueItem>> Raised;

        /// <summary>
        /// Eleva la entidad especificada.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje.</param>
        /// <param name="idCliente">El id de cliente.</param>
        /// <param name="allowEmptyResult"><c>true</c> si se permite el valor vacío; en caso contrario, <c>false</c>.</param>
        /// <param name="queryService">El servicio de consulta a emplear en la ventana.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public void Raise(BaseKeyValueItem entity, string windowTitle, string message, int idCliente, bool allowEmptyResult, IQueryService queryService, Action<BaseKeyValueItem> callback, Action cancelCallback)
        {
            this.Raised(this, new QueryDialogRequestEventArgs(entity, windowTitle, message, idCliente, allowEmptyResult, queryService, callback, cancelCallback));
        }

        /// <summary>
        /// Eleva la entidad especificada.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje.</param>
        /// <param name="idCliente">El id de cliente.</param>
        /// <param name="queryService">El servicio de consulta a emplear en la ventana.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public void Raise(BaseKeyValueItem entity, string windowTitle, string message, int idCliente, IQueryService queryService, Action<BaseKeyValueItem> callback, Action cancelCallback)
        {
            this.Raised(this, new QueryDialogRequestEventArgs(entity, windowTitle, message, idCliente, queryService, callback, cancelCallback));
        }

        /// <summary>
        /// Eleva la entidad especificada.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje.</param>
        /// <param name="idCliente">El id de cliente.</param>
        /// <param name="queryFunction">El método de consulta a emplear en la ventana.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public void Raise(BaseKeyValueItem entity, string windowTitle, string message, int idCliente, Func<IEnumerable<IKeyValueItem>> queryFunction, Action<BaseKeyValueItem> callback, Action cancelCallback)
        {
            this.Raised(this, new QueryDialogRequestEventArgs(entity, windowTitle, message, idCliente, queryFunction, callback, cancelCallback));
        }

        /// <summary>
        /// Eleva la entidad especificada.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje.</param>
        /// <param name="idCliente">El id de cliente.</param>
        /// <param name="allowEmptyResult"><c>true</c> si se permite el valor vacío; en caso contrario, <c>false</c>.</param>
        /// <param name="queryFunction">El método de consulta a emplear en la ventana.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public void Raise(BaseKeyValueItem entity, string windowTitle, string message, int idCliente, bool allowEmptyResult, Func<IEnumerable<IKeyValueItem>> queryFunction, Action<BaseKeyValueItem> callback, Action cancelCallback)
        {
            this.Raised(this, new QueryDialogRequestEventArgs(entity, windowTitle, message, idCliente, allowEmptyResult, queryFunction, callback, cancelCallback));
        }
    }
}
