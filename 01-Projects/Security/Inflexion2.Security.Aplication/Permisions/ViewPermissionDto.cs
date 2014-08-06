// -----------------------------------------------------------------------
// <copyright file="ViewPermissionDto.cs" company="Microsoft">
//    Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion.Framework.Application.Security.Data.Base.Permissions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Clase sellada que corresponde con el DTO de la entidad IViewPermission.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [DataContract]
    public sealed class ViewPermissionDto<TIdentifier> : Inflexion2.Application.DataTransfer.Base.BaseEntityDataTransferObject<TIdentifier>
    where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:ViewPermissionDto"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public ViewPermissionDto()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad que obtiene o establece el identificador del elemento
        /// sobre el que se aplica el permiso.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el identificador del elemento.
        /// </value>
        [DataMember]
        public int DataElementId
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que obtiene o establece el nombre de elemento.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el nombre de elemento.
        /// </value>
        [DataMember]
        public string DataElementName
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que obtiene o establece el tipo de elemento.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el tipo de elemento.
        /// </value>
        [DataMember]
        public string DataElementType
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

        #endregion Properties
    }
}