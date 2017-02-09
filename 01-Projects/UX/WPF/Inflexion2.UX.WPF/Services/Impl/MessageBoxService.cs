// -----------------------------------------------------------------------
// <copyright file="IModalDialogService.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Services
{
    using System.Windows;

    /// <summary>
    /// IMessageBoxService implementation
    /// </summary>
    public class MessageBoxService : IMessageBoxService
    {
        /// <summary>
        /// <see cref="IMessageBoxService.Show(string, string, MessageBoxButton, MessageBoxImage, MessageBoxResult)"/> implementation
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <param name="defaultResult"></param>
        /// <returns></returns>
        public MessageBoxResult Show(string message, string caption, MessageBoxButton buttons, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            var result = MessageBox.Show(message, caption, buttons, icon, defaultResult);

            return result;
        }

        /// <summary>
        /// <see cref="IMessageBoxService.Show(string, string, MessageBoxButton, MessageBoxImage)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public MessageBoxResult Show(string message, string caption, MessageBoxButton buttons, MessageBoxImage icon)

        {
            var result = MessageBox.Show(message, caption, buttons, icon);

            return result;
        }

        /// <summary>
        /// <see cref="IMessageBoxService.Show(string, string, MessageBoxButton)"/> implementation
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public MessageBoxResult Show(string message, string caption, MessageBoxButton buttons)
        {
            var result = MessageBox.Show(message, caption, buttons);

            return result;
        }

        /// <summary>
        /// <see cref="IMessageBoxService.Show(string, string)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        public void Show(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK);
        }

        /// <summary>
        /// <see cref="IMessageBoxService.Show(string, string)"/> implementation
        /// </summary>
        /// <param name="message"></param>
        public void Show(string message)
        {
            MessageBox.Show(message, string.Empty, MessageBoxButton.OK);
        }
    }
}
