// -----------------------------------------------------------------------
// <copyright file="TrueSpecification.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain.Specification
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Clase para la especificación TRUE.
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    public sealed class TrueSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region Methods

        /// <summary>
        /// Función encargada de comprobar si la especificación se satisface
        /// con la expresión lambda especifica.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <returns>
        /// Devuelve expresión lambda que satisface la especificación.
        /// </returns>
        public override Expression<Func<TEntity, bool>> IsSatisfiedBy()
        {
            // Variable booleana.
            bool result = true;
            // Construimos la expresión lambda.
            Expression<Func<TEntity, bool>> trueExpression = t => result;
            // Devolvemos el resultado.
            return trueExpression;
        }

        #endregion Methods
    }
}