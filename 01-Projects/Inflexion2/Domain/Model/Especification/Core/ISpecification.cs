// -----------------------------------------------------------------------
// <copyright file="ISpecification.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain.Specification
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Interfaz para el patrón Especificación.
    /// </summary>
    /// <remarks>
    /// Variante del patrón especificación para que
    /// soporte árboles de expresión.
    /// <see href="http://en.wikipedia.org/wiki/Specification_pattern"/>
    /// </remarks>
    /// <typeparam name="TEntity">
    /// Representación de la entidad.
    /// </typeparam>
    public interface ISpecification<TEntity>
        where TEntity : class
        {
            #region Methods

            /// <summary>
            /// Función encargada de comprobar si la especificación se satisface
            /// con la expresión lambda especifica.
            /// </summary>
            /// <returns>
            /// Devuelve expresión lambda que satisface la especificación.
            /// </returns>
            Expression<Func<TEntity, bool>> IsSatisfiedBy();

            #endregion Methods
        }
}