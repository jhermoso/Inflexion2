// -----------------------------------------------------------------------
// <copyright file="PermissionStateType.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Security.Application // old Inflexion.Framework.Infrastructure.Security.Data
{
    using System.Runtime.Serialization;

    #region Enumerations

    /// <summary>
    /// Enumerado de estados de permisos tanto de operaciones como de datos.
    /// <list type="bullet">
    /// <item>
    /// Estado <see cref="Grant"/>, corresponde al estado de permiso
    /// concedido al rol determinado.
    /// </item>
    /// <item>
    /// Estado <see cref="Revoke"/>, corresponde al estado de permiso
    /// no concedido al rol determinado.
    /// </item>
    /// <item>
    /// Estado <see cref="Unassigned"/>, corresponde al estado de
    /// permiso no asignado.
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// Posibles estados de los permisos de operación o dato.
    /// </remarks>
    [DataContract]
    public enum PermissionStateType : int
    {
        /// <summary>
        /// Estado correspondiente a permiso concedido.
        /// </summary>
        /// <value>
        /// El valor del enumerado es <c>1</c>.
        /// </value>
        [EnumMember(Value = "Grant")]
        Grant = 1,

        /// <summary>
        /// Estado correspondiente a permiso no concedido.
        /// </summary>
        /// <value>
        /// El valor del enumerado es <c>2</c>.
        /// </value>
        [EnumMember(Value = "Revoke")]
        Revoke = 2,

        /// <summary>
        /// Estado correspondiente a permiso no asignado.
        /// </summary>
        /// <value>
        /// El valor del enumerado es <c>3</c>.
        /// </value>
        [EnumMember(Value = "Unassigned")]
        Unassigned = 3
    }

                 #endregion Enumerations
}