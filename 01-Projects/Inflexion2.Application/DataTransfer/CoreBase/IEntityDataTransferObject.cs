// -----------------------------------------------------------------------
// <copyright file="IDataTransferObject.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application
{
    using Inflexion2;
    using System.Runtime.Serialization;

    /// <summary>
    /// .es Interfaz para representar los objetos de transferencia de datos para una entidad.
    /// </summary>
    /// <remarks>
    /// <para>
    /// La interfaz <c>IEntityDataTransferObject</c> permite representar
    /// los objetos de transferencia de datos para una entidad.
    /// </para>
    /// </remarks>
    public interface IEntityDataTransferObject<TIdentifier> : IDataTransferObject,
                                            System.IComparable,
                                            System.IEquatable<TIdentifier>,
                                            System.IComparable<TIdentifier>
    where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Properties

        /// <summary>
        /// .es Obtiene el Id de la entidad representada por el dto.
        /// </summary>
        TIdentifier Id
        {
            get;
        }

        #endregion Properties
    }
}