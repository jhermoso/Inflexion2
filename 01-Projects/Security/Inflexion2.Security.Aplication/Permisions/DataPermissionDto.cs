// -----------------------------------------------------------------------
// <copyright file="DataPermissionDto.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Security.Application.Permissions
{
    using System;
    using System.Runtime.Serialization;

    using Inflexion2.Security.Application; // old Inflexion.Framework.Infrastructure.Security.Data;

    /// <summary>
    /// Clase que corresponde con el dominio de IDataPermission dentro del
    /// contexto de seguridad.
    /// </summary>
    /// <remarks>
    /// Dto de la clase DataPermission
    /// </remarks>
    [DataContract]
    public sealed class DataPermissionDto : Inflexion2.Application.DataTransfer.Core.IDataTransferObject
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:DataPermissionDto"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        public DataPermissionDto()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad pública que obtiene el identificador del elemento.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener el identificador del elemento.
        /// </value>
        [DataMember]
        public int DataElementId
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene el tipo de elemento.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener el tipo de elemento.
        /// </value>
        [DataMember]
        public string DataElementName
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que obtiene o establece el identificador
        /// único del permiso.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor utilizada para el identificador
        /// único del permiso.
        /// </value>
        [DataMember]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que indica si el permiso está activo.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
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
        /// Propiedad pública que obtiene el tipo de permiso a aplicar.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
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