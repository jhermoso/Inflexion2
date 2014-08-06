// -----------------------------------------------------------------------
// <copyright file="AuditInfoFactory.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;

    /// <summary>
    /// Clase estática factoría para la creación de objetos
    /// valor de tipo <see cref="IAuditInfo"/>
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    public static class AuditInfoFactory
    {
        #region Methods

        /// <summary>
        /// Método encargado de crear objetos valor de tipo
        /// <see cref="IAuditInfo"/>
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="createdBy">
        /// Parámetro que indica el identificador del usuario
        /// que crea el registro.
        /// </param>
        /// <param name="updatedBy">
        /// Parámetro que indica el identificador del usuario
        /// que modifica el registro.
        /// </param>
        /// <param name="createTimestamp">
        /// Parámetro que indica la fecha de creación del registro.
        /// </param>
        /// <param name="updateTimestamp">
        /// Parámetro que indica la fecha de modificación del registro.
        /// </param>
        /// <returns>
        /// Devuelve el objeto valor <see cref="IAuditInfo"/> creado.
        /// </returns>
        public static IAuditInfo Create(
            string createdBy,
            string updatedBy,
            DateTime createTimestamp,
            DateTime? updateTimestamp)
        {
            // Creamos un objeto de tipo AuditInfo
            IAuditInfo auditInfo = new AuditInfo(
                createdBy,
                updatedBy,
                createTimestamp,
                updateTimestamp);
            // Devolvemos el resultado.
            return auditInfo;
        }

        #endregion Methods
    }
}