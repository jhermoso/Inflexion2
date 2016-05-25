// -----------------------------------------------------------------------
// <copyright file="MultiSelectQueryDialogAction.cs" company="I+3 Televisión">
//     Copyright (c) 2012. I+3 Televisión. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace I3TV.Framework.Windows.UI.Controls.Dialogs
{
    using System;
    using System.Collections.Generic;
    using I3TV.Framework.Windows.UI.Controls.Dialogs;
    using I3TV.Framework.Windows.UI.Controls.Dialogs.Views;
    using I3TV.Framework.Windows.UI.MVVM.Dialogs;
    using I3TV.Framework.Windows.UI.Services;

    /// <summary>
    /// Clase base para la interacción con popup de consulta
    /// </summary>
    public class MultiSelectQueryDialogAction : BaseDialogAction<IEnumerable<IKeyValueItem>>
    {
        /// <summary>
        /// Invoca el parámetro especificado.
        /// </summary>
        /// <param name="parameter">El parámetro.</param>
        protected override void Invoke(object parameter)
        {
            var args = parameter as MultiSelectQueryDialogRequestEventArgs;
            this.SetDialog(args.Entity, args.WindowTitle, args.Message, args.IdCliente, args.AllowEmptyResult, args.QueryFunction, args.SelectedString, args.Columns, args.Callback, args.CancelCallback, null);
            this.Initialize();
        }

        /// <summary>
        /// Establece los datos del diálogo.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="windowTitle">El título de la ventana.</param>
        /// <param name="message">El mensaje para la ventana.</param>
        /// <param name="idCliente">El id de cliente.</param>
        /// <param name="allowEmptyResult"><c>true</c> si se permite el valor vacío; en caso contrario, <c>false</c>.</param>
        /// <param name="queryFunction">El método de consulta a emplear en la ventana.</param>
        /// <param name="selectedString">The selected string.</param>
        /// <param name="columns">Las columnas a mostrar.</param>
        /// <param name="callback">El callback para la acción Ok.</param>
        /// <param name="cancelCallback">El callback para la acción Cancel.</param>
        /// <param name="element">El elemento de UI.</param>
        private void SetDialog(IEnumerable<IKeyValueItem> entity, string windowTitle, string message, int idCliente, bool allowEmptyResult, Func<IEnumerable<IKeyValueItem>> queryFunction, string selectedString, IEnumerable<QueryColumn> columns, Action<IEnumerable<IKeyValueItem>> callback, Action cancelCallback, System.Windows.UIElement element)
        {
            base.SetDialog(entity, callback, cancelCallback, element);
            var d = this.Dialog as QueryMultipleInteractionView;
            if (d != null) 
            {
                d.SetWindowTitle(windowTitle);
                d.SetMessage(message);
                d.SetQueryFunction(queryFunction);
                d.SetIdCliente(idCliente);
                d.AllowEmptyResult(allowEmptyResult);
                d.SetSelectedString(selectedString);
                d.SetColumns(columns);
            }
        }
    }
}
