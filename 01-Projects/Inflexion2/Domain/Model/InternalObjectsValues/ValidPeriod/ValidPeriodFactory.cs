// -----------------------------------------------------------------------
// <copyright file="ValidPeriodFactory.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;

    /// <summary>
    /// Clase factoría para la creación de objetos
    /// valor de tipo <see cref="IValidPeriod"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    public static class ValidPeriodFactory
    {
        #region Methods

        /// <summary>
        /// Método encargado de la creación de objetos valor de
        /// periodo de vigencia.
        /// </summary>
        /// <param name="fromDate">
        /// Parámetro que indica la fecha inicial del periodo de vigencia.
        /// </param>
        /// <param name="toDate">
        /// Parámetro que indica la fecha final del periodo de vigencia.
        /// </param>
        /// <returns>
        /// Devuelve objeto de tipo <see cref="IValidPeriod"/> creado.
        /// </returns>
        public static IValidPeriod Create(DateTime? fromDate, DateTime? toDate)
        {
            // Creamos el objeto valor de periodo de vigencia.
            IValidPeriod validPeriod = new ValidPeriod(fromDate, toDate);
            // Devolvemos el objeto valor creado.
            return validPeriod;
        }

        #endregion Methods
    }
}