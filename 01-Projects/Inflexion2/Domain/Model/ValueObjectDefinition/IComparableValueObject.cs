// -----------------------------------------------------------------------
// <copyright file="IValueObject.cs" company="Inflexion Software">
//     Copyright (c) 2014. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    //using System.Collections.Generic;
    //using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// TODO: implementar un icomparable para objetos valor basado en la firma de los campos seleccionados por orden.
    /// Interfaz marcadora para los objetos valor del dominio.
    /// </summary>
    /// <typeparam name="TValueObject">
    /// Representación del Objeto Valor.
    /// </typeparam>
    /// <remarks>
    /// Sin comentartios especiales.
    /// </remarks>
    public interface IComparableValueObject<TValueObject> : IEquatable<TValueObject>, IComparable<TValueObject>
        where TValueObject : IComparableValueObject<TValueObject>
    {
        #region Methods

        ///// <summary>
        ///// Método encargado de afirmar la validación.
        ///// </summary>
        ///// <remarks>
        ///// Sin comentarios adicionales.
        ///// </remarks>
        //void AssertValidation();

        ///// <summary>
        ///// Función encargada de determinar si la instancia del objeto valor es válida.
        ///// </summary>
        ///// <remarks>
        ///// Sin comentarios adicionales.
        ///// </remarks>
        ///// <returns>
        ///// Devuelve <c>true</c> si el objeto es válido y <c>false</c> en caso contrario.
        ///// </returns>
        //bool IsValid();

        ///// <summary>
        ///// Método encargado de validar los datos.
        ///// </summary>
        ///// <returns>
        ///// Devuelve <see cref="List{ValidationResult}"/> con los resultados
        ///// de la validación.
        ///// </returns>
        //ValidationResult Validate();

        #endregion Methods
    }
}