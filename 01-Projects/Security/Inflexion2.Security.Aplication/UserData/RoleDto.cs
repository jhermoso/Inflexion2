// -----------------------------------------------------------------------
// <copyright file="RoleDto.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Security.Application.UserData//old Inflexion.Framework.Application.Security.Data.Base
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Inflexion2.Security.Application.Permissions;

    /// <summary>
    /// Clase sellada que corresponde con el DTO de la entidad IRole.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [DataContract]
    public sealed class RoleDto<TIdentifier> : Inflexion2.Application.DataTransfer.Base.BaseEntityDataTransferObject<TIdentifier>
    where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Constructors<TIdentifier> 

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:RoleDto"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public RoleDto()
        {
            // Instanciamos las propiedades de la clase.
            this.DataPermissions = new List<DataPermissionDto>();
            this.OperationPermissions = new List<RoleOperationPermissionDto<TIdentifier>>();
            this.ViewPermissions = new List<RoleViewPermissionDto<TIdentifier>>();
            this.Users = new List<UserIdentityDto<TIdentifier>>();
            this.ChildrenRoles = new List<RoleDto<TIdentifier>>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad pública que obtiene o establece la
        /// lista de permisos de operaciones del rol.
        /// </summary>
        /// <remarks>
        /// Nos permite obtener y establecer la lista de permisos de
        /// operaciones del rol.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer la
        /// lista de permisos de operaciones del rol.
        /// </value>
        [DataMember]
        public List<RoleDto<TIdentifier>> ChildrenRoles
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece la
        /// lista de permisos de datos del rol.
        /// </summary>
        /// <remarks>
        /// Nos permite obtener y establecer la lista de permisos de datos
        /// del rol.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer la
        /// lista de permisos de datos del rol.
        /// </value>
        [DataMember]
        public List<DataPermissionDto> DataPermissions
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece la descripción del
        /// rol.
        /// </summary>
        /// <remarks>
        /// Nos permite obtener y establecer a descripción del rol.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer la descripción
        /// del rol.
        /// </value>
        [DataMember]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que indica si el role está activo.
        /// </summary>
        /// <remarks>
        /// Nos permite obtener y establecer si el role está activo o no.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado indicar si el role está activo.
        /// </value>
        [DataMember]
        public bool IsActive
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece la
        /// lista de permisos de operaciones del rol.
        /// </summary>
        /// <remarks>
        /// Nos permite obtener y establecer la lista de permisos de
        /// operaciones del rol.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer la
        /// lista de permisos de operaciones del rol.
        /// </value>
        [DataMember]
        public List<RoleOperationPermissionDto<TIdentifier>> OperationPermissions
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece el rol padre.
        /// </summary>
        /// <remarks>
        /// Nos permite obtener y establecer el rol padre.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el rol padre.
        /// </value>
        [DataMember]
        public TIdentifier  ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que permite establecer y obtener el nombre
        /// del rol.
        /// </summary>
        /// <remarks>
        /// Nos permite obtener y establecer el nombre del rol.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener el nombre del
        /// rol.
        /// </value>
        [DataMember]
        public string RoleName
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece la lista de usuarios
        /// que pertenecen al rol.
        /// </summary>
        /// <remarks>
        /// Nos permite obtener y establecer la lista de usuarios que
        /// pertenecen al rol.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer la lista de
        /// usuarios que pertenecen al rol.
        /// </value>
        [DataMember]
        public List<UserIdentityDto<TIdentifier>> Users
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece la
        /// lista de permisos de interfaz del rol.
        /// </summary>
        /// <remarks>
        /// Nos permite obtener y establecer la lista de permisos de
        /// interfaz del rol.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer la
        /// lista de permisos de interfaz del rol.
        /// </value>
        [DataMember]
        public List<RoleViewPermissionDto<TIdentifier>> ViewPermissions
        {
            get;
            set;
        }

        #endregion Properties
    }
}