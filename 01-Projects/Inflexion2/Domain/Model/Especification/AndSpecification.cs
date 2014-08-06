// -----------------------------------------------------------------------
// <copyright file="AndSpecification.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain.Specification
{
    using System;
    using System.Linq.Expressions;


    /// <summary>
    /// Clase que representa la especificación
    /// del operador And lógico.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Representa la entidad que verifica la especificación.
    /// </typeparam>
    public sealed class AndSpecification<TEntity> : CompositeSpecification<TEntity>
        where TEntity : class
    {
        #region Fields

        /// <summary>
        /// Variable privada que representa la especificación izquierda;
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        private ISpecification<TEntity> leftSpecification;

        /// <summary>
        /// Variable privada que representa la especificación izquierda;
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        private ISpecification<TEntity> rightSpecification;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase AndSpecification.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="left">
        /// Parámetro que indica la especifición del operando de la
        /// izquierda.
        /// </param>
        /// <param name="right">
        /// Parámetro que indica la especificación del operando de la
        /// derecha.
        /// </param>
        public AndSpecification(
            ISpecification<TEntity> left,
            ISpecification<TEntity> right)
        {
            // Comprobamos los parámetros de entrada.
            if (left == null)
            {
                // Error, lanzamos la excepción.
                throw new System.ArgumentNullException("Left Specification is null.");
            }
            if (right == null)
            {
                // Error, lanzamos la excepción.
                throw new System.ArgumentNullException("Right Specification is null.");
            }
            // Asignamos los valores.
            this.leftSpecification = left;
            this.rightSpecification = right;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad que establece la especificación de la parte
        /// derecha del elemento compuesto.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer la especificación de la
        /// parte derecha del elemento compuesto.
        /// </value>
        public override ISpecification<TEntity> LeftSpecification
        {
            get
            {
                return this.leftSpecification;
            }
        }

        /// <summary>
        /// Propiedad que establece la especificación de la parte
        /// izquierda del elemento compuesto.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer la especificación de la
        /// parte izquierda del elemento compuesto.
        /// </value>
        public override ISpecification<TEntity> RightSpecification
        {
            get
            {
                return rightSpecification;
            }
        }

        #endregion Properties

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
            Expression<Func<TEntity, bool>> left = this.LeftSpecification.IsSatisfiedBy();
            Expression<Func<TEntity, bool>> right = this.RightSpecification.IsSatisfiedBy();
            // Devolvemos el resultado.
            return (left.And(right));
        }

        #endregion Methods
    }
}