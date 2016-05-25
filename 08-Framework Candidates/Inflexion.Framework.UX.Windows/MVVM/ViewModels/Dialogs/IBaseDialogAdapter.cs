// -----------------------------------------------------------------------
// <copyright file="IGenericAdapter.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.ViewModels.Dialogs
{
    /// <summary>
    /// Contrato para los adaptadores para interacción.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad para la interacción.</typeparam>
    public interface IBaseDialogAdapter<T>
    {
        /// <summary>
        /// Obtiene el ViewModel.
        /// </summary>
        IBaseDialogViewModel<T> ViewModel { get; }
    }
}
