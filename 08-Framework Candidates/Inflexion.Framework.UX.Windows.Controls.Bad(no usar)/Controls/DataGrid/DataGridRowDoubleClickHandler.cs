﻿// -----------------------------------------------------------------------
// <copyright file="DataGridRowDoubleClickHandler.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public sealed class DataGridRowDoubleClickHandler
    {
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

        public static string GetMethodName(DataGrid dataGrid)
        {
            return (string)dataGrid.GetValue(MethodNameProperty);
        }

        public static void SetMethodName(DataGrid dataGrid, string value)
        {
            dataGrid.SetValue(MethodNameProperty, value);
        }

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