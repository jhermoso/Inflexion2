//----------------------------------------------------------------------------------------------
// <copyright file="NHRepository.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Inflexion2.Logging;
    using NHibernate;
    using NHibernate.Linq;

    /// <summary>
    /// nh repository implementation
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdentifier"></typeparam>
    public class NHRepository<TEntity, TIdentifier> : BaseRepository<TEntity, TIdentifier>
        where TEntity : AggregateRoot<TEntity, TIdentifier>
        where TIdentifier : IEquatable<TIdentifier>, IComparable<TIdentifier>
    {
        private readonly ILogger logger;
        private readonly ISession session;

        /// <summary>
        /// repository constructor and intialization
        /// </summary>
        /// <param name="session"></param>
        public NHRepository(ISession session) : base()
        {
            this.logger = LoggerManager.GetLogger(GetType());
            this.logger.Debug(string.Format(CultureInfo.InvariantCulture, "Created repository for type: {0}", typeof(TEntity).Name));
            this.session = session;
        }

        /// <summary>
        /// add operation
        /// </summary>
        /// <param name="entity"></param>
        protected override void InternalAdd(TEntity entity)
        {
            this.session.Save(entity);
        }

        /// <summary>
        /// attach operation
        /// </summary>
        /// <param name="entity"></param>
        protected override void InternalAttach(TEntity entity)
        {
            this.session.Lock(entity, LockMode.None);
        }

        /// <summary>
        /// override modify
        /// </summary>
        /// <param name="entity"></param>
        protected override void InternalModify(TEntity entity)
        {
            if (!this.session.Contains(entity))
            {
                this.session.Update(entity);
            }
        }

        /// <summary>
        /// delete operation
        /// </summary>
        /// <param name="entity"></param>
        protected override void InternalRemove(TEntity entity)
        {
            this.session.Lock(entity, LockMode.None);
            this.session.Delete(entity);
        }

        /// <summary>
        /// gets UoW
        /// </summary>
        /// <returns></returns>
        protected override IQueryable<TEntity> Query()
        {
            return this.session.Query<TEntity>();
        }
    }
}