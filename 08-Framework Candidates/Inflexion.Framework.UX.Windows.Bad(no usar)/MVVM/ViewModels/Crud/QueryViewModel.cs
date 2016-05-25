// -----------------------------------------------------------------------
// <copyright file="QueryViewModel.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.CRUD
{
    using System;
    using System.Collections.ObjectModel;
    using Inflexion.Framework.Application.DataTransfer.Core;
    using Inflexion.Framework.UX.Windows.MVVM.ViewModels;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Prism;
    using Microsoft.Practices.Prism.Regions;

    /// <summary>
    /// Clase pública que representa la Vista Modelo Base de la cuál tiran el
    /// resto de ViewModels.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public abstract class QueryViewModel<T, TView> : WorkspaceViewModel where T : IEntityViewModel
    {

        private T item;
        private ObservableCollection<T> items;
        private SpecificationDto specification = new SpecificationDto();

        #region CONSTRUCTORS

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public QueryViewModel()
        {
            if (!this.IsDesignTime)
            {
                // Inicializamos el objeto colección genérica.
                this.Items = new ObservableCollection<T>();
                this.Specification = new SpecificationDto() { PageIndex = 0, PageSize = 10 };
            }
        }

        #endregion

        #region PROPERTIES

        public T SelectedItem
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
                RaisePropertyChanged(()=> this.SelectedItem);

                

                this.RefreshCommands();
            }
        }

        public ObservableCollection<T> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
                RaisePropertyChanged(() => this.Items);
            }
        }

        public override string Title
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Variable privada utilizada para obtener y establecer el número de 
        /// registros cargados.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        private int totalRecordCount = 0;

        /// <summary>
        /// Propiedad pública encargada de obtener e indicar el número de registros 
        /// cargados en el control de datos.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public int TotalRecordCount
        {
            get
            {
                return totalRecordCount;
            }
            set
            {
                if (this.totalRecordCount != value)
                {
                    this.totalRecordCount = value;
                    RaisePropertyChanged(() => this.TotalRecordCount);
                }
            }
        } // TotalRecordCount

        private int pageIndex = 0;
        public int PageIndex
        {
            get
            {
                return pageIndex;
            }
            set
            {
                if (this.pageIndex != value)
                {
                    this.pageIndex = value;
                    if (value >= 0)
                    {
                        this.Specification.PageIndex = value;
                        this.OnGetRecords(null);
                        RaisePropertyChanged(() => this.PageIndex);
                    }
                }
            }
        } // PageIndex

        private int pageSize = 10;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                if (this.pageSize != value)
                {
                    this.pageSize = value;
                    this.Specification.PageSize = value;
                    RaisePropertyChanged(() => this.PageSize);
                }
            }
        } // PageSize

        public SpecificationDto Specification
        {
            get
            {
                return this.specification;
            }
            set
            {
                if (this.specification != value)
                {
                    this.specification = value;
                    this.RaisePropertyChanged(() => this.Specification);
                }
            }
        }

        #endregion

        public override bool CanActivateRecord(object parameter)
        {
            return (this.SelectedItem != null && !this.SelectedItem.Activo);
        }

        public override bool CanGetRecords(object parameter)
        {
            return true;
        }

        public override bool CanNewRecord(object parameter)
        {
            return true;
        }

        public override bool CanDeleteRecord(object parameter)
        {
            return (this.SelectedItem != null && this.SelectedItem.Activo);
        }

        public override bool CanEditRecord(object parameter)
        {
            return this.SelectedItem != null;
        }

        protected virtual void NavigateToRecord(int id)
        {
            if (this.IsActive)
            {
                this.NavigationService.NavigateToWorkSpace(typeof(TView).FullName, id);
            }
        }

        public override void OnNewRecord(object parameter)
        {
            this.NavigateToRecord(0);
        }

        public override void OnEditRecord(object parameter)
        {
            this.NavigateToRecord(this.item.Id);
        }

        public virtual void NavigateToSelectedItem()
        {
            NavigateToRecord(this.item.Id);
        }

        protected void RefreshCommands()
        {
            var cmd = this.deleteRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            cmd = this.editRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            cmd = this.saveRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            cmd = this.activateRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();
        }

    }
}