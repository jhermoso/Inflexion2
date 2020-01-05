//----------------------------------------------------------------------------------------------
// <copyright file="EntityFrameworkUnitOfWorkFactory.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    //todo: change the namespace
    using System;
    using System.Data.Entity;
    using Inflexion2.Data;

    /// <summary>
    /// Main Database factory operations for EF
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class EfUnitOfWorkFactory<TContext> : IDatabaseManager
        where TContext : RootAggregateContext
    {
        private string connectionString;

        /// <summary>
        /// initialize the connection string
        /// </summary>
        /// <param name="connectionString"></param>
        public EfUnitOfWorkFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// create the unity of work
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork Create()
        {
            return new EfUnitOfWork(this.CreateContext());
        }

        /// <summary>
        /// Create de database is the database don't exist
        /// </summary>
        public void CreateDatabase()
        {
            using (DbContext context = this.CreateContext())
            {
                context.Database.CreateIfNotExists();
            }
        }

        /// <summary>
        /// ask if the database exist
        /// </summary>
        /// <returns></returns>
        public bool DatabaseExists()
        {
            using (DbContext context = this.CreateContext())
            {
                return context.Database.Exists();
            }
        }

        /// <summary>
        /// delete the databade
        /// </summary>
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

        /// <summary>
        /// creates the context for the current conection string
        /// </summary>
        /// <returns></returns>
        private TContext CreateContext()
        {
            var result =  Activator.CreateInstance(typeof(TContext), new object[] { this.connectionString }) as TContext;

            return result;
        }
    }
}