//----------------------------------------------------------------------------------------------
// <copyright file="BaseClassMap.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using FluentNHibernate.Mapping;

    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using Inflexion2;

    public class BaseClassMap<TEntity> : ClassMap<TEntity>
    {
        public BaseClassMap() 
        {
            Configuration = ServiceLocator.GetInstance<Configuration>();
            Dialect = Dialect.GetDialect(Configuration.Properties);
        }

        protected Configuration Configuration
        {
            get;
            private set;
        }

        protected Dialect Dialect
        {
            get;
            private set;
        }
    }
}