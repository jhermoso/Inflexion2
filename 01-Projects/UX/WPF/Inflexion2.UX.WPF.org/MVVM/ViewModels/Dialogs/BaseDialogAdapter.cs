// -----------------------------------------------------------------------
// <copyright file="GenericAdapter.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.ViewModels.Dialogs
{
    /// <summary>
    /// Adaptador genérico para la interacción involucrando una entidad o tipo de datos.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad.</typeparam>
    public class BaseDialogAdapter<T> : IBaseDialogAdapter<T>
    {
        /// <summary>
        /// Campo que contiene el ViewModel 
        /// </summary>
        private readonly IBaseDialogViewModel<T> viewModel;

        /// <summary>
        /// Inicia una nueva instancia de la clase <see cref="BaseDialogAdapter&lt;T&gt;"/>.
        /// </summary>
        public BaseDialogAdapter() : this(new BaseDialogViewModel<T>())
        {
        }

        /// <summary>
        /// Inicia una nueva instancia de la clase <see cref="BaseDialogAdapter&lt;T&gt;"/>.
        /// </summary>
        /// <param name="viewModel">El ViewModel.</param>
        public BaseDialogAdapter(IBaseDialogViewModel<T> viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// Obtiene el ViewModel.
        /// </summary>
        public IBaseDialogViewModel<T> ViewModel
        {
            get { return this.viewModel; }
        }

        /// <summary>
        /// Establece la entidad.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        public void SetEntity(T entity)
        {
            this.ViewModel.SetEntity(entity);
        }

        /// <summary>
        /// Obtiene la entidad.
        /// </summary>
        /// <returns>La entidad.</returns>
        public T GetEntity()
        {
            return this.ViewModel.GetEntity();
        }
    }
}
