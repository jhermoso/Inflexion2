// -----------------------------------------------------------------------
// <copyright file="QueryViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.CRUD
{
    using System;
    using System.Collections.ObjectModel;
    using Inflexion2.Application;
    using Inflexion2.UX.WPF.MVVM.ViewModels;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Prism;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.Events;
    using System.Collections.Generic;
    using System.Windows.Controls;


    /// <summary>
    /// .en Generic abstract Base class for the Query View Models.
    /// this kind of ViewModel are prepared to manage collection of entities whose are Root Aggreagates.
    /// .es Clase generica y abstracta de la que derivan los query view models. 
    /// Este tipo de view models se utiza para manejar conjuntos de entidades que son root aggregates
    /// es decir que puedne tener operaciones CRUD sobre el repositorio.
    /// </summary>
    public abstract class ValueObjQueryViewModel<TVoVm, TView, TDto> : WorkspaceViewModel 
        where TVoVm : ValueObjCrudViewModel<TDto>, IValueObjViewModel, System.ComponentModel.IEditableObject, new()
        where TView : UserControl
        where TDto : BaseValueObjectDataTransferObject
    {
        #region Fields

        private TVoVm item;
        // esta collección se inicializa en el metodo getRecords de los view models derivados y que se aplican ya entidades concretas
        protected internal ObservableCollection<TVoVm> _items ;
        // La inizialización de este campo hace que se ejecute antes que la cadena de constructores.
        // y debe estar inizializado para evitar que prism genere una excepción de navegación.
        private SpecificationDto specification = new SpecificationDto() ;

        /// <summary>
        /// .es Variable privada utilizada para obtener y establecer el número de 
        /// registros cargados.
        /// </summary>
        private int totalRecordCount = 0;
        private int pageIndex = 0;
        private int pageSize;// = 10


        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// .es Inicializacion de base para una nueva instancia de un nuevo query view model.
        /// </summary>
        public ValueObjQueryViewModel()
        {
            if (!this.IsDesignTime)
            {
                // Inicializamos el objeto colección genérica.
                this.Items = new ObservableCollection<TVoVm>();
                this.PageSize = 5; // TODO inicializar estos valores con settings/ preferencias
                this.PageIndex = 0;// TODO inicializar estos valores con settings/preferencias
                this.Specification = new SpecificationDto() { PageIndex = this.PageIndex, PageSize = this.PageSize };
            }
        }


        #endregion

        #region PROPERTIES

        /// <summary>
        /// .es todos los viewmodels de query manejan siempre una colleción de entidades 
        /// que son root aggregate y que se guardan en un repositorio.
        /// Para cualquier collección es importante saber sobre que registro se desea aplicar una operación.
        /// Esta propiedad mantiene una sicronización con el control de usuario (datagrid o cualquier otro tipo)
        /// indicandonos cual es el registro o entidad seleccionado.
        /// </summary>
        public TVoVm SelectedItem
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

        /// <summary>
        /// .es Mantiene la coleccion de viewmodels de las entidades que deseamos manejar.
        /// En este caso cada linea de el datagrid o del control seleccionado tiene su propio view model.
        /// Este tiene asu vez la información del registro correspondiente o de la entidad que vamos a mostrar en una linea concreta.
        /// </summary>
        public ObservableCollection<TVoVm> Items
        {
            get
            {
                return this._items;
            }
            set
            {
                // este set se lleva a acabo en el metodo getrecords de los view models derivados sobre entidades concretas
                this._items = value;
                RaisePropertyChanged(() => this.Items);
            }
        }

        /// <summary>
        /// Esta es la propiedad que proporciona el nombre a la ventana o al control de usuario donde 
        /// se va a visualizar este view model.
        /// </summary>
        public override string Title
        {
            get; set;
        }

        /// <summary>
        /// .en Variable to calculate the total pages.
        /// .es Variable calculada para obtener el numero de paginas en función del numero de registros y el numero de registros paginados.
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
        } // end TotalPagesCount

        /// <summary>
        /// Propiedad pública encargada de obtener e indicar el número de registros 
        /// cargados en el control de datos.
        /// </summary>
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


        /// <summary>
        /// .es Indice actual correspondiente a la página en la que nos encontramos.
        /// </summary>
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
                        this.OnGetRecords("from QueryViewModel");
                        RaisePropertyChanged(() => this.PageIndex);

                        this.RefreshPagingCommands();
                    }
                }
            }
        } // PageIndex

        /// <summary>
        /// .es Tamaño en registros que se desean visualizar en una página.
        /// </summary>
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

        /// <summary>
        /// This property is used to stablish a common base filtering over the collection of items asociated to the QueryViewModel
        /// </summary>
        public Inflexion2.Application.SpecificationDto Specification
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

        #region Can Methods  for commands

        /// <summary>
        /// method to decide if the record can be activated
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanActivateRecord(object parameter)
        {
            return (this.SelectedItem != null /* && !this.SelectedItem.Activo */); // todo: incluir en nuevos view models para business entity
        }

        /// <summary>
        /// method to decide if is possible to read the records
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanGetRecords(object parameter)
        {           
            return true;
        }

        /// <summary>
        /// method to decide if is possible to add a new record
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanNewRecord(object parameter)
        {
            return true;
        }

        /// <summary>
        /// method to decide if is possible to delete one record
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanDeleteRecord(object parameter)
        {
            return (this.SelectedItem != null /*&& this.SelectedItem.Activo*/ ); // todo: incluir en nuevos view models para business entity
        }

        /// <summary>
        /// method to decide if is possible to edit the record
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanEditRecord(object parameter)
        {
            return this.SelectedItem != null;
        }

        /// <summary>
        /// method to decide if is possible to go to the first page
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanGetFirstPageRecords(object parameter)
        {
            if (this.TotalRecordCount == 0)
            {
                return false;
            }

            
            return this.TotalPagesCount > 0 && this.PageIndex != 0;
        }

        /// <summary>
        /// .en method to decide if is possible to go to the next page
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanGetNextPageRecords(object parameter)
        {
            if (this.TotalRecordCount == 0)
            {
                return false;
            }

            return this.TotalPagesCount > 0 && this.PageIndex >= 0 && this.PageIndex < TotalPagesCount;
        }

        /// <summary>
        /// method to decide if is possible to go to the Previous page
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanGetPreviousPageRecords(object parameter)
        {
            if (this.TotalRecordCount == 0)
            {
                return false;
            }

            return this.TotalPagesCount > 0 && this.pageIndex > 0 && this.pageIndex <= TotalPagesCount;
        }

        /// <summary>
        /// method to decide if is possible to go to the last page
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanGetLastPageRecords(object parameter)
        {
            if (this.TotalRecordCount == 0)
            {
                return false;
            }

            return this.TotalPagesCount > 0 && this.pageIndex != TotalPagesCount;
        }

        #endregion

        /// <summary>
        /// go to the record with dto
        /// </summary>
        /// <param name="valueObj"></param>
        public virtual void NavigateToRecord(TDto valueObj)
        {
            if (this.Specification == null)
            {
                this.NavigationService.NavigateToWorkSpace(typeof(TView).FullName, valueObj);
            }
            else
            {
                //this.NavigationService.NavigateToWorkSpace(typeof(TView).FullName, valueObj, this.Specification);
            }
        }

        /// <summary>
        /// go to the new record
        /// </summary>
        /// <param name="parameter"></param>
        public override void OnNewRecord(object parameter)
        {
            this.NavigateToRecord(null);
        }

        /// <summary>
        /// edit the record
        /// </summary>
        /// <param name="parameter"></param>
        public override void OnEditRecord(object parameter)
        {
            this.NavigateToRecord(this.SelectedItem.ObjectElement);
        }

        /// <summary>
        /// open the selected record
        /// this method is invoked from DataGridRowDoubleClickHandler
        /// </summary>
        public virtual void NavigateToSelectedItem()
        {
            // todo: add a queryrecordviewmodel  for the rows inthe query viewmodel and field flag to tell if the queryviewmodel is root or is emmbebed inside a parent viewmodel
            if (this.item != null)
            {
                //NavigateToRecord(this.item.Id);
            }
        }


        /// <summary>
        /// .en Get First Page records method. 
        ///     This command answer to a call from the ribbon region tab.
        /// .es ejecutamos el servicio de ir a la primera página de la lista de registros. 
        ///     responde al command invocado desde su comando en la region del ribbon.
        /// </summary>
        /// <param name="parameter">.en aditional info to pass to this method .es informacion adicional </param>
        public override void OnGetFirstPageRecords(object parameter)
        {
            this.PageIndex = 0;
        }

        /// <summary>
        /// .en Get Next Page records method. 
        ///     This command answer to a call from the ribbon region tab.
        /// .es ejecutamos el servicio de ir a la siguiente página de la lista de registros. 
        ///     responde al command invocado desde su comando en la region del ribbon.
        /// </summary>
        /// <param name="parameter">.en aditional info to pass to this method .es informacion adicional </param>
        public override void OnGetNextPageRecords(object parameter)
        {
            this.PageIndex++;
        }

        /// <summary>
        /// .en Get Previus Page records method. 
        ///     This command answer to a call from the ribbon region tab.
        /// .es ejecutamos el servicio de ir a la página anterior de la lista de registros. 
        ///     responde al command invocado desde su comando en la region del ribbon.
        /// </summary>
        /// <param name="parameter">.en aditional info to pass to this method .es informacion adicional </param>
        public override void OnGetPreviousPageRecords(object parameter)
        {
            this.PageIndex--;
        }

        /// <summary>
        /// .en Get Last Page records method. 
        ///     This command answer to a call from the ribbon region tab.
        /// .es ejecutamos el servicio de ir a la ultima página de la lista de registros. 
        ///     responde al command invocado desde su comando en la region del ribbon.
        /// </summary>
        /// <param name="parameter">.en aditional info to pass to this method .es informacion adicional </param>
        public override void OnGetLastPageRecords(object parameter)
        {
            this.PageIndex = this.TotalPagesCount;
        }

        /// <summary>
        /// refrescamos los susbcriptores de los comandos CRUD recalculando para cada uno de ellos si se habilita o no.
        /// </summary>
        public void RefreshCommands()
        {
            var cmd = this.deleteRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            cmd = this.editRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            cmd = this.saveRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            cmd = this.activateRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            cmd = this.newRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            cmd = this.getRecordsCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            this.RefreshPagingCommands();
        }

        /// <summary>
        /// refrescamos los subscriptores de los comandos de navegación recalculando para cada uno de ellos 
        /// si se habilitan sus suscriptores o no.
        /// </summary>
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