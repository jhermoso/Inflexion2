// -----------------------------------------------------------------------
// <copyright file="ProductoQueryViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace EF.UX.WPF.Module.Entities
{

    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    //using Inflexion.Framework.Application.Security.Data.Base;
    using Inflexion2.Domain;
    using Inflexion2.UX.WPF;
    using Inflexion2.UX.WPF.MVVM.CRUD;

    using EFApplication;
    //using WcfClient;

    using Microsoft.Practices.Prism.Commands;


    /// <summary>
    /// Clase que representa el ViewModel de la vista ViewModel de 
    /// <see cref="T:Company.Product.Shared.Producto.UI.WPF.Medio.View.ProductoQueryView"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public class EntityBQueryViewModel : Inflexion2.UX.WPF.MVVM.CRUD.QueryViewModel<EntityBViewModel, EntityBView, int>
    {

        #region FIELDS

        /// <summary>
        /// Variable privada que hace referencia al contexto de seguridad del usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        //private UserContextDto userContext; //TODO: descomentar al implementar seguridad

        

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:ProductoQueryViewModel"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public EntityBQueryViewModel()
        {
            if (!this.IsDesignTime)
            {
                this.ChangeActivateStatusCommand = new DelegateCommand(this.ResetEntityB);
            }
            // Contexto de seguridad.
            //this.userContext = ApplicationContext.UserContext;
        } // ProductoQueryViewModel Constructor

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Propiedad para establecer el Titulo de la ventana
        /// </summary>
        public override string Title
        {
            get
            {
                return "Entidades B."; // ToDo - Desarrollo - Texto en recursos.
            }
        }

        /// <summary>
        /// Propiedad que obtiene el comando de cambio de estado.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor utilizado para obtener el comando de cambio de estado.
        /// </value>
        public ICommand ChangeActivateStatusCommand
        {
            get;
            private set;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Método sobreescrito que encargado de la activación de la entidad.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        public override void OnActivateRecord(object parameter)
        {
            // Si está activo y seleccionado.
            if (this.IsActive && this.SelectedItem != null)
            {

                try
                {

                    this.MessageBoxService.Show(
                            "Método sin implementar",
                            Application.Current.MainWindow.Title,
                            MessageBoxButton.OK,
                            MessageBoxImage.Exclamation);

                    // Instanciamos el proxy.
                    //ProductoServiceClient services = new ProductoServiceClient();

                    // ToDo :: Desarrollo - Descomentar cuando este el servicio.
                    //// Ejecutamos el servicio.
                    //bool result = services.Activate(
                    //                                this.SelectedItem.Id,
                    //                                this.userContext);
                    //bool result = false;
                    //// Comprobamos el resultado.
                    //if (result)
                    //{
                    //    // Activamos
                    //    this.SelectedItem.Activo = true;
                    //    this.MessageBoxService.Show(
                    //                                "El registro se ha activado correctamente.",
                    //                                Application.Current.MainWindow.Title,
                    //                                MessageBoxButton.OK,
                    //                                MessageBoxImage.Information);
                    //    this.RefreshCommands();

                    //}
                    //else
                    //{
                    //    this.MessageBoxService.Show(
                    //                                "¡Ha sido imposible activar el registro!",
                    //                                Application.Current.MainWindow.Title,
                    //                                MessageBoxButton.OK,
                    //                                MessageBoxImage.Exclamation);
                    //}
                }
                catch (System.Exception ex)
                {
                    // Mensaje de error.
                    this.MessageBoxService.Show(
                                                string.Format(
                                                              "¡Se ha producido un error al activar el registro!\r\n\r\n{0}",
                                                              ex.Message),
                                                Application.Current.MainWindow.Title,
                                                MessageBoxButton.OK,
                                                MessageBoxImage.Error);
                }
            }
        } // OnActivateRecord

        /// <summary>
        /// Método público encargado del borrado de una entidad .
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public override void OnDeleteRecord(object parameter)
        {
            try
            {
                if (this.IsActive && this.SelectedItem != null)
                {
                    // Instanciamos el proxy.

                    WcfClient.EntityBServiceReference.EntityBWebServiceClient serviceClient = new WcfClient.EntityBServiceReference.EntityBWebServiceClient();
                    // Ejecutamos el servicio.
                    bool result = serviceClient.Delete(
                                                        this.SelectedItem.Id
                                                    /*, this.userContext*/);
                    if (result)
                    {
                        // Desactivamos
                        //this.SelectedItem.Activo = false;
                        this.MessageBoxService.Show(
                                                    "El registro se ha borrado correctamente.", /* TODO pass to resources borrar/ deshabilitar */
                                                    Application.Current.MainWindow.Title,
                                                    MessageBoxButton.OK,
                                                    MessageBoxImage.Information);
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
        /// Método encargado de obtener todos los registros de Producto.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public override void OnGetRecords(object parameter)
        {
            // Si está activo y no ocupado.
            if (this.IsActive && !this.IsBusy)
            {
                // Ocupado.
                this.IsBusy = true;
                // Instanciamos el proxy.
                WcfClient.EntityBServiceReference.EntityBWebServiceClient serviceClient = new WcfClient.EntityBServiceReference.EntityBWebServiceClient();

                //Ejecutamos el servicio de forma asíncrona.
                serviceClient.BeginGetPaged(this.Specification, /*this.userContext,*/
                    (asyncResult) =>
                    {
                        // Obtenemos el resultado.
                        PagedElements<EFApplication.Dtos.EntityBDto> result = serviceClient.EndGetPaged(asyncResult);

                        this.Items = new ObservableCollection<EntityBViewModel>(result.Select(i => new EntityBViewModel(i)));
                        this.TotalRecordCount = result.TotalElements;
                        this.IsBusy = false;
                        this.RefreshPagingCommands();
                    },
                    null);
                
            }
        } // OnGetRecords

        public override void OnGetFirstPageRecords(object parameter)
        {
            this.PageIndex = 0;
            
            OnGetRecords(parameter);
        }

        public override void OnGetNextPageRecords(object parameter)
        {
            this.PageIndex++;

            OnGetRecords(parameter);
        }

        public override void OnGetPreviousPageRecords(object parameter)
        {
            this.PageIndex--;
            OnGetRecords(parameter);
        }

        public override void OnGetLastPageRecords(object parameter)
        {
            this.PageIndex = this.TotalPagesCount;
            OnGetRecords(parameter);
        } 

        #endregion

        #region PRIVATE METHODS

        /// <summary>
        /// Método privada para resetear el ViewModel.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        private void ResetEntityB()
        {
            if (CanActivateRecord(null))
            {
                OnActivateRecord(null);
            }
            else if (CanDeleteRecord(null))
            {
                OnDeleteRecord(null);
            }
        } // ResetEntityB

        #endregion

    } // EntityBQueryViewModel

} // EF.UX.WPF.Module.Entities.EntityB.ViewModel