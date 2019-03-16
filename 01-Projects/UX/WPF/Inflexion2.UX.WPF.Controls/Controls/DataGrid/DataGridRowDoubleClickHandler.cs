// -----------------------------------------------------------------------
// <copyright file="DataGridRowDoubleClickHandler.cs" company="Inflexion2">
//     Copyright (c) 2014. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Controls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// asociate an action to the gesture of double click in the datagrid
    /// </summary>
    public sealed class DataGridRowDoubleClickHandler
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="dataGrid"></param>
        public DataGridRowDoubleClickHandler(DataGrid dataGrid)
        {
            MouseButtonEventHandler handler = (sender, args) =>
            {
                var row = sender as DataGridRow;
                if (row != null && row.IsSelected)
                {
                    var methodName = GetMethodName(dataGrid);

                    var dataContextType = dataGrid.DataContext.GetType();
                    var method = dataContextType.GetMethod(methodName);
                    if (method == null)
                    {
                        throw new MissingMethodException(methodName);
                    }

                    method.Invoke(dataGrid.DataContext, null);
                }
            };

            dataGrid.LoadingRow += (s, e) =>
            {
                e.Row.MouseDoubleClick += handler;
            };

            dataGrid.UnloadingRow += (s, e) =>
            {
                e.Row.MouseDoubleClick -= handler;
            };
        }

        /// <summary>
        /// get the method name to execute from the property
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static string GetMethodName(DataGrid dataGrid)
        {
            return (string)dataGrid.GetValue(MethodNameProperty);
        }

        /// <summary>
        /// set the method name to execute from the property 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="value"></param>
        public static void SetMethodName(DataGrid dataGrid, string value)
        {
            dataGrid.SetValue(MethodNameProperty, value);
        }

        /// <summary>
        /// dependency property register
        /// </summary>
        public static readonly DependencyProperty MethodNameProperty = DependencyProperty.RegisterAttached(
            "MethodName",
            typeof(string),
            typeof(DataGridRowDoubleClickHandler),
            new PropertyMetadata((o, e) =>
            {
                var dataGrid = o as DataGrid;
                if (dataGrid != null)
                {
                    new DataGridRowDoubleClickHandler(dataGrid);
                }
            }));
    }
}