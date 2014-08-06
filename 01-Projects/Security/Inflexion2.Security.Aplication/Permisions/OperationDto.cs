// -----------------------------------------------------------------------
// <copyright file="DataPermissionDto.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Security.Application.Permissions
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Clase que corresponde con DTO de la entidad IOperation.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [DataContract]
    public sealed class OperationDto<TIdentifier> : Inflexion2.Application.DataTransfer.Base.BaseEntityDataTransferObject<TIdentifier>
    where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:OperationDto"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public OperationDto()
        {
        }

        #endregion Constructors

        #region Properties

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

        #endregion Properties
    }
}