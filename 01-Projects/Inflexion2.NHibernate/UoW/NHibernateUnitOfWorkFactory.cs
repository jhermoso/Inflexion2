﻿//----------------------------------------------------------------------------------------------
// <copyright file="NHibernateUnitOfWorkFactory.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    using Inflexion2.Data;
    using Inflexion2.Domain.Extensions;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Bytecode;
    using NHibernate.Cfg;
    using NHibernate.Event;
    using NHibernate.Tool.hbm2ddl;
    using Environment = NHibernate.Cfg.Environment;


    //TODO: estudiar si es posible eliminar el parametro <tidentifier>
    public sealed class NHibernateUnitOfWorkFactory< TIdentifier> : IDatabaseManager

        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        private static Configuration _builtConfiguration;
        private static string _connectionString;
        private static DbProvider _DbProvider;
        private static bool _InMemoryDatabase;
        private static bool _validationSupported = true;

        private ISessionFactory _sessionFactory;

        public NHibernateUnitOfWorkFactory(
            DbProvider provider,
            string connectionString,
            string cacheProvider,
            Assembly[] mappingAssemblies)
        {
            _DbProvider = provider;
            _connectionString = connectionString;

            FluentConfiguration cfg = null;

            switch (_DbProvider)
            {
            case DbProvider.MsSqlProvider:
            {
                cfg = Fluently.Configure().Database(MsSqlConfiguration.MsSql2008
                                                    .Raw("format_sql", "true")
                                                    .ConnectionString(_connectionString))
                      .ExposeConfiguration(
                          c =>
                          c.Properties.Add(
                              Environment.SqlExceptionConverter,
                              typeof(SqlExceptionHandler).AssemblyQualifiedName))
                      .ExposeConfiguration(c => c.Properties.Add(Environment.DefaultSchema, "dbo"));

                break;
            }

            case DbProvider.SQLiteProvider:
            {
                cfg = Fluently.Configure().Database(SQLiteConfiguration.Standard
                                                    .Raw("format_sql", "true")
                                                    .ConnectionString(_connectionString));

                _InMemoryDatabase = _connectionString.ToUpperInvariant().Contains(":MEMORY:");

                break;
            }

            case DbProvider.SqlCe:
            {
                cfg = Fluently.Configure().Database(MsSqlCeConfiguration.Standard
                                                    .Raw("format_sql", "true")
                                                    .ConnectionString(_connectionString))
                      .ExposeConfiguration(
                          c =>
                          c.Properties.Add(
                              Environment.SqlExceptionConverter,
                              typeof(SqlExceptionHandler).AssemblyQualifiedName));

                _validationSupported = false;

                break;
            }

            case DbProvider.Firebird:
            {
                cfg = Fluently.Configure().Database(new FirebirdConfiguration()
                                                    .Raw("format_sql", "true")
                                                    .ConnectionString(_connectionString));

                break;
            }

            case DbProvider.PostgreSQLProvider:
            {
                cfg = Fluently.Configure().Database(PostgreSQLConfiguration.PostgreSQL82
                                                    .Raw("format_sql", "true")
                                                    .ConnectionString(_connectionString));

                _validationSupported = false;

                break;
            }
            }

            Guard.IsNotNull(
                cfg,
                string.Format(
                    "Db provider {0} is currently not supported.",
                    EnumExtension.GetEnumMemberValue(_DbProvider)));

            PropertyInfo pinfo = typeof(FluentConfiguration)
                                 .GetProperty(
                                     "Configuration",
                                     BindingFlags.Instance | BindingFlags.NonPublic);

            Configuration nhConfiguration = pinfo.GetValue(cfg, null) as Configuration;
            ServiceLocator.RegisterInstance<Configuration>(nhConfiguration);

            cfg.Mappings(m =>
            {
                m.FluentMappings.Conventions.AddAssembly(typeof(NHibernateUnitOfWorkFactory<TIdentifier>).Assembly);
                foreach (Assembly mappingAssembly in mappingAssemblies)
                {
                    m.FluentMappings.Conventions.AddAssembly(mappingAssembly);
                }
            })
            .Mappings(m =>
            {
                m.FluentMappings.AddFromAssembly(typeof(NHibernateUnitOfWorkFactory<TIdentifier>).Assembly);
                foreach (Assembly mappingAssembly in mappingAssemblies)
                {
                    m.FluentMappings.AddFromAssembly(mappingAssembly);
                }
            })
            .Mappings(m =>
            {
                m.HbmMappings.AddFromAssembly(typeof(NHibernateUnitOfWorkFactory<TIdentifier>).Assembly);
                foreach (Assembly mappingAssembly in mappingAssemblies)
                {
                    m.HbmMappings.AddFromAssembly(mappingAssembly);
                }
            })
            .ExposeConfiguration(c => c.Properties.Add(Environment.BatchSize, "100"))
            .ExposeConfiguration(c => c.Properties.Add(Environment.UseProxyValidator, "true"));

            if (!string.IsNullOrEmpty(cacheProvider))
            {
                cfg.ExposeConfiguration(c => c.Properties.Add(Environment.CacheProvider, cacheProvider))
                .ExposeConfiguration(c => c.Properties.Add(Environment.UseSecondLevelCache, "true"))
                .ExposeConfiguration(c => c.Properties.Add(Environment.UseQueryCache, "true"));
            }

            _builtConfiguration = cfg.BuildConfiguration();
            _builtConfiguration.SetProperty(
                Environment.ProxyFactoryFactoryClass,
                typeof(DefaultProxyFactoryFactory).AssemblyQualifiedName);

            #region Add Listeners to NHibernate pipeline....

            _builtConfiguration.SetListeners(
                ListenerType.Flush,
            new IFlushEventListener[] { new FixedDefaultFlushEventListener() });

            _builtConfiguration.SetListeners(
                ListenerType.FlushEntity,
            new IFlushEntityEventListener[] { new AuditFlushEntityEventListener<TIdentifier>() });

            _builtConfiguration.SetListeners(
                ListenerType.PreInsert,
                _builtConfiguration.EventListeners.PreInsertEventListeners.Concat(
            new IPreInsertEventListener[] { new ValidateEventListener(), new AuditEventListener<TIdentifier>() }).ToArray());

            _builtConfiguration.SetListeners(
                ListenerType.PreUpdate,
                _builtConfiguration.EventListeners.PreUpdateEventListeners.Concat(
            new IPreUpdateEventListener[] { new ValidateEventListener(), new AuditEventListener<TIdentifier>() }).ToArray());

            #endregion
        }

        internal NHibernateUnitOfWorkFactory()
        {
        }

        public ISessionFactory Create()
        {
            this._CreateSessionFactory();

            return this._sessionFactory;
        }

        public void CreateDatabase()
        {
            var dbManager = new DatabaseManager(_DbProvider, _connectionString);

            // Check if database exists.. (and create it if needed)
            if (!dbManager.DatabaseExists())
            {
                dbManager.CreateDatabase();
                new SchemaExport(_builtConfiguration).Create(false, true);

                if (_DbProvider == DbProvider.MsSqlProvider)
                {
                    using (var conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "RENAME_UNIQUE_KEYS";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public bool DatabaseExists()
        {
            var dbManager = new DatabaseManager(_DbProvider, _connectionString);
            return dbManager.DatabaseExists();
        }

        public void DeleteDatabase()
        {
            var dbManager = new DatabaseManager(_DbProvider, _connectionString);

            if (dbManager.DatabaseExists())
            {
                dbManager.DropDatabase();
            }
        }

        public void ValidateDatabaseSchema()
        {
            if (!_InMemoryDatabase && _validationSupported)
            {
                new SchemaValidator(_builtConfiguration).Validate();
            }
        }

        private void _CreateSessionFactory()
        {
            if (this._sessionFactory == null)
            {
                this._sessionFactory = _builtConfiguration.BuildSessionFactory();
            }
        }
    }
}