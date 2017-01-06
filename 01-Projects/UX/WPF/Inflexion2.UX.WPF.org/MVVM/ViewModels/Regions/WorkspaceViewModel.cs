// -----------------------------------------------------------------------
// <copyright file="WorkspaceViewModel.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.ViewModels
{
    using System.Windows.Input;

    using Inflexion2.UX.WPF.MVVM.Commands;

    using Microsoft.Practices.Prism.Commands;

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
        /// Referencia al comando global activar registro.
        /// </summary>
        protected readonly ICommand activateRecordCommand;

        /// <summary>
        /// Referencia al comando global eliminar registro.
        /// </summary>
        protected readonly ICommand deleteRecordCommand;

        /// <summary>
        /// Referencia al comando global editar registro.
        /// </summary>
        protected readonly ICommand editRecordCommand;

        /// <summary>
        /// Referencia al comando global obtener registros.
        /// </summary>
        protected readonly ICommand getRecordsCommand;

        /// <summary>
        /// Referencia al comando global nuevo registro.
        /// </summary>
        protected readonly ICommand newRecordCommand;

        /// <summary>
        /// Referencia al comando global guardar registro.
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
        /// Indica si el view model esta o no ejecutando un proceso.
        /// </summary>
        private bool isBusy;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:WorkspaceViewModel"/>.
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
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene el comando eliminar registro.
        /// </summary>
        /// <value>
        /// Comando eliminar registro.
        /// </value>
        private ICommand ActivateRecordCommand
        {
            get { return this.activateRecordCommand; }
        }

        /// <summary>
        /// Obtiene el proxy para los comandos de edición.
        /// </summary>
        private EditionCommandsProxy EditionCommandsProxy
        {
            get { return this.editionCommandsProxy; }
        }

        /// <summary>
        /// Obtiene el comando editar registro.
        /// </summary>
        /// <value>
        /// Comando editar registro.
        /// </value>
        private ICommand EditRecordCommand
        {
            get { return this.editRecordCommand; }
        }

        /// <summary>
        /// Obtiene el comando eliminar registro.
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
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// Propiedad que indica si el view model esta o no ejecutando un proceso.
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
            return false;
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
                this.RegisterCommands();
            }
            else
            {
                this.UnregisterCommands();
            }

            base.RaiseIsActiveChanged();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Registra los comandos globales.
        /// </summary>
        private void RegisterCommands()
        {
            this.EditionCommandsProxy.ActivateRecordCommand.RegisterCommand(this.ActivateRecordCommand);
            this.EditionCommandsProxy.DeleteRecordCommand.RegisterCommand(this.DeleteRecordCommand);
            this.EditionCommandsProxy.EditRecordCommand.RegisterCommand(this.EditRecordCommand);
            this.EditionCommandsProxy.GetRecordsCommand.RegisterCommand(this.GetRecordsCommand);
            this.EditionCommandsProxy.NewRecordCommand.RegisterCommand(this.NewRecordCommand);
            this.EditionCommandsProxy.SaveRecordCommand.RegisterCommand(this.SaveRecordCommand);

            this.EditionCommandsProxy.GetFirstPageRecordsCommand.RegisterCommand(this.GetFirstPageRecordsCommand);
            this.EditionCommandsProxy.GetNextPageRecordsCommand.RegisterCommand(this.GetNextPageRecordsCommand);
            this.EditionCommandsProxy.GetPreviousPageRecordsCommand.RegisterCommand(this.GetPreviousPageRecordsCommand);
            this.EditionCommandsProxy.GetLastPageRecordsCommand.RegisterCommand(this.GetLastPageRecordsCommand);
        }

        /// <summary>
        /// Cancela el registro de los comandos globales.
        /// </summary>
        private void UnregisterCommands()
        {
            this.EditionCommandsProxy.ActivateRecordCommand.UnregisterCommand(this.ActivateRecordCommand);
            this.EditionCommandsProxy.DeleteRecordCommand.UnregisterCommand(this.DeleteRecordCommand);
            this.EditionCommandsProxy.EditRecordCommand.UnregisterCommand(this.EditRecordCommand);
            this.EditionCommandsProxy.GetRecordsCommand.UnregisterCommand(this.GetRecordsCommand);
            this.EditionCommandsProxy.NewRecordCommand.UnregisterCommand(this.NewRecordCommand);
            this.EditionCommandsProxy.SaveRecordCommand.UnregisterCommand(this.SaveRecordCommand);

            this.EditionCommandsProxy.GetFirstPageRecordsCommand.UnregisterCommand(this.GetFirstPageRecordsCommand);
            this.EditionCommandsProxy.GetNextPageRecordsCommand.UnregisterCommand(this.GetNextPageRecordsCommand);
            this.EditionCommandsProxy.GetPreviousPageRecordsCommand.UnregisterCommand(this.GetPreviousPageRecordsCommand);
            this.EditionCommandsProxy.GetLastPageRecordsCommand.UnregisterCommand(this.GetLastPageRecordsCommand);
        }

        #endregion
    }
}