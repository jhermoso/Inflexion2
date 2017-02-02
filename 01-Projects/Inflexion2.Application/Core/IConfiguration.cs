// -----------------------------------------------------------------------
// <copyright file="IConfiguration.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application
{
    /// <summary>
    /// Interface encargada de la configuración para los servicios Wcf.
    /// </summary>
    /// <remarks>
    /// Interface para la configuración predeterminada de los servicios WCF que
    /// forman parte de la fachada remota.
    /// </remarks>
    public interface IConfiguration
    {
        #region Methods

        /// <summary>
        /// Método encargado de la ejecución de la configuración.
        /// </summary>
        /// <remarks>
        /// Configuración predeterminada construyendo la cadena de conexión por usuario.
        /// </remarks>
        void Configure();

        /// <summary>
        /// Método encarga de la ejecución de la configuración del acceso a datos.
        /// </summary>
        /// <param name="userName">
        /// Parámetro que indica el nombre de usuario para el inicio de sesión.
        /// </param>
        /// <param name="password">
        /// Parámetro que indica la password del usuario para el inicio de sesión.
        /// </param>
        /// <remarks>
        /// Configuración predeterminada construyendo la cadena de conexión por usuario.
        /// </remarks>
        /// <exception cref="System.ArgumentNullException">
        /// Lanzada cuando el valor de <c>userName</c> ó <c>password</c> es null ó vacío.
        /// </exception>
        void ConfigureDataAccess(string userName, string password);

        #endregion Methods
    }
}