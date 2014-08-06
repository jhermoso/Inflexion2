// -----------------------------------------------------------------------
// <copyright file="RoleOperationPermissionDto.cs" company="Microsoft">
//    Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Security.Application.Permissions
{
    using System;
    using System.Runtime.Serialization;

    //using Inflexion.Framework.Infrastructure.Security.Data;

    /// <summary>
    /// Clase que corresponde con el dominio de IOperation dentro del
    /// contexto de seguridad.
    /// </summary>
    /// <remarks>
    /// Dto de la clase RoleOperationPermission.
    /// </remarks>
    [DataContract]
    public sealed class RoleOperationPermissionDto<TIdentifier> : Inflexion2.Application.DataTransfer.Base.BaseEntityDataTransferObject<TIdentifier>
    where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:OperationPermissionDto"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public RoleOperationPermissionDto()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad pública que indica si el permiso está activo.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para indicar si elpermiso está activo.
        /// </value>
        [DataMember]
        public bool IsActive
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene el código de la operación.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener el código de la operación.
        /// </value>
        [DataMember]
        public string OperationCode
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene el nombre de la operación.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener el nombre de la operación.
        /// </value>
        [DataMember]
        public string OperationName
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene el tipo de permiso a aplicar.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener el tipo de permiso a aplicar.
        /// </value>
        [DataMember]
        public PermissionStateType PermissionState
        {
            get;
            set;
        }

        #endregion Properties
    }
}