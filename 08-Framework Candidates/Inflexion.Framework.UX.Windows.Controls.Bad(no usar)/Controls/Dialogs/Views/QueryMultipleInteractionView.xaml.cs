// -----------------------------------------------------------------------
// <copyright file="QueryMultipleInteractionView.xaml.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// to use this code set the  "Build Action" in Properties Window to value "Compile" 
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls.Dialogs.Views
{
    using System.Collections.Generic;
    using System.Windows.Data;

    using Inflexion.Framework.UX.Windows.Controls.Dialogs;
    using Inflexion.Framework.UX.Windows.Controls.Dialogs;
    using Inflexion.Framework.UX.Windows.Controls.Dialogs.ViewModels;
    using Inflexion.Framework.UX.Windows.MVVM.ViewModels.Dialogs;
    using Inflexion.Framework.UX.Windows.MVVM.Views.Dialogs;
    using Inflexion.Framework.UX.Windows.Services;

    using Microsoft.Practices.Prism.Commands;
    using TelerikControls = Telerik.Windows.Controls;
    using TelerikDataFilter = Telerik.Windows.Controls.Data.DataFilter;
    using System;

    /// <summary>
    /// Lógica de interacción con QueryInteractionView.xaml
    /// </summary>
    public partial class QueryMultipleInteractionView : MultiSelectQueryDialog,
        IBaseDialogView<IEnumerable<IKeyValueItem>>,
        IBaseDialogAdapter<IEnumerable<IKeyValueItem>>
    {
        /// <summary>
        /// Campo adapter encargado de enganchar el diálogo con su ViewModel
        /// </summary>
        private IBaseDialogAdapter<IEnumerable<IKeyValueItem>> adapter;

        /// <summary>
        /// Inicia una nueva instancia de la clase <see cref="QueryInteractionView" />.
        /// </summary>
        public QueryMultipleInteractionView()
        {
            this.adapter = new BaseDialogAdapter<IEnumerable<IKeyValueItem>>(new MultiSelectQueryDialogViewModel());
            this.DataContext = this.ViewModel;

            this.ViewModel.CancelCommand = new DelegateCommand(this.Cancel);
            this.ViewModel.OkCommand = new DelegateCommand(this.Ok);

            this.InitializeComponent();
        }

        /// <summary>
        /// Obtiene el ViewModel.
        /// </summary>
        /// <value>
        /// El ViewModel.
        /// </value>
        IBaseDialogViewModel<IEnumerable<IKeyValueItem>> IBaseDialogAdapter<IEnumerable<IKeyValueItem>>.ViewModel
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// Obtiene el ViewModel.
        /// </summary>
        /// <value>
        /// El ViewModel.
        /// </value>
        public MultiSelectQueryDialogViewModel ViewModel
        {
            get
            {
                return this.adapter.ViewModel as MultiSelectQueryDialogViewModel;
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
        /// Devuelve Ok para esta instancia.
        /// </summary>
        public override void Ok()
        {
            this.ViewModel.SetEntity(this.ViewModel.GetSelectedItems());
            base.Ok();
        }

        /// <summary>
        /// Establece la entidad.
        /// </summary>
        /// <param name="entity">La entidad.</param>
        public void SetEntity(IEnumerable<IKeyValueItem> entity)
        {
            this.ViewModel.SetEntity(entity);
        }

        /// <summary>
        /// Obtiene la entidad.
        /// </summary>
        /// <returns>La entidad.</returns>
        public IEnumerable<IKeyValueItem> GetEntity()
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
        /// Establece los elementos preseleccionados en el grid.
        /// </summary>
        /// <param name="selectedString">Elementos preseleccionados.</param>
        internal void SetSelectedString(string selectedString)
        {
            this.ViewModel.SelectedString = selectedString;
        }

        /// <summary>
        /// Establece la propiedad AllowEmptyResult en el ViewModel.
        /// </summary>
        /// <param name="allowEmptyResult"><c>true</c> si se permite el valor vacío; en caso contrario, <c>false</c>.</param>
        internal void AllowEmptyResult(bool allowEmptyResult)
        {
            this.ViewModel.AllowEmptyResult = allowEmptyResult;
        }

        /// <summary>
        /// Establece las columnas a mostrar.
        /// </summary>
        /// <param name="columns">Las columnas.</param>
        internal void SetColumns(IEnumerable<QueryColumn> columns)
        {
            // Limpia el filtrado
            radDataFilter1.ItemPropertyDefinitions.Clear();

            // Elimina las columnas innecesarias, dejando sólo la columna de selección
            if (dgData.Columns.Count > 1)
            {
                for (int i = dgData.Columns.Count - 1; i > 0; i--)
                {
                    dgData.Columns.RemoveAt(i);
                }
            }

            // Crea las columnas dinámicamente con la información proprcionada.
            foreach (QueryColumn column in columns)
            {
                TelerikControls.GridViewDataColumn textColumn = new TelerikControls.GridViewDataColumn();
                textColumn.Header = column.DisplayName;
                textColumn.DataMemberBinding = new Binding(column.Binding);
                textColumn.DataFormatString = column.StringFormat;
                if (column.Width > 0)
                {
                    textColumn.Width = new TelerikControls.GridViewLength(column.Width);
                }

                dgData.Columns.Add(textColumn);
                if (column.DataType != typeof(DateTime))
                {
                    // TODO: No funciona correctamente el filtro DateTime para el caso de horas.
                    radDataFilter1.ItemPropertyDefinitions.Add(new TelerikDataFilter.ItemPropertyDefinition(column.Binding, column.DataType, column.DisplayName));
                }
            }
        }
    }
}
