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
                                            System.IEquatable<BaseValueObjectDataTransferObject>

    {
        #region System.IComparable

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion System.IComparable

        #region
        public bool Equals(BaseValueObjectDataTransferObject other)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}