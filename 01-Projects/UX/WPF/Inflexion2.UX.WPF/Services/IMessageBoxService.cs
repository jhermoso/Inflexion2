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

    public interface IMessageBoxService
    {
        MessageBoxResult Show(string message, string caption, MessageBoxButton buttons, MessageBoxImage icon, MessageBoxResult defaultResult);
        MessageBoxResult Show(string message, string caption, MessageBoxButton buttons, MessageBoxImage icon);
        MessageBoxResult Show(string message, string caption, MessageBoxButton buttons);
        void Show(string message, string caption);
        void Show(string message);
    }
}
