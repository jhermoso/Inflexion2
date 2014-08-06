// -----------------------------------------------------------------------
// <copyright file="CompositeSpecification.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain.Specification
{
    using System;
    using System.Linq.Expressions;


    /// <summary>
    /// Clase base para especificaciones compuestas.
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    /// <typeparam name="TEntity">
    /// Representa la entidad que verifica la especificación.
    /// </typeparam>
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region Properties

        /// <summary>
        /// Propiedad pública que establece la especificación
        /// de la parte izquierda dentro de la composición.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer la especificación
        /// de la parte izquierda dentro de la composición.
        /// </value>
        public abstract ISpecification<TEntity> LeftSpecification
        {
            get;
        }

        /// <summary>
        /// Propiedad pública que establece la especificación
        /// de la parte derecha dentro de la composición.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer la especificación
        /// de la parte derecha dentro de la composición.
        /// </value>
        public abstract ISpecification<TEntity> RightSpecification
        {
            get;
        }

        #endregion Properties
    }
}