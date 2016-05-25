// -----------------------------------------------------------------------
// <copyright file="GenericInteractionDialogBase.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.Dialogs
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Clase base para los diálogos de interacción
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad del diálogo de interacción</typeparam>
    public class BaseDialog<T> : UserControl
    {
        /// <summary>
        /// Inicia una nueva instancia de la clase <see cref="BaseDialog&lt;T&gt;"/>.
        /// </summary>
        public BaseDialog()
        {
        }

        /// <summary>
        /// Occurs when Dialog is closed via OK
        /// </summary>
        public event EventHandler ConfirmEventHandler;

        /// <summary>
        /// Occurs when Dialog is closed via Cancel
        /// </summary>
        public event EventHandler CancelEventHandler;

        /// <summary>
        /// Inicializa el diálogo.
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Method to close the dialog with OK result
        /// </summary>
        public virtual void Ok()
        {
            this.OnClose(new BaseDialogEventArgs(DialogResultType.OK));
        }

        /// <summary>
        /// Method to close the dialog with Cancel result
        /// </summary>
        public virtual void Cancel()
        {
            this.OnClose(new BaseDialogEventArgs(DialogResultType.Cancel));
        }

        /// <summary>
        /// Raises the <see cref="E:ConfirmEventHandler"/> or the <see cref="E:CancelEventHandler"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Teki.Frontend.Common.Interactions.InteractionEventArgs"/> instance containing the event data.</param>
        protected void OnClose(BaseDialogEventArgs e)
        {
            var handler = (e.Type == DialogResultType.OK) ? this.ConfirmEventHandler : this.CancelEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Obtiene un valor que indica si la vista es una vista en tiempo de diseño.
        /// </summary>
        /// <value>
        /// Es true si la vista es una vista en tiempo de diseño; en caso contrario, false.
        /// </value>
        protected bool IsDesignTime
        {
            get
            {
                return (bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(
                    typeof(DependencyObject)).DefaultValue;
            }
        }
    }
}
