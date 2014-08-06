// -----------------------------------------------------------------------
// <copyright file="IModalDialogService.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;

    public class MessageBoxService : IMessageBoxService
    {
        public MessageBoxResult Show(string message, string caption, MessageBoxButton buttons, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            var result = MessageBox.Show(message, caption, buttons, icon, defaultResult);

            return result;
        }

        public MessageBoxResult Show(string message, string caption, MessageBoxButton buttons, MessageBoxImage icon)
        {
            var result = MessageBox.Show(message, caption, buttons, icon);

            return result;
        }

        public MessageBoxResult Show(string message, string caption, MessageBoxButton buttons)
        {
            var result = MessageBox.Show(message, caption, buttons);

            return result;
        }

        public void Show(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK);
        }

        public void Show(string message)
        {
            MessageBox.Show(message, string.Empty, MessageBoxButton.OK);
        }
    }
}
