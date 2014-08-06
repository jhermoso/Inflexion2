// ---------------------------------------------------------------
// <copyright file="EntityBase.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// ---------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Clase pública abstracta para representar las entidades del negocio.
    /// </summary>
    /// <remarks>
    /// La clase abstracta <see cref="Entity{TIdentifier}"/> representa una clase base de tipo
    /// entidad de negocio.
    /// </remarks>
    /// <typeparam name="TEntity">
    /// Tipo genérico para representar el propio tipo del identificador.
    /// su inclusión se justifica para facilitar las operaciones de reflexión, 
    /// concretamente para facilitar la construción del metodo CanDelete del AgregateRoot.
    /// </typeparam>
    /// <typeparam name="TIdentifier">
    /// Tipo genérico para representar el tipo de identificador de las
    /// entidades y que es necesario para los repositorios.
    /// </typeparam>
    /// <seealso cref="T:Inflexion2.Domain.IEntity{TIdentifier}" />
    [Serializable]
    public abstract class Entity<TEntity, TIdentifier> : IEntity< TIdentifier>
        where TEntity : IEntity<TIdentifier>
        where TIdentifier :  System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Constants

        /// <summary>
        ///     To help ensure hashcode uniqueness, a carefully selected random number multiplier 
        ///     is used within the calculation.  Goodrich and Tamassia's Data Structures and
        ///     Algorithms in Java asserts that 31, 33, 37, 39 and 41 will produce the fewest number
        ///     of collissions.  See http://computinglife.wordpress.com/2008/11/20/why-do-hash-functions-use-prime-numbers/
        ///     for more information.
        /// </summary>
        private const int HASH_MULTIPLIER = 31;

        #endregion

        #region Fields

        /// <summary>
        /// Identificador único de la entidad.
        /// </summary>
        /// <remarks>
        /// Este campo o variable se utiliza conjuntamente con la propiedad
        /// <see cref="Id"/>.
        /// </remarks>
        private TIdentifier id;

        /// <summary>
        /// Derived from Hexacore
        /// 
        /// </summary>
        private int? cachedHashcode;

        /// <summary>
        ///     This static member caches the domain signature properties to avoid looking them up for 
        ///     each instance of the same type.
        /// 
        ///     A description of the very slick ThreadStatic attribute may be found at 
        ///     http://www.dotnetjunkies.com/WebLog/chris.taylor/archive/2005/08/18/132026.aspx
        /// </summary>
        [ThreadStatic]
        private static Dictionary<Type, IEnumerable<PropertyInfo>> signaturePropertiesDictionary;

        #endregion

        #region Properties

        /// <summary>
        /// Devuelve el identificador único de la entidad.
        /// </summary>
        /// <value>
        /// Identificador único de la entidad.
        /// </value>
        /// <remarks>
        /// <para>
        /// El valor del identificador único será utilizado como
        /// criterio principal durante la igualdad y comparación entre
        /// entidades.
        /// </para>
        /// <para>
        /// TIdentifier Representa el tipo de datos del identificador único
        /// de la entidad.
        /// </para>
        /// </remarks>
        public virtual TIdentifier Id
        {
            get
            {
                return this.id;
            }
            protected set
            {
                this.id = value;
            }
        }

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
                return typeof(Entity<TEntity, TIdentifier>);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <remarks>
        /// El constructor nos permite crear una entidad de acuerdo al
        /// identificador único.
        /// </remarks>
        /// <param name="id">
        /// Identificador unívoco de la entidad.
        /// </param>
        protected Entity(TIdentifier id):base()
        {
            this.Id = id;
        }

        /// <summary>
        /// Constructor vacio de la clase.
        /// </summary>
        /// <remarks>
        /// El constructor nos permite crear una entidad de acuerdo al
        /// identificador único.
        /// </remarks>
        protected Entity()
        {

        }

        #endregion Constructors

        #region methods

        /// <summary>
        /// Define la función encargada de comparar u ordenar objetos.
        /// </summary>
        /// <remarks>
        /// Compara el identificador único de dos entidades para saber si
        /// son iguales o no.
        /// </remarks>
        /// <param name="element">
        /// Parámetro que hace referencia al elemento a comparar.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Lanzada cuando el valor del argumento <c>element</c> es null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Lanzada cuando el valor de la variable <c>otherEntity</c> es null.
        /// </exception>
        /// <returns>
        /// Devuelve un entero que indica si la comparación es correcta o no.
        /// </returns>
        public virtual int CompareTo(object element)
        {
            // Comprobamos que el elemento no es nulo.
            if (element == null)
            {
                throw new System.ArgumentNullException("element");
            }
            else
            {
                // Realizamos el cast del argumento.
                var otherEntity = element as IEntity<TIdentifier>;
                if (otherEntity == null)
                {
                    throw new System.ArgumentNullException("element");
                }
                else
                {
                    return this.CompareTo(otherEntity);
                }
            }
        }

        /// <summary>
        /// Define la función encargada de comparar u ordenar objetos.
        /// </summary>
        /// <remarks>
        /// Compara el identificador único de dos entidades para saber si
        /// son iguales o no.
        /// </remarks>
        /// <param name="entityIdentifier">
        /// Parámetro que hace referencia al identificador a comparar.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Lanzada cuando el valor del argumento <c>entityIdentifier</c> es null.
        /// </exception>
        /// <returns>
        /// Devuelve un entero que indica si la comparación es correcta o no.
        /// </returns>
        public virtual int CompareTo(IEntity<TIdentifier> entityIdentifier)
        {
            if (entityIdentifier == null)
            {
                throw new System.ArgumentNullException("entityIdentifier");
            }
            else
            {
                // Utilizamos el identificador único como criterio principal de ordenación.
                int resultado = this.Id.CompareTo(entityIdentifier.Id);
                // Devolvemos el resultado.
                return resultado;
            }
        }

        /// <summary>
        /// Define la función encargada de comparar u ordenar objetos.
        /// </summary>
        /// <remarks>
        /// Compara el identificador de dos entidades base para saber si
        /// son iguales o no.
        /// </remarks>
        /// <param name="entityIdentifier">Indica el otro objeto con el cual comparar.</param>
        /// <returns>Devuelve un entero que indica si la comparación es correcta o no.</returns>
        public virtual int CompareTo(Entity<TEntity, TIdentifier> entityIdentifier)
        {
            return this.CompareTo(entityIdentifier as IEntity<TIdentifier>);
        }

        /// <summary>
        /// Define la función encargada de comparar u ordenar objetos.
        /// </summary>
        /// <remarks>
        /// Compara el identificador de dos entidades base para saber si
        /// son iguales o no.
        /// </remarks>
        /// <param name="entity">Indica el otro objeto con el cual comparar.</param>
        /// <returns>Devuelve un entero que indica si la comparación es correcta o no.</returns>
        public virtual int CompareTo(TEntity entity)
        {
            return this.CompareTo(entity as IEntity<TIdentifier>);
        }

        /// <summary>
        ///     Transient objects are not associated with an item already in storage.  For instance,
        ///     a Customer is transient if its Id is 0.  It's virtual to allow NHibernate-backed 
        ///     objects to be lazily loaded.
        /// </summary>
        public virtual bool IsTransient()
        {
            if (this.id==null && default(TIdentifier) == null)
            { 
                return true; 
            }
            return this.id.Equals(default(TIdentifier)); 
        }

        /// <summary>
        /// Equalses the specified compare to.
        /// </summary>
        /// <param name="other">The compare to.</param>
        /// <returns></returns>
        public virtual bool Equals(TEntity other)
        {
            return base.Equals(other);
        }

        /// <summary>
        /// Equalses the specified compare to.
        /// </summary>
        /// <param name="other">The compare to.</param>
        /// <returns></returns>
        public virtual bool Equals(IEntity<TIdentifier> other)
        {
            return this.Equals(other as IEntity<TIdentifier>);
        }
        
        /// 
        /// Equalses the specified compare to.
        /// </summary>
        /// <param name="other">The compare to.</param>
        /// <returns></returns>
        public virtual bool Equals(Entity<TEntity, TIdentifier> other)
        {
            return base.Equals(other);
        }
        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<TEntity, TIdentifier>;

            if (object.ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (compareTo == null || compareTo is Entity<TEntity, TIdentifier> == false)
            {
                return false;
            }

            if (this.IsTransient())
            {
                return false;
            }

            return HasSameNonDefaultIdAs(compareTo);

            // Since the Ids aren't the same, both of them must be transient to
            // compare domain signatures; because if one is transient and the
            // other is a persisted entity, then they cannot be the same object.
            //return this.IsTransient() && compareTo.IsTransient();
        }

        /// <summary>
        /// This is used to provide the hashcode identifier of an object using the signature
        /// properties of the object; although it's necessary for NHibernate's use, this can
        /// also be useful for business logic purposes and has been included in this base
        /// class, accordingly.  Since it is recommended that GetHashCode change infrequently,
        /// if at all, in an object's lifetime, it's important that properties are carefully
        /// selected which truly represent the signature of an object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // Once we have a hash code we'll never change it
            if (this.cachedHashcode.HasValue)
            {
                return this.cachedHashcode.Value;
            }

            if (IsTransient())
            {
                this.cachedHashcode = base.GetHashCode();
            }
            else
            {
                unchecked
                {
                    //var signatureProperties = this.GetSignatureProperties();  // opcion 2 from SharpArchitecure                  

                    // It's possible for two objects to return the same hash code based on
                    // identically valued properties, even if they're of two different types,
                    // so we include the object's type in the hash calculation
                    int hashCode = this.GetType().GetHashCode();

                    // opcion 1 from hexacore selected
                    this.cachedHashcode = (hashCode * HASH_MULTIPLIER) ^ this.Id.GetHashCode();
                    // opcion 2 from SharpArchitecure

                    //this.cachedHashcode = signatureProperties.Select(property => property.GetValue(this, null))
                    //                          .Where(value => value != null)
                    //                          .Aggregate(hashCode, (current, value) => (current * HASH_MULTIPLIER) ^ value.GetHashCode());

                //if (signatureProperties.Any())
                //{
                //    return hashCode;
                //}

                }
            }

            return cachedHashcode.Value;
        }

        /// <summary>
        /// Init the signaturePropertiesDictionary here due to reasons described at 
        /// http://blogs.msdn.com/jfoscoding/archive/2006/07/18/670497.aspx
        /// </summary>
        public virtual IEnumerable<PropertyInfo> GetSignatureProperties()
        {
            IEnumerable<PropertyInfo> properties;


            if (signaturePropertiesDictionary == null)
            {
                signaturePropertiesDictionary = new Dictionary<Type, IEnumerable<PropertyInfo>>();
            }

            if (signaturePropertiesDictionary.TryGetValue(this.GetType(), out properties))
            {
                return properties;
            }

            return signaturePropertiesDictionary[this.GetType()] = this.GetTypeSpecificSignatureProperties();
        }



        /// <summary>
        ///     When NHibernate proxies objects, it masks the type of the actual entity object.
        ///     This wrapper burrows into the proxied object to get its actual type.
        /// 
        ///     Although this assumes NHibernate is being used, it doesn't require any NHibernate
        ///     related dependencies and has no bad side effects if NHibernate isn't being used.
        /// 
        ///     Related discussion is at http://groups.google.com/group/sharp-architecture/browse_thread/thread/ddd05f9baede023a ...thanks Jay Oliver!
        /// </summary>
        protected virtual Type GetTypeUnproxied()
        {
            return this.GetType();
        }

        /// <summary>
        /// derived from Hexacore
        /// Returns true if self and the provided entity have the same Id values
        /// and the Ids are not of the default Id value
        /// </summary>
        private bool HasSameNonDefaultIdAs(Entity<TEntity, TIdentifier> compareTo)
        {
            return !this.IsTransient() &&
                   !compareTo.IsTransient() &&
                   this.Id.Equals(compareTo.Id);
        }

        /// <summary>
        ///     The property getter for SignatureProperties should ONLY compare the properties which make up 
        ///     the "domain signature" of the object.
        /// 
        ///     If you choose NOT to override this method (which will be the most common scenario), 
        ///     then you should decorate the appropriate property(s) with [DomainSignature] and they 
        ///     will be compared automatically.  This is the preferred method of managing the domain
        ///     signature of entity objects.
        /// </summary>
        /// <remarks>
        ///     This ensures that the entity has at least one property decorated with the 
        ///     [DomainSignature] attribute.
        /// </remarks>
        protected virtual IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties()
        {
            return
                this.GetType().GetProperties().Where(
                    p => Attribute.IsDefined(p, typeof(DomainSignatureAttribute), true));
        }

        #endregion
    }
}