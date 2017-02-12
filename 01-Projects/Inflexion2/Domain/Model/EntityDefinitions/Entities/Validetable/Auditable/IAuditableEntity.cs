// -----------------------------------------------------------------------
// <copyright file="IAuditableEntity.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    /// <summary>
    /// Interfaz para representar las entidades del negocio auditables.
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    /// <typeparam name="TIdentifier">
    /// Representación del tipo del identificador de la entidad.
    /// </typeparam>
    /// <example>
    /// Ejemplo de implementación de esta interfaz suponiendo la interfaz
    /// <c>IAmbito</c> que la implementa:
    /// <code>
    ///   <![CDATA[
    ///
    /// using System;
    ///
    /// /// <summary>
    /// /// Interfaz que identifica una entidad de tipo Ámbito
    /// /// dentro de la aplicación.
    /// /// </summary>
    /// /// <remarks>
    /// /// Sin comentarios especiales.
    /// /// </remarks>
    /// public interface IAmbito : Inflexion2.Domain.IAuditableEntity<int>
    /// {
    ///
    ///     #region PROPERTIES
    ///
    ///         /// <summary>
    ///         /// Propiedad pública que permite obtener la descripción del ámbito.
    ///         /// </summary>
    ///         /// <remarks>
    ///         /// Sin comentarios especiales.
    ///         /// </remarks>
    ///         /// <value>
    ///         /// Valor que es utilizado para obtener la descripción del ámbito.
    ///         /// </value>
    ///         string Descripcion { get; }
    ///
    ///     #endregion
    ///
    ///     #region MEMBERS
    ///
    ///         /// <summary>
    ///         /// Método encargada del borrado lógico de la entidad.
    ///         /// </summary>
    ///         /// <remarks>
    ///         /// Modifica el valor la propiedad Activo a <c>false</c>.
    ///         /// </remarks>
    ///         void Disable();
    ///
    ///         /// <summary>
    ///         /// Método encargada de establecer la descripción
    ///         /// de la entidad ámbito.
    ///         /// </summary>
    ///         /// <remarks>
    ///         /// Sin comentarios especiales.
    ///         /// </remarks>
    ///         /// <param name="description">
    ///         /// Parámetro que indica la descripción del ámbito.
    ///         /// </param>
    ///         /// <exception cref="System.ArgumentNullException">
    ///         /// Lanzada cuando el valor del parámetro <c>description</c> es cadena vacía.
    ///         /// </exception>
    ///         void SetDescripcion(string description);
    ///
    ///     #endregion
    ///
    /// } // IAmbito
    ///
    ///   ]]>
    /// </code>
    /// </example>
    public interface IAuditableEntity<TIdentifier> : IEntity<TIdentifier>, 
                                                                Inflexion2.Domain.Validation.IValidatable, 
                                                                System.IEquatable<IEntity<TIdentifier>>, 
                                                                System.IComparable<IEntity<TIdentifier>>, 
                                                                System.IComparable
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Properties

        /// <summary>
        /// Propiedad que obtiene la información de auditoría.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor utilizado para obtener la información de auditoría.
        /// </value>
        IAuditInfo AuditInfo
        {
            get;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Método para auditar la eliminación de una entidad existente.
        /// </summary>
        /// <param name="updatedBy">
        /// Parámetro que indica el identificador único del usuario
        /// que elimina la entidad.
        /// </param>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        void AuditDelete(string updatedBy);

        /// <summary>
        /// Método para auditar la creación de una nueva entidad.
        /// </summary>
        /// <param name="createdBy">
        /// Parámetro que indica el identificador único del usuario
        /// que crea la nueva entidad.
        /// </param>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        void AuditInsert(string createdBy);

        /// <summary>
        /// Método para auditar la modificación de una entidad existente.
        /// </summary>
        /// <param name="updatedBy">
        /// Parámetro que indica el identificador único del usuario
        /// que modifica la entidad.
        /// </param>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        void AuditUpdate(string updatedBy);

        #endregion Methods
    }
}