// -----------------------------------------------------------------------
// <copyright file="IModalDialogService.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Services
{
    using System.Windows;

    /// <summary>
    /// Messages services for user interface
    /// </summary>
    public interface IMessageBoxService
    {
        /// <summary>
        /// Show a message with captation, buttons icon and default result
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <param name="defaultResult"></param>
        /// <returns></returns>
        MessageBoxResult Show(string message, string caption, MessageBoxButton buttons, MessageBoxImage icon, MessageBoxResult defaultResult);

        /// <summary>
        /// Show e message with captation buttons and icon
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        MessageBoxResult Show(string message, string caption, MessageBoxButton buttons, MessageBoxImage icon);

        /// <summary>
        /// Show a message with captation and buttons
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        MessageBoxResult Show(string message, string caption, MessageBoxButton buttons);

        /// <summary>
        /// Show a message with captatio
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        void Show(string message, string caption);

        /// <summary>
        /// Show a message.
        /// </summary>
        /// <param name="message"></param>
        void Show(string message);
    }
}
