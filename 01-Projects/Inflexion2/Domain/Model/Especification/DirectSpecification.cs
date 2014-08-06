// -----------------------------------------------------------------------
// <copyright file="DirectSpecification.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain.Specification
{
    using System;
    using System.Linq.Expressions; // asembly system.data.linq

    /// <summary>
    /// Clase que representa la especificación directa.
    /// </summary>
    /// <remarks>
    /// La especificación directa es una implementación simple de una
    /// especificación que viene dada por la expresión lambda en el constructor.
    /// </remarks>
    /// <typeparam name="TEntity">
    /// Representa la entidad que verifica la especificación.
    /// </typeparam>
    public sealed class DirectSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region Fields

        /// <summary>
        /// Variable privada que representa el criterio de coincidencia.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        private Expression<Func<TEntity, bool>> matchingCriteria;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// <see cref="T:DirectSpecification"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="matchingCriteria">
        /// Parámetro de tipo <see cref="Expression"/> que representa
        /// los criterios coincidentes.
        /// </param>
        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            // Comprobamos el argumento del entrada.
            if (matchingCriteria == null)
            {
                // Error, lanzamos la excepción.
                throw new ArgumentNullException("matchingCriteria");
            }
            // Asignamos el valor.
            this.matchingCriteria = matchingCriteria;
        }

        #endregion Constructors

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
            // Devolvemos el resultado.
            return this.matchingCriteria;
        }

        #endregion Methods
    }
}