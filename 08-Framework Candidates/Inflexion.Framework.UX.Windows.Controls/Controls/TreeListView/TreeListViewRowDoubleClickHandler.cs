
namespace I3TV.Framework.Windows.UI.Controls
{

    using System;
    using System.Windows;
    using System.Windows.Input;
    using Telerik.Windows.Controls;
    using Telerik.Windows.Controls.TreeListView;

    public sealed class TreeListViewRowDoubleClickHandler
    {
        public TreeListViewRowDoubleClickHandler(RadTreeListView treeListView)
        {
            MouseButtonEventHandler handler = (sender, args) =>
            {
                var row = sender as TreeListViewRow;
                if (row != null)
                {
                    var methodName = GetMethodName(treeListView);

                    var dataContextType = treeListView.DataContext.GetType();
                    var method = dataContextType.GetMethod(methodName);
                    if (method == null)
                    {
                        throw new MissingMethodException(methodName);
                    }

                    method.Invoke(treeListView.DataContext, null);
                }
            };

            treeListView.RowLoaded += (s, e) =>
            {
                e.Row.MouseDoubleClick += handler;
            };

            treeListView.RowUnloaded += (s, e) =>
            {
                e.Row.MouseDoubleClick -= handler;
            };
        }

        public static string GetMethodName(RadTreeListView treeListView)
        {
            return (string)treeListView.GetValue(MethodNameProperty);
        }

        public static void SetMethodName(RadTreeListView treeListView, string value)
        {
            treeListView.SetValue(MethodNameProperty, value);
        }

        public static readonly DependencyProperty MethodNameProperty = DependencyProperty.RegisterAttached(
            "MethodName",
            typeof(string),
            typeof(TreeListViewRowDoubleClickHandler),
            new PropertyMetadata((o, e) =>
            {
                var treeListView = o as RadTreeListView;
                if (treeListView != null)
                {
                    new TreeListViewRowDoubleClickHandler(treeListView);
                }
            }));
    }
}
