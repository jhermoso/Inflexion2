// -----------------------------------------------------------------------
// <copyright file="IDataTransferObject.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application
{
    using System.Runtime.Serialization;
    using Inflexion2;

    /// <summary>
    /// Clase base para los objetos DTO que representan entidades persistidas.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [DataContract]
    public abstract class BaseBussinesEntityDataTransferObject<TIdentifier> : IEntityDataTransferObject<TIdentifier>
                where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Properties

        /// <summary>
        /// Propiedad que indica si la entidad representada está activa.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para indicar si la entidad representado está activa.
        /// </value>
        [DataMember]
        public bool Activo
        {
            get;
            set;
        }

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
        /// Propiedad que obtiene el valor que indica si la entidad representada
        /// por el DTO ha sido persistida previamente o no.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtenerel valor que indica si la entidad representada
        /// por el DTO ha sido persistida previamente o no.
        /// </value>
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