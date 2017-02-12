// -----------------------------------------------------------------------
// <copyright file="Manager.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Infrastructure
{
    using global::System.Data;
    using global::System.Data.Common;
    using global::System.Threading;

    //Alias
    using ProviderFactoryDictionary = global::System.Collections.Generic.Dictionary<string, global::System.Data.Common.DbProviderFactory>;

    /// <summary>
    /// Clase estática
    /// </summary>
    /// <remarks>
    /// .en The System.Data.Common namespace provides classes for creating DbProviderFactory 
    /// instances to work with specific data sources. 
    /// When you create a DbProviderFactory instance and pass it information about the data provider, 
    /// the DbProviderFactory can determine the correct, strongly typed connection object to return based on the information it has been provided.
    /// Beginning in the .NET Framework version 4, data providers such as System.Data.Odbc, 
    /// System.Data.OleDb, System.Data.SqlClient, 
    /// and System.Data.OracleClient are no longer listed in machine.config file, 
    /// but custom providers will continue to be listed there.
    /// </remarks>
    /// <seealso href="http://msdn.microsoft.com/en-us/library/wda6c36e.aspx">DbProviderFactories (ADO.NET) .NET Framework 4</seealso>
    public static class Manager
    {
        #region Fields

        /// <summary>
        /// Variable privada de tipo colección de objetos de tipo
        /// <see cref="DbProviderFactory"/>
        /// </summary>
        /// <remarks>
        /// http://juank.io/csharp-c-palabra-clave-volatile-explicacion-ejemplos/
        /// advertencia ProviderFactoryDictionary es un alias de DbProviderFactory declarado al principio de este fichero de código.
        /// </remarks>
        private static volatile ProviderFactoryDictionary providerFactories;

        /// <summary>
        /// Variable privada utilizada para la sección crítica.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        private static object providerFactoriesMonitorLock = new object();

        /// <summary>
        /// Variable privada utilizada para aplicar el patrón singelton.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        private static object providerFactoriesSingletonMutex = new object();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Propiedad que obtiene una colección de objetos <see cref="DbProviderFactory"/>
        /// </summary>
        /// <remarks>
        /// Se utiliza un patrón solitario para la creación
        /// perezosa de la colección (diccionario) de factorías.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener una colección de objetos
        /// de tipo <see cref="DbProviderFactory"/>.
        /// </value>
        private static ProviderFactoryDictionary Factories
        {
            get
            {
                if (providerFactories == null)
                {
                    lock (providerFactoriesSingletonMutex)
                    {
                        if (providerFactories == null)
                        {
                            providerFactories = new ProviderFactoryDictionary();
                        }
                    }
                }
                return providerFactories;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Método estático para limpiar la colección.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        public static void Clear()
        {
            // Entramos en la sección crítica.
            Monitor.Enter(providerFactoriesMonitorLock);
            // Limpiamos toda la colección.
            Factories.Clear();
            // Salimos de la sección crítica.
            Monitor.Exit(providerFactoriesMonitorLock);
        }

        /// <summary>
        /// Método estático encargado de devolver una instancia de la clase
        /// <see cref="DbProviderFactory"/> de acuerdo al nombre del proveedor proporcionado.
        /// </summary>
        /// <param name="providerFactoryName">
        /// Parámetro que indica el nombre del proveedor de acceso a datos.
        /// </param>
        /// <returns>
        /// Devuelve objeto <see cref="DbProviderFactory"/> que representa la
        /// factoría de proveedores.
        /// </returns>
        public static DbProviderFactory GetFactory(string providerFactoryName)
        {
            // Entramos en la sección crítica.
            Monitor.Enter(providerFactoriesMonitorLock);
            // Verificamos si existe la factoría de proveedor.
            if (!Factories.ContainsKey(providerFactoryName))
            {
                var newFactory = DbProviderFactories.GetFactory(providerFactoryName);
                Factories.Add(providerFactoryName, newFactory);
            }
            // Salimos de la sección crítica.
            Monitor.Exit(providerFactoriesMonitorLock);
            // Devolvemos el resultado.
            return Factories[providerFactoryName];
        }

        /// <summary>
        /// Función estática encargada de crear una conexión abierta.
        /// </summary>
        /// <param name="providerName">
        /// Parámetro que indica el nombre del proveedor de acceso a datos.
        /// </param>
        /// <param name="connectionString">
        /// Parámetro que indica la cadena de conexión.
        /// </param>
        /// <returns>
        /// Devuelve objeto de tipo <see cref="IDbConnection"/> con la conexión creada.
        /// </returns>
        public static DbConnection GetOpenConnection(string providerName, string connectionString)
        {
            // Creamos la conexión.
            DbConnection connection = GetFactory(providerName).CreateConnection();
            // Establecemos la cadena de conexión.
            connection.ConnectionString = connectionString;
            // Abrimos la conexión.
            connection.Open();
            // Devolvemos el resultado.
            return connection;
        }

        /// <summary>
        /// Método estático encargado de eliminar una factoría de la colección.
        /// </summary>
        /// <param name="providerFactoryName">
        /// Parámetro que indica el nombre del proveedor de acceso a datos.
        /// </param>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        public static void Remove(string providerFactoryName)
        {
            // Entramos en la sección crítica.
            Monitor.Enter(providerFactoriesMonitorLock);
            // Borramos el elemento de la colección.
            Factories.Remove(providerFactoryName);
            // Salimos de la sección crítica.
            Monitor.Exit(providerFactoriesMonitorLock);
        }

        /// <summary>
        /// Método encargado de devolver todas las factorías de tipo
        /// <see cref="DbProviderFactory"/>.
        /// </summary>
        /// <param name="clearCurrentFactories">
        /// Parámetro que indica si se limpiará previamente la colección.
        /// </param>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <seealso href="http://msdn.microsoft.com/en-us/library/system.data.common.dbproviderfactories.getfactoryclasses.aspx"/>
        public static void RetrieveAllConfiguredFactories(bool clearCurrentFactories = true)
        {
            // Entramos en la sección crítica.
            Monitor.Enter(providerFactoriesMonitorLock);
            // Primero, eliminamos todas las factorías.
            if (clearCurrentFactories)
            {
                Factories.Clear();
            }
            // Cargamos todas las factorías configuradas a través del APP/WEB.CONFIG.
            DataTable allProviderFactories = DbProviderFactories.GetFactoryClasses();
            foreach (DataRow providerFactory in allProviderFactories.Rows)
            {
                // Obtenemos el nombre de la factoría de proveedor.
                string providerFactoryName = providerFactory["InvariantName"].ToString();
                // Cargamos dicha factoría de proveedor.
                GetFactory(providerFactoryName);
            }
            // Salimos de la sección crítica.
            Monitor.Exit(providerFactoriesMonitorLock);
        }

        #endregion Methods
    }
}