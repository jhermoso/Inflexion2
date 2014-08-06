// -----------------------------------------------------------------------
// <copyright file="ExpressionBuilder.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain.Specification
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Clase extensora para añadir AND y OR con parámetros
    /// en expresiones lambda.
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    public static class ExpressionBuilder
    {
        #region Methods

        /// <summary>
        /// Método extensor del operador AND.
        /// </summary>
        /// <typeparam name="T">
        /// Representa el tipo de los parámetros en la expresión.
        /// </typeparam>
        /// <param name="first">
        /// Parámetro de tipo <see cref="Expression"/> que representa el operando
        /// izquierdo de la operación AND.
        /// </param>
        /// <param name="second">
        /// Parámetro de tipo <see cref="Expression"/> que representa el operando
        /// derecho de la operación AND.
        /// </param>
        /// <returns>
        /// Devuelve nueva AND <see cref="Expression"/>.
        /// </returns>
        public static Expression<Func<T, bool>> And<T>(
            this Expression<Func<T, bool>> first,
            Expression<Func<T, bool>> second)
        {
            // Devolvemos el resultado.
            return first.Compose(second, Expression.AndAlso);
        }

        /// <summary>
        /// Método extensor que compone y une dos expresiones en una nueva expresión.
        /// </summary>
        /// <typeparam name="T">
        /// Representa el tipo de los parámetros en la expresión.
        /// </typeparam>
        /// <param name="first">
        /// Parámetro de tipo <see cref="Expression"/> que representa la
        /// instancia de la primera expresión.
        /// </param>
        /// <param name="second">
        /// Parámetro de tipo <see cref="Expression"/> que representa la
        /// instancia de la segunda expresión a unir o juntar.
        /// </param>
        /// <param name="merge">
        /// Parámetro que representa la función de unión.
        /// </param>
        /// <returns>
        /// Devuelve nueva <see cref="Expression"/>.
        /// </returns>
        public static Expression<T> Compose<T>(
            this Expression<T> first,
            Expression<T> second,
            Func<Expression, Expression, Expression> merge)
        {
            // Construimos el mapeo de los parámetros, apartir de la segunda expresión y terminando con la primera.
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // Reemplazamos los parámetros.
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
            // Realizamos la unión de las expresiones y devolvemos el resultado.
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// Método extensor del operador OR.
        /// </summary>
        /// <typeparam name="T">
        /// Representa el tipo de los parámetros en la expresión.
        /// </typeparam>
        /// <param name="first">
        /// Parámetro de tipo <see cref="Expression"/> que representa el operando
        /// izquierdo de la operación OR.
        /// </param>
        /// <param name="second">
        /// Parámetro de tipo <see cref="Expression"/> que representa el operando
        /// derecho de la operación OR.
        /// </param>
        /// <returns>
        /// Devuelve nueva OR <see cref="Expression"/>.
        /// </returns>
        public static Expression<Func<T, bool>> Or<T>(
            this Expression<Func<T, bool>> first,
            Expression<Func<T, bool>> second)
        {
            // Devolvemos el resutlado.
            return first.Compose(second, Expression.OrElse);
        }

        #endregion Methods
    }
}