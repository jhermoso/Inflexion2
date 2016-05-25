namespace Inflexion.Framework.UX.WPF.Common.BaseClasses
{
    using System.ComponentModel;
    /// <summary>
    /// Esta clase nos proporciona una implementación sobreescribible de las propiedades 
    /// de INotifyPropertyChanging, INotifyPropertyChanged. La implementación proporcionada nos 
    /// permite contar en los viewModels que la incorporen de las propiedades y metodos para elevar los eventos de pre-modificación 
    /// y modificación de una propiedad cuyo nombre se pasa como string.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region Miembros de INotifyPropertyChanging

        public event PropertyChangingEventHandler PropertyChanging;

        #endregion


        #region Miembros de INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        #region Administrative Properties

        /// <summary>
        /// Si el viewModel debiera ignorar los eventos de Property-Change.
        /// </summary>
        public virtual bool IgnorePropertyChangeEvents { get; set; }

        #endregion


        #region Public Methods

        /// <summary>
        /// eleva el evento de PropertyChanged. La propiedad especificada has sido cambiada.
        /// </summary>
        /// <param name="propertyName">El nombre de la propiedad que ha cambiado</param>
        public virtual void RaisePropertyChangedEvent(string propertyName)
        {
            // Salir si los cambios son ignorados.
            if (IgnorePropertyChangeEvents) return;

            // Salir si no se suscriben
            if (PropertyChanged == null) return;

            // Elevar el evento
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged(this, e);
        }

        /// <summary>
        /// elevar el evento de PropertyChanging. La propiedad especificada va a ser cambiada.
        /// </summary>
        /// <param name="propertyName">El nombre de la propiedad que ha cambiado.</param>
        public virtual void RaisePropertyChangingEvent(string propertyName)
        {
            // Salir si los cambios son ignorados.
            if (IgnorePropertyChangeEvents) return;

            // Salir si no se suscriben
            if (PropertyChanging == null) return;

            // Elevar el evento
            var e = new PropertyChangingEventArgs(propertyName);
            PropertyChanging(this, e);
        }

        #endregion
    }
}