using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace Inflexion2.UX.WPF.Security
{
    /// <summary>
    /// This behavior controls the UI elements. 
    /// </summary>
    public class AccessBehavior : Behavior<FrameworkElement>
    {
        /// <summary>
        /// todo: update sumary
        /// </summary>
        public static DependencyProperty VMBoundedProperty = DependencyProperty.Register("VMBounded", typeof(object), typeof(AccessBehavior), new PropertyMetadata(null));

        /// <summary>
        /// todo: update sumary
        /// </summary>
        public static DependencyProperty RemoveInvisibleProperty = DependencyProperty.Register("RemoveInvisible", typeof(bool), typeof(AccessBehavior), new PropertyMetadata(null));

        /// <summary>
        /// todo: update sumary
        /// </summary>
        public static DependencyProperty CollapseInvisibleProperty = DependencyProperty.Register("CollapseInvisible", typeof(bool), typeof(AccessBehavior), new PropertyMetadata(null));

        /// <summary>
        /// todo: update sumary
        /// </summary>
        public static DependencyProperty ContextProperty = DependencyProperty.Register("Context", typeof(object), typeof(AccessBehavior), new PropertyMetadata(null));

        /// <summary>
        /// todo: update sumary
        /// </summary>
        public static DependencyProperty DTemplateProperty = DependencyProperty.Register("DTemplate", typeof(string), typeof(AccessBehavior), new PropertyMetadata(null));

        /// <summary>
        /// The template key for readonly mode.
        /// </summary>
        public static DependencyProperty DTemplateNameProperty = DependencyProperty.Register("DTemplateName", typeof(object), typeof(AccessBehavior), new PropertyMetadata(null));

        /// <summary>
        /// todo: update sumary
        /// </summary>
        public static DependencyProperty ReadOnlyTemplateProperty = DependencyProperty.Register("$NAME", typeof(DataTemplate), typeof(AccessBehavior), new PropertyMetadata(null));
        private AccessLevel _level;

        /// <summary>
        /// Gets or sets the VM bounded property.
        /// </summary>
        /// <value>The VM bounded.</value>
        public object VMBounded
        {
            get { return GetValue(VMBoundedProperty); }
            set { SetValue(VMBoundedProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [remove invisible].
        /// </summary>
        /// <value><c>true</c> if [remove invisible]; otherwise, <c>false</c>.</value>
        public bool RemoveInvisible
        {
            get { return (bool)GetValue(RemoveInvisibleProperty); }
            set { SetValue(RemoveInvisibleProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [collapse invisible].
        /// </summary>
        /// <value><c>true</c> if [collapse invisible]; otherwise, <c>false</c>.</value>
        public bool CollapseInvisible
        {
            get { return (bool)GetValue(CollapseInvisibleProperty); }
            set { SetValue(CollapseInvisibleProperty, value); }
        }

        /// <summary>
        /// todo: update sumary
        /// </summary>
        public object Context
        {
            set { SetValue(ContextProperty, value); }
            get { return GetValue(ContextProperty); }
        }

        /// <summary>
        /// todo: update sumary
        /// </summary>
        public string DTemplate
        {
            set { SetValue(DTemplateProperty, value); }
            get { return (string)GetValue(DTemplateProperty); }
        }

        /// <summary>
        /// todo: update sumary
        /// </summary>
        public object DTemplateName
        {
            set { SetValue(DTemplateNameProperty, value); }
            get { return GetValue(DTemplateNameProperty); }
        }

        /// <summary>
        /// todo: update sumary
        /// </summary>
        public DataTemplate ReadOnlyTemplate
        {
            set { SetValue(ReadOnlyTemplateProperty, value); }
            get { return (DataTemplate)GetValue(ReadOnlyTemplateProperty); }
        }

        /// <summary>
        /// Gets or sets the auth level provider.
        /// </summary>
        /// <value>The auth provider.</value>
        public static IAccessLevelProvider Provider { get; set; }

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            EnforceAuthorization();
        }

        /// <summary>
        /// Updates the UI base on authorization level.
        /// </summary>
        public void EnforceAuthorization()
        {
            _level = GetLevel(VMBounded);
            if (_level == AccessLevel.Invisible)
            {
                SetInvisible();
                return;
            }
            if (_level == AccessLevel.ReadOnly)
                SetReadOnly();
        }

        /// <summary>
        /// Sets the read only.
        /// </summary>
        private void SetReadOnly()
        {
            if (DTemplate != null)
            {
                PropertyInfo element = AssociatedObject.GetType().GetProperties().Where(p => p.Name == DTemplate).FirstOrDefault();
                if (ReadOnlyTemplate != null)
                {
                    element.SetValue(AssociatedObject, ReadOnlyTemplate, null);
                }

                if (!string.IsNullOrEmpty((string)DTemplateName))
                {
                    var template = AssociatedObject.FindResource(DTemplateName) as DataTemplate;
                    element.SetValue(AssociatedObject, template, null);
                }
            }
            else
                AssociatedObject.IsEnabled = false;
        }

        /// <summary>
        /// Sets the invisible.
        /// </summary>
        private void SetInvisible()
        {
            if (RemoveInvisible)
            {
                DependencyObject parrent = VisualTreeHelper.GetParent(AssociatedObject);
                var contentControl = parrent as ContentControl;
                if (contentControl != null)
                    contentControl.Content = null;

                var itemsControl = parrent as ItemsControl;
                if (itemsControl != null)
                    itemsControl.Items.Remove(AssociatedObject);

                var panel = parrent as Panel;
                if (panel != null)
                    panel.Children.Remove(AssociatedObject);

                var border = parrent as Border;
                if (border != null)
                    border.Child = null;
                return;
            }
            if (CollapseInvisible)
            {
                AssociatedObject.Visibility = Visibility.Collapsed;
                return;
            }
            AssociatedObject.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Gets the level from bounded property or entire VM.
        /// </summary>
        /// <param name="vmBounded">The vm bounded property.</param>
        /// <returns></returns>
        private AccessLevel GetLevel(object vmBounded)
        {
            Binding binding = BindingOperations.GetBinding(this, VMBoundedProperty);
            if (binding == null)
            {
                return AccessLevel.Unassigned;
            }

            object context = Context ?? AssociatedObject.DataContext;
            if (context == null)
            {
                return AccessLevel.Unassigned;
            }

            Type contextType = context.GetType();
            PropertyInfo[] properties = contextType.GetProperties();
            PropertyInfo bounded = properties.Where(x => x.Name == binding.Path.Path).FirstOrDefault();
            AccessLevel level = CheckLevel(bounded);
            if (level == AccessLevel.Unassigned)
            {
                level = CheckLevel(context);
            }
            return level;
        }

        /// <summary>
        /// Checks the level for class.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static AccessLevel CheckLevel(object o)
        {
            if (Provider != null)
            {
                var att = o.GetType().GetCustomAttributes(typeof(CheckAccessAttribute), true).FirstOrDefault() as CheckAccessAttribute;
                if (att == null)
                    return AccessLevel.Unassigned;

                string permissionName = att.PermissionName;
                if (string.IsNullOrEmpty(permissionName))
                {
                    permissionName = o.GetType().FullName;
                }

                return Provider.GetAccessLevel(permissionName); // delegate the decision to other component.
            }
            else
            {
                return AccessLevel.Unassigned;
            }
        }

        /// <summary>
        /// Checks the level.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <returns></returns>
        public static AccessLevel CheckLevel(PropertyInfo info)
        {
            if (info == null)
                return AccessLevel.Unassigned;

            if (Provider != null)
            {
                var att = (info.GetCustomAttributes(typeof(CheckAccessAttribute), true).FirstOrDefault() as CheckAccessAttribute);
                if (att == null) // there is no restrict. 
                    return AccessLevel.Unassigned;

                string permissionName = att.PermissionName;
                if (string.IsNullOrEmpty(permissionName))
                {
                    permissionName = string.Format("{0}.{1}", info.DeclaringType.FullName, info.Name);
                }

                return Provider.GetAccessLevel(permissionName); // delegate the decision to other component.
            }
            else
            {
                return AccessLevel.Unassigned;
            }
        }
    }
}
