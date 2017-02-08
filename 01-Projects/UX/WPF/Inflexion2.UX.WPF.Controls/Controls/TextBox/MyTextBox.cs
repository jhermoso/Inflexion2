// -----------------------------------------------------------------------
// <copyright file="MyTextBox.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Controls
{

    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;


    /// <summary>
    /// Password watermarking code from: http://prabu-guru.blogspot.com/2010/06/how-to-add-watermark-text-to-textbox.html
    /// </summary>
    public class MyTextBox : DependencyObject
    {
        /// <summary>
        /// monitor de input of the text box
        /// </summary>
        public static readonly DependencyProperty IsMonitoringProperty = DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(MyTextBox), new UIPropertyMetadata(false, OnIsMonitoringChanged));

        /// <summary>
        /// Watermark text
        /// </summary>
        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(MyTextBox), new UIPropertyMetadata(string.Empty));

        /// <summary>
        /// internal property which decides whether the watermark text needs to be shown in box or not
        /// </summary>
        private static readonly DependencyProperty HasTextProperty = DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(MyTextBox), new FrameworkPropertyMetadata(false));

        /// <summary>
        /// finding the input text length
        /// </summary>
        public static readonly DependencyProperty TextLengthProperty = DependencyProperty.RegisterAttached("TextLength", typeof(int), typeof(MyTextBox), new UIPropertyMetadata(0));

        /// <summary>
        /// clear watermark when click on text box
        /// </summary>
        public static readonly DependencyProperty ClearTextButtonProperty = DependencyProperty.RegisterAttached("ClearTextButton", typeof(bool), typeof(MyTextBox), new FrameworkPropertyMetadata(false, ClearTextChanged));

        /// <summary>
        /// Setter Property ismonitoring
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetIsMonitoring(
                                           DependencyObject obj,
                                           bool value)
        {
            obj.SetValue(IsMonitoringProperty, value);
        }

        /// <summary>
        /// Getter property
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        /// <summary>
        /// Setter Property
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetWatermark( DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        private static void SetTextLength( DependencyObject obj, int value)
        {
            obj.SetValue(TextLengthProperty, value);
            obj.SetValue(HasTextProperty, value >= 1);
        }

        /// <summary>
        /// Wrapper dependency property has text
        /// </summary>
        public bool HasText
        {
            get { return (bool)GetValue(HasTextProperty); }
        }

        static void OnIsMonitoringChanged(
                                          DependencyObject d,
                                          DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox)
            {
                var txtBox = d as TextBox;

                if ((bool)e.NewValue)
                {
                    SetTextLength(txtBox, txtBox.Text.Length);
                    txtBox.TextChanged += TextChanged;
                }
                else
                    txtBox.TextChanged -= TextChanged;
            }
            else if (d is PasswordBox)
            {
                var passBox = d as PasswordBox;

                if ((bool)e.NewValue)
                {
                    SetTextLength(passBox, passBox.Password.Length);
                    passBox.PasswordChanged += PasswordChanged;
                }
                else
                    passBox.PasswordChanged -= PasswordChanged;
            }
        }

        static void TextChanged(
                                object sender,
                                TextChangedEventArgs e)
        {
            var txtBox = sender as TextBox;
            if (txtBox == null)
                return;
            SetTextLength(txtBox, txtBox.Text.Length);
        }

        static void PasswordChanged(
                                    object sender,
                                    RoutedEventArgs e)
        {
            var passBox = sender as PasswordBox;
            if (passBox == null)
                return;
            SetTextLength(passBox, passBox.Password.Length);
        }

        /// <summary>
        /// Wrapper dependency property get clear
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool GetClearTextButton(DependencyObject d)
        {
            return (bool)d.GetValue(ClearTextButtonProperty);
        }

        /// <summary>
        /// Setter Clear 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetClearTextButton(DependencyObject obj, bool value)
        {
            obj.SetValue(ClearTextButtonProperty, value);
        }

        private static void ClearTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textbox = d as TextBox;
            if (textbox != null)
                textbox.Loaded += TextBoxLoaded;
        }

        static void TextBoxLoaded(object sender, RoutedEventArgs e)
        {
            if (!(sender is TextBox))
                return;

            var textbox = sender as TextBox;
            if (textbox.Style == null)
                return;

            var setter = textbox.Style.Setters.FirstOrDefault(s => ((Setter)s).Property.ToString() == "Template") as Setter;

            if (setter == null)
                return;

            var template = setter.Value as ControlTemplate;
            if (template == null)
                return;

            var button = template.FindName("PART_ClearText", textbox) as Button;
            if (button == null)
                return;

            if (GetClearTextButton(textbox))
                button.Click += ClearTextClicked;
            else
                button.Click -= ClearTextClicked;
        }

        static void ClearTextClicked(object sender, RoutedEventArgs e)
        {
            var button = ((Button)sender);
            var parent = VisualTreeHelper.GetParent(button);
            while (!(parent is TextBox))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            ((TextBox)parent).Text = string.Empty;
        }

    } // MyTextBox

} // Inflexion2.UX.WPF.Controls