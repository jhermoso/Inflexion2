﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Persona" company="Atento">
//     Copyright (c) 2017. Atento. All Rights Reserved.
//     Copyright (c) 2017. Atento. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " ApplicationIocRepositoryLayer.tt" with "public class ApplicationIocRepositoryLayer : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "ApplicationIocRepositoryLayer.tt" con "public class ApplicationIocRepositoryLayer : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Atento.Suite.Shared.Application.WcfService
{
    #region usings
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;

    using Microsoft.Practices.Unity;
    using Inflexion2;
    using Inflexion2.Domain;
    using Inflexion2.Data;
    using Inflexion2.Application;

    using Atento.Suite.Shared.Domain;
    using Atento.Suite.Shared.Domain.Data;
    using Atento.Suite.Shared.Infrastructure;
    #endregion
    /// <summary>
    /// Registra en el contenedor de Ioc de la capa de aplicacion las clases de acceso al repositorio
    /// </summary>
    public static class SharedRepositoryLayer
    {
        private static string ConnString = null;
        public static RootAggregateFrameworkUnitOfWorkFactory<Atento.Suite.Shared.Infrastructure.BootstrapUnitOfWork> CtxFactory = null;
        public static void IocRegistry()
        {
            // Context Factory
            ConnString = ConnectionString();
            CtxFactory = new RootAggregateFrameworkUnitOfWorkFactory<Atento.Suite.Shared.Infrastructure.BootstrapUnitOfWork>(ConnString);//1

            //ctxFactory.ValidateDatabaseSchema();//1
            if (!CtxFactory.DatabaseExists())
            {
                CtxFactory.CreateDatabase();
            }

            ApplicationLayer.IocContainer.RegisterInstance<IDatabaseManager>(CtxFactory);
            ApplicationLayer.IocContainer.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>(ApplicationLayer.UnitOfWorkPerTestLifeTimeManager);
            ApplicationLayer.IocContainer.RegisterType<DbContext, BootstrapUnitOfWork>(ApplicationLayer.ContextPerTestLifeTimeManager, new InjectionConstructor(ConnString));
            RegisterRepositoryTypes();
        }
        private static void RegisterRepositoryTypes()
        {
            // registramos el repositorio de cada uno de las entidades que son rootaggregates
            ApplicationLayer.IocContainer.RegisterType<IPersonaRepository, PersonaRepository>(new PerResolveLifetimeManager());
            ApplicationLayer.IocContainer.RegisterType<ICategoriaRepository, CategoriaRepository>(new PerResolveLifetimeManager());
// bloque de cierre
}

        /// <summary>
        /// Get the conection string from the app.config or web config file asociated to the project on execution.
        /// </summary>
        /// <returns>The database connection string </returns>
        static private string ConnectionString()
        {

            System.Diagnostics.Contracts.Contract.Requires<ConfigurationErrorsException>(ConfigurationManager.AppSettings != null, "The configuration file don't exist or is not in the executed project");
            //System.Diagnostics.Contracts.Contract.Requires<ConfigurationErrorsException>(AppConfigHasTheSection("Suite.Connection"), "The configuration file has not a 'Suite.Connection' name for a connection string ");
            string result;
            try
            {
                result = ConfigurationManager.ConnectionStrings["Suite.Connection"].ConnectionString;
            }
            catch (ConfigurationErrorsException)
            {
                throw;
            }

            return result;
        }
	}
}
