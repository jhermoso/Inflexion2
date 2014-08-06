// -----------------------------------------------------------------------
// <copyright file="IService.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application.Core
{
    /// <summary>
    /// Interfaz para marcar los servicios de aplicación.
    /// </summary>
    /// <remarks>
    /// <para>
    /// La interfaz <c>IServicio</c> permite marcar los servicios de aplicación.
    /// </para>
    /// </remarks>
    /// <example>
    /// Ejemplo de implementación de esta interfaz suponiendo la interfaz
    /// <c>ICreateAmbito</c> que la implementa:
    /// <code>
    ///   <![CDATA[
    ///
    /// using Inflexion.Framework.Application.Security.Data.Base;
    ///
    /// /// <summary>
    /// /// Interfaz que permite definir las acciones del servicio de creación de
    /// /// una entidad de tipo <see cref="Inflexion.Suite.Foo.BoundedContext.Domain.Core.IAmbito"/>.
    /// /// </summary>
    /// /// <remarks>
    /// /// Representa una interfaz de la entidad a utilizar en el servicio de aplicación.
    /// /// </remarks>
    /// public interface ICreateAmbito : Inflexion.Framework.Application.Core.IService
    /// {
    ///
    ///     #region FUNCTIONS
    ///
    ///         /// <summary>
    ///         /// Función encargada de la creación de una entidad de tipo ámbito.
    ///         /// </summary>
    ///         /// <remarks>
    ///         /// Sin comentarios especiales.
    ///         /// </remarks>
    ///         /// <param name="description">
    ///         /// Parámetro que indica la descripción del ámbito.
    ///         /// </param>
    ///         /// <param name="userContextDto">
    ///         /// Parámetro de tipo <see cref="Inflexion.Framework.Application.Security.Data.Base.UserContextDto"/>
    ///         /// que representa el contexto del usuario de la parte cliente.
    ///         /// </param>
    ///         /// <exception cref="System.ArgumentNullException">
    ///         /// Lanzada cuando el valor del parámetro de entrada <c>userContextDto</c>
    ///         /// es <c>null</c>.
    ///         /// </exception>
    ///         /// <returns>
    ///         /// Devuelve el identificador único de la entidad creada.
    ///         /// </returns>
    ///         int Execute(
    ///                     string description,
    ///                     UserContextDto userContextDto);
    ///
    ///     #endregion
    ///
    /// } // ICreateAmbito
    ///
    ///   ]]>
    /// </code>
    /// </example>
    /// <example>
    /// Ejemplo de implementación de esta interfaz suponiendo la interfaz
    /// <c>IDeleteAmbito</c> que la implementa:
    /// <code>
    ///   <![CDATA[
    ///
    /// using Inflexion.Framework.Application.Security.Data.Base;
    ///
    /// /// <summary>
    /// /// Interfaz que permite definir las acciones del servicio de borrado de
    /// /// una entidad de tipo <see cref="Inflexion.Suite.Foo.BoundedContext.Domain.Core.IAmbito"/>.
    /// /// </summary>
    /// /// <remarks>
    /// /// Sin comentarios especiales.
    /// /// </remarks>
    /// public interface IDeleteAmbito : Inflexion.Framework.Application.Core.IService
    /// {
    ///
    ///     #region FUNCTIONS
    ///
    ///         /// <summary>
    ///         /// Función encargada de la eliminación de una entidad
    ///         /// de tipo <see cref="Inflexion.Suite.Foo.BoundedContext.Domain.Core.IAmbito"/>.
    ///         /// </summary>
    ///         /// <remarks>
    ///         /// Se realizará un borrado lógico de la entidad.
    ///         /// </remarks>
    ///         /// <param name="ambitoId">
    ///         /// Parámetro que indica el identificador único del
    ///         /// ámbito a eliminar.
    ///         /// </param>
    ///         /// <param name="userContextDto">
    ///         /// Parámetro de tipo <see cref="UserContextDto"/> que representa
    ///         /// el contexto del usuario de la parte cliente.
    ///         /// </param>
    ///         /// <exception cref="System.ArgumentNullException">
    ///         /// Lanzada cuando el valor del parámetro <c>userContextDto</c> es null.
    ///         /// </exception>
    ///         /// <returns>
    ///         /// Devuelve <b>true</b> si la eliminación ha sido correcta y
    ///         /// <b>false</b> en caso contrario.
    ///         /// </returns>
    ///         bool Execute(
    ///                      int ambitoId,
    ///                      UserContextDto userContextDto);
    ///
    ///     #endregion
    ///
    /// } // IDeleteAmbito
    ///
    ///   ]]>
    /// </code>
    /// </example>
    /// <example>
    /// Ejemplo de implementación de esta interfaz suponiendo la interfaz
    /// <c>IUpdateAmbito</c> que la implementa:
    /// <code>
    ///   <![CDATA[
    ///
    /// using System;
    /// using System.Collections.Generic;
    ///
    /// using Inflexion.Framework.Application.Security.Data.Base;
    ///
    /// using Inflexion.Suite.Foo.BoundedContext.Application.Data.Base;
    ///
    /// /// <summary>
    /// /// Interfaz que permite definir las acciones del servicio de actualización
    /// /// de la entidad de tipo
    /// /// <see cref="Inflexion.Suite.Foo.BoundedContext.Domain.Core.IAmbito"/>.
    /// /// </summary>
    /// /// <remarks>
    /// /// Sin comentarios especiales.
    /// /// </remarks>
    /// public interface IUpdateAmbito : Inflexion.Framework.Application.Core.IService
    /// {
    ///
    ///     #region FUNCTIONS
    ///
    ///         /// <summary>
    ///         /// Función encargada de la actualizacón de una entidad de tipo
    ///         /// de tipo <see cref="Inflexion.Suite.Foo.BoundedContext.Domain.Core.IAmbito"/>.
    ///         /// </summary>
    ///         /// <remarks>
    ///         /// Se realizará una actualización de la entidad.
    ///         /// </remarks>
    ///         /// <param name="ambitoDto">
    ///         /// Parámetro de tipo <see cref="AmbitoDto"/>que representa el DTO
    ///         /// de la entidad Ambito.
    ///         /// </param>
    ///         /// <param name="userContextDto">
    ///         /// Parámetro de tipo <see cref="UserContextDto"/> que representa
    ///         /// el contexto del usuario de la parte cliente.
    ///         /// </param>
    ///         /// <exception cref="System.ArgumentNullException">
    ///         /// Lanzada cuando alguno de los parámetros de entrada sea <c>null</c>.
    ///         /// </exception>
    ///         /// <returns>
    ///         /// Devuelve <b>true</b> si la eliminación ha sido correcta y
    ///         /// <b>false</b> en caso contrario.
    ///         /// </returns>
    ///         bool Execute(
    ///                      AmbitoDto ambitoDto,
    ///                      UserContextDto userContextDto);
    ///
    ///     #endregion
    ///
    /// } // IUpdateAmbito
    ///
    ///   ]]>
    /// </code>
    /// </example>
    public interface IService
    {
    }
}