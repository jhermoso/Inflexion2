// -----------------------------------------------------------------------
// <copyright file="ParameterRebinder.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain.Specification
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Clase de ayuda para los carga de parámetros en
    /// expresiones sin utilizar el método Invoke.
    /// </summary>
    /// <remarks>
    /// Este método no está soportado por todos lo proveedores de Linq,
    /// por ejemplo en LinqToEntities.
    /// </remarks>
    public sealed class ParameterRebinder : ExpressionVisitor
    {
        #region Fields

        /// <summary>
        /// Variable privada de tipo colección
        /// de parámetros para árboles de expresión.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase ParameterRebinder.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="map">
        /// Parámetro de tipo colección de parámetros de expresión.
        /// </param>
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            // Comprobamos si viene null, en ese caso inicializamos la colección.
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Función encargada de reemplazar los parámetros
        /// en la expresión dada según la información contenidad
        /// en la colección de parámetros <paramref name="map"/>.
        /// </summary>
        /// <param name="map">
        /// Parámetro de tipo colección de parámetros que se utilizarán para reemplazar
        /// en la expresión.
        /// </param>
        /// <param name="expression">
        /// Parámetro de tipo <see cref="System.Linq.Expressions.Expression"/>
        /// donde se reempalzarán los  parámetros.
        /// </param>
        /// <returns>
        /// Devuelve <see cref="System.Linq.Expressions.Expression"/>
        /// con los parámetros reemplazados.
        /// </returns>
        public static Expression ReplaceParameters(
            Dictionary<ParameterExpression, ParameterExpression> map,
            Expression expression)
        {
            // Devolvemos el resultado.
            return new ParameterRebinder(map).Visit(expression);
        }

        /// <summary>
        /// Función del patrón Visitor.
        /// </summary>
        /// <param name="parameter">
        /// Parámetro de tipo <see cref="ParameterExpression"/> que representa el
        /// parámetro a reemplazar.
        /// </param>
        /// <returns>
        /// Devuelve <see cref="System.Linq.Expressions.Expression"/> visitada
        /// con el parámetro reeplazado.
        /// </returns>
        protected override Expression VisitParameter(ParameterExpression parameter)
        {
            // Objeto de tipo parámetro de expresión.
            ParameterExpression replacement;
            if (map.TryGetValue(parameter, out replacement))
            {
                parameter = replacement;
            }
            // Devolvemos el resultado.
            return base.VisitParameter(parameter);
        }

        #endregion Methods
    }
}