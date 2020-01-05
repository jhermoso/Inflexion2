// -----------------------------------------------------------------------
// <copyright file="IAuditableEntity.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;


    /// <summary>
    /// Interfaz para representar las entidades del negocio auditables.
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    /// <typeparam name="TEntity">
    /// <see cref="T:Inflexion2.Domain.IEntity{TIdentifier}" />
    /// </typeparam>
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
    [Serializable]
    public abstract class AuditableEntity<TEntity, TIdentifier> : ValidatableEntity<TEntity, TIdentifier>,
                                                                    IAuditableEntity<TIdentifier>,
                                                                    System.IEquatable<IEntity<TIdentifier>>,
                                                                    System.IComparable<IEntity<TIdentifier>>,
                                                                    System.IComparable
        where TEntity : AuditableEntity<TEntity, TIdentifier>, System.IEquatable<TEntity>, System.IComparable<TEntity>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Fields

        /// <summary>
        /// Variable encargada de almacenar la información
        /// de auditoría.
        /// </summary>
        /// <remarks>
        /// Para ello se utilizará el objeto valor <see cref="IAuditInfo"/>.
        /// </remarks>
        private IAuditInfo auditInfo;

        #endregion Fields

        #region Constructors

        ///// <summary>
        //// TODO: incorporar en la creación la inserción del auditinfo de creación.
        ///// Inicializa una nueva instancia de la clase <see cref="T:AuditableEntityBase"/>.
        ///// </summary>
        ///// <remarks>
        ///// Sin comentarios especiales.
        ///// </remarks>
        ///// <param name="id">
        ///// Parámetro que indica el identificador único de la entidad.
        ///// </param>
        //protected AuditableEntity(TIdentifier id)
        //{
        //    this.Id = id;
        //    this.IsActive = true;
        //}

        #endregion Constructors

        #region Properties

        ///// <summary>
        ///// Devuelve el tipo actual de la entidad, con independencia
        ///// del nivel en el que nos encontremos en la jerarquía de clases.
        ///// </summary>
        ///// <remarks>
        ///// El tipo real será utilizado como criterio principal
        ///// durante la igualdad y comparación entre entidades.
        ///// </remarks>
        ///// <value>
        ///// El tipo real (tipo <see cref="T:System.Type"/> hoja) de la
        ///// entidad.
        ///// </value>
        //public virtual System.Type ActualType
        //{
        //    get
        //    {
        //        return typeof(AuditableEntity<TEntity, TIdentifier>);
        //    }
        //}

        /// <summary>
        /// Propiedad que obtiene la información de auditoría.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor utilizado para obtener la información de auditoría.
        /// </value>
        public virtual IAuditInfo AuditInfo
        {
            get
            {
                return this.auditInfo;
            }
            protected set
            {
                this.auditInfo = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Método para auditar la eliminación de la entidad.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="updatedBy">
        /// Parámetro que indica el identificador único del usuario
        /// que modifica la entidad.
        /// </param>
        public virtual void AuditDelete(string updatedBy)
        {
            this.AuditUpdate(updatedBy);
        }

        /// <summary>
        /// Método para auditar la creación de la entidad.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="createdBy">
        /// Parámetro que indica el identificador único del usuario
        /// que modifica la entidad.
        /// </param>
        public virtual void AuditInsert(string createdBy)
        {
            // Creamos el objeto-valor AuditInfo.
            IAuditInfo auditInfoObject = AuditInfoFactory.Create(
                                             createdBy,
                                             null,
                                             System.DateTime.UtcNow,
                                             null);
            // Establecemos los datos de auditoría.
            this.AuditInfo = auditInfoObject;
        }

        /// <summary>
        /// Método para auditar la modificación de la entidad.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="updatedBy">
        /// Parámetro que indica el identificador único del usuario
        /// que modifica la entidad.
        /// </param>
        public virtual void AuditUpdate(string updatedBy)
        {
            // Creamos el objeto-valor AuditInfo.
            IAuditInfo auditInfoObject = AuditInfoFactory.Create(
                                             System.Convert.ToString(this.AuditInfo.CreatedBy),
                                             updatedBy,
                                             this.auditInfo.CreatedTimestamp,
                                             System.DateTime.UtcNow);
            // Establecemos los datos de auditoría.
            this.AuditInfo = auditInfoObject;
        }

        #endregion Methods
    }
}
