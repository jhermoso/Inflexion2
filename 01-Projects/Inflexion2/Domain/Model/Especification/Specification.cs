// -----------------------------------------------------------------------
// <copyright file="Specification.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain.Specification
{
    using System;
    using System.Linq.Expressions;


    /// <summary>
    /// Clase que representa una especificación de expresión.
    /// </summary>
    /// <remarks>
    /// Esta clase sobrecarga los operadores
    /// para crear AND, OR, ó NOT especificaciones.
    /// </remarks>
    /// <typeparam name="TEntity">
    /// Representa la entidad que verifica la especificación.
    /// </typeparam>
    public abstract class Specification<TEntity> : ISpecification<TEntity>
        where TEntity : class
    {
        #region Methods

        /// <summary>
        /// Función que representa el operador NOT.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="specification">
        /// Parámetro de tipo <see cref="Specification"/> que representa el operando
        /// izquierdo de la operación OR.
        /// </param>
        /// <returns>
        /// Devuelve nueva especificación aplicando la operación NOT.
        /// </returns>
        public static Specification<TEntity> operator !(Specification<TEntity> specification)
        {
            // Devolvemos el resultado.
            return new NotSpecification<TEntity>(specification);
        }

        /// <summary>
        /// Función que representa el operador AND.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="leftSpecification">
        /// Parámetro de tipo <see cref="Specification"/> que representa el operando
        /// izquierdo de la operación AND.
        /// </param>
        /// <param name="rightSpecification">
        /// Parámetro de tipo <see cref="Specification"/> que representa el operando
        /// derecho de la operación AND.
        /// </param>
        /// <returns>
        /// Devuelve nueva especificación aplicando la operación AND.
        /// </returns>
        public static Specification<TEntity> operator &(
            Specification<TEntity> leftSpecification,
            Specification<TEntity> rightSpecification)
        {
            // Devolvemos el resultado.
            return new AndSpecification<TEntity>(leftSpecification, rightSpecification);
        }

        /// <summary>
        /// Función que representa el operador false.
        /// </summary>
        /// <remarks>
        /// Operador sobreescrito sólo para el soporte a
        /// los operadores AND y OR.
        /// </remarks>
        /// <param name="specification">
        /// Parámetro de tipo <see cref="Specification"/>.
        /// </param>
        /// <returns>
        /// Devuelve False.
        /// </returns>
        public static bool operator false(Specification<TEntity> specification)
        {
            return false;
        }

        /// <summary>
        /// Función que representa el operador true.
        /// </summary>
        /// <remarks>
        /// Operador sobreescrito sólo para el soporte a
        /// los operadores AND y OR.
        /// </remarks>
        /// <param name="specification">
        /// Parámetro de tipo <see cref="Specification"/>.
        /// </param>
        /// <returns>
        /// Devuelve true.
        /// </returns>
        public static bool operator true(Specification<TEntity> specification)
        {
            return true;
        }

        /// <summary>
        /// Función que representa el operador OR.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="leftSpecification">
        /// Parámetro de tipo <see cref="Specification"/> que representa el operando
        /// izquierdo de la operación OR.
        /// </param>
        /// <param name="rightSpecification">
        /// Parámetro de tipo <see cref="Specification"/> que representa el operando
        /// derecho de la operación OR.
        /// </param>
        /// <returns>
        /// Devuelve nueva especificación aplicando la operación OR.
        /// </returns>
        public static Specification<TEntity> operator |(
            Specification<TEntity> leftSpecification,
            Specification<TEntity> rightSpecification)
        {
            // Devolvemos el resultado.
            return new OrSpecification<TEntity>(leftSpecification, rightSpecification);
        }

        /// <summary>
        /// Método abstracto encargado de comprobar si la
        /// especificación se satisface con la expresión
        /// lambda especifica.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <returns>
        /// Devuelve expresión lambda que satisface la especificación.
        /// </returns>
        public abstract Expression<Func<TEntity, bool>> IsSatisfiedBy();

        #endregion Methods
    }
}