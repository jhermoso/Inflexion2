// -----------------------------------------------------------------------
// <copyright file="IEntity.cs" company="Inflexion Software">
//     Copyright (c) 2014. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;

    /// <summary>
    /// Interfaz para representar las entidades del negocio.
    /// </summary>
    /// <remarks>
    /// La interfaz <c>IEntity</c> representa una entidad de negocio.
    /// </remarks>
    /// <typeparam name="TIdentifier">
    /// Representación del tipo del identificador de la entidad.
    /// </typeparam>
    public interface IBusinessEntity<TIdentifier> : IAuditableEntity<TIdentifier>, 
                                                    System.IEquatable<IEntity<TIdentifier>>, 
                                                    System.IComparable<IEntity<TIdentifier>>, 
                                                    System.IComparable
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Properties

        /// <summary>
        /// Devuelve el tipo actual de la entidad, con independencia
        /// del nivel en el que nos encontremos en la jerarquía de clases.
        /// </summary>
        /// <value>
        /// El tipo real (tipo <see cref="T:System.Type"/> hoja) de la
        /// entidad.
        /// </value>
        /// <remarks>
        /// El tipo real será utilizado como criterio principal
        /// durante la igualdad y comparación entre entidades.
        /// </remarks>
        System.Type ActualType
        {
            get;
        }

        /// <summary>
        /// Propiedad que indica si la entidad está activa.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para indicar si la entidad
        /// está o no activa.
        /// </value>
        bool IsActive
        {
            get;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Método encargado del borrado lógico de la entidad.
        /// </summary>
        /// <remarks>
        /// Modifica el valor la propiedad IsActive a <c>False</c>.
        /// </remarks>
        void Disable();

        /// <summary>
        /// Método encargada del activar ó habilitar una entidad.
        /// </summary>
        /// <remarks>
        /// Modifica el valor la propiedad IsActive a <c>True</c>.
        /// </remarks>
        void Enable();

        #endregion Methods
    }
}
