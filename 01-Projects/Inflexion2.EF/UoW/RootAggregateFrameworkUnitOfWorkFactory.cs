//----------------------------------------------------------------------------------------------
// <copyright file="EntityFrameworkUnitOfWorkFactory.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Data.Entity;
    using Data;

    public class RootAggregateFrameworkUnitOfWorkFactory<TContext> : IDatabaseManager
        where TContext : RootAggregateContext
    {
        private string connectionString;

        public RootAggregateFrameworkUnitOfWorkFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IUnitOfWork Create()
        {
            return new EntityFrameworkUnitOfWork(this.CreateContext());
        }

        public void CreateDatabase()
        {
            using (DbContext context = this.CreateContext())
            {
                context.Database.CreateIfNotExists();
            }
        }

        public bool DatabaseExists()
        {
            using (DbContext context = this.CreateContext())
            {
                return context.Database.Exists();
            }
        }

        public void DeleteDatabase()
        {
            using (DbContext context = this.CreateContext())
            {
                context.Database.Delete();
            }
        }


        /// <summary>
        /// Este metodo valida el esquema de la base de datos.
        /// Esta validación solo se puede realizar si el modelo de la base de datos se ha llevado a cabo 
        /// con entity framework code first. Si la base de datos se ha obtenido de otra manera entonces la 
        /// invocación generara una excepción.
        /// </summary>
        public void ValidateDatabaseSchema()
        {
            using (DbContext context = this.CreateContext())
            {
                //context.Database.CompatibleWithModel(true);
            }
        }

        private TContext CreateContext()
        {
            return Activator.CreateInstance(typeof(TContext), new object[] { this.connectionString }) as TContext;
        }
    }
}