//----------------------------------------------------------------------------------------------
// <copyright file="EFRepository.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System.Data.Entity;
    using System.Globalization;
    using System.Linq;
    using Inflexion2.Logging;
    using System;

    /// <summary>
    /// see the remarks class
    /// </summary>
    /// <remarks>
    /// it just attaches the the entity to the dataContext otherwise you will have to search for the entity using the primary key and then edit the value and save it..
    /// If you have an entity that you know already exists in the database but to which changes may have been made then you can tell the context to attach the entity and set its state to Modified.
    /// </remarks>
    /// <typeparam name="TValueObject"></typeparam>
    public class EFValueObjectRepository<TValueObject> : BaseValueObjectRepository<TValueObject>, IValueObjectRepository<TValueObject>
        where TValueObject : ValueObject<TValueObject>, IValueObject/*, IComparable<TValueObject>, IEquatable<TValueObject>*/
    {
        private readonly ILogger logger;
        private DbContext dbContext;

        /// <summary>
        /// see the remarks
        /// </summary>
        /// <param name="dbContext"></param>
        public EFValueObjectRepository(DbContext dbContext) : base()
        {
            this.logger = LogManager.GetLogger(GetType());
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Created repository for type: {0}", typeof(TValueObject).Name));
            this.dbContext = dbContext;
        }

        /// <summary>
        /// generic add operation adapter 
        /// </summary>
        /// <param name="entity"></param>
        protected override void InternalAdd(TValueObject entity)
        {
            this.dbContext.Set<TValueObject>().Add(entity);
        }

        /// <summary>
        /// generic attach operation adapter for EF
        /// </summary>
        /// <param name="entity"></param>
        protected override void InternalAttach(TValueObject entity)
        {
            this.dbContext.Set<TValueObject>().Attach(entity);
        }

        /// <summary>
        /// gerneric 
        /// </summary>
        /// <param name="entity"></param>
        protected override void InternalModify(TValueObject entity)
        {
            var entry = this.dbContext.Entry(entity);
            entry.State = System.Data.Entity.EntityState.Modified;
        }

        /// <summary>
        /// see the remarks
        /// </summary>
        /// <param name="entity"></param>
        protected override void InternalRemove(TValueObject entity)
        {
            this.dbContext.Set<TValueObject>().Remove(entity);
        }

        /// <summary>
        /// see the remarks
        /// </summary>
        /// <returns></returns>
        protected override IQueryable<TValueObject> Query()
        {
            return this.dbContext.Set<TValueObject>();
        }
    }
}