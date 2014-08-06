// --------------------------------------------------------------------------
// <copyright file="ViewPermissionStateType.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------
namespace Inflexion2.Security.Application // old Inflexion.Framework.Infrastructure.Security.Data
{
    using System.Runtime.Serialization;

    #region Enumerations

    /// <summary>
    /// Enumerado de estados de permisos relacionados con las vistas.
    /// <list type="bullet">
    /// <item>
    /// Estado <see cref="Invisible"/>, corresponde al estado de dato no mostrado.
    /// </item>
    /// <item>
    /// Estado <see cref="ReadOnly"/>, corresponde al estado de dato de solo lectura.
    /// </item>
    /// <item>
    /// Estado <see cref="Disabled"/>, corresponde al estado de dato deshabilitado.
    /// </item>
    /// <item>
    /// Estado <see cref="Unassigned"/>, corresponde al estado de permiso de dato no asignado.
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// Posibles estados de los permisos de interfaz.
    /// </remarks>
    [DataContract]
    public enum ViewPermissionStateType : int
    {
        /// <summary>
        /// Estado correspondiente a dato que no se muestra.
        /// </summary>
        /// <value>
        /// El valor del enumerado es <c>1</c>.
        /// </value>
        [EnumMember(Value="Invisible")]
        Invisible = 1,

        /// <summary>
        /// Estado correspondiente a dato que se muestra pero no se
        /// puede modificar.
        /// </summary>
        /// <value>
        /// El valor del enumerado es <c>2</c>.
        /// </value>
        [EnumMember(Value = "ReadOnly")]
        ReadOnly = 2,

        /// <summary>
        /// Estado correspondiente a dato no activo.
        /// </summary>
        /// <value>
        /// El valor del enumerado es <c>3</c>.
        /// </value>
        [EnumMember(Value = "Disabled")]
        Disabled = 3,

        /// <summary>
        /// Estado correspondiente a permiso no asignado.
        /// </summary>
        /// <value>
        /// El valor del enumerado es <c>4</c>.
        /// </value>
        [EnumMember(Value = "Unassigned")]
        Unassigned = 4
    }

                 #endregion Enumerations
}