// -----------------------------------------------------------------------
// <copyright file="QueryMultipleInteractionRequest.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls.Dialogs
{
    using System;
    using System.Collections.Generic;
    using Inflexion.Framework.UX.Windows.Controls.Dialogs;
    using Inflexion.Framework.UX.Windows.MVVM.Dialogs;
    using Inflexion.Framework.UX.Windows.Services;

    /// <summary>
    /// Clase empleada para suministrar datos desde el ViewModel hacia la vista
    /// </summary>
    public class MultiSelectQueryDialogRequest : IBaseDialogRequest<IEnumerable<IKeyValueItem>>
    {
        /// <summary>
        /// Ocurre cuando se llama al método Raise.
        /// </summary>
        public event EventHandler<BaseDialogRequestEventArgs<IEnumerable<IKeyValueItem>>> Raised;

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
        /// <remarks>
        /// Este método construye un popup con las columnas Id y Nombre.
        /// </remarks>
        public void Raise(IEnumerable<IKeyValueItem> entity, string windowTitle, string message, int idCliente, Func<IEnumerable<IKeyValueItem>> queryFunction, Action<IEnumerable<IKeyValueItem>> callback, Action cancelCallback)
        {
            QueryColumn[] columns = new QueryColumn[] { new QueryColumn { DisplayName = "Id", Binding = "Id" }, new QueryColumn { DisplayName = "Nombre", Binding = "Nombre", Width = 300 } };
            this.Raised(this, new MultiSelectQueryDialogRequestEventArgs(entity, windowTitle, message, idCliente, true, queryFunction, string.Empty, columns, callback, cancelCallback));
        }

        /// <summary>
        /// Eleva la entidad especificada.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje.</param>
        /// <param name="idCliente">El id de cliente.</param>
        /// <param name="queryFunction">El método de consulta a emplear en la ventana.</param>
        /// <param name="columns">Las columnas.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public void Raise(IEnumerable<IKeyValueItem> entity, string windowTitle, string message, int idCliente, Func<IEnumerable<IKeyValueItem>> queryFunction, IEnumerable<QueryColumn> columns, Action<IEnumerable<IKeyValueItem>> callback, Action cancelCallback)
        {
            this.Raised(this, new MultiSelectQueryDialogRequestEventArgs(entity, windowTitle, message, idCliente, true, queryFunction, string.Empty, columns, callback, cancelCallback));
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
        /// <remarks>
        /// Este método construye un popup con las columnas Id y Nombre.
        /// </remarks>
        public void Raise(IEnumerable<IKeyValueItem> entity, string windowTitle, string message, int idCliente, bool allowEmptyResult, Func<IEnumerable<IKeyValueItem>> queryFunction, Action<IEnumerable<IKeyValueItem>> callback, Action cancelCallback)
        {
            QueryColumn[] columns = new QueryColumn[] { new QueryColumn { DisplayName = "Id", Binding = "Id" }, new QueryColumn { DisplayName = "Nombre", Binding = "Nombre", Width = 300 } };
            this.Raised(this, new MultiSelectQueryDialogRequestEventArgs(entity, windowTitle, message, idCliente, allowEmptyResult, queryFunction, string.Empty, columns, callback, cancelCallback));
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
        /// <param name="columns">Las columnas.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public void Raise(IEnumerable<IKeyValueItem> entity, string windowTitle, string message, int idCliente, bool allowEmptyResult, Func<IEnumerable<IKeyValueItem>> queryFunction, IEnumerable<QueryColumn> columns, Action<IEnumerable<IKeyValueItem>> callback, Action cancelCallback)
        {
            this.Raised(this, new MultiSelectQueryDialogRequestEventArgs(entity, windowTitle, message, idCliente, allowEmptyResult, queryFunction, string.Empty, columns, callback, cancelCallback));
        }

        /// <summary>
        /// Eleva la entidad especificada.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje.</param>
        /// <param name="idCliente">El id de cliente.</param>
        /// <param name="queryFunction">El método de consulta a emplear en la ventana.</param>
        /// <param name="selectedString">La cadena con los items seleccionados</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        /// <remarks>
        /// Este método construye un popup con las columnas Id y Nombre.
        /// </remarks>
        public void Raise(IEnumerable<IKeyValueItem> entity, string windowTitle, string message, int idCliente, Func<IEnumerable<IKeyValueItem>> queryFunction, string selectedString, Action<IEnumerable<IKeyValueItem>> callback, Action cancelCallback)
        {
            QueryColumn[] columns = new QueryColumn[] { new QueryColumn { DisplayName = "Id", Binding = "Id" }, new QueryColumn { DisplayName = "Nombre", Binding = "Nombre", Width = 300 } };
            this.Raised(this, new MultiSelectQueryDialogRequestEventArgs(entity, windowTitle, message, idCliente, true, queryFunction, selectedString, columns, callback, cancelCallback));
        }

        /// <summary>
        /// Eleva la entidad especificada.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje.</param>
        /// <param name="idCliente">El id de cliente.</param>
        /// <param name="queryFunction">El método de consulta a emplear en la ventana.</param>
        /// <param name="selectedString">La cadena con los items seleccionados</param>
        /// <param name="columns">Las columnas.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public void Raise(IEnumerable<IKeyValueItem> entity, string windowTitle, string message, int idCliente, Func<IEnumerable<IKeyValueItem>> queryFunction, string selectedString, IEnumerable<QueryColumn> columns, Action<IEnumerable<IKeyValueItem>> callback, Action cancelCallback)
        {
            this.Raised(this, new MultiSelectQueryDialogRequestEventArgs(entity, windowTitle, message, idCliente, true, queryFunction, selectedString, columns, callback, cancelCallback));
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
        /// <param name="selectedString">La cadena con los items seleccionados</param>
        /// <param name="columns">Las columnas.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public void Raise(IEnumerable<IKeyValueItem> entity, string windowTitle, string message, int idCliente, bool allowEmptyResult, Func<IEnumerable<IKeyValueItem>> queryFunction, string selectedString, IEnumerable<QueryColumn> columns, Action<IEnumerable<IKeyValueItem>> callback, Action cancelCallback)
        {
            this.Raised(this, new MultiSelectQueryDialogRequestEventArgs(entity, windowTitle, message, idCliente, allowEmptyResult, queryFunction, selectedString, columns, callback, cancelCallback));
        }
    }
}
