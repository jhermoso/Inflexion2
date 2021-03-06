﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="GraphNode" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " WpfEntityQueryViewModelCT.tt" with "public class WpfEntityQueryViewModelCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "WpfEntityQueryViewModelCT.tt" con "public class WpfEntityQueryViewModelCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.FrontEnd.WpfModule
{

    #region usings   
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.ServiceModel;
    using System.Windows;
    using System.Windows.Input;

    using Microsoft.Practices.Prism.Commands;

    using Inflexion2.Domain;
    using Inflexion2.UX.WPF;
    using Inflexion2.UX.WPF.MVVM.CRUD;

    using Needel.Common.Application;
    using Needel.Common.Application.Dtos;
    using Needel.Common.Application.WcfClient.GraphNodeReference;
    using Needel.Common.Infrastructure.Resources;
    using System.Collections.Generic;
    using Inflexion2.Application;
    using Microsoft.Practices.Prism.Events;
    using Inflexion2.UX.WPF.MVVM.ViewModels;
    #endregion

    /// <summary>
    /// .en Interaction logic for GraphNodeQueryView.xaml
    /// .es Logica de interación para la vista GraphNodeQueryView.xaml
    /// </summary>
    public partial class GraphNodeQueryViewModel : Inflexion2.UX.WPF.MVVM.CRUD.QueryViewModel<GraphNodeViewModel, GraphNodeView, Int32>
    {

        #region Constructors
        /// <summary>
        /// .en Initialize a new instace for the class <see cref="T:GraphNodeQueryViewModel"/>.
        /// .es Inicializa una nueva instancia de la clase <see cref="T:GraphNodeQueryViewModel"/>.
        /// </summary>
        /// <param name="parentViewName"></param>
        public GraphNodeQueryViewModel(string parentViewName = null)
            :base()
        {
            this.ParentViewName = parentViewName;
            if (!this.IsDesignTime)
            {
                this.ChangeActivateStatusCommand = new DelegateCommand(this.ResetGraphNode);
            }

            // https://github.com/SeriousM/WPFLocalizationExtension/issues/87#issuecomment-174510689
            // bind the property title of the VM to a dependecy property for the view. To allow the localization of the property tittle.
            // becouse this property don´t belong the clas UserControl who is the base for the view
            // but avalon dock uses this property to set the title of the dockable elements
            // if we wont tha this can be updated when the selected culture is changed we need this work arround.
            var targetProperty = this.GetType().GetProperty(nameof(GraphNodeQueryViewModel.Title));
            var locBinding = new WPFLocalizeExtension.Extensions.LocTextExtension("GraphNodePluralEntity");
            locBinding.SetBinding(this, targetProperty);

            // after to bind the property with the depdendecy property watch if theres is a change of the 
            // the culture to raise an event to warning that the title property has changed
            WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Culture")
                {
                    this.RaisePropertyChanged(() => Title);
                }
            };

  
        } // GraphNodeQueryView Constructor

        /// <summary>
        /// .en Constructor for nested view models in master detail from parent entities and Many to many.
        /// </summary>
        /// <param name="baseFilter"></param>
        /// <param name="parentViewName"></param>
        public GraphNodeQueryViewModel(SpecificationDto baseFilter, string parentViewName )
            : this(parentViewName)
        {
            this.Specification = baseFilter;
            this.ParentViewName = parentViewName;
            this.OnGetRecords("1");
            this.IsBusy = false;

            // only in this case there is a need of subscription to update a parent view
            if (!CompositeViewUpdateEvent.Contains(this.OnReceiveCompositeViewUpdateEvent))
            {
                CompositeViewUpdateEvent.Subscribe(this.OnReceiveCompositeViewUpdateEvent, ThreadOption.UIThread);
            }
        }

        /// <summary>
        /// .en View Model constructor from collection of Dtos.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="parentViewName"></param>
        public GraphNodeQueryViewModel( IList<GraphNodeDto> collection, string parentViewName)
            : this(parentViewName)
        {
            if (collection != null)
            foreach (var item in collection)
            {
                this.Items.Add(new GraphNodeViewModel(item));
            }
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// .en Property to get the command of changing state.
        /// .es Propiedad que obtiene el comando de cambio de estado.
        /// </summary>
        /// <value>
        /// Valor utilizado para obtener el comando de cambio de estado.
        /// </value>
        public ICommand ChangeActivateStatusCommand
        {
            get;
            private set;
        }
        #endregion

        #region Methods for commands from ribbon

        /// <summary>
        /// Método público encargado del borrado de una entidad.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        public override void OnDeleteRecord(object parameter)
        {
            try
            {
                if (this.IsActive && this.SelectedItem != null)
                {
                    // Instanciamos el proxy.

                    GraphNodeServiceClient serviceClient = new GraphNodeServiceClient();
                    // Ejecutamos el servicio.
                    bool result = serviceClient.Delete( this.SelectedItem.Id );
                    if (result)
                    {
                        this.MessageBoxService.Show(
                                                    "El registro se ha borrado correctamente.", /* TODO pass to resources borrar/ deshabilitar */
                                                    Application.Current.MainWindow.Title,
                                                    MessageBoxButton.OK,
                                                    MessageBoxImage.Information);
                        UpdateParentView();

                        this.RefreshCommands();
                    }
                    else
                    {
                        this.MessageBoxService.Show(
                                                    "¡Ha sido imposible borrar el registro!",/* TODO pass to resources borrar / deshabilitar*/
                                                    Application.Current.MainWindow.Title,
                                                    MessageBoxButton.OK,
                                                    MessageBoxImage.Exclamation);
                    }

                    this.Rebind();
                }
                else if (this.ParentViewName == "GraphNodeView")
                {
                    // If is not active and parent view is Student then delete the asociation with student not the record teacher.
                    MoveDataFromSrcToDest(this, this.SelectedItem.ObjectElement);//*
                }
            }

            catch (System.Exception ex)
            {
                this.MessageBoxService.Show(
                                            string.Format(
                                                          "¡Se ha producido un error al intentar borrar el registro!\r\n\r\n{0}",
                                                          ex.Message),
                                            Application.Current.MainWindow.Title,
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Error);
            }
        } // OnDeleteRecord

        /// <summary>
        /// .en get records from GraphNode.
        /// .es Método encargado de obtener todos los registros de GraphNode.
        /// </summary>
        /// <param name="parameter">
        /// .en parameter with additional info
        /// .es Parámetro con información adicional.
        /// </param>
        public override void OnGetRecords(object parameter)
        {
            if (!this.IsBusy)
            {
                this.IsBusy = true;
                // .en proxy instation // .es Instanciamos el proxy.
                GraphNodeServiceClient serviceClient = new GraphNodeServiceClient();
                try
                {
                    this.IsBusy = true;
                    PagedElements<GraphNodeDto> result = null;
                    //.en Asyncronous execution of the service. //.es Ejecutamos el servicio de forma asíncrona.
                    serviceClient.BeginGetPaged(this.Specification,                                                 (asyncResult) =>
                    {
                        // Obtenemos el resultado.
                        try
                        {
                            result = serviceClient.EndGetPaged(asyncResult);
                        }
                        catch (TimeoutException e)
                        {
                            this.MessageBoxService.Show("The service operation timed out. " + e.Message);
                            serviceClient.Abort();
                        }
                        catch (FaultException<Inflexion2.Application.ValidationException> e)
                        {
                            this.MessageBoxService.Show("Validation Exception. Message: {0}", e.Message);
                            serviceClient.Abort();
                        }
                        catch (FaultException<Inflexion2.Application.InternalException> e)
                        {
                            this.MessageBoxService.Show("Internal Exception. Message: {0}", e.Message);
                            serviceClient.Abort();
                        }

                        // .en Catch unrecognized faults.This handler receives exceptions thrown by WCF
                        // services when ServiceDebugBehavior.IncludeExceptionDetailInFaults
                        // is set to true or when un - typed FaultExceptions raised.
                        catch (FaultException fe)
                        {
                            this.MessageBoxService.Show("Unhalded fault exception. Message:" + fe.Message);
                            serviceClient.Abort();
                        }
                        catch (Exception e)
                        {
                            this.MessageBoxService.Show("Unexpected exception" + e.Message);
                            serviceClient.Abort();
                            throw;
                        }

                        if (result != null)
                        {
                            //var first = result.FirstOrDefault();
                            //var last = result.LastOrDefault();

                            this._items = new ObservableCollection<GraphNodeViewModel>(result.Select(i => new GraphNodeViewModel(i/*, first, result.GetPrevious(i), result.GetNext(i), last*/, true)));
                            this.TotalRecordCount = result.TotalElements;
                        }

                        this.RefreshPagingCommands();
                        this.Rebind();
                        this.IsBusy = false;
                    },
                    null);

                }
                catch (Exception e)
                {
                    this.MessageBoxService.Show("catched on PersonaQueryViewModel" + e.Message);
                    serviceClient.Abort();
                    throw;
                }
            }
        } // OnGetRecords

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
            OnGetRecords(parameter);
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
            OnGetRecords(parameter);
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
            OnGetRecords(parameter);
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
            OnGetRecords(parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataContextTarget"></param>
        /// <param name="data"></param>
        public void MoveDataFromSrcToDest( GraphNodeQueryViewModel dataContextTarget, GraphNodeDto data)
        {
            var view = dataContextTarget.ParentViewName;
            var views = this.RegionManager.Regions[Inflexion2.UX.WPF.MVVM.RegionNames.WorkspaceRegion].ActiveViews;
            dynamic currentView = views.FirstOrDefault(c => c as GraphNodeView != null);

            if (this.Title.Equals("AllGraphNodesQueryVM"))
            {
                currentView.DataContext.AttachGraphNode(dataContextTarget, data);
                //move from "all" means to add new association
                //dataContextTarget.AttachGraphNode(data);
            }
            else
            {
                currentView.DataContext.RemoveGraphNode(this.Title, dataContextTarget, data);
                //move to "all" means to remove association
                //dataContextTarget.RemoveGraphNode(data);
            }
        }
        #endregion

        #region PRIVATE METHODS

        /// <summary>
        /// .es Método privado para resetear el ViewModel.
        /// </summary>
        private void ResetGraphNode()
        {
            if (CanDeleteRecord(null))
            {
                OnDeleteRecord(null);
            }
        } // ResetGraphNode

        /// <summary>
        /// .en refresh the collection of items raising a property changed event
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
        }

        /// <summary>
        /// nuevo record en el menu
        /// </summary>
        /// <param name="id"></param>
        public override void NavigateToRecord(int id)
        {
            // hacer un override del navigate to record para controlar la especificacion de la que viene
            // controlar el 
            var s = this.Specification;
            base.NavigateToRecord(id);
        }

        internal void RefreshItems()
        {
            RaisePropertyChanged(() => this.Items);
        }
        #endregion

    }// GraphNodeQueryViewModel
} //  Needel.Common.FrontEnd.WpfModule
