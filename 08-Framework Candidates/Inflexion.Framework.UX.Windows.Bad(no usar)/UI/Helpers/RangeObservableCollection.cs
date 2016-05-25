// -----------------------------------------------------------------------
// <copyright file="RangeObservableCollection.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;

    /// <summary>
    /// Esta clase hereda de ObservableCollection y soporta añadir bloques de entidades.
    /// </summary>
    /// <typeparam name="T">El tipo a implementar.</typeparam>
    public class RangeObservableCollection<T> : ObservableCollection<T> where T : class
    {
        /// <summary>
        /// Flag que hace que se inhiba o se dispare el evento OnCollectionChanged
        /// </summary>
        private bool suppressNotification = false;

        /// <summary>
        /// Agrega un rango de elementos a la ObservableCollection.
        /// </summary>
        /// <param name="list">La lista de entidades.</param>
        /// <exception cref="System.ArgumentNullException">Eleva una excepción si la lista suministrada es nula.</exception>
        public void AddRange(IEnumerable<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            // Deshabilitamos el evento OncollectionChanged por motivos de rendimiento.
            this.suppressNotification = true;

            // Añadimos los elementos solicitados a la colección.
            foreach (T item in list)
            {
                this.Add(item);
            }

            // Rehabilitamos el evento OnCollectionChanged.
            this.suppressNotification = false;

            // Después de toda la operación, notificamos que la colección ha sido modificada.
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Levanta el evento <see cref="E:CollectionChanged" />.
        /// </summary>
        /// <param name="e">La instancia <see cref="NotifyCollectionChangedEventArgs" /> conteniendo los datos del evento.</param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            // Notifica que la colección ha sido modificada
            if (!this.suppressNotification)
            {
                base.OnCollectionChanged(e);
            }
        }
    }
}

