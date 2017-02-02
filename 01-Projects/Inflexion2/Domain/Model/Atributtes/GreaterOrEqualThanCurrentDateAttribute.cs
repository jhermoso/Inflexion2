// ----------------------------------------------------------------------------------------
// <copyright file="GreaterOrEqualThanCurrentDateAttribute.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase atributo encargada comprobar si una fecha es menor
    /// que la fecha actual.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public class GreaterOrEqualThanCurrentDateAttribute : ValidationAttribute
    {
        #region Fields

        /// <summary>
        /// Variable encargada de almacenar el mensaje de error.
        /// </summary>
        private string errorMessage = "TODO: escribir mensaje de error y pasarlo a recursos";
        
        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:GreaterOrEqualThanCurrentDateAttribute"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public GreaterOrEqualThanCurrentDateAttribute()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Función encargada de validar si una fecha es mayor a otra.
        /// </summary>
        /// <param name="value">
        /// Parámetro que indica la fecha a comparar.
        /// </param>
        /// <param name="validationContext">
        /// Parámetro que indica el contexto de validación.
        /// </param>
        /// <returns>
        /// Devuelve <c>true</c> si el valor de la fecha es válido y <c>false</c> en caso contrario.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Obtenemos el valor de la fecha que nos viene para comparar.
            var thisDate = (DateTime)value;
            // Comprobamos las fechas.
            if (DateTime.Compare(thisDate, DateTime.Now) < 0)
            {
                // Devolvemos los errores.
                return new ValidationResult(this.errorMessage, new List<string>()
                {
                    validationContext.MemberName
                });
            }
            // No ha habido error, devolvemos la respuesta.
            return null;
        }

        #endregion Methods
    }
}