// -----------------------------------------------------------------------
// <copyright file="QueryViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.CRUD
{
    using System;
    using System.Collections.ObjectModel;
    using Inflexion2.Application.DataTransfer.Core;
    using Inflexion2.UX.WPF.MVVM.ViewModels;
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
    public abstract class QueryViewModel<T, TView, TIdentifier> : WorkspaceViewModel 
        where T : IEntityViewModel<TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
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
                this.PageSize = 5; // TODO inicializar estos valores con settings/ preferencias
                this.PageIndex = 0;// TODO inicializar estos valores con settings/preferencias
                this.Specification = new SpecificationDto() { PageIndex = this.PageIndex, PageSize = this.PageSize };
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
        /// .es Variable calculada para obtener el numero de paginas en función del numero de registros y el numero de registros paginados.
        /// .en Private variable to calculate the total pages
        /// </summary>
        public int TotalPagesCount
        {
            get
            {
                if (this.PageSize != 0 )
                { 
                    return ((this.TotalRecordCount + this.PageSize - 1) / this.PageSize)-1;// las páginas empiezan en cero
                }
                return 0;
            }
        } // TotalRecordCount

        /// <summary>
        /// .es Variable privada utilizada para obtener y establecer el número de 
        /// registros cargados.
        /// </summary>
        /// <remarks>
        /// .es Sin comentarios adicionales.
        /// </remarks>
        private int totalRecordCount = 0;

        /// <summary>
        /// Propiedad pública encargada de obtener e indicar el número de registros 
        /// cargados en el control de datos.
        /// </summary>
        /// <remarks>
        /// .es Sin comentarios adicionales.
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

                        this.RefreshPagingCommands();
                    }
                }
            }
        } // PageIndex

        private int pageSize ;// = 10
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

        public Inflexion2.Application.DataTransfer.Core.SpecificationDto Specification
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
            return (this.SelectedItem != null /* && !this.SelectedItem.Activo */); // todo: incluir en nuevos view models para business entity
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
            return (this.SelectedItem != null /*&& this.SelectedItem.Activo*/ ); // todo: incluir en nuevos view models para business entity
        }

        public override bool CanEditRecord(object parameter)
        {
            return this.SelectedItem != null;
        }

        public override bool CanGetFirstPageRecords(object parameter)
        {
            if (this.totalRecordCount == 0)
            {
                return true;
            }
            return this.PageIndex != 0;
        }

        public override bool CanGetNextPageRecords(object parameter)
        {
            if (this.totalRecordCount == 0)
            {
                return true;
            }
            return this.pageIndex >= 0 && this.pageIndex < TotalPagesCount;
        }

        public override bool CanGetPreviousPageRecords(object parameter)
        {
            if (this.totalRecordCount == 0)
            {
                return false;
            }
            return this.pageIndex > 0 && this.pageIndex <= TotalPagesCount;
        }

        public override bool CanGetLastPageRecords(object parameter)
        {
            if (this.totalRecordCount == 0)
            {
                return true;
            }
            return this.pageIndex != TotalPagesCount;
        }

        protected virtual void NavigateToRecord(TIdentifier id)
        {
            //if (this.IsActive)
            //{
                this.NavigationService.NavigateToWorkSpace(typeof(TView).FullName, id);
            //}
        }

        public override void OnNewRecord(object parameter)
        {
            this.NavigateToRecord(default(TIdentifier));
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

            //cmd = this.saveRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            //cmd.RaiseCanExecuteChanged();

            cmd = this.activateRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            this.RefreshPagingCommands();
        }

        protected void RefreshPagingCommands()
        {
            var cmd = this.getFirstPageRecordsCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            cmd     = this.getNextPageRecordsCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            cmd     = this.getPreviousPageRecordsCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            cmd     = this.getLastPageRecordsCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();
        }

    }
}