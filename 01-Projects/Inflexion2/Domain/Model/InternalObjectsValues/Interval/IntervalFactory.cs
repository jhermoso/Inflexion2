// -----------------------------------------------------------------------
// <copyright file="IntervalFactory.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;

    /// <summary>
    /// Clase factoría para la creación de objetos
    /// valor de tipo <see cref="IInterval"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public static class IntervalFactory
    {
        #region Methods

        /// <summary>
        /// Método encargado de la creación de objetos valor <see cref="IInterval"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="fromTime">
        /// Parámetro que indica la hora inicial del intervalo.
        /// </param>
        /// <param name="atTime">
        /// Parámetro que indica la hora final del intervalo.
        /// </param>
        /// <returns>
        /// Devuelve objeto de tipo <see cref="IInterval"/> creado.
        /// </returns>
        public static IInterval Create(DateTime? fromTime, DateTime? atTime)
        {
            // Creamos el objeto valor de periodo de vigencia.
            IInterval interval = new Interval(fromTime, atTime);
            // Devolvemos el objeto valor creado.
            return interval;
        }

        /// <summary>
        /// Método estático encargado de la creación de objetos valor <see cref="IInterval"/>
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="fromTime">
        /// Parámetro que indica la hora inicial del intervalo.
        /// </param>
        /// <param name="duration">
        /// Parámetro que indica la duración del intervalo.
        /// </param>
        /// <returns>
        /// Devuelve objeto de tipo <see cref="IInterval"/> creado.
        /// </returns>
        public static IInterval Create(DateTime? fromTime, TimeSpan duration)
        {
            // Creamos el objeto valor de periodo de vigencia.
            IInterval interval = new Interval(fromTime, duration);
            // Devolvemos el objeto valor creado.
            return interval;
        }

        #endregion Methods
    }
}