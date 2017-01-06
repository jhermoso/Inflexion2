// -----------------------------------------------------------------------
// <copyright file="EditionCommandsProxy.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.Commands
{
    using System.ComponentModel.Composition;

    using Microsoft.Practices.Prism.Commands;

    /// <summary>
    /// .es Clase proxy para los comandos globales de edición.
    /// .en Proxy for edition global commands
    /// </summary>
    /// <remarks>
    /// .es Utilizar esta clase proxy para acceder a los comandos globales de edición
    /// disponibles y poder realizar las pruebas correspondientes de test (mocks).
    /// .en Use this proxy to acces to edition global commands. This proxy enable testing and mocking.
    /// </remarks>
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditionCommandsProxy
    {
        #region Properties

        /// <summary>
        /// .es Obtiene el comando global activa registro.
        /// </summary>
        /// <value>
        /// .es Comando global activa registro.
        /// </value>
        public virtual CompositeCommand ActivateRecordCommand
        {
            get
            {
                return EditionCommands.ActivateRecordCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global editar registro.
        /// </summary>
        /// <value>
        /// .es Comando global editar registro.
        /// </value>
        public virtual CompositeCommand EditRecordCommand
        {
            get
            {
                return EditionCommands.EditRecordCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global eliminar registro.
        /// </summary>
        /// <value>
        /// .es Comando global eliminar registro.
        /// </value>
        public virtual CompositeCommand DeleteRecordCommand
        {
            get
            {
                return EditionCommands.DeleteRecordCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global obtener registros.
        /// </summary>
        /// <value>
        /// .es Comando global obtener registro.
        /// </value>
        public virtual CompositeCommand GetRecordsCommand
        {
            get
            {
                return EditionCommands.GetRecordsCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global nuevo registro.
        /// </summary>
        /// <value>
        /// .es Comando global nuevo registro.
        /// </value>
        public virtual CompositeCommand NewRecordCommand
        {
            get
            {
                return EditionCommands.NewRecordCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global guardar registro.
        /// </summary>
        /// <value>
        /// .es Comando global guardar registro.
        /// </value>
        public virtual CompositeCommand SaveRecordCommand
        {
            get
            {
                return EditionCommands.SaveRecordCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global para obtener la primera página de registros.
        /// .en it gets global command to get the first page of records
        /// </summary>
        /// <value>
        /// .es Comando global para obtener la primera página de registros.
        /// .en Global Command to get the first page of records
        /// </value>
        public virtual CompositeCommand GetFirstPageRecordsCommand
        {
            get
            {
                return EditionCommands.GetFirstPageRecordsCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global para obtener la siguiente página de registros.
        /// .en it gets global command to get the next page of records
        /// </summary>
        /// <value>
        /// .es Comando global para obtener la siguiente pagina de registros.
        /// .en Global Command to get the first page of records
        /// </value>
        public virtual CompositeCommand GetNextPageRecordsCommand
        {
            get
            {
                return EditionCommands.GetNextPageRecordsCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global 
        /// .en it gets global command to get the previous page records
        /// </summary>
        /// <value>
        /// .es Comando global para obtener la anterior pagina de registros.
        /// .en Global Command to get the previous page of records
        /// </value>
        public virtual CompositeCommand GetPreviousPageRecordsCommand
        {
            get
            {
                return EditionCommands.GetPreviousPageRecordsCommand;
            }
        }

        /// <summary>
        /// .es Obtiene el comando global 
        /// .en it gets global command to get the last page of records
        /// </summary>
        /// <value>
        /// .es Comando global para obtener la ultima pagina de registros.
        /// .en Global Command to get the last page of records
        /// </value>
        public virtual CompositeCommand GetLastPageRecordsCommand
        {
            get
            {
                return EditionCommands.GetLastPageRecordsCommand;
            }
        }

        #endregion
    }
}