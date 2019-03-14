//----------------------------------------------------------------------------------------------
// <copyright file="BaseClassMap.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using FluentNHibernate.Mapping;

    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using Inflexion2;

    /// <summary>
    /// map base
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseClassMap<TEntity> : ClassMap<TEntity>
    {
        /// <summary>
        /// map base initilization
        /// </summary>
        public BaseClassMap() 
        {
            Configuration = ServiceLocator.GetInstance<Configuration>();
            Dialect = Dialect.GetDialect(Configuration.Properties);
        }

        /// <summary>
        /// nh configuration
        /// </summary>
        protected Configuration Configuration
        {
            get;
            private set;
        }

        /// <summary>
        /// nh dialect
        /// </summary>
        protected Dialect Dialect
        {
            get;
            private set;
        }
    }
}