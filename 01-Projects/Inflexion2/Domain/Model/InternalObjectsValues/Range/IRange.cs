// -----------------------------------------------------------------------
// <copyright file="IRange.cs" company="Inflexion Software">
//     Copyright (c) 2014. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;

    /// <summary>
    /// Interfaz que expone el contrato para el objeto-valor de rango.
    /// </summary>
    /// <remarks>
    /// Este objeto valor consta de un valor inicial y valor final,
    /// de tipo Int32, que determinan dicho rango.
    /// </remarks>
    public interface IRange : IValueObject<IRange>
    {
        #region Properties

        /// <summary>
        /// Propiedad que obtiene el valor final del rango
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener el valor final del rango
        /// </value>
        int FinalValue
        {
            get;
        }

        /// <summary>
        /// Propiedad que obtiene el valor inicial del rango.
        /// </summary>
        /// /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener el valor inicial del rango
        /// </value>
        int InitialValue
        {
            get;
        }

        #endregion Properties
    }
}