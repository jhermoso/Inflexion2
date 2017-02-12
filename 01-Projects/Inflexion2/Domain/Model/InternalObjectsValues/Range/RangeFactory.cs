// -----------------------------------------------------------------------
// <copyright file="RangeFactory.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    /// <summary>
    /// Clase estática factoría para la creación de objetos
    /// valor de tipo <see cref="IRange"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public static class RangeFactory
    {
        #region Methods

        /// <summary>
        /// Método estático encargado de crear objetos valor de tipo
        /// <see cref="IRange"/> según los parámetros proporcionados.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="initialValue">
        /// Parámetro que indica el valor inicial del rango.
        /// </param>
        /// <param name="finalValue">
        /// Parámetro que indica el valor final del rango.
        /// </param>
        /// <returns>
        /// Devuelve objeto <see cref="IRange"/> creado.
        /// </returns>
        public static IRange Create(int initialValue, int finalValue)
        {
            // Creamos el objeto-valor Rango.
            IRange range = new Range(initialValue, finalValue);
            // Devolvemos el resultado.
            return range;
        }

        #endregion Methods
    }
}