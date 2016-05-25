// -----------------------------------------------------------------------
// <copyright file="MultiSelectQueryDialogRequestEventArgs.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls.Dialogs
{
    using System;
    using System.Collections.Generic;
    using Inflexion.Framework.UX.Windows.MVVM.Dialogs;
    using Inflexion.Framework.UX.Windows.Services;

    /// <summary>
    /// Clase que almacena los argumentos a elevar a la vista desde el ViewModel
    /// </summary>
    public class MultiSelectQueryDialogRequestEventArgs : BaseDialogRequestEventArgs<IEnumerable<IKeyValueItem>>
    {
        /// <summary>
        /// Inicia una nueva instancia de la clase <see cref="MultiSelectQueryDialogRequestEventArgs" />.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="title">El título de la ventana.</param>
        /// <param name="message">El mensaje a mostrar.</param>
        /// <param name="idCliente">El id de cliente.</param>
        /// <param name="allowEmptyResult"><c>true</c> si se permite el valor vacío; en caso contrario, <c>false</c>.</param>
        /// <param name="queryFunction">El servicio de consulta a emplear en la ventana.</param>
        /// <param name="selectedString">The selected string.</param>
        /// <param name="columns">Las columnas a mostrar.</param>
        /// <param name="callback">El callback.</param>
        /// <param name="cancelCallback">El callback de cancelación.</param>
        public MultiSelectQueryDialogRequestEventArgs(IEnumerable<IKeyValueItem> entity, string title, string message, int idCliente, bool allowEmptyResult, Func<IEnumerable<IKeyValueItem>> queryFunction, string selectedString, IEnumerable<QueryColumn> columns, Action<IEnumerable<IKeyValueItem>> callback, Action cancelCallback)
            : base(entity, callback, cancelCallback)
        {
            this.WindowTitle = title;
            this.Message = message;
            this.QueryFunction = queryFunction;
            this.IdCliente = idCliente;
            this.AllowEmptyResult = allowEmptyResult;
            this.SelectedString = selectedString;
            this.Columns = columns;
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
        /// Obtiene el método de consulta a ejecutar para obtener valores.
        /// </summary>
        /// <value>
        /// El método de consulta.
        /// </value>
        public Func<IEnumerable<IKeyValueItem>> QueryFunction { get; private set; }

        /// <summary>
        /// Obtiene el id de cliente.
        /// </summary>
        /// <value>
        /// El id de cliente.
        /// </value>
        public int IdCliente { get; private set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si se va a permitir mostrar el valor vacío como resultado de la consulta.
        /// </summary>
        /// <value>
        ///   <c>true</c> si se permite el valor vacío; en caso contrario, <c>false</c>.
        /// </value>
        public bool AllowEmptyResult { get; set; }

        /// <summary>
        /// Obtiene la cadena de los seleccionados
        /// </summary>
        /// <value>
        /// El id de cliente.
        /// </value>
        public string SelectedString { get; private set; }

        /// <summary>
        /// Obtiene las columnas a mostrar.
        /// </summary>
        /// <value>
        /// Las columnas.
        /// </value>
        public IEnumerable<QueryColumn> Columns { get; private set; }
    }
}
