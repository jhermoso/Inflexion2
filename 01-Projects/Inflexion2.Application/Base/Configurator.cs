// -----------------------------------------------------------------------
// <copyright file="Configurator.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application.Base
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using Inflexion2.Domain.Base;
    using Inflexion2.Infrastructure.IoC;
    using Inflexion2.Infrastructure.DataAccess.UoW.NHibernate31;

    using NHibernate.Bytecode;
    using NHibernate.Cfg;
    using NHibernate.Dialect;

    // : Inflexion.Framework.Application.Core.IConfiguration
    /// <summary>
    /// Clase encargada de configuración predeterminada para cualquiera de los
    /// servicios que forman parte de la fachada WCF.
    /// </summary>
    /// <remarks>
    /// Establece la configuración predeterminada para cualquiera de los
    /// servicios que forman parte de la fachada WCF.
    /// </remarks>
    public static class Configurator
    {
        #region Fields

        /// <summary>
        /// Variable privada para comprobar si ya se ha configurado el servicio.
        /// </summary>
        /// <remarks>
        /// Variable booleana para comprobar si ya se ha configurado.
        /// </remarks>
        private static bool isConfigured = false;
        private static Configuration nhConfiguration;

        #endregion Fields

        #region Events

        /// <summary>
        ///
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public static event System.EventHandler<ReadOnlyEventArgs<IAdapterIoC>> AddTypesToContainer;

        #endregion Events

        #region Properties

        public static string Dialect
        {
            get
            {
                return NHibernate.Dialect.Dialect.GetDialect(nhConfiguration.Properties).ToString();
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Método público encargado de configurar el servicio.
        /// </summary>
        /// <remarks>
        /// Se encarga de configurar lo referente al inversor de depencias y al ORM.
        /// </remarks>
        public static void Configure()
        {
            Configure(new List<Assembly>());
        }

        /// <summary>
        /// Método público encargado de configurar el servicio con una lista de ensamblados.
        /// </summary>
        /// <param name="mappingAssemblies">
        /// Parámetro que identifica la lista de ensamblados a mapear.
        /// </param>
        /// <remarks>
        /// Se encarga de configurar lo referente al inversor de depencias y al ORM.
        /// </remarks>
        public static void Configure(List<Assembly> mappingAssemblies)
        {
            if (!isConfigured)
            {
                System.AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

                // Configuramos la inversion de dependencias.
                DependencyInjectionConfiguration();
                // Configuramos el ORM NHibernate para el acceso a datos.
                DataAccessConfiguration(mappingAssemblies);
                // Configuramos el proveedor de EagerFetch
                EagerFetch.FetchingProvider = () => new NHFetchProvider();

                // Marcamos el entorno como configurado.
                isConfigured = true;
            }
        }

        /// <summary>
        /// Maneja el evento AssemblyResolve del dominio de aplicacion
        /// </summary>
        /// <param name="sender">la fuente del evento</param>
        /// <param name="args">The <see cref="System.ResolveEventArgs"/>Datos del assembly requerido</param>
        /// <returns></returns>
        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            // Si el container de IoC no es capaz de resolver un assembly escribimos su nombre para conocer exactamente cual
            // fue el assembly que genero el problema. Esto es especialemente util con los errores cripticos de MS Unity
            System.Diagnostics.Debug.WriteLine(string.Format("No se ha encontrado el assembly: {0}", args.Name));

            //retornamos null
            return null;
        }

        /// <summary>
        /// Método privado estático encargado de establecer la
        /// configuración para la unidad de trabajo en el acceso a datos.
        /// </summary>
        /// <remarks>
        /// Establece la configuración para la unidad de trabajo en el acceso
        /// a datos.
        /// </remarks>
        private static void DataAccessConfiguration(List<Assembly> mappingAssemblies)
        {
            // Creamos el controlador de la unidad de trabajo.
            Inflexion2.Infrastructure.DataAccess.UoW.NHibernate31.Controller defaultUnitOfWorkController = null;

            try
            {
                // Instanciamos el controlador de la unidad de trabajo.
                defaultUnitOfWorkController = new Inflexion2.Infrastructure.DataAccess.UoW.NHibernate31.Controller();

                // Creamos un objeto de tipo NHibernate.Cfg.Configuration
                var config = FluentlyConfigureNHiberante(mappingAssemblies);

                if (Inflexion2.Application.Properties.Settings.Default.CreateDatabaseScript)
                {
                    //***************************************************************************************************************/
                    // Creamos el script de BBDD si estamos en modo debug.
                    new NHibernate.Tool.hbm2ddl.SchemaExport(config)
                    .SetOutputFile(SolvePath() + @"\database_script.sql").Create(false, false);
                    //***************************************************************************************************************/
                }

                // Configuramos el adaptador.
                defaultUnitOfWorkController.Initialize(config);
                // Establecemos dicho controlador como predeterminado.
                Inflexion2.Infrastructure.DataAccess.UoW.Manager.DefaultController = defaultUnitOfWorkController;
            }
            catch (System.Exception ex)
            {
                // Comprobamos si la unidad de trabajo es null.
                if (defaultUnitOfWorkController != null)
                {
                    // Llamamos al método Dispose del objeto.
                    defaultUnitOfWorkController.Dispose();
                    defaultUnitOfWorkController = null;
                }
                // Lanzamos la excepción.
                throw;
            }
        }

        /// <summary>
        /// Método privado para establecer la configuración para la inversión de dependencias
        /// basada en Microsoft Unity 2.1.
        /// </summary>
        /// <remarks>
        /// Configuración para la inversión de dependencias basada en Microsoft Unity 2.1
        /// </remarks>
        private static void DependencyInjectionConfiguration()
        {
            // Objeto contenedor de inversión de control.
            Inflexion2.Infrastructure.IoC.MicrosoftUnity21.Adapter unityContainer = null;

            try
            {
                // Creamos el controlador de la unidad de trabajo.
                unityContainer = new Inflexion2.Infrastructure.IoC.MicrosoftUnity21.Adapter();
                // Obtenemos la ruta del fichero de configuración del acceso a datos.
                string pathFile = SolvePath();

                // Obtenemos todos los ficheros de configuración de Unity.
                string[] unityFiles = Directory.GetFiles(
                                          pathFile,
                                          Inflexion2.Application.Properties.Settings.Default.SearchPatternUnityFiles,
                                          SearchOption.TopDirectoryOnly);
                // Recorremos la colección de ficheros y configuramos el adaptador.
                foreach (var item in unityFiles)
                {
                    // Configuramos el adaptador.
                    unityContainer.Execute(item);
                }
                // Comprobamos si tenemos ensamblados a mapear.
                if (AddTypesToContainer != null)
                {
                    AddTypesToContainer(null, new ReadOnlyEventArgs<IAdapterIoC>(unityContainer));
                }

                // Establecemos dicho adaptador como predeterminado.
                Inflexion2.Infrastructure.IoC.ManagerIoC.Container = unityContainer;
            }
            catch (System.Exception ex)
            {
                // Comprobamos si el contenedor de inversión es null.
                if (unityContainer != null)
                {
                    // Hacemos Dispose del objeto.
                    unityContainer.Dispose();
                    unityContainer = null;
                }
                // Lanzamos la excepción.
                throw;
            }
        }

        /// <summary>
        /// Método privado estático encargado de la configuración de nHibernate con Fluent.
        /// </summary>
        /// <param name="nHibernateConfigFile">
        /// Parámetro que indica la ruta del fichero de configuración de nhibernate.
        /// </param>
        /// <param name="mappingAssemblies">
        /// Parámetro que indica la lista de ensamblados a mapear.
        /// </param>
        /// <returns>
        /// Devuelve la configuración <see cref="Configuration"/> correspondiente.
        /// </returns>
        private static Configuration FluentlyConfigureNHiberante(List<Assembly> mappingAssemblies)
        {
            // Configuramos Fluent.
            FluentConfiguration fluentConfiguration = Fluently.Configure(new Configuration().Configure());

            fluentConfiguration.Mappings(m =>
                {
                    m.FluentMappings.Conventions.AddAssembly(typeof(Configurator).Assembly);

                    foreach (Assembly mappingAssembly in mappingAssemblies)
                    {
                        m.FluentMappings.Conventions.AddAssembly(mappingAssembly);
                    }
                })
                .Mappings(m =>
                {
                    foreach (Assembly mappingAssembly in mappingAssemblies)
                    {
                        m.FluentMappings.AddFromAssembly(mappingAssembly);
                    }
                })
                .Mappings(m =>
                {
                    foreach (Assembly mappingAssembly in mappingAssemblies)
                    {
                        m.HbmMappings.AddFromAssembly(mappingAssembly);
                    }
                });

            // Añadimos configuraciones.
            fluentConfiguration.ExposeConfiguration(c => c.Properties.Add(NHibernate.Cfg.Environment.BatchSize, "100"))
                .ExposeConfiguration(c => c.Properties.Add(NHibernate.Cfg.Environment.UseProxyValidator, "true"));

            PropertyInfo pinfo = typeof(FluentConfiguration).GetProperty("Configuration",BindingFlags.Instance | BindingFlags.NonPublic);
            nhConfiguration = pinfo.GetValue(fluentConfiguration, null) as Configuration;

            Configuration builtConfiguration = fluentConfiguration.BuildConfiguration();

            // Devolvemos la respuesta.
            return builtConfiguration;
        }

        /// <summary>
        /// Función privada para resolver el path de una ruta leída del fichero de configuración.
        /// </summary>
        /// <remarks>
        /// Resolverá la ruta en caso de que sea una ruta relativa.
        /// </remarks>
        /// <param name="isDataAccess">
        /// Indica si leeremos el valor de la clave para el fichero de acceso a datos.
        /// </param>
        /// <returns>Devuelve una cadena con la ruta absoluta.</returns>
        private static string SolvePath()
        {
            // Leemos el valor del fichero de configuración para el acceso a datos,
            // o bien
            // leemos el valor del fichero de configuración para la inversión de control.
            //string valueKey = (isDataAccess == true ?
            //                   Properties.Settings.Default.PathFileDataAccessConfig :
            //                   Properties.Settings.Default.PathFileInversionConfig);

            FileInfo configurationFile = new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);     // obtenemos el directorio del app.config o del web.config para la aplicación que se esta ejecutando 
            // Comprobamos si el path es correcto.
            if (!configurationFile.Exists)
            {
                throw new System.IO.FileNotFoundException();
            }

            return configurationFile.DirectoryName;

            //// Obtenemos el nombre del fichero de configuración a leer.
            //string fileName = System.IO.Path.GetFileName(valueKey);
            //// Obtenemos la ruta del ensamblado.
            //string assemblyPath = System.AppDomain.CurrentDomain.RelativeSearchPath;
            //// Nos aseguramos que assemblyPath no sea nulo.
            //if (assemblyPath == null)
            //        assemblyPath = System.AppDomain.CurrentDomain.BaseDirectory;

            //// Montamos y devolvemos el path absoluto.
            //return System.IO.Path.Combine(assemblyPath, fileName);
        }

        #endregion Methods
    }

    public class ReadOnlyEventArgs<T> : EventArgs
    {
        #region Constructors

        public ReadOnlyEventArgs(T input)
        {
            Parameter = input;
        }

        #endregion Constructors

        #region Properties

        public T Parameter
        {
            get;
            private set;
        }

        #endregion Properties
    }
}