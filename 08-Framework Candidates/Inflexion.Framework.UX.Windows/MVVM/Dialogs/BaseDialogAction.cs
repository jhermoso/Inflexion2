// -----------------------------------------------------------------------
// <copyright file="GenericInteractionAction.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.Dialogs
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    using Inflexion.Framework.UX.Windows.MVVM.Dialogs;
    using Inflexion.Framework.UX.Windows.MVVM.Views.Dialogs;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Acción genérica para mostrar un diálogo de interacción para el tipo involucrado.
    /// </summary>
    /// <typeparam name="T">Tipo o entidad involucrado en la interacción.</typeparam>
    public class BaseDialogAction<T> : TriggerAction<Grid>
    {
        /// <summary>
        /// Propiedad de dependencia Dialog
        /// </summary>
        public static readonly DependencyProperty DialogProperty =
            DependencyProperty.Register("Dialog", typeof(BaseDialog<T>), typeof(BaseDialogAction<T>), new PropertyMetadata(null));

        /// <summary>
        /// Grid que va a contener el diálogo
        /// </summary>
        private Grid parentElement;

        /// <summary>
        /// Diccionario que mantiene el estado de la aplicación.
        /// </summary>
        private Dictionary<UIElement, bool> currentState = new Dictionary<UIElement, bool>();

        /// <summary>
        /// Obtiene o establece el diálogo.
        /// </summary>
        /// <value>
        /// El diálogo.
        /// </value>
        public BaseDialog<T> Dialog
        {
            get { return (BaseDialog<T>)GetValue(DialogProperty); }
            set { SetValue(DialogProperty, value); }
        }

        /// <summary>
        /// Invoca la acción.
        /// </summary>
        /// <param name="parameter">El parámetro de la acción. Si la acción no requiere parámetro, puede ser establecido a null.</param>
        protected override void Invoke(object parameter)
        {
            var args = parameter as BaseDialogRequestEventArgs<T>;
            this.SetDialog(args.Entity, args.Callback, args.CancelCallback, null);
            this.Initialize();
        }

        /// <summary>
        /// Establece el diálogo.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        /// <param name="callback">El callback para la acción Ok.</param>
        /// <param name="cancelCallback">El callback para la acción Cancel.</param>
        /// <param name="element">El elemento de UI.</param>
        protected virtual void SetDialog(T entity, Action<T> callback, Action cancelCallback, UIElement element)
        {
            if (this.Dialog is IBaseDialogView<T>)
            {
                IBaseDialogView<T> view = this.Dialog as IBaseDialogView<T>;
                view.SetEntity(entity);

                EventHandler handler = null;
                handler = (s, e) =>
                {
                    this.Dialog.ConfirmEventHandler -= handler;
                    this.Dialog.CancelEventHandler -= handler;
                    this.parentElement.Children.Remove(this.Dialog);

                    if (e.ToString() == DialogResultType.OK.ToString())
                    {
                        callback(view.GetEntity());
                    }
                    else
                    {
                        cancelCallback();
                    }

                    this.RestorePreviousState();
                };

                this.Dialog.ConfirmEventHandler += handler;
                this.Dialog.CancelEventHandler += handler;
                this.parentElement = System.Windows.Application.Current.MainWindow.Content as Grid;
                this.Dialog.SetValue(Grid.RowSpanProperty, this.parentElement.RowDefinitions.Count == 0 ? 1 : this.parentElement.RowDefinitions.Count);
                this.Dialog.SetValue(Grid.ColumnSpanProperty, this.parentElement.ColumnDefinitions.Count == 0 ? 1 : this.parentElement.ColumnDefinitions.Count);
                this.parentElement.Children.Add(Dialog);
                this.SaveCurrentState();
            }
        }

        /// <summary>
        /// Se emplea para inicializar el diálogo.
        /// </summary>
        protected virtual void Initialize()
        {
            if (this.Dialog is IBaseDialogView<T>)
            {
                ((IBaseDialogView<T>)this.Dialog).Initialize();
            }
        }

        /// <summary>
        /// Guarda el estado actual de la aplicación
        /// </summary>
        private void SaveCurrentState()
        {
            IEnumerator en = this.parentElement.Children.GetEnumerator();
            while (en.MoveNext())
            {
                if (en.Current != this.Dialog)
                {
                    UIElement element = (UIElement)en.Current;
                    this.currentState.Add(element, element.IsEnabled);
                    element.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// Restaura el estado anterior al diálogo modal.
        /// </summary>
        private void RestorePreviousState()
        {
            foreach (UIElement element in this.currentState.Keys)
                element.IsEnabled = this.currentState[element];

            this.currentState.Clear();
        }
    }
}
