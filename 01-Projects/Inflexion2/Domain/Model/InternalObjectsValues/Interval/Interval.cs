// -----------------------------------------------------------------------
// <copyright file="Interval.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Inflexion2.Domain.Validation;
    

    /// <summary>
    /// Clase pública que representa un intervalo.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public class Interval : ValueObject<IInterval>, IInterval
    {
        #region Fields

        /// <summary>
        /// Variable privada de propiedad para almacenar la hora de inicio.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        private DateTime? fromTime;

        /// <summary>
        /// Variable privada de propiedad para almacenar la hora de fin.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        private DateTime? toTime;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:Interval"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        internal Interval()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:Interval"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="fromTime">
        /// Parámetro que indica la hora inicial del intervalo.
        /// </param>
        /// <param name="toTime">
        /// Parámetro que indica la hora final del intervalo.
        /// </param>
        internal Interval(
            DateTime? fromTime,
            DateTime? toTime)
        {
            // Inicializamos las propiedades.
            this.FromTime = fromTime;
            this.ToTime = toTime;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:Interval"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="fromTime">
        /// Parámetro que indica la hora inicial del intervalo.
        /// </param>
        /// <param name="duration">
        /// Parámetro que indica la duración del intervalo.
        /// </param>
        internal Interval(
            DateTime? fromTime,
            TimeSpan duration)
        {
            // Inicializamos las propiedades.
            this.FromTime = fromTime;
            if (fromTime.HasValue)
            {
                this.ToTime = fromTime.Value.Subtract(duration);
            }
            //this.Duration = duration;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad pública que obtiene la hora inicial
        /// del intervalo
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener la hota inicial
        /// del intervalo.
        /// </value>
        [DataType(DataType.DateTime)]
        public virtual DateTime? FromTime
        {
            get
            {
                return this.fromTime;
            }
            protected set
            {
                if (value.HasValue)
                {
                    // Asignamos la hora y minutos del valor.
                    this.fromTime = new DateTime(1900, 1, 1, value.Value.Hour, value.Value.Minute, 0);
                }
            }
        }

        /// <summary>
        /// Propiedad pública que obtiene la hora final del intervalo.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener la hora final del intervalo.
        /// </value>
        [DataType(DataType.DateTime)]
        [DateGreaterThan("FromTime", "La hora final debe ser mayor que la hora inicial.")]
        public virtual DateTime? ToTime
        {
            get
            {
                return this.toTime;
            }
            protected set
            {
                if (value.HasValue)
                {
                    // Asignamos la hora y minutos del valor.
                    this.toTime = new DateTime(1900, 1, 1, value.Value.Hour, value.Value.Minute, 0);
                }
            }
        }

        #endregion Properties
    }
}