// -----------------------------------------------------------------------
// <copyright file="QueryInteractionView.xaml.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls.Dialogs.Views
{
    using Inflexion.Framework.UX.Windows.Controls.Dialogs;
    using Inflexion.Framework.UX.Windows.Controls.Dialogs.ViewModels;
    using Inflexion.Framework.UX.Windows.MVVM.ViewModels.Dialogs;
    using Inflexion.Framework.UX.Windows.MVVM.Views.Dialogs;
    using Inflexion.Framework.UX.Windows.Services;
    using Microsoft.Practices.Prism.Commands;

    /// <summary>
    /// Lógica de interacción con QueryInteractionView.xaml
    /// </summary>
    public partial class QueryInteractionView : QueryDialog,
        IBaseDialogView<BaseKeyValueItem>,
        IBaseDialogAdapter<BaseKeyValueItem>
    {
        /// <summary>
        /// Campo adapter encargado de enganchar el diálogo con su ViewModel
        /// </summary>
        private IBaseDialogAdapter<BaseKeyValueItem> adapter;

        /// <summary>
        /// Inicia una nueva instancia de la clase <see cref="QueryInteractionView" />.
        /// </summary>
        public QueryInteractionView()
        {
            this.adapter = new BaseDialogAdapter<BaseKeyValueItem>(new QueryDialogViewModel());
            this.DataContext = this.ViewModel;

            this.ViewModel.CancelCommand = new DelegateCommand(Cancel);
            this.ViewModel.OkCommand = new DelegateCommand(Ok);

            this.InitializeComponent();

            radDataFilter1.ItemPropertyDefinitions.Add(new Telerik.Windows.Controls.Data.DataFilter.ItemPropertyDefinition("Id", typeof(string), "Id"));
            radDataFilter1.ItemPropertyDefinitions.Add(new Telerik.Windows.Controls.Data.DataFilter.ItemPropertyDefinition("Nombre", typeof(string), "Nombre"));

           
        }

        /// <summary>
        /// Obtiene el ViewModel.
        /// </summary>
        /// <value>
        /// El ViewModel.
        /// </value>
        IBaseDialogViewModel<BaseKeyValueItem> IBaseDialogAdapter<BaseKeyValueItem>.ViewModel
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// Obtiene el ViewModel.
        /// </summary>
        /// <value>
        /// El ViewModel.
        /// </value>
        public QueryDialogViewModel ViewModel
        {
            get
            {
                return this.adapter.ViewModel as QueryDialogViewModel;
            }
        }

        /// <summary>
        /// Inicializa el diálogo.
        /// </summary>
        public override void Initialize()
        {
            this.ViewModel.Initialize();
        }

        /// <summary>
        /// Establece la entidad.
        /// </summary>
        /// <param name="entity">La entidad de tipo <see cref="BaseKeyValueItem"/>.</param>
        public void SetEntity(BaseKeyValueItem entity)
        {
            this.ViewModel.SetEntity(entity);
        }

        /// <summary>
        /// Obtiene la entidad.
        /// </summary>
        /// <returns>La entidad de tipo <see cref="BaseKeyValueItem"/>.</returns>
        public BaseKeyValueItem GetEntity()
        {
            return this.ViewModel.Entity;
        }

        /// <summary>
        /// Establece el título de la ventana.
        /// </summary>
        /// <param name="windowTitle">El título de la ventana.</param>
        public void SetWindowTitle(string windowTitle)
        {
            this.ViewModel.WindowTitle = windowTitle;
        }

        /// <summary>
        /// Establece el mensaje de la ventana.
        /// </summary>
        /// <param name="message">El mensaje.</param>
        public void SetMessage(string message)
        {
            this.ViewModel.Message = message;
        }

        /// <summary>
        /// Establece el servicio de consulta de la ventana.
        /// </summary>
        /// <param name="queryService">El servicio de consulta.</param>
        internal void SetQueryService(IQueryService queryService)
        {
            this.ViewModel.QueryService = queryService;
        }

        /// <summary>
        /// Establece el id de cliente en el ViewModel.
        /// </summary>
        /// <param name="idCliente">El id de cliente.</param>
        internal void SetIdCliente(int idCliente)
        {
            this.ViewModel.IdCliente = idCliente;
        }

        /// <summary>
        /// Establece el método de consulta en el ViewModel
        /// </summary>
        /// <param name="queryFunction">Función de consulta.</param>
        internal void SetQueryFunction(System.Func<System.Collections.Generic.IEnumerable<IKeyValueItem>> queryFunction)
        {
            this.ViewModel.QueryFunction = queryFunction;
        }

        /// <summary>
        /// Establece la propiedad AllowEmptyResult en el ViewModel.
        /// </summary>
        /// <param name="allowEmptyResult"><c>true</c> si se permite el valor vacío; en caso contrario, <c>false</c>.</param>
        internal void AllowEmptyResult(bool allowEmptyResult)
        {
            this.ViewModel.AllowEmptyResult = allowEmptyResult;
        }
    }
}
