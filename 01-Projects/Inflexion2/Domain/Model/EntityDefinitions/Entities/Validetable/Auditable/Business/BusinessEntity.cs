// -----------------------------------------------------------------------
// <copyright file="IAuditableEntity.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using Inflexion2.Domain.Validation;


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdentifier"></typeparam>
    [Serializable]
    public abstract class BusinessEntity<TEntity, TIdentifier> :   AuditableEntity<TEntity, TIdentifier>, 
                                                                    IBusinessEntity<TIdentifier>, 
                                                                    System.IEquatable<IEntity<TIdentifier>>, 
                                                                    System.IComparable<IEntity<TIdentifier>>, 
                                                                    System.IComparable
        where TEntity : BusinessEntity<TEntity, TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Fields

        /// <summary>
        /// Variable privada de propiedad para indicar
        /// si la entidad está activa ó habilitada.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        private bool isActive;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// TODO: INCORPORAR EL AUDITINFO ENLOS CONSTRUCTORES Y DESTRUCTORES
        /// Inicializa una nueva instancia de la clase <see cref="T:AuditableEntityBase"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <param name="id">
        /// Parámetro que indica el identificador único de la entidad.
        /// </param>
        protected BusinessEntity(TIdentifier id)
        {
            this.Id = id;
            this.IsActive = true;
        }

        /// <summary>
        /// 
        /// </summary>
        protected BusinessEntity()
        {
            this.IsActive = true;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Devuelve el tipo actual de la entidad, con independencia
        /// del nivel en el que nos encontremos en la jerarquía de clases.
        /// </summary>
        /// <remarks>
        /// El tipo real será utilizado como criterio principal
        /// durante la igualdad y comparación entre entidades.
        /// </remarks>
        /// <value>
        /// El tipo real (tipo <see cref="T:System.Type"/> hoja) de la
        /// entidad.
        /// </value>
        public virtual System.Type ActualType
        {
            get
            {
                return typeof(AuditableEntity<TEntity, TIdentifier>);
            }
        }


        /// <summary>
        /// Propiedad pública que indica
        /// si la entidad está activa.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para indicar si la entidad
        /// está o no activa.
        /// </value>
        public virtual bool IsActive
        {
            get
            {
                return this.isActive;
            }
            protected set
            {
                this.isActive = value;
            }
        }



        #endregion Properties

        #region Methods

        /// <summary>
        /// Método encargado del borrado lógico de la entidad.
        /// </summary>
        /// <remarks>
        /// Borrado lógico de la entidad.
        /// </remarks>
        public virtual void Disable()
        {
            if (this.IsActive)
            {
                this.IsActive = false;
            }
        }

        /// <summary>
        /// Método encargada del activar ó habilitar una entidad.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        public virtual void Enable()
        {
            if (!this.IsActive)
            {
                this.IsActive = true;
            }
        }

        #endregion Methods
    }
}