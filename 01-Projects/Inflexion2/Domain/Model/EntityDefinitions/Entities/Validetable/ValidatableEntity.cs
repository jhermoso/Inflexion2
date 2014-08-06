

namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Inflexion2.Domain.Validation;

    /// <summary>
    /// Entitiy validatable with data annotations
    /// </summary>
    /// <typeparam name="TIdentifier"></typeparam>
    [Serializable]
    public abstract class ValidatableEntity<TEntity, TIdentifier> : Entity<TEntity, TIdentifier>, 
                                Inflexion2.Domain.Validation.IValidatable,
                                IEntity<TIdentifier>,
                                System.IEquatable<IEntity<TIdentifier>>, 
                                System.IComparable<IEntity<TIdentifier>>, 
                                System.IComparable
        where TEntity : ValidatableEntity<TEntity, TIdentifier>, IValidatable, IEntity<TIdentifier>                        
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        /// <summary>
        /// 
        /// </summary>
        private IValidator<Entity<TEntity, TIdentifier>> validator;

        /// <summary>
        /// Gets the validator.
        /// </summary>
        /// <value>The validator.</value>
        /// <remarks>Object should _explicitly_ implement IValidatable or this call will fail.</remarks>
        protected IValidator<Entity<TEntity, TIdentifier>> Validator
        {
            get
            {
                if (this.validator == null)
                {
                    this.validator = new DataAnnotationsValidator<Entity<TEntity, TIdentifier>>();
                }

                return this.validator;
            }
        }

        /// <summary>
        /// Validates this instance.
        /// If instance is not valid, method must throw a ValidationException.
        /// </summary>
        public virtual void AssertValidation()
        {
            ValidationResult result = this.Validate();
            if (!result.IsValid)
            {
                throw new ValidationException(this.GetType(), result.Errors);
            }
        }

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsValid()
        {
            return this.Validate().IsValid;
        }

        /// <summary>
        /// Validates this instance.
        /// If instance is not valid, a collection of errors will be returned.
        /// </summary>
        /// <returns>A list containing error details, or null</returns>
        public virtual ValidationResult Validate()
        {
            return this.Validator.Validate((Entity<TEntity, TIdentifier>)this);
        }

        /// <summary>
        /// Validates the instance with the specified validator.
        /// </summary>
        /// <param name="validator">The validator.</param>
        /// <returns></returns>
        public virtual ValidationResult Validate(IValidator<Entity<TEntity, TIdentifier>> validator)
        {
            return validator.Validate((Entity<TEntity, TIdentifier>)this);
        }

    }
}
