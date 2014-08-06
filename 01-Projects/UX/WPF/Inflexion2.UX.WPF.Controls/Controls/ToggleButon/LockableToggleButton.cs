// -----------------------------------------------------------------------
// <copyright file="LockableToggleButton.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Controls.Controls.ToggleButton
{
    using System.Windows;
    using System.Windows.Controls.Primitives;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LockableToggleButton : ToggleButton
    {
        protected override void OnToggle()
        {
            if (!LockToggle)
            {
                base.OnToggle();
            }
        }

        public bool LockToggle
        {
            get { return (bool)GetValue(LockToggleProperty); }
            set { SetValue(LockToggleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LockToggle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LockToggleProperty =
            DependencyProperty.Register("LockToggle", typeof(bool), typeof(LockableToggleButton), new UIPropertyMetadata(false));

    }
}
