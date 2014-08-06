// -----------------------------------------------------------------------
// <copyright file="IDataTransferObject.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application.DataTransfer.Core
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Interfaz para representar los objetos de transferencia de datos para una entidad.
    /// </summary>
    /// <remarks>
    /// <para>
    /// La interfaz <c>IEntityDataTransferObject</c> permite representar
    /// los objetos de transferencia de datos para una entidad.
    /// </para>
    /// </remarks>
    public interface IBussinesEntityDataTransferObject : IDataTransferObject
    {
        #region Properties

        /// <summary>
        /// Propiedad que indica si la entidad representada está activa.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        bool Activo
        {
            get;
        }

        /// <summary>
        /// Obtiene el Id de la entidad representada por el dto.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        int Id
        {
            get;
        }

        /// <summary>
        /// Obtiene el valor que indica si la entidad representada por el dto ha sido persistida previamente o no.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        bool IsTransient
        {
            get;
        }

        #endregion Properties
    }
}