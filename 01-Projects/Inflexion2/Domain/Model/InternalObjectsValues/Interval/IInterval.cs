// -----------------------------------------------------------------------
// <copyright file="IInterval.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;

    /// <summary>
    /// Interfaz que expone el contrato para el objeto valor intervalo.
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    public interface IInterval : IValueObject
    {
        #region Properties

        /// <summary>
        /// Propiedad que indica la hora de inicio
        /// del intervalo.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que se utilizada para representar la
        /// hora de inicio del intervalo.
        /// </value>
        DateTime? FromTime
        {
            get;
        }

        /// <summary>
        /// Propiedad que indica la hora de fin del intervalo.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que se utilizada para representar la
        /// hora de fin del intervalo.
        /// </value>
        DateTime? ToTime
        {
            get;
        }

        #endregion Properties

        #region Other

        ///// <summary>
        ///// Propiedad que indica la duración del intervalo.
        ///// </summary>
        ///// <remarks>
        ///// Sin comentarios especiales.
        ///// </remarks>
        ///// <value>
        ///// Valor que se utilizada para representar la duración del intervalo.
        ///// </value>
        //TimeSpan Duration { get; }

        #endregion Other
    }
}