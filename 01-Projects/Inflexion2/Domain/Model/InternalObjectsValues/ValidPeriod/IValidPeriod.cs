// -----------------------------------------------------------------------
// <copyright file="IValidPeriod.cs" company="Inflexion Software">
//     Copyright (c) 2014. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Interfaz que expone el contrato para el objeto valor
    /// de periodo de vigencia.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public interface IValidPeriod : IValueObject<IValidPeriod>
    {
        #region Properties

        /// <summary>
        /// Propiedad que indica la fecha de inicio
        /// del periodo de vigencia.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que se utilizada para representar la
        /// fecha de inicio del periodo de vigencia.
        /// </value>
        DateTime? FromDate
        {
            get;
        }

        /// <summary>
        /// Propiedad que indica la fecha de fin
        /// del periodo de vigencia.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que se utilizada para representar la
        /// fecha de fin del periodo de vigencia.
        /// </value>
        DateTime? ToDate
        {
            get;
        }

        #endregion Properties
    }
}