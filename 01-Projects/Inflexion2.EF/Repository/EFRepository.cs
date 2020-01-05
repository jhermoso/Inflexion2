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

    using Reflection;
    using System;

    /// <summary>
    /// .en it just attaches the the entity to the dataContext otherwise you will have to search for the entity using the primary key and then edit the value and save it..
    /// If you have an entity that you know already exists in the database but to which changes may have been made then you can tell the context to attach the entity and set its state to Modified.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdentifier"></typeparam>
    public class EFRepository<TEntity, TIdentifier> : BaseRepository<TEntity, TIdentifier>
        where TEntity : class, IEntity<TIdentifier>, /* Entity<TEntity, TIdentifier>, */  IEquatable<TEntity>, IComparable<TEntity>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        //private readonly ILogger logger;
        private DbContext dbContext;

        /// <summary>
        /// see the summary
        /// </summary>
        /// <param name="dbContext"></param>
        public EFRepository(DbContext dbContext) : base()
        {
            //logger = LogManager.GetLogger(GetType());
            //this.logger_.Debug(string.Format(CultureInfo.InvariantCulture, "Created repository for type: {0}", typeof(TEntity).Name));
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
        /// generic 
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
        /// <param name="id"></param>
        protected override void InternalRemove(TIdentifier id)
        {
            var entity2delete = this.dbContext.Set<TEntity>().First(c => c.Id.Equals(id));
            this.InternalRemove(entity2delete);
        }

        /// <summary>
        /// see the remarks
        /// </summary>
        /// <returns></returns>
        protected override IQueryable<TEntity> Query()
        {
            return this.dbContext.Set<TEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override TEntity GetAggregateById(TIdentifier id)
        {
            this.logger_.Debug(string.Format(CultureInfo.InvariantCulture, "Get record by Id from entity {0}.", typeof(TEntity).Name));

            IQueryable<TEntity> query = this.Query().AsQueryable();
            var includes = EntityReflection<TEntity, TIdentifier>.GetChildrenProperties();
            foreach (var item in includes)
            {
                query = query.Include(item.Name);
            }

            TEntity result = query.SingleOrDefault(c => c.Id.Equals(id));

            return result;
        }
    }
}
