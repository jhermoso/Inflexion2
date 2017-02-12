// -----------------------------------------------------------------------
// <copyright file="Range.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    /// <summary>
    /// Clase pública que representa un rango de enteros.
    /// </summary>
    /// <remarks>
    /// Objeto-valor para rangos de números enteros.
    /// </remarks>
    public class Range : ValueObject<IRange>, IRange
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:Range"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        internal Range()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:Range"/>.
        /// </summary>
        /// <param name="initialValue">
        /// Parámetro que indica el valor inicial del rango.
        /// </param>
        /// <param name="finalValue">
        /// Parámetro que indica el valor final del rango.
        /// </param>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        internal Range(int initialValue, int finalValue)
        {
            // Inicializamos las propiedades.
            this.InitialValue = initialValue;
            this.FinalValue = finalValue;
        }

        #endregion Constructors

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
        public virtual int FinalValue
        {
            get;
            protected set;
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
        public virtual int InitialValue
        {
            get;
            protected set;
        }

        #endregion Properties
    }
}