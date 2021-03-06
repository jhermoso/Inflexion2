﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="MNZ" company="Company">
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
    using Needel.Common.Application.WcfClient.MNZReference;
    using Needel.Common.Infrastructure.Resources;
    using System.Collections.Generic;
    using Inflexion2.Application;
    using Microsoft.Practices.Prism.Events;
    using Inflexion2.UX.WPF.MVVM.ViewModels;
    #endregion

    /// <summary>
    /// .en Interaction logic for MNZQueryView.xaml
    /// .es Logica de interación para la vista MNZQueryView.xaml
    /// </summary>
    public partial class MNZQueryViewModel : Inflexion2.UX.WPF.MVVM.CRUD.ValueObjQueryViewModel<MNZViewModel, MNZView, MNZDto>
    {

        #region Constructors
        /// <summary>
        /// .en Initialize a new instace for the class <see cref="T:MNZQueryViewModel"/>.
        /// .es Inicializa una nueva instancia de la clase <see cref="T:MNZQueryViewModel"/>.
        /// </summary>
        /// <param name="parentViewName"></param>
        public MNZQueryViewModel(string parentViewName = null)
            :base()
        {
            this.ParentViewName = parentViewName;
            if (!this.IsDesignTime)
            {
                this.ChangeActivateStatusCommand = new DelegateCommand(this.ResetMNZ);
            }

            // https://github.com/SeriousM/WPFLocalizationExtension/issues/87#issuecomment-174510689
            // bind the property title of the VM to a dependecy property for the view. To allow the localization of the property tittle.
            // becouse this property don´t belong the clas UserControl who is the base for the view
            // but avalon dock uses this property to set the title of the dockable elements
            // if we wont tha this can be updated when the selected culture is changed we need this work arround.
            var targetProperty = this.GetType().GetProperty(nameof(MNZQueryViewModel.Title));
            var locBinding = new WPFLocalizeExtension.Extensions.LocTextExtension("MNZPluralEntity");
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

  
        } // MNZQueryView Constructor

        /// <summary>
        /// .en Constructor for nested view models in master detail from parent entities and Many to many.
        /// </summary>
        /// <param name="baseFilter"></param>
        /// <param name="parentViewName"></param>
        public MNZQueryViewModel(SpecificationDto baseFilter, string parentViewName )
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
        public MNZQueryViewModel( IList<MNZDto> collection, string parentViewName)
            : this(parentViewName)
        {
            if (collection != null)
            foreach (var item in collection)
            {
                this.Items.Add(new MNZViewModel(item));
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

                    MNZServiceClient serviceClient = new MNZServiceClient();
                    // Ejecutamos el servicio.
                    bool result = serviceClient.Delete( this.SelectedItem.ObjectElement );
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
        /// .en get records from MNZ.
        /// .es Método encargado de obtener todos los registros de MNZ.
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
                MNZServiceClient serviceClient = new MNZServiceClient();
                try
                {
                    this.IsBusy = true;
                    PagedElements<MNZDto> result = null;
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
                            this._items = new ObservableCollection<MNZViewModel>(result.Select(i => new MNZViewModel(i)));
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

        #endregion

        #region PRIVATE METHODS

        /// <summary>
        /// .es Método privado para resetear el ViewModel.
        /// </summary>
        private void ResetMNZ()
        {
            if (CanDeleteRecord(null))
            {
                OnDeleteRecord(null);
            }
        } // ResetMNZ

        /// <summary>
        /// .en refresh the collection of items raising a property changed event
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueObj"></param>
        public override void NavigateToRecord(MNZDto valueObj)
        {
            if (this.Specification == null)
            {
                this.NavigationService.NavigateToWorkSpace(typeof(MNZView).FullName, valueObj);
            }
            else
            {
                NavigateToWorkSpace(typeof(MNZView).FullName,  this.Specification, valueObj);
            }
        }

        private void NavigateToWorkSpace(string view, SpecificationDto specification, MNZDto valueObj)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (valueObj != null)
            {
                parameters.Add("EntityM.Id", valueObj.EntityM.Id.ToString());
                parameters.Add("EntityN.Id", valueObj.EntityN.Id.ToString());
                parameters.Add("EntityZ.Id", valueObj.EntityZ.Id.ToString());
            }
            
            var entityViewName = view.Split('.').Last();
            var entityName = entityViewName.Remove(entityViewName.Length - 4); // 4 is the lenght of "View" word in the view string name
            if (specification.CompositeFilter != null)
            {
                foreach (var filter in specification.CompositeFilter.Filters)
                {
                    parameters.Add(string.Format("{0};{1}", entityName, filter.Property), string.Format("{0};{1}", filter.Operator, filter.Value));
                }
            }

            this.NavigationService.NavigateTo(Inflexion2.UX.WPF.MVVM.RegionNames.WorkspaceRegion, view, parameters);
        }

        internal void RefreshItems()
        {
            RaisePropertyChanged(() => this.Items);
        }
        #endregion

    }// MNZQueryViewModel
} //  Needel.Common.FrontEnd.WpfModule
