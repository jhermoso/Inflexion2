// -----------------------------------------------------------------------
// <copyright file="ValidPeriod.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase pública que representa un periodo de vigencia.
    /// </summary>
    /// <remarks>
    /// Objeto-valor para las fechas de un periodo de vigencia.
    /// </remarks>
    public class ValidPeriod : ValueObject<IValidPeriod>, IValidPeriod
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:ValidPeriod"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        internal ValidPeriod()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:ValidPeriod"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="fromDate">
        /// Parámetro que indica la fecha inicial del período.
        /// </param>
        /// <param name="toDate">
        /// Parámetro que indica la fecha final del período.
        /// </param>
        internal ValidPeriod(
            DateTime? fromDate,
            DateTime? toDate)
        {
            // Inicializamos las propiedades.
            this.FromDate = fromDate;
            this.ToDate = toDate;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad pública que obtiene la fecha inicial
        /// del periodo de vigencia.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener la fecha inicial
        /// del periodo de vigencia.
        /// </value>
        [DataType(DataType.DateTime)]
        public virtual DateTime? FromDate
        {
            get;
            protected set;
        }

        /// <summary>
        /// Propiedad pública que obtiene la fecha final del período de
        /// vigencia.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener la fecha final
        /// del periodo de vigencia.
        /// </value>
        [DataType(DataType.DateTime)]
        [DateGreaterThan("FromDate", "La fecha final debe ser mayor que la fecha inicial.")]
        public virtual DateTime? ToDate
        {
            get;
            protected set;
        }

        #endregion Properties
    }
}