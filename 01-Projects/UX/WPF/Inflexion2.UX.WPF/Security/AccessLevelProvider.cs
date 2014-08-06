// -----------------------------------------------------------------------
// <copyright file="AccessLevelProvider.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Inflexion2.UX.WPF.Security
{

    using System.Linq;

    //using Inflexion.Framework.Application.Security.Data.Base;
    //using Inflexion.Framework.Core;


    /// <summary>
    /// ClasepProveedor del nivel de autorización.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public class AccessLevelProvider : IAccessLevelProvider
    {

        #region FUNCTIONS

            /// <summary>
            /// Función pública encargada de obtener el nivel de acceso para el nombre 
            /// del permiso de seguridad en interfaz proporcionado.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <param name="permissionName">
            /// Parámetro que indica el nombre del permiso de seguridad para interfaz.
            /// </param>
            /// <returns>
            /// Devuelve el nivel de acceso asignado.<see cref="AccessLevel"/>
            /// </returns>
            public AccessLevel GetAccessLevel(string permissionName)
            {
                throw new System.NotImplementedException();
                //TODO: Descomentar al meter seguridad

                //// Comprobamos los parámetros de entrada.
                //Guard.ArgumentNotNullOrEmpty(permissionName, "Permission name is null or empty.");

                //// Obtenemos el contexto de usuario. 
                //UserContextDto userContext = ApplicationContext.UserContext;

                //// Comprobamos los datos del contexto.
                //Guard.ArgumentIsNotNull(userContext, "User context is null.");

                //// Buscamos si el rol tiene el permiso especificado.
                //var data = (from role in userContext.Roles
                //           from permission in role.ViewPermissions
                //           where permission.DataElementName == permissionName
                //           select permission).FirstOrDefault();

                //// Comprobamos los datos.
                //if (data == null)
                //    return AccessLevel.Unassigned;
                //// Devolvemos el resultado.
                //return (AccessLevel)data.PermissionState;
            } // GetAccessLevel

        #endregion

    } // AccessLevelProvider

} // Inflexion2.UX.WPF.Security