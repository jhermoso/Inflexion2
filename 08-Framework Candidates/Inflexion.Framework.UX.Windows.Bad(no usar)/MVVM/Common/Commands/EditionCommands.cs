// -----------------------------------------------------------------------
// <copyright file="EditionCommands.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.Commands
{
    using Microsoft.Practices.Prism.Commands;

    /// <summary>
    /// Clase estática que define los comandos globales de edición.
    /// </summary>
    public static class EditionCommands
    {
        #region Fields

        /// <summary>
        /// Comando global activar registro.
        /// </summary>
        private static CompositeCommand activateRecordCommand;

        /// <summary>
        /// Comando global eliminar registro.
        /// </summary>
        private static CompositeCommand deleteRecordCommand;

        /// <summary>
        /// Comando global editar registro.
        /// </summary>
        private static CompositeCommand editRecordCommand;

        /// <summary>
        /// Comando global obtener registros.
        /// </summary>
        private static CompositeCommand getRecordsCommand;

        /// <summary>
        /// Comando global nuevo registro.
        /// </summary>
        private static CompositeCommand newRecordCommand;

        /// <summary>
        /// Comando global guardar registro.
        /// </summary>
        private static CompositeCommand saveRecordCommand;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor estático.
        /// </summary>
        static EditionCommands()
        {
            activateRecordCommand = new CompositeCommand();
            deleteRecordCommand = new CompositeCommand();
            editRecordCommand = new CompositeCommand();
            getRecordsCommand = new CompositeCommand();
            newRecordCommand = new CompositeCommand();
            saveRecordCommand = new CompositeCommand();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene el comando global activar registro.
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
        /// Obtiene el comando global editar registro.
        /// </summary>
        /// <value>
        /// Comando global editar registro.
        /// </value>
        public static CompositeCommand EditRecordCommand
        {
            get
            {
                return EditionCommands.editRecordCommand;
            }
        }

        /// <summary>
        /// Obtiene el comando global eliminar registro.
        /// </summary>
        /// <value>
        /// Comando global eliminar registro.
        /// </value>
        public static CompositeCommand DeleteRecordCommand
        {
            get
            {
                return EditionCommands.deleteRecordCommand;
            }
        }

        /// <summary>
        /// Obtiene el comando global obtener registros.
        /// </summary>
        /// <value>
        /// Comando global obtener registro.
        /// </value>
        public static CompositeCommand GetRecordsCommand
        {
            get
            {
                return EditionCommands.getRecordsCommand;
            }
        }

        /// <summary>
        /// Obtiene el comando global nuevo registro.
        /// </summary>
        /// <value>
        /// Comando global nuevo registro.
        /// </value>
        public static CompositeCommand NewRecordCommand
        {
            get
            {
                return EditionCommands.newRecordCommand;
            }
        }

        /// <summary>
        /// Obtiene el comando global guardar registro.
        /// </summary>
        /// <value>
        /// Comando global guardar registro.
        /// </value>
        public static CompositeCommand SaveRecordCommand
        {
            get
            {
                return EditionCommands.saveRecordCommand;
            }
        }

        #endregion
    }
}