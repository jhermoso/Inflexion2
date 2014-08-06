// ---------------------------------------------------------------------------
// <copyright file="DateGreaterThanAttribute.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// ---------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase de tipo atributo encargado de validar fechas.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public sealed class DateGreaterThanAttribute : ValidationAttribute
    {
        #region Fields

        /// <summary>
        /// Variable privada que representa el nombre de la propiedad.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        private string basePropertyName;

        /// <summary>
        /// Variable privada encargada de almacenar el mensaje de error.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        private string errorMessage;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DateGreaterThanAttribute"/>.
        /// </summary>
        /// <param name="basePropertyName">
        /// Parámetro que indica el nombre base de la propiedad fecha de la que comparar.
        /// </param>
        /// <param name="errorMessage">
        /// Parámetro que indica el mensaje en caso de error.
        /// </param>
        public DateGreaterThanAttribute(
            string basePropertyName,
            string errorMessage)
        : base()
        {
            this.basePropertyName = basePropertyName;
            this.errorMessage = errorMessage;
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
            // Obtenemos el objeto PropertyInfo.
            var basePropertyInfo = validationContext.ObjectType.GetProperty(this.basePropertyName);
            // Obtenemos el valor de la propiedad.
            var startDate = (DateTime?)basePropertyInfo.GetValue(validationContext.ObjectInstance, null);
            // Comprobamos si viene valor (puedes ser nullable)
            if (!startDate.HasValue)
            {
                return null;
            }
            // Obtenemos el valor de la fecha que nos viene para comparar.
            var thisDate = (DateTime?)value;
            // Comprobamos las fechas.
            if (thisDate <= startDate.Value)
            {
                // Devolvemos la lista de errores de validación.
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