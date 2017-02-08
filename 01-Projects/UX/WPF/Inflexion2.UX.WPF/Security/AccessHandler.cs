namespace Inflexion2.UX.WPF.Security
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interactivity;
    using System.Windows.Controls.Primitives;

    /// <summary>
    /// todo: update sumary
    /// </summary>
    public sealed class AccessHandler
    {
        /// <summary>
        /// todo: update sumary
        /// </summary>
        /// <param name="obj"></param>
        public AccessHandler(DependencyObject obj)
        {
            bool authorize = GetCheck(obj);
            BehaviorCollection behaviors = Interaction.GetBehaviors(obj);
            AccessBehavior authorizationBehavior = behaviors.SingleOrDefault(x => x is AccessBehavior) as AccessBehavior;

            if (authorizationBehavior != null && !authorize)
            {
                behaviors.Remove(authorizationBehavior);
            }
            else if (authorizationBehavior == null && authorize)
            { 
                authorizationBehavior = new AccessBehavior();

                var binding = BindingOperations.GetBinding(obj, TextBox.TextProperty);
                if (binding != null)
                {
                    BindingOperations.SetBinding(authorizationBehavior, AccessBehavior.VMBoundedProperty, binding);
                }

                binding = BindingOperations.GetBinding(obj, ItemsControl.ItemsSourceProperty);
                if (binding != null)
                {
                    BindingOperations.SetBinding(authorizationBehavior, AccessBehavior.VMBoundedProperty, binding);
                }

                binding = BindingOperations.GetBinding(obj, ButtonBase.CommandProperty);
                if (binding != null)
                {
                    BindingOperations.SetBinding(authorizationBehavior, AccessBehavior.VMBoundedProperty, binding);
                }

                behaviors.Add(authorizationBehavior);
            }         
        }

        /// <summary>
        /// todo: update sumary
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetCheck(DependencyObject obj)
        {
            return (bool)obj.GetValue(CheckProperty);
        }

        /// <summary>
        /// todo: update sumary
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetCheck(DependencyObject obj, bool value)
        {
            obj.SetValue(CheckProperty, value);
        }

        /// <summary>
        /// todo: update sumary
        /// </summary>
        public static readonly DependencyProperty CheckProperty = DependencyProperty.RegisterAttached(
            "Check",
            typeof(bool),
            typeof(AccessHandler),
            new PropertyMetadata((o, e) =>
            {
                DependencyObject obj = o as DependencyObject;
                if (obj != null)
                {
                    new AccessHandler(obj);
                }
            }));
    }
}