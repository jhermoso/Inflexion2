// -----------------------------------------------------------------------
// <copyright file="EditionCommandsProxy.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.Commands
{
    using System.ComponentModel.Composition;

    using Microsoft.Practices.Prism.Commands;

    /// <summary>
    /// Clase proxy para los comandos globales de edición.
    /// </summary>
    /// <remarks>
    /// Utilizar esta clase proxy para acceder a los comandos globales de edición
    /// disponibles y poder realizar las pruebas correspondientes de test (mocks).
    /// </remarks>
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditionCommandsProxy
    {
        #region Properties

        /// <summary>
        /// Obtiene el comando global activa registro.
        /// </summary>
        /// <value>
        /// Comando global activa registro.
        /// </value>
        public virtual CompositeCommand ActivateRecordCommand
        {
            get
            {
                return EditionCommands.ActivateRecordCommand;
            }
        }

        /// <summary>
        /// Obtiene el comando global editar registro.
        /// </summary>
        /// <value>
        /// Comando global editar registro.
        /// </value>
        public virtual CompositeCommand EditRecordCommand
        {
            get
            {
                return EditionCommands.EditRecordCommand;
            }
        }

        /// <summary>
        /// Obtiene el comando global eliminar registro.
        /// </summary>
        /// <value>
        /// Comando global eliminar registro.
        /// </value>
        public virtual CompositeCommand DeleteRecordCommand
        {
            get
            {
                return EditionCommands.DeleteRecordCommand;
            }
        }

        /// <summary>
        /// Obtiene el comando global obtener registros.
        /// </summary>
        /// <value>
        /// Comando global obtener registro.
        /// </value>
        public virtual CompositeCommand GetRecordsCommand
        {
            get
            {
                return EditionCommands.GetRecordsCommand;
            }
        }

        /// <summary>
        /// Obtiene el comando global nuevo registro.
        /// </summary>
        /// <value>
        /// Comando global nuevo registro.
        /// </value>
        public virtual CompositeCommand NewRecordCommand
        {
            get
            {
                return EditionCommands.NewRecordCommand;
            }
        }

        /// <summary>
        /// Obtiene el comando global guardar registro.
        /// </summary>
        /// <value>
        /// Comando global guardar registro.
        /// </value>
        public virtual CompositeCommand SaveRecordCommand
        {
            get
            {
                return EditionCommands.SaveRecordCommand;
            }
        }

        #endregion
    }
}