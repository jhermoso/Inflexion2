// -----------------------------------------------------------------------
// <copyright file="IAuditInfo.cs" company="Inflexion Software">
//     Copyright (c) 2014. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;

    /// <summary>
    /// Interfaz que representa el objeto-valor
    /// de tipo auditoría de datos.
    /// </summary>
    /// <remarks>
    /// Representa los datos de tipo auditoría.
    /// </remarks>
    public interface IAuditInfo : IValueObject
    {
        #region Properties

        /// <summary>
        /// Propiedad que obtiene el identificador único
        /// del usuario que crea el registro.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que se utilizada para obtener el
        /// identificador único del usuario que crea el registro.
        /// </value>
        string CreatedBy
        {
            get;
        }

        /// <summary>
        /// Propiedad que indica la fecha de creación del registro.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que se utilizada para representar la
        /// fecha de creación del registro.
        /// </value>
        DateTime CreatedTimestamp
        {
            get;
        }

        /// <summary>
        /// Propiedad que obtiene el identificador único
        /// del usuario que modifica el registro.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que se utilizada para obtener el identificador
        /// único del usuario que modifica el registro.
        /// </value>
        string UpdatedBy
        {
            get;
        }

        /// <summary>
        /// Propiedad que indica la fecha de modificación del registro.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que se utilizada para representar la
        /// fecha de modificación del registro.
        /// </value>
        DateTime? UpdatedTimestamp
        {
            get;
        }

        #endregion Properties
    }
}