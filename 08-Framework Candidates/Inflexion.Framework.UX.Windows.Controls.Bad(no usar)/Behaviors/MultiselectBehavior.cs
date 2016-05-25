// -----------------------------------------------------------------------
// <copyright file="MultiselectBehavior.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// to use this code set the  "Build Action" in Properties Window to value "Compile" 
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls.Behaviors
{
    using System.Collections;
    using System.Collections.Specialized;
    using System.Windows;
    using System.Windows.Interactivity;
    using Telerik.Windows.Controls;

    /// <summary>
    /// Behavior empleado para poder hacer binding de la colección SelectedItems del control RadGridView
    /// cuando se emplea el modo de selección múltiple.
    /// </summary>
    public class MultiselectBehavior : Behavior<RadGridView>
    {
        /// <summary>
        /// Using a DependencyProperty as the backing store for SelectedItemsProperty.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(INotifyCollectionChanged), typeof(MultiselectBehavior), new PropertyMetadata(OnSelectedItemsPropertyChanged));

        /// <summary>
        /// Obtiene o establece la propiedad en la que hacer el binding.
        /// </summary>
        public INotifyCollectionChanged SelectedItems
        {
            get { return (INotifyCollectionChanged)this.GetValue(SelectedItemsProperty); }
            set { this.SetValue(SelectedItemsProperty, value); }
        }

        /// <summary>
        /// Obtiene el grid asociado al behavior.
        /// </summary>
        /// <value>El grid.</value>
        private RadGridView Grid
        {
            get
            {
                return this.AssociatedObject as RadGridView;
            }
        }

        /// <summary>
        /// Transfiere las listas.
        /// </summary>
        /// <param name="source">El origen.</param>
        /// <param name="target">El destino.</param>
        public static void Transfer(IList source, IList target)
        {
            if (source == null || target == null)
            {
                return;
            }

            target.Clear();

            foreach (var o in source)
            {
                target.Add(o);
            }
        }

        /// <summary>
        /// Se llama al atachar la propiedad.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            this.Grid.SelectedItems.CollectionChanged += this.GridSelectedItems_CollectionChanged;
        }

        /// <summary>
        /// Se llama cuando la propiedad SelectedItems cambia.
        /// </summary>
        /// <param name="target">El target.</param>
        /// <param name="args">La instancia de tipo <see cref="DependencyPropertyChangedEventArgs"/> que contiene los datos del evento.</param>
        private static void OnSelectedItemsPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            var collection = args.NewValue as INotifyCollectionChanged;
            if (collection != null)
            {
                collection.CollectionChanged += ((MultiselectBehavior)target).ContextSelectedItems_CollectionChanged;
            }
        }

        /// <summary>
        /// Maneja el evento CollectionChanged de la colección ContextSelectedItems.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">La instancia de tipo <see cref="NotifyCollectionChangedEventArgs"/> que contiene los datos del evento.</param>
        private void ContextSelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.UnsubscribeFromEvents();

            Transfer(this.SelectedItems as IList, this.Grid.SelectedItems);

            this.SubscribeToEvents();
        }

        /// <summary>
        /// Maneja el evento CollectionChanged de la colección GridSelectedItems.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">La instancia de tipo <see cref="NotifyCollectionChangedEventArgs"/> que contiene los datos del evento.</param>
        private void GridSelectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.UnsubscribeFromEvents();

            Transfer(this.Grid.SelectedItems, this.SelectedItems as IList);

            this.SubscribeToEvents();
        }

        /// <summary>
        /// Se suscribe a los eventos.
        /// </summary>
        private void SubscribeToEvents()
        {
            this.Grid.SelectedItems.CollectionChanged += this.GridSelectedItems_CollectionChanged;

            if (this.SelectedItems != null)
            {
                this.SelectedItems.CollectionChanged += this.ContextSelectedItems_CollectionChanged;
            }
        }

        /// <summary>
        /// Se desuscribe de los eventos.
        /// </summary>
        private void UnsubscribeFromEvents()
        {
            this.Grid.SelectedItems.CollectionChanged -= this.GridSelectedItems_CollectionChanged;

            if (this.SelectedItems != null)
            {
                this.SelectedItems.CollectionChanged -= this.ContextSelectedItems_CollectionChanged;
            }
        }
    }
}