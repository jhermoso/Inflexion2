//----------------------------------------------------------------------------------------------
// <copyright file="EFRepository.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System.Data.Entity;
    using System.Globalization;
    using System.Linq;
    using Logging;

    /// <summary>
    /// see the remarks class
    /// </summary>
    /// <remarks>
    /// it just attaches the the entity to the dataContext otherwise you will have to search for the entity using the primary key and then edit the value and save it..
    /// If you have an entity that you know already exists in the database but to which changes may have been made then you can tell the context to attach the entity and set its state to Modified.
    /// </remarks>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdentifier"></typeparam>
    public class EFRepository<TEntity, TIdentifier> : BaseRepository<TEntity, TIdentifier>
        where TEntity : AggregateRoot<TEntity, TIdentifier>, IAggregateRoot<TEntity, TIdentifier>, IEntity<TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        private readonly ILogger logger;
        private DbContext dbContext;

        /// <summary>
        /// see the remarks
        /// </summary>
        /// <param name="dbContext"></param>
        public EFRepository(DbContext dbContext) : base()
        {
            this.logger = LoggerManager.GetLogger(GetType());
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Created repository for type: {0}", typeof(TEntity).Name));
            this.dbContext = dbContext;
        }

        /// <summary>
        /// generic add operation adapter 
        /// </summary>
        /// <param name="entity"></param>
        protected override void InternalAdd(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// generic attach operation adapter for EF
        /// </summary>
        /// <param name="entity"></param>
        protected override void InternalAttach(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Attach(entity);
        }

        /// <summary>
        /// gerneric 
        /// </summary>
        /// <param name="entity"></param>
        protected override void InternalModify(TEntity entity)
        {
            var entry = this.dbContext.Entry(entity);
            entry.State = System.Data.Entity.EntityState.Modified;
        }

        /// <summary>
        /// see the remarks
        /// </summary>
        /// <param name="entity"></param>
        protected override void InternalRemove(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// see the remarks
        /// </summary>
        /// <returns></returns>
        protected override IQueryable<TEntity> Query()
        {
            return this.dbContext.Set<TEntity>();
        }
    }
}