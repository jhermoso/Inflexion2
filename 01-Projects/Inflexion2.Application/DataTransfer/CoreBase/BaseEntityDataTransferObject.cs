// -----------------------------------------------------------------------
// <copyright file="IDataTransferObject.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Clase base para los objetos DTO que representan entidades persistidas.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [DataContract]
    public abstract class BaseEntityDataTransferObject<TIdentifier> : IEntityDataTransferObject<TIdentifier> , 
                                            System.IComparable,
                                            System.IEquatable<BaseEntityDataTransferObject<TIdentifier>>,
                                            System.IComparable<TIdentifier>
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
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            //TODO Change this for preconditions
            //check the argument is not null
            // Comprobamos que el elemento no es nulo.
            if (obj == null)
            {
                throw new System.ArgumentNullException("obj");
            }
            else
            {
                // Realizamos el cast del argumento.
                var otherDTO = obj as IEntityDataTransferObject<TIdentifier>;
                if (otherDTO == null)
                {
                    throw new System.ArgumentNullException("obj");
                }
                else
                {
                    return this.CompareTo(otherDTO);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(TIdentifier otherId)
        {
            return this.CompareTo(otherId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual int CompareTo(IEntityDataTransferObject<TIdentifier> dto)
        {
            if (dto == null)
            {
                throw new System.ArgumentNullException("entityIdentifier");
            }
            else
            {
                // Use the id property like a criteria for default sorting
                // Utilizamos el identificador único como criterio principal de ordenación.
                return this.Id.CompareTo(dto.Id);
            }
        }

        /// <summary>
        /// Use the id property like a criteria for default sorting
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(BaseEntityDataTransferObject<TIdentifier> other)
        {
           if (other == null)
            {
                throw new System.ArgumentNullException("entityIdentifier");
            }
           else
            {
                return this.Id.Equals(other.Id);
            }

        }

        /// <summary>
        /// for the DTOs of entities we use the Id value like a criteria to compare and check the equality
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(TIdentifier other)
        {
            return base.Equals(other);
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