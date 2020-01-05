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
    public abstract class BaseValueObjectDataTransferObject :
                                            System.IComparable,
                                            System.IEquatable<BaseValueObjectDataTransferObject>,
                                            IDataTransferObject

    {

        #region System.IComparable


        /// <summary>
        /// System.IComparable implementation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion System.IComparable

        #region
        /// <summary>
        /// System.IComparable implementation
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(BaseValueObjectDataTransferObject other)
        {
            if (other == null) return false;

            return base.Equals(other);
        }
        #endregion

        #region IClonable Implementation

        /// <summary>
        /// Dto clone implementation to help the implementation of IEditableObject in View Models
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}