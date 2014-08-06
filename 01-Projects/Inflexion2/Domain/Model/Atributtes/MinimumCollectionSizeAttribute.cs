// -------------------------------------------------------------------------------
// <copyright file="MinimumCollectionSizeAttribute.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace Inflexion2.Domain.Validation
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase atributo para la validación de tamaño mínimo de una colección.
    /// </summary>
    /// <remarks>
    /// Validamos el número de elementos mínimos que tiene que tener la colección.
    /// </remarks>
    public class MinimumCollectionSizeAttribute : ValidationAttribute
    {
        #region Fields

        /// <summary>
        ///  Variable privada que indica el tamañon mínimo de la colección.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        private int minSize;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase MinimumCollectionSizeAttribute.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="minSize">
        /// Parámetro que indica el tamaño mínimo.
        /// </param>
        public MinimumCollectionSizeAttribute(int minSize)
        {
            this.minSize = minSize;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Función para validar el tamaño mínimo de una colección.
        /// </summary>
        /// <param name="value">
        /// Parámetro que corresponde a la colección que se quiere validar.
        /// </param>
        /// <returns>
        /// Devuelve <c>true</c> sin la colección cumple con el tamaño mínimo y <c>false</c>
        /// en caso contrario.
        /// </returns>
        public override bool IsValid(object value)
        {
            // Comprobamos el argumento de entrada.
            if (value == null)
            {
                return true;
            }
            // Cast de la colección.
            var list = value as System.Collections.ICollection;
            // Comprobamos si es una lista.
            if (list == null)
            {
                return true;
            }
            // Devolvemos la respueta.
            return list.Count >= minSize;
        }

        #endregion Methods
    }
}