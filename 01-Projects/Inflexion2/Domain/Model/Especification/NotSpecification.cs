// -----------------------------------------------------------------------
// <copyright file="NotSpecification.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain.Specification
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;


    /// <summary>
    /// Clase que representa la especificación
    /// del operador NOT lógico.
    /// </summary>
    /// <remarks>
    /// Convierte una especificación original con el operador NOT.
    /// </remarks>
    /// <typeparam name="TEntity">
    /// Representa la entidad que verifica la especificación.
    /// </typeparam>
    public sealed class NotSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region Fields

        /// <summary>
        /// Variable privada que indica el criterio original.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        Expression<Func<TEntity, bool>> originalCriteria;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase NotSpecification.
        /// </summary>
        /// <param name="originalSpecification"></param>
        public NotSpecification(ISpecification<TEntity> originalSpecification)
        {
            // Comprobamos el parámetro de entrada.
            if (originalSpecification == null)
            {
                // Error, lanzamos la excepción.
                throw new ArgumentNullException("originalSpecification");
            }
            // Asignamos el valor.
            this.originalCriteria = originalSpecification.IsSatisfiedBy();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase NotSpecification.
        /// </summary>
        /// <param name="originalSpecification">
        /// Parámetro de tipo <see cref="System.Linq.Expressions"/>
        /// que representa la especificación original.
        /// </param>
        public NotSpecification(Expression<Func<TEntity, bool>> originalSpecification)
        {
            // Comprobamos el parámetro de entrada.
            if (originalSpecification == null)
            {
                throw new ArgumentNullException("originalSpecification");
            }

            // Asignamos el valor.
            this.originalCriteria = originalSpecification;
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
            // Obtenemos la expresión negada.
            var notExpression = Expression.Not(originalCriteria.Body);
            // Devolvemos el resultado.
            return Expression.Lambda<Func<TEntity, bool>>(notExpression, originalCriteria.Parameters.Single());
        }

        #endregion Methods
    }
}