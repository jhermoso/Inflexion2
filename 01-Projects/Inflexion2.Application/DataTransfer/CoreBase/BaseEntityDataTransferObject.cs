// -----------------------------------------------------------------------
// <copyright file="IDataTransferObject.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application.DataTransfer.Base
{
    using System.Runtime.Serialization;
    using Inflexion2.Application.DataTransfer.Core;

    /// <summary>
    /// Clase base para los objetos DTO que representan entidades persistidas.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [DataContract]
    public abstract class BaseEntityDataTransferObject<TIdentifier> : IEntityDataTransferObject<TIdentifier>
    where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Properties

        /// <summary>
        /// Propiedad que obtiene o establece el identificador de la entidad representada por el DTO.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el identificador de
        /// la entidad representada por el DTO.
        /// </value>
        [DataMember]
        public TIdentifier Id
        {
            get;
            set;
        }

        /// <summary>
        ///     Transient objects are not associated with an item already in storage.  For instance,
        ///     a Customer is transient if its Id is 0.  It's virtual to allow NHibernate-backed 
        ///     objects to be lazily loaded.
        /// </summary>
        public virtual bool IsTransient()
        {
            if (this.Id == null && default(TIdentifier) == null)
            {
                return true;
            }
            return this.Id.Equals(default(TIdentifier));
        }

        #endregion Properties
    }
}