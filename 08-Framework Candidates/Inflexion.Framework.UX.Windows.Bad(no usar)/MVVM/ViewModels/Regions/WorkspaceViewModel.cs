// -----------------------------------------------------------------------
// <copyright file="WorkspaceViewModel.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.ViewModels
{
    using System.Windows.Input;

    using Inflexion.Framework.UX.Windows.MVVM.Commands;

    using Microsoft.Practices.Prism.Commands;

    /// <summary>
    /// Clase base para las clases modelo de vista (MVVM) que utilizan la región WorkspaceRegion.
    /// </summary>
    public abstract class WorkspaceViewModel : RegionViewModel, Inflexion.Framework.UX.Windows.MVVM.ViewModels.Regions.IWorkspaceViewModel
    {
        #region Fields

        /// <summary>
        /// Referencia al proxy para los comandos globales de edición.
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
                this.activateRecordCommand = new DelegateCommand<object>(this.OnActivateRecord, this.CanActivateRecord); 
                this.deleteRecordCommand = new DelegateCommand<object>(this.OnDeleteRecord, this.CanDeleteRecord);
                this.editRecordCommand = new DelegateCommand<object>(this.OnEditRecord, this.CanEditRecord);
                this.getRecordsCommand = new DelegateCommand<object>(this.OnGetRecords, this.CanGetRecords);
                this.newRecordCommand = new DelegateCommand<object>(this.OnNewRecord, this.CanNewRecord);
                this.saveRecordCommand = new DelegateCommand<object>(this.OnSaveRecord, this.CanSaveRecord);
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
        /// Obtiene el comando guardar registro.
        /// </summary>
        /// <value>
        /// Comando guardar registro.
        /// </value>
        private ICommand SaveRecordCommand
        {
            get { return this.saveRecordCommand; }
        }

        /// <summary>
        /// Obtiene el titulo a mostrar en la vista.
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
            return true;
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
        /// </summary>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        /// <returns>
        /// true si el comando se puede ejecutar; en caso contrario, false.
        /// </returns>
        public virtual bool CanGetRecords(object parameter)
        {
            return true;
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
        }

        #endregion
    }
}