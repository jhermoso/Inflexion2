// -----------------------------------------------------------------------
// <copyright file="IDataTransferObject.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application.DataTransfer.Core
{
    /// <summary>
    /// Interfaz para representar los objetos de transferencia de datos.
    /// </summary>
    /// <remarks>
    /// <para>
    /// La interfaz <c>IDataTransferObject</c> permite representar
    /// los objetos de transferencia de datos.
    /// </para>
    /// </remarks>
    /// <example>
    /// Ejemplo de implementación de esta interfaz suponiendo la clase Dto
    /// <c>AmbitoDto</c> que la implementa:
    /// <code>
    ///   <![CDATA[
    ///
    /// using System;
    /// using System.Runtime.Serialization;
    ///
    /// /// <summary>
    /// /// Clase pública sellada que representa a la entidad <see cref="T:AmbitoDto"/>.
    /// /// </summary>
    /// /// <remarks>
    /// /// Sin comentarios especiales.
    /// /// </remarks>
    /// [DataContract]
    /// public sealed class AmbitoDto : Inflexion.Framework.Application.DataTransfer.Core.IDataTransferObject
    /// {
    ///
    ///     #region CONSTRUCTORS
    ///
    ///         /// <summary>
    ///         /// Inicializa una nueva instancia de la clase <see cref="T:AmbitoDto"/>.
    ///         /// </summary>
    ///         /// <remarks>
    ///         /// Sin comentarios especiales.
    ///         /// </remarks>
    ///         public AmbitoDto()
    ///         {
    ///         } // AmbitoDto Constructor
    ///
    ///     #endregion
    ///
    ///     #region PROPERTIES
    ///
    ///         /// <summary>
    ///         /// Propiedad pública que permite establecer y obtener el identificador del Dto.
    ///         /// </summary>
    ///         /// <remarks>
    ///         /// Sin comentarios especiales.
    ///         /// </remarks>
    ///         /// <value>
    ///         /// Valor que es utilizado para establecer y obtener el identificador del Dto.
    ///         /// </value>
    ///         [DataMember]
    ///         public int Id { get; set; }
    ///
    ///         /// <summary>
    ///         /// Propiedad pública que permite obtener ó
    ///         /// establecer la descripción del ámbito.
    ///         /// </summary>
    ///         /// <remarks>
    ///         /// Sin comentarios especiales.
    ///         /// </remarks>
    ///         /// <value>
    ///         /// Valor que es utilizado para establecer y obtener la descripción del ámbito.
    ///         /// </value>
    ///         [DataMember]
    ///         public string Descripcion { get; set; }
    ///
    ///         /// <summary>
    ///         /// Propiedad pública que permite obtener ó establecer
    ///         /// si un registro está activo o no.
    ///         /// </summary>
    ///         /// <remarks>
    ///         /// Sin comentarios especiales.
    ///         /// </remarks>
    ///         /// <value>
    ///         /// Valor que es utilizado para obtener ó
    ///         /// establecer si un registro está activo o no.
    ///         /// </value>
    ///         [DataMember]
    ///         public bool Activo { get; set; }
    ///
    ///     #endregion
    ///
    /// } // AmbitoDto
    ///
    ///   ]]>
    /// </code>
    /// </example>
    public interface IDataTransferObject
    {
    }
}