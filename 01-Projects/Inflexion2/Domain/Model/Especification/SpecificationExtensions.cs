// -----------------------------------------------------------------------
// <copyright file="SpecificationExtensions.cs" company="Inflexion Software">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
// Based on https://github.com/cmendible/Hexa.Core/blob/master/Hexa.Core/Domain/Specification/SpecificationExtensions.cs
namespace Inflexion2.Domain.Specification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class SpecificationExtensions
    {
        #region Methods

        /// <summary>
        ///  AndAlso operator
        /// </summary>
        /// <param name="leftSideSpecification">left operand in this AND operation</param>
        /// <param name="rightSideSpecification">right operand in this AND operation</param>
        /// <returns>New specification</returns>
        public static ISpecification<TEntity> AndAlso<TEntity>(this ISpecification<TEntity> leftSideSpecification,
                ISpecification<TEntity> rightSideSpecification)
        where TEntity : class
        {
            return new AndSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
        }

        /// <summary>
        /// OrElse operator
        /// </summary>
        /// <param name="leftSideSpecification">left operand in this OR operation</param>
        /// <param name="rightSideSpecification">left operand in this OR operation</param>
        /// <returns>New specification</returns>
        public static ISpecification<TEntity> OrElse<TEntity>(this ISpecification<TEntity> leftSideSpecification,
                ISpecification<TEntity> rightSideSpecification)
        where TEntity : class
        {
            return new OrSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
        }

        #endregion Methods
    }
}