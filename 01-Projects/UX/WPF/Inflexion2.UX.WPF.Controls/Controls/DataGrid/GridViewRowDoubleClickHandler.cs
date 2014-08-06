
namespace Inflexion2.UX.WPF.Controls
{

    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;


    public sealed class GridViewRowDoubleClickHandler
    {
        public GridViewRowDoubleClickHandler(RadGridView gridView)
        {
            MouseButtonEventHandler handler = (sender, args) =>
            {
                var row = sender as GridViewRow;
                if (row != null && row.IsSelected)
                {
                    var methodName = GetMethodName(gridView);

                    var dataContextType = gridView.DataContext.GetType();
                    var method = dataContextType.GetMethod(methodName);
                    if (method == null)
                    {
                        throw new MissingMethodException(methodName);
                    }

                    method.Invoke(gridView.DataContext, null);
                }
            };

            gridView.RowLoaded += (s, e) =>
            {
                e.Row.MouseDoubleClick += handler;
            };

            gridView.RowUnloaded += (s, e) =>
            {
                e.Row.MouseDoubleClick -= handler;
            };

        }

        public static string GetMethodName(RadGridView gridView)
        {
            return (string)gridView.GetValue(MethodNameProperty);
        }

        public static void SetMethodName(RadGridView gridView, string value)
        {
            gridView.SetValue(MethodNameProperty, value);
        }

        public static readonly DependencyProperty MethodNameProperty = DependencyProperty.RegisterAttached(
            "MethodName",
            typeof(string),
            typeof(GridViewRowDoubleClickHandler),
            new PropertyMetadata((o, e) =>
            {
                var gridView = o as RadGridView;
                if (gridView != null)
                {
                    new GridViewRowDoubleClickHandler(gridView);
                }
            }));
    }
}
