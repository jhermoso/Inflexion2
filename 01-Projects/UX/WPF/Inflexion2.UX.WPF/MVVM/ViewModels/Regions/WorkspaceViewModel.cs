// -----------------------------------------------------------------------
// <copyright file="WorkspaceViewModel.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.ViewModels
{
    using Inflexion2.UX.WPF.MVVM.Commands;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// .es Clase base para las clases modelo de vista (MVVM) que utilizan la región WorkspaceRegion.
    /// 
    /// .en Base Class for model classes in MVVM wich works in the WorkspaceRegion region.
    /// </summary>
    public abstract class WorkspaceViewModel : RegionViewModel, Inflexion2.UX.WPF.MVVM.ViewModels.Regions.IWorkspaceViewModel
    {
        #region Fields

        /// <summary>
        /// .es Referencia al proxy para los comandos globales de edición.
        /// .en references to the proxy for edition global commands
        /// </summary>
        private readonly EditionCommandsProxy editionCommandsProxy;

        /// <summary>
        /// .es Referencia al comando global activar registro.
        /// .en
        /// </summary>
        protected readonly ICommand activateRecordCommand;

        /// <summary>
        /// .es Referencia al comando global eliminar registro.
        /// </summary>
        protected readonly ICommand deleteRecordCommand;

        /// <summary>
        /// .es Referencia al comando global editar registro.
        /// </summary>
        protected readonly ICommand editRecordCommand;

        /// <summary>
        /// .es Referencia al comando global obtener registros.
        /// </summary>
        protected readonly ICommand getRecordsCommand;

        /// <summary>
        /// .es Referencia al comando global nuevo registro.
        /// </summary>
        protected readonly ICommand newRecordCommand;

        /// <summary>
        /// .es Referencia al comando global guardar registro.
        /// </summary>
        protected readonly ICommand saveRecordCommand;

        /// <summary>
        /// .es Referencia al comando global para obtener la primera página de registros.
        /// </summary>
        protected readonly ICommand getFirstPageRecordsCommand;

        /// <summary>
        /// .es Referencia al comando global para obtener la siguiente página de registros.
        /// </summary>
        protected readonly ICommand getNextPageRecordsCommand;

        /// <summary>
        /// .es Referencia al comando global para obtener la anterior página de registros.
        /// </summary>
        protected readonly ICommand getPreviousPageRecordsCommand;

        /// <summary>
        /// .es Referencia al comando global para obtener la anterior página de registros.
        /// </summary>
        protected readonly ICommand getLastPageRecordsCommand;

        /// <summary>
        /// .en is the viewmodel executing a process?
        /// </summary>
        private bool isBusy;

        /// <summary>
        /// .en list of invisible fields in the view
        /// </summary>
        private Dictionary<string, bool> booleanInvisibleFieldsUI = new Dictionary<string, bool>();

        private string currentViewName;

        private string parentViewName;

        private UIMessageEvent compositeViewUpdateEvent;

        #endregion

        #region Constructors

        /// <summary>
        /// .es Inicializa una nueva instancia de la clase <see cref="T:WorkspaceViewModel"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:WorkspaceViewModel"/>.
        /// </remarks>
        protected WorkspaceViewModel()
        {
            if (!this.IsDesignTime)
            {
                // Inicialización de proxys para comandos globales.
                this.editionCommandsProxy = new EditionCommandsProxy();

                // Inicialización de comandos globales.
                this.activateRecordCommand          = new DelegateCommand<object>(this.OnActivateRecord, this.CanActivateRecord); 
                this.deleteRecordCommand            = new DelegateCommand<object>(this.OnDeleteRecord, this.CanDeleteRecord);
                this.editRecordCommand              = new DelegateCommand<object>(this.OnEditRecord, this.CanEditRecord);
                this.getRecordsCommand              = new DelegateCommand<object>(this.OnGetRecords, this.CanGetRecords);
                this.newRecordCommand               = new DelegateCommand<object>(this.OnNewRecord, this.CanNewRecord);
                this.saveRecordCommand              = new DelegateCommand<object>(this.OnSaveRecord, this.CanSaveRecord);

                this.getFirstPageRecordsCommand     = new DelegateCommand<object>(this.OnGetFirstPageRecords, this.CanGetFirstPageRecords);
                this.getNextPageRecordsCommand      = new DelegateCommand<object>(this.OnGetNextPageRecords, this.CanGetNextPageRecords);
                this.getPreviousPageRecordsCommand  = new DelegateCommand<object>(this.OnGetPreviousPageRecords, this.CanGetPreviousPageRecords);
                this.getLastPageRecordsCommand      = new DelegateCommand<object>(this.OnGetLastPageRecords, this.CanGetLastPageRecords);

                this.compositeViewUpdateEvent = this.EventAggregator.GetEvent<UIMessageEvent>();

            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// .es Obtiene el comando eliminar registro.
        /// </summary>
        /// <value>
        /// .es Comando eliminar registro.
        /// </value>
        private ICommand ActivateRecordCommand
        {
            get { return this.activateRecordCommand; }
        }

        /// <summary>
        /// .es Obtiene el proxy para los comandos de edición.
        /// </summary>
        private EditionCommandsProxy EditionCommandsProxy
        {
            get { return this.editionCommandsProxy; }
        }

        /// <summary>
        /// .es Obtiene el comando editar registro.
        /// </summary>
        /// <value>
        /// .es Comando editar registro.
        /// </value>
        private ICommand EditRecordCommand
        {
            get { return this.editRecordCommand; }
        }

        /// <summary>
        /// .es Obtiene el comando eliminar registro.
        /// </summary>
        /// <value>
        /// Comando eliminar registro.
        /// </value>
        private ICommand DeleteRecordCommand
        {
            get { return this.deleteRecordCommand; }
        }

        /// <summary>
        /// Obtiene el comando obtener registros.
        /// </summary>
        /// <value>
        /// Comando obtener registro.
        /// </value>
        private ICommand GetRecordsCommand
        {
            get { return this.getRecordsCommand; }
        }

        /// <summary>
        /// Obtiene el comando nuevo registro.
        /// </summary>
        /// <value>
        /// Comando nuevo registro.
        /// </value>
        private ICommand NewRecordCommand
        {
            get { return this.newRecordCommand; }
        }

        /// <summary>
        /// .es Obtiene el comando guardar registro.
        /// </summary>
        /// <value>
        /// Comando guardar registro.
        /// </value>
        private ICommand SaveRecordCommand
        {
            get { return this.saveRecordCommand; }
        }

        /// <summary>
        /// .es Obtiene el comando cargar la primera página de registros.
        /// </summary>
        /// <value>
        /// Comando cargar la primera página de registros.
        /// </value>
        private ICommand GetFirstPageRecordsCommand
        {
            get { return this.getFirstPageRecordsCommand; }
        }

        /// <summary>
        /// .es Obtiene el comando cargar la siguiente página de registros.
        /// </summary>
        /// <value>
        /// Comando cargar la siguiente página de registros.
        /// </value>
        private ICommand GetNextPageRecordsCommand
        {
            get { return this.getNextPageRecordsCommand; }
        }

        /// <summary>
        /// .es Obtiene el comando cargar la anterior página de registros.
        /// </summary>
        /// <value>
        /// Comando cargar la siguiente página de registros.
        /// </value>
        private ICommand GetPreviousPageRecordsCommand
        {
            get { return this.getPreviousPageRecordsCommand; }
        }

        /// <summary>
        /// .es Obtiene el comando cargar la anterior página de registros.
        /// </summary>
        /// <value>
        /// Comando cargar la siguiente página de registros.
        /// </value>
        private ICommand GetLastPageRecordsCommand
        {
            get { return this.getLastPageRecordsCommand; }
        }

        /// <summary>
        /// .es Obtiene el titulo a mostrar en la vista.
        /// .en Gets the title to show in the view.
        /// </summary>
        public abstract string Title { get; set; }

        /// <summary>
        /// .es Propiedad que indica si el view model esta o no ejecutando un proceso.
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                if (this.isBusy != value)
                {
                    this.isBusy = value;
                    RaisePropertyChanged(() => this.IsBusy);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, bool> BooleanInvisibleFieldsUI
        {
            get
            {
                return booleanInvisibleFieldsUI;
            }
            set
            {
                if (booleanInvisibleFieldsUI != value)
                {
                    booleanInvisibleFieldsUI = value;
                    RaisePropertyChanged(() => this.BooleanInvisibleFieldsUI);
                }
            }
        }

        /// <summary>
        /// Name of the current view instance associated to this viewmodel
        /// </summary>
        public string CurrentViewName
        {
            get
            {
                return currentViewName;
            }

            set
            {
                currentViewName = value;
            }
        }

        /// <summary>
        /// Name of the current parent view instance associated to this viewmodel.
        /// This property is for those query/crud view/viewmodels that are embbeded inside other views.
        /// The most common case is when a query view is inside other crud view.
        /// </summary>
        public string ParentViewName
        {
            get
            {
                return parentViewName;
            }

            set
            {
                parentViewName = value;
            }
        }

        /// <summary>
        /// Property to send decoupled updating messages in user interface betwwen modules or inside them
        /// </summary>
        public UIMessageEvent CompositeViewUpdateEvent
        {
            get
            {
                return compositeViewUpdateEvent;
            }

            set
            {
                compositeViewUpdateEvent = value;
            }
        }

        #endregion

        #region Public Methods

        #region CanExecuteCommand

        /// <summary>
        /// Determina si el comando activa registro se puede ejecutar.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        /// <returns>
        /// true si el comando se puede ejecutar; en caso contrario, false.
        /// </returns>
        public virtual bool CanActivateRecord(object parameter)
        {
            return false;
        }

        /// <summary>
        /// Determina si el comando eliminar registro se puede ejecutar.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        /// <returns>
        /// true si el comando se puede ejecutar; en caso contrario, false.
        /// </returns>
        public virtual bool CanDeleteRecord(object parameter)
        {
            return false;
        }

        /// <summary>
        /// Determina si el comando editar registro se puede ejecutar.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        /// <returns>
        /// true si el comando se puede ejecutar; en caso contrario, false.
        /// </returns>
        public virtual bool CanEditRecord(object parameter)
        {
            return false;
        }

        /// <summary>
        /// Determina si el comando obtener registros se puede ejecutar.
        /// Este metodo (y todos lo "can") aun siendo virtual se ejecuta cuando se carga el viewmodel de la region workspace
        /// al inicializar el shell el cual no tiene todavia ningun módulo cargado que lo inicialize. 
        /// el cual lo inicializaria con sus metodos sobreescritos.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        /// <returns>
        /// true si el comando se puede ejecutar; en caso contrario, false.
        /// </returns>
        public virtual bool CanGetRecords(object parameter)
        {
            return false;
        }

        /// <summary>
        /// Determina si el comando nuevo registro se puede ejecutar.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        /// <returns>
        /// true si el comando se puede ejecutar; en caso contrario, false.
        /// </returns>
        public virtual bool CanNewRecord(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Determina si el comando guardar registro se puede ejecutar.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        /// <returns>
        /// true si el comando se puede ejecutar; en caso contrario, false.
        /// </returns>
        public virtual bool CanSaveRecord(object parameter)
        {
            return false;
        }

        /// <summary>
        /// .es Determina si el comando obtener la primera pagina de registros se puede ejecutar.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        /// <returns>
        /// .es true si el comando se puede ejecutar; en caso contrario, false.
        /// </returns>
        public virtual bool CanGetFirstPageRecords(object parameter)
        {
            return false;
        }

        /// <summary>
        /// .es Determina si el comando "obtener la siguiente página de registros" se puede ejecutar.
        /// </summary>
        /// <param name="parameter">
        /// .es Parámetro con información adicional.
        /// </param>
        /// <returns>
        /// .es true si el comando se puede ejecutar; en caso contrario, false.
        /// </returns>
        public virtual bool CanGetNextPageRecords(object parameter)
        {
            return false;
        }

        /// <summary>
        /// .es Determina si el comando "obtener la anterior pagina de registros" se puede ejecutar.
        /// </summary>
        /// <param name="parameter">
        /// .es Parámetro con información adicional.
        /// </param>
        /// <returns>
        /// .es true si el comando se puede ejecutar; en caso contrario, false.
        /// </returns>
        public virtual bool CanGetPreviousPageRecords(object parameter)
        {
            return false;
        }

        /// <summary>
        /// .es Determina si el comando "obtener la ultima página de registros" se puede ejecutar.
        /// </summary>
        /// <param name="parameter">
        /// .es Parámetro con información adicional.
        /// </param>
        /// <returns>
        /// .es true si el comando se puede ejecutar; en caso contrario, false.
        /// </returns>
        public virtual bool CanGetLastPageRecords(object parameter)
        {
            return false;
        }

        #endregion CanExecuteCommand

        #region ExecuteCommand

        /// <summary>
        /// Se ejecuta cuando se va a eliminar el registro actual.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        public virtual void OnActivateRecord(object parameter)
        {

        }

        /// <summary>
        /// Se ejecuta cuando se va a eliminar el registro actual.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        public virtual void OnDeleteRecord(object parameter)
        {

        }

        /// <summary>
        /// Se ejecuta cuando se va a editar el registro actual.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        public virtual void OnEditRecord(object parameter)
        {

        }

        /// <summary>
        /// Se ejecuta cuando se van a obtener registros.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        public virtual void OnGetRecords(object parameter)
        {

        }

        /// <summary>
        /// Se ejecuta cuando se va a editar un nuevo registro.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        public virtual void OnNewRecord(object parameter)
        {

        }

        /// <summary>
        /// Se ejecuta cuando se va a guardar el registro actual.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        public virtual void OnSaveRecord(object parameter)
        {

        }

        /// <summary>
        /// .es Se ejecuta cuando se van a obtener la primera pagina de registros.
        /// </summary>
        /// <param name="parameter">
        /// .es Parámetro con información adicional.
        /// </param>
        public virtual void OnGetFirstPageRecords(object parameter)
        {
            
        }

        /// <summary>
        /// .es Se ejecuta cuando se van a obtener la siguiente pagina de registros.
        /// </summary>
        /// <param name="parameter">
        /// .es Parámetro con información adicional.
        /// </param>
        public virtual void OnGetNextPageRecords(object parameter)
        {

        }

        /// <summary>
        /// .es Se ejecuta cuando se van a obtener la anterior página de registros.
        /// </summary>
        /// <param name="parameter">
        /// .es Parámetro con información adicional.
        /// </param>
        public virtual void OnGetPreviousPageRecords(object parameter)
        {

        }

        /// <summary>
        /// .es Se ejecuta cuando se van a obtener la ultima página de registros.
        /// </summary>
        /// <param name="parameter">
        /// .es Parámetro con información adicional.
        /// </param>
        public virtual void OnGetLastPageRecords(object parameter)
        {

        }


        /// <summary>
        /// Action to execute when receiving a message to update a queryViewmodel who has a parent view.
        /// Composited view update.
        /// </summary>
        /// <param name="message"></param>
        public virtual void OnReceiveCompositeViewUpdateEvent(string message)
        {
            OnGetRecords("from WorkspaceViewModel " + message);
            //this.Rebind();
        }


        #endregion ExecuteCommand

        #endregion

        #region Overridden Methods

        /// <summary>
        /// Provoca el evento <see cref="M:IsActiveChanged"/> si es necesario.
        /// </summary>
        protected override void RaiseIsActiveChanged()
        {
            if (this.IsActive)
            {
                this.RegisterCommands(true);
            }
            else
            {
                this.UnregisterCommands(true);
            }

            base.RaiseIsActiveChanged();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Registra los comandos globales.
        /// </summary>
        public void RegisterCommands(bool includeSaveCommand = false)
        {
            // avoid register the same comand twice checking the first command
            if (!this.EditionCommandsProxy.ActivateRecordCommand.RegisteredCommands.Any(c => c == this.ActivateRecordCommand))
            {
                this.EditionCommandsProxy.ActivateRecordCommand.RegisterCommand(this.ActivateRecordCommand);
            }

            if (!this.EditionCommandsProxy.DeleteRecordCommand.RegisteredCommands.Any(c => c == this.DeleteRecordCommand))
            {
                this.EditionCommandsProxy.DeleteRecordCommand.RegisterCommand(this.DeleteRecordCommand);
            }

            if (!this.EditionCommandsProxy.EditRecordCommand.RegisteredCommands.Any(c => c == this.EditRecordCommand))
            {
                this.EditionCommandsProxy.EditRecordCommand.RegisterCommand(this.EditRecordCommand);
            }

            if (!this.EditionCommandsProxy.GetRecordsCommand.RegisteredCommands.Any(c => c == this.GetRecordsCommand))
            {
                this.EditionCommandsProxy.GetRecordsCommand.RegisterCommand(this.GetRecordsCommand);
            }

            if (!this.EditionCommandsProxy.NewRecordCommand.RegisteredCommands.Any(c => c == this.NewRecordCommand))
            {
                this.EditionCommandsProxy.NewRecordCommand.RegisterCommand(this.NewRecordCommand);
            }

            // el comando save no se modifica para poder salvar el registro independientemente de donde 
            // esta el foco
            if (includeSaveCommand && !this.EditionCommandsProxy.SaveRecordCommand.RegisteredCommands.Any(c => c == this.SaveRecordCommand))
            {
                this.EditionCommandsProxy.SaveRecordCommand.RegisterCommand(this.SaveRecordCommand);
            }

            if (!this.EditionCommandsProxy.GetFirstPageRecordsCommand.RegisteredCommands.Any(c => c == this.GetFirstPageRecordsCommand))
            {
                this.EditionCommandsProxy.GetFirstPageRecordsCommand.RegisterCommand(this.GetFirstPageRecordsCommand);
            }

            if (!this.EditionCommandsProxy.GetNextPageRecordsCommand.RegisteredCommands.Any(c => c == this.GetNextPageRecordsCommand))
            {
                this.EditionCommandsProxy.GetNextPageRecordsCommand.RegisterCommand(this.GetNextPageRecordsCommand);
            }

            if (!this.EditionCommandsProxy.GetPreviousPageRecordsCommand.RegisteredCommands.Any(c => c == this.GetPreviousPageRecordsCommand))
            {
                this.EditionCommandsProxy.GetPreviousPageRecordsCommand.RegisterCommand(this.GetPreviousPageRecordsCommand);
            }

            if (!this.EditionCommandsProxy.GetLastPageRecordsCommand.RegisteredCommands.Any(c => c == this.GetLastPageRecordsCommand))
            {
                this.EditionCommandsProxy.GetLastPageRecordsCommand.RegisterCommand(this.GetLastPageRecordsCommand);
            }
            
        }

        /// <summary>
        /// Cancela el registro de los comandos globales.
        /// </summary>
        public void UnregisterCommands(bool includeSaveCommand = false)
        {
            foreach (var item in this.EditionCommandsProxy.ActivateRecordCommand.RegisteredCommands)
            {
                //this.EditionCommandsProxy.ActivateRecordCommand.UnregisterCommand(this.ActivateRecordCommand);
                this.EditionCommandsProxy.ActivateRecordCommand.UnregisterCommand(item);
            }

            foreach (var item in this.EditionCommandsProxy.DeleteRecordCommand.RegisteredCommands)
            {
                //this.EditionCommandsProxy.DeleteRecordCommand.UnregisterCommand(this.DeleteRecordCommand);
                this.EditionCommandsProxy.DeleteRecordCommand.UnregisterCommand(item);
            }

            foreach (var item in this.EditionCommandsProxy.EditRecordCommand.RegisteredCommands)
            {
                //this.EditionCommandsProxy.EditRecordCommand.UnregisterCommand(this.EditRecordCommand);
                this.EditionCommandsProxy.EditRecordCommand.UnregisterCommand(item);
            }

            foreach (var item in this.EditionCommandsProxy.GetRecordsCommand.RegisteredCommands)
            {
                //this.EditionCommandsProxy.GetRecordsCommand.UnregisterCommand(this.GetRecordsCommand);
                this.EditionCommandsProxy.GetRecordsCommand.UnregisterCommand(item);
            }

            foreach (var item in this.EditionCommandsProxy.NewRecordCommand.RegisteredCommands)
            {
                //this.EditionCommandsProxy.NewRecordCommand.UnregisterCommand(this.NewRecordCommand);
                this.EditionCommandsProxy.NewRecordCommand.UnregisterCommand(item);
            }

            // el comando save no se modifica para poder salvar el registro independientemente de donde 
            // esta el foco
            if (includeSaveCommand)
            foreach (var item in this.EditionCommandsProxy.SaveRecordCommand.RegisteredCommands)
            {
                //this.EditionCommandsProxy.SaveRecordCommand.UnregisterCommand(this.SaveRecordCommand);
                this.EditionCommandsProxy.SaveRecordCommand.UnregisterCommand(item);
            }


            foreach (var item in this.EditionCommandsProxy.GetFirstPageRecordsCommand.RegisteredCommands)
            {
                //this.EditionCommandsProxy.GetFirstPageRecordsCommand.UnregisterCommand(this.GetFirstPageRecordsCommand);
                this.EditionCommandsProxy.GetFirstPageRecordsCommand.UnregisterCommand(this.GetFirstPageRecordsCommand);
            }

            foreach (var item in this.EditionCommandsProxy.GetNextPageRecordsCommand.RegisteredCommands)
            {
                //this.EditionCommandsProxy.GetNextPageRecordsCommand.UnregisterCommand(this.GetNextPageRecordsCommand);
                this.EditionCommandsProxy.GetNextPageRecordsCommand.UnregisterCommand(item);
            }

            foreach (var item in this.EditionCommandsProxy.GetPreviousPageRecordsCommand.RegisteredCommands)
            {
                //this.EditionCommandsProxy.GetPreviousPageRecordsCommand.UnregisterCommand(this.GetPreviousPageRecordsCommand);
                this.EditionCommandsProxy.GetPreviousPageRecordsCommand.UnregisterCommand(item);
            }

            foreach (var item in this.EditionCommandsProxy.GetLastPageRecordsCommand.RegisteredCommands)
            {
                //this.EditionCommandsProxy.GetLastPageRecordsCommand.UnregisterCommand(this.GetLastPageRecordsCommand);
                this.EditionCommandsProxy.GetLastPageRecordsCommand.UnregisterCommand(item);
            }
            
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void UpdateParentView()
        {
            if (this.ParentViewName != null)
            {
                this.CompositeViewUpdateEvent.Publish(this.ParentViewName);
            }
        }

    }
}