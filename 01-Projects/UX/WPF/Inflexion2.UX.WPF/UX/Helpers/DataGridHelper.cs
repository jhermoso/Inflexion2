// -----------------------------------------------------------------------
// <copyright file="DataGridHelper.cs" company = Inflexion2">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Inflexion2.UX.WPF.Helpers
{

    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;


    /// <summary>
    /// Clase pública estática utilizada como ayuda adicional a acciones 
    /// habituales o generales con los controles DataGrid.
    /// </summary>
    public static class DataGridHelper
    {

        #region FUNCTIONS

            /// <summary>
            /// Función pública estática, que nos devuelve una celda 
            /// seleccionada en el control DataGrid.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <param name="dataGridCellInfo">
            /// Información de la celda del control DataGrid.
            /// </param>
            /// <returns>
            /// Celda seleccionada.
            /// </returns>
            public static DataGridCell GetCell(DataGridCellInfo dataGridCellInfo)
            {
                if (!dataGridCellInfo.IsValid)
                {
                    return null;
                }
                var cellContent = dataGridCellInfo.Column.GetCellContent(dataGridCellInfo.Item);
                if (cellContent != null)
                {
                    return (DataGridCell)cellContent.Parent;
                }
                else
                {
                    return null;
                }
            } // GetCell

            /// <summary>
            /// Función pública estática, que nos devuelve el control DataGrid existente en un control child.
            /// </summary>
            /// <param name="dataGridPart"></param>
            /// <returns></returns>
            public static DataGrid GetDataGridFromChild(DependencyObject dataGridPart)
            {
                if (VisualTreeHelper.GetParent(dataGridPart) == null)
                {
                    throw new NullReferenceException("Control is null.");
                }
                if (VisualTreeHelper.GetParent(dataGridPart) is DataGrid)
                {
                    return (DataGrid)VisualTreeHelper.GetParent(dataGridPart);
                }
                else
                {
                    return GetDataGridFromChild(VisualTreeHelper.GetParent(dataGridPart));
                }
            } // GetDataGridFromChild

            /// <summary>
            /// Función pública estática, que nos devuelve el índice de la 
            /// fila seleccionada en el control DataGrid.
            /// </summary>
            /// <param name="dataGridCell">
            /// Celda seleccionada en el control DataGrid.
            /// </param>
            /// <returns>
            /// Índica de la fila seleccionada en el control DataGrid.
            /// </returns>
            public static int GetRowIndex(DataGridCell dataGridCell)
            {
                // Use reflection to get DataGridCell.RowDataItem property value.
                PropertyInfo rowDataItemProperty = dataGridCell.GetType().GetProperty("RowDataItem", 
                                                                                      BindingFlags.Instance | BindingFlags.NonPublic);
                DataGrid dataGrid = GetDataGridFromChild(dataGridCell);
                return dataGrid.Items.IndexOf(rowDataItemProperty.GetValue(
                                                                           dataGridCell, 
                                                                           null));
            } // GetRowIndex

            /// <summary>
            /// Función pública estática, que nos devuelve una fila de acuerdo 
            /// a la fila seleccionada.
            /// </summary>
            /// <param name="dataGrid">
            /// Control DataGrid.
            /// </param>
            /// <returns>
            /// Fila seleccionada.
            /// </returns>
            public static DataGridRow GetSelectedRow(this DataGrid dataGrid)
            {
                return (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.SelectedItem);
            } // GetSelectedRow

        /// <summary>
        /// Event handler for drag in a drag & drop action with a datagrid row source
        /// </summary>
        /// <typeparam name="TVm"></typeparam>
        /// <typeparam name="TDto"></typeparam>
        /// <typeparam name="TIdentifier"></typeparam>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="_startPoint"></param>
        public static void DataGridPreviewMouseMoveHandler<TVm, TDto, TIdentifier>(object sender, System.Windows.Input.MouseEventArgs e, Point? _startPoint)
            where TVm : Inflexion2.UX.WPF.MVVM.CRUD.CrudViewModel<TDto, TIdentifier>
            where TDto : Inflexion2.Application.BaseEntityDataTransferObject<TIdentifier>, Inflexion2.Application.IDataTransferObject
            where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
        {
            if (_startPoint == null)
                return;

            var dg = sender as DataGrid;
            if (dg == null) return;
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = _startPoint.Value - mousePos;
            // test for the minimum displacement to begin the drag
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                // Get the dragged DataGridRow
                var DataGridRow =
                    Inflexion2.UX.WPF.Helpers.GeneralHelper.FindAnchestor<DataGridRow>((DependencyObject)e.OriginalSource);

                if (DataGridRow == null)
                    return;

                // Find the data behind the DataGridRow
                var dataTodrop = (TVm)dg.ItemContainerGenerator.
                    ItemFromContainer(DataGridRow);

                if (dataTodrop == null) return;

                // Initialize the drag & drop operation
                var dataObj = new DataObject(dataTodrop.ObjectElement);
                dataObj.SetData("DragSource", sender);
                DragDrop.DoDragDrop(dg, dataObj, DragDropEffects.Copy);
                _startPoint = null;
            }
        }


        #endregion

    } // DataGridHelper

} // Company.Product.Shared.SharedCore.UI.MVVM.Helpers