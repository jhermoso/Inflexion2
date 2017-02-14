// -----------------------------------------------------------------------
// <copyright file="IEntity.cs" company="Inflexion Software">
//     Copyright (c) 2014. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    /// <summary>
    /// .es Interfaz para representar una entidad basica siguiendo la defenición de Eric Evans.
    /// Las entidades estan pensadas para que tengan 2 factorias estaticas con la responsabilidad de crear la propia entidad.
    /// Una primera factoria sin parametros para cuando se hace cqrs y podemos guardar con 
    /// .en Interface for basic entity from Eric Evans definition.
    /// </summary>
    /// <remarks>
    /// .ee La interfaz <c>IEntity</c> representa una entidad basica.
    /// .en The interface <c>IEntity</c> represents a basic entity.
    /// </remarks>
    /// <typeparam name="TIdentifier">
    /// Representación del tipo del identificador de la entidad.
    /// Representation of Entity's type.
    /// </typeparam>
    public interface IEntity<TIdentifier> : System.IComparable,
                                            System.IEquatable<IEntity<TIdentifier>>, 
                                            System.IComparable<IEntity<TIdentifier>>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Properties

        /// <summary>
        /// .es Devuelve el identificador único de la entidad.
        /// .en Get unic entity's identification
        /// </summary>
        /// <remarks>
        /// .es El valor del identificador único será utilizado como criterio
        /// principal durante la igualdad y comparación entre entidades.
        /// .en identity's value is the only criteria to compare two entities.
        /// </remarks>
        /// <value>
        /// <para>
        /// .es Identificador único de la entidad.
        /// .en Unic Entity's Identifier
        /// </para>
        /// <para>
        /// .es TIdentifier representa el tipo de datos del identificador único de
        /// la entidad.
        /// .en TIdentifier represents identity's type used to identify an entity.
        /// </para>
        /// </value>
        TIdentifier Id
        {
            get;
        }

        #endregion

        #region methods

        /// <summary>
        ///     Derived from Sharp Arch
        ///     Transient objects are not associated with an item already in storage.  For instance,
        ///     a Customer is transient if its Id is defalut value.  It's virtual to allow NHibernate-backed 
        ///     objects to be lazily loaded.
        /// </summary>
        bool IsTransient();

        #endregion
    }
}