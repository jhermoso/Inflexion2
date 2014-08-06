// -----------------------------------------------------------------------
// <copyright file="SpecificationExtensions.cs" company="Inflexion Software">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
// Based on https://github.com/cmendible/Hexa.Core/blob/master/Hexa.Core/Domain/Specification/SpecificationModel.cs
namespace Inflexion2.Application.DataTransfer.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Inflexion2.Domain.Specification;

    /// TODO: Update summary.
    /// </summary>
    public static class SpecificationDtoExtensions
    {
        #region Methods
        /// <summary>
        /// Convierte el dto de especification a una especification
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="specificationDto"></param>
        /// <returns></returns>
        public static ISpecification<TEntity> ToSpecification<TEntity>(this SpecificationDto specificationDto)
        where TEntity : class
        {
            return specificationDto.ToSpecification<TEntity>(null);
        }

        public static ISpecification<TEntity> ToSpecification<TEntity>(this SpecificationDto specificationDto, Inflexion2.Domain.Specification.ISpecification<TEntity> specification)
        where TEntity : class
        {
            foreach (Filter rule in specificationDto.CompositeFilter.Filters)
            {
                if (rule.Value != "")
                {
                    if (specification == null)
                    {
                        specification = Inflexion2.Extensions.SpecificationsLinqExtensions.CreateSpecification<TEntity>(rule.Property, rule.Value, rule.Operator);
                    }
                    else
                    {
                        if (specificationDto.CompositeFilter.LogicalOperator == CompositeFilterLogicalOperator.And)
                        {
                            specification = specification.AndAlso(rule.Property, rule.Value, rule.Operator);
                        }
                        else
                        {
                            specification = specification.OrElse(rule.Property, rule.Value, rule.Operator);
                        }
                    }
                }
            }

            if (specification == null)
            {
                specification = new TrueSpecification<TEntity>();
            }

            return specification;
        }

        #endregion Methods
    }
}