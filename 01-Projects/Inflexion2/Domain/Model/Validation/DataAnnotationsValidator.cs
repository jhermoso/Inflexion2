﻿//----------------------------------------------------------------------------------------------
// <copyright file="DataAnnotationsValidator.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// generic implementation of data anotations validations for validetable entitys
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    [Serializable]
    public class DataAnnotationsValidator<TEntity> : IValidator<TEntity>
    {
        /// <summary>
        /// Generic Entity Assert Validation 
        /// </summary>
        /// <param name="instance"></param>
        public void AssertValidation(TEntity instance)
        {
            ValidationResult result = this.Validate(instance);
            if (!result.IsValid)
            {
                throw new ValidationException(instance.GetType(), result.Errors);
            }
        }

        /// <summary>
        /// Generic valid condition for an entity
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>Instance Entity valid condition</returns>
        public bool IsValid(TEntity instance)
        {
            return this.Validate(instance).IsValid;
        }

        /// <summary>
        /// Generic validate trigger for a Validate entity.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public virtual ValidationResult Validate(TEntity instance)
        {
            Type entityType = instance.GetType();

            IEnumerable<ValidationError> errors =
                from prop in TypeDescriptor.GetProperties(instance).Cast<PropertyDescriptor>()
                from attribute in prop.Attributes.OfType<ValidationAttribute>()
                where !attribute.IsValid(prop.GetValue(instance))
                select
                new ValidationError(
                    entityType,
                    attribute.FormatErrorMessage(string.Empty),
                    DataAnnotationHelper.ParseDisplayName(entityType, prop.Name));

            if (errors.Any())
            {
                return new ValidationResult(errors.Cast<ValidationError>());
            }
            else
            {
                return new ValidationResult();
            }
        }
    }
}