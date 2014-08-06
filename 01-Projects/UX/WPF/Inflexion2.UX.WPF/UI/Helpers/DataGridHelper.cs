// -----------------------------------------------------------------------
// <copyright file="DataGridHelper.cs" company = Company">
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
    /// Clase pública estática utilzada como ayuda adicional a acciones 
    /// habituales o generales con los controles DataGrid.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
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

        #endregion

    } // DataGridHelper

} // Company.Product.Shared.SharedCore.UI.MVVM.Helpers