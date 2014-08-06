// -----------------------------------------------------------------------
// <copyright file="GenericViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.ViewModels.Dialogs
{

    /// <summary>
    /// Clase que representa un ViewModel genérico para una solicitud de interacción.
    /// </summary>
    /// <typeparam name="T">
    /// Tipo de la entidad para la solicitud de itneracción.
    /// </typeparam>
    public class BaseDialogViewModel<T> : BaseViewModel, IBaseDialogViewModel<T>
    {

        /// <summary>
        /// Obtiene o establece la entidad.
        /// </summary>
        /// <value>
        /// La entidad.
        /// </value>
        public virtual T Entity { get; private set; }

        /// <summary>
        /// Establece la entidad.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        public void SetEntity(T entity)
        {
            this.Entity = entity;
            this.RaisePropertyChanged(() => Entity);
        }

        /// <summary>
        /// Obtiene la entidad.
        /// </summary>
        /// <returns>La entidad.</returns>
        public T GetEntity()
        {
            return this.Entity;
        }

        /// <summary>
        /// Se usa para inicializar el diálogo.
        /// </summary>
        public virtual void Initialize()
        {
        }

    }// GenericViewModel

} // Inflexion2.UX.WPF.MVVM.ViewModels.Dialogs