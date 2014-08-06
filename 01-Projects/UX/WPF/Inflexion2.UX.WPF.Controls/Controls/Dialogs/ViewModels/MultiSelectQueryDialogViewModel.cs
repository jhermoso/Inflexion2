// -----------------------------------------------------------------------
// <copyright file="QueryMultipleInteractionViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Controls.Dialogs.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Inflexion2.UX.WPF.MVVM.ViewModels.Dialogs;
    using Inflexion2.UX.WPF.Services;

    /// <summary>
    /// Clase de ViewModel para el diálogo de MessageBox
    /// </summary>
    public class MultiSelectQueryDialogViewModel : BaseDialogViewModel<IEnumerable<IKeyValueItem>>
    {
        /// <summary>
        /// Backing field para WindowTitle
        /// </summary>
        private string windowTitle;

        /// <summary>
        /// Backing field para Message
        /// </summary>
        private string message;

        /// <summary>
        /// Backing field para IdCliente
        /// </summary>
        private int idCliente;

        /// <summary>
        /// Backing field para QueryFunction.
        /// </summary>
        private Func<IEnumerable<IKeyValueItem>> queryFunction;

        /// <summary>
        /// Backing field para Items.
        /// </summary>
        private ObservableCollection<IKeyValueItem> items;

        /// <summary>
        /// Backing field para la propiedad SelectedItems.
        /// </summary>
        private IEnumerable<IKeyValueItem> selectedItem;

        /// <summary>
        /// Backing field para la propiedad AllowEmptyResult.
        /// </summary>
        private bool allowEmptyResult;

        /// <summary>
        /// Backing field para la propiedad selectedString.
        /// </summary>
        private string selectedString;

        /// <summary>
        /// Obtiene y establece el botón Ok.
        /// </summary>
        /// <value>
        /// El botón Ok.
        /// </value>
        public ICommand OkCommand { get; set; }

        /// <summary>
        /// Obtiene y establece el botón Cancel.
        /// </summary>
        /// <value>
        /// El botón Cancel.
        /// </value>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Obtiene la colección de elementos.
        /// </summary>
        /// <value>
        /// La colección de elementos.
        /// </value>
        public ObservableCollection<IKeyValueItem> Items
        {
            get 
            { 
                return this.items; 
            }

            set 
            { 
                this.items = value;
                this.RaisePropertyChanged(() => this.Items);
            }
        }

        /// <summary>
        /// Obtiene o establece los elementos seleccionados en la lista.
        /// </summary>
        /// <value>
        /// Los elementos seleccionados.
        /// </value>
        public IEnumerable<IKeyValueItem> SelectedItems
        {
            get 
            { 
                return this.selectedItem; 
            }

            set 
            { 
                this.selectedItem = value;
                this.RaisePropertyChanged(() => this.SelectedItems);
                this.SetEntity(this.SelectedItems);
            }
        }

        /// <summary>
        /// Obtiene y establece el título de la ventana.
        /// </summary>
        /// <value>
        /// El titulo de la ventana.
        /// </value>
        public string WindowTitle
        {
            get
            {
                return this.windowTitle;
            }

            set
            {
                this.windowTitle = value;
                this.RaisePropertyChanged(() => this.WindowTitle);
            }
        }

        /// <summary>
        /// Obtiene y establece el mensaje de la ventana.
        /// </summary>
        /// <value>
        /// El mensaje de la ventana.
        /// </value>
        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
                this.RaisePropertyChanged(() => this.Message);
            }
        }

        /// <summary>
        /// Obtiene o establece el id de cliente.
        /// </summary>
        /// <value>
        /// el id de cliente.
        /// </value>
        public int IdCliente 
        {
            get
            {
                return this.idCliente;
            }

            set
            {
                this.idCliente = value;
                this.RaisePropertyChanged(() => this.IdCliente);
            }
        }

        /// <summary>
        /// Obtiene o establece la función de consulta.
        /// </summary>
        /// <value>
        /// La función de consulta.
        /// </value>
        public Func<IEnumerable<IKeyValueItem>> QueryFunction 
        { 
            get
            {
                return this.queryFunction;
            } 
            
            set
            {
                this.queryFunction = value;
                this.RaisePropertyChanged(() => this.QueryFunction);
            }
        }

        /// <summary>
        /// Obtiene o establece el id de cliente.
        /// </summary>
        /// <value>
        /// el id de cliente.
        /// </value>
        public string SelectedString
        {
            get
            {
                return this.selectedString;
            }

            set
            {
                this.selectedString = value;
                this.RaisePropertyChanged(() => this.SelectedString);
            }
        }
        /// <summary>
        /// Obtiene o establece un valor que indica si se añade el valor vacío a los resultados de la consulta.
        /// </summary>
        /// <value>
        ///   <c>true</c> si se permite el valor vacío; en caso contrario, <c>false</c>.
        /// </value>
        public bool AllowEmptyResult
        {
            get
            {
                return this.allowEmptyResult;
            }

            set
            {
                this.allowEmptyResult = value;
                this.RaisePropertyChanged(() => this.AllowEmptyResult);
            }
        }

        /// <summary>
        /// Obtiene los items seleccionados en la colección.
        /// </summary>
        /// <returns>Un enumerado con los items seleccionados.</returns>
        public IEnumerable<IKeyValueItem> GetSelectedItems()
        {
            return new ObservableCollection<IKeyValueItem>(this.Items.Where(i => i.IsSelected == true));
        }

        /// <summary>
        /// Inicializa el diálogo.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            this.Items = new ObservableCollection<IKeyValueItem>(this.queryFunction.Invoke());
            if (this.AllowEmptyResult)
            {
                // Agregar a la lista de clientes asociados el cliente "vacío" (para permitir la desociación de clientes).
                this.Items.Insert(0, new BaseKeyValueItem(0, string.Empty, true));
            }

            if (this.SelectedString != null)
            {
                string[] words = SelectedString.Split(',');

                foreach (IKeyValueItem item in Items)
                {
                    foreach (string w in words)
                    {
                        if (item.Id.Trim() == w.Trim())
                            item.IsSelected = true;
                    }
                }
            }

            // Quitar de la lista de clientes asociados el cliente actual (no se puede relacionar así mismo).
            if (this.IdCliente != 0)
            {
                var cliente = this.Items.FirstOrDefault(c => c.Id == this.IdCliente.ToString());
                if (cliente != null)
                {
                    this.Items.Remove(cliente);
                }
            }
         } // Initialize
    } 
} 