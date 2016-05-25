// -----------------------------------------------------------------------
// <copyright file="IBaseDialogView.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.Views.Dialogs
{
    /// <summary>
    /// Contrato para las vistas de interacción.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad de interacción.</typeparam>
    public interface IBaseDialogView<T>
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
