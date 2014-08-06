// -----------------------------------------------------------------------
// <copyright file="EditionCommands.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.Commands
{
    using Microsoft.Practices.Prism.Commands;

    /// <summary>
    /// .es Clase estática que define los comandos globales de edición.
    /// .en Static Class to define the edition global commands.
    /// </summary>
    public static class EditionCommands
    {
        #region Fields

        /// <summary>
        /// .es Comando global activar registro.
        /// .en Global command activate new record.
        /// </summary>
        private static CompositeCommand activateRecordCommand;

        /// <summary>
        /// .es Comando global eliminar registro.
        /// .en Global command delete Record.
        /// </summary>
        private static CompositeCommand deleteRecordCommand;

        /// <summary>
        /// .es Comando global editar registro.
        /// .en Global command edit record.
        /// </summary>
        private static CompositeCommand editRecordCommand;

        /// <summary>
        /// .es Comando global obtener registros.
        /// .en Global command get records.
        /// </summary>
        private static CompositeCommand getRecordsCommand;

        /// <summary>
        /// .es Comando global nuevo registro.
        /// .en Global command add new record.
        /// </summary>
        private static CompositeCommand newRecordCommand;

        /// <summary>
        /// .es Comando global guardar registro.
        /// .en Global command save record.
        /// </summary>
        private static CompositeCommand saveRecordCommand;


        /// <summary>
        /// .es Comando global obtener 1 página de registros .
        /// .en global command to get 1º page of records
        /// </summary>
        private static CompositeCommand getFirstPageRecordsCommand;

        /// <summary>
        /// .es Comando global obtener la siguiente página de registros.
        /// .en global command to get the next page of records
        /// </summary>
        private static CompositeCommand getNextPageRecordsCommand;

        /// <summary>
        /// .es Comando global obtener la anterior página de registros.
        /// .en global command to get the previous page of records
        /// </summary>
        private static CompositeCommand getPreviousPageRecordsCommand;

        /// <summary>
        /// .es Comando global obtener la ultima página de registros.
        /// .en global command to get the last page of records
        /// </summary>
        private static CompositeCommand getLastPageRecordsCommand;
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor estático.
        /// Static constructor.
        /// </summary>
        static EditionCommands()
        {
            activateRecordCommand           = new CompositeCommand();
            deleteRecordCommand             = new CompositeCommand();
            editRecordCommand               = new CompositeCommand();
            getRecordsCommand               = new CompositeCommand();
            newRecordCommand                = new CompositeCommand();
            saveRecordCommand               = new CompositeCommand();

            getFirstPageRecordsCommand      = new CompositeCommand();
            getNextPageRecordsCommand       = new CompositeCommand();
            getPreviousPageRecordsCommand   = new CompositeCommand();
            getLastPageRecordsCommand       = new CompositeCommand();
        }

        #endregion

        #region Properties

        /// <summary>
        /// .es Obtiene el comando global activar registro.
        /// .en Get the activate global command
        /// </summary>
        /// <value>
        /// Comando global activar registro.
        /// </value>
        public static CompositeCommand ActivateRecordCommand
        {
            get
            {
                return EditionCommands.activateRecordCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global editar registro.
        /// </summary>
        /// <value>
        /// .es Comando global editar registro.
        /// </value>
        public static CompositeCommand EditRecordCommand
        {
            get
            {
                return EditionCommands.editRecordCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global eliminar registro.
        /// </summary>
        /// <value>
        /// .es Comando global eliminar registro.
        /// </value>
        public static CompositeCommand DeleteRecordCommand
        {
            get
            {
                return EditionCommands.deleteRecordCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global obtener registros.
        /// </summary>
        /// <value>
        /// .es Comando global obtener registro.
        /// </value>
        public static CompositeCommand GetRecordsCommand
        {
            get
            {
                return EditionCommands.getRecordsCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global nuevo registro.
        /// </summary>
        /// <value>
        /// .es Comando global nuevo registro.
        /// </value>
        public static CompositeCommand NewRecordCommand
        {
            get
            {
                return EditionCommands.newRecordCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global para guardar el registro.
        /// .en It gets the global command to save the record.
        /// </summary>
        /// <value>
        /// .es Comando global guardar registro.
        /// .en Save record global command
        /// </value>
        public static CompositeCommand SaveRecordCommand
        {
            get
            {
                return EditionCommands.saveRecordCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global para obtener la primera página de registros.
        /// .en It gets the global command to get the first page of records
        /// </summary>
        /// <value>
        /// .es Comando global guardar registro.
        /// </value>
        public static CompositeCommand GetFirstPageRecordsCommand
        {
            get
            {
                return EditionCommands.getFirstPageRecordsCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global para obtener la siguiente página de registros.
        /// .en It gets the global command to get the next page of records
        /// </summary>
        /// <value>
        /// .es Comando global guardar registro.
        /// </value>
        public static CompositeCommand GetNextPageRecordsCommand
        {
            get
            {
                return EditionCommands.getNextPageRecordsCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global para obtener la anterior página de registros.
        /// .en It gets the global command to get the previous page of records
        /// </summary>
        /// <value>
        /// .es Comando global para obtener la siguiente página de registros
        /// .en property to get the command
        /// </value>
        public static CompositeCommand GetPreviousPageRecordsCommand
        {
            get
            {
                return EditionCommands.getPreviousPageRecordsCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global para obtener la ultima página de registros.
        /// .en It gets the global command to get the last page of records
        /// </summary>
        /// <value>
        /// .es comando global para obtener la ultima página de registros.
        /// .en property to get the command
        /// </value>
        public static CompositeCommand GetLastPageRecordsCommand
        {
            get
            {
                return EditionCommands.getLastPageRecordsCommand;
            }
        }

        #endregion
    }
}