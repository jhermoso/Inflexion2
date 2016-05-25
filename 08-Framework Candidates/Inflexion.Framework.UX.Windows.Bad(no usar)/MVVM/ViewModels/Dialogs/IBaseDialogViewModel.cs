// -----------------------------------------------------------------------
// <copyright file="IGenericViewModel.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.ViewModels.Dialogs
{
    using System.ComponentModel;
    using Inflexion.Framework.UX.Windows.MVVM.Views.Dialogs;

    /// <summary>
    /// Contrato del ViewModel genérico para diálogos de interacción.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad.</typeparam>
    public interface IBaseDialogViewModel<T> : INotifyPropertyChanged
    {
        /// <summary>
        /// Establece la entidad.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        void SetEntity(T entity);

        /// <summary>
        /// Obtiene la entidad.
        /// </summary>
        /// <returns>La entidad</returns>
        T GetEntity();

        /// <summary>
        /// Se usa para inicializar el diálogo.
        /// </summary>
        void Initialize();
    }
}
