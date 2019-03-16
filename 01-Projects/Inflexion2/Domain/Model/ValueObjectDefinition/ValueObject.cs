﻿namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Provides a standard base class for facilitating comparison of value objects using all the object's fields.
    /// </summary>
    /// <typeparam name="TValueObject"></typeparam>
    /// <remarks>
    /// For a discussion of the implementation of Equals/GetHashCode, see
    /// http://devlicio.us/blogs/billy_mccafferty/archive/2007/04/25/using-equals-gethashcode-effectively.aspx
    /// and http://groups.google.com/group/sharp-architecture/browse_thread/thread/f76d1678e68e3ece?hl=en for
    /// an in depth and conclusive resolution.
    /// </remarks>
    [Serializable]
    public abstract class ValueObject<TValueObject> : IValueObject, IEquatable<TValueObject>
        where TValueObject :class, IValueObject
    {
        /// <summary>
        /// Flags used to reflect over Generic Equeatable
        /// </summary>
        protected BindingFlags reflectingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        /// <summary>
        /// To help ensure hashcode uniqueness, a carefully selected random number multiplier
        /// is used within the calculation.  Goodrich and Tamassia's Data Structures and
        /// Algorithms in Java asserts that 31, 33, 37, 39 and 41 will produce the fewest number
        /// of collissions.  See http://computinglife.wordpress.com/2008/11/20/why-do-hash-functions-use-prime-numbers/
        /// for more information.
        /// </summary>
        private const int HASH_MULTIPLIER = 31;


        /// <summary>
        /// implementation of iequality interface, DEfinition of distinct operator
        /// </summary>
        /// <param name="x">first value object to check</param>
        /// <param name="y">second value object to check</param>
        /// <returns></returns>
        public static bool operator !=(ValueObject<TValueObject> x, ValueObject<TValueObject> y)
        {
            return !Equals(x, y);
        }


        /// <summary>
        /// implementation of iequality interface, Definition of equality operator
        /// </summary>
        /// <param name="x">first value object to check</param>
        /// <param name="y">second value object to check</param>
        /// <returns></returns>
        public static bool operator ==(ValueObject<TValueObject> x, ValueObject<TValueObject> y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        public virtual bool Equals(TValueObject other)
        {
            if (other == null)
            {
                return false;
            }

            Type t = GetType();
            Type otherType = other.GetType();

            if (t != otherType)
            {
                return false;
            }

            foreach (FieldInfo field in this.GetFields(this))
            {
                object value1 = field.GetValue(other);
                object value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                    {
                        return false;
                    }
                }
                else if (!value1.Equals(value2))
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Equalses the specified compare to.
        /// </summary>
        /// <param name="other">The compare to.</param>
        /// <returns></returns>
        public virtual bool Equals(IValueObject other)
        {
            return this.Equals(other as TValueObject);
        }

        /// <summary>
        /// Equalses the specified compare to.
        /// </summary>
        /// <param name="other">The compare to.</param>
        /// <returns></returns>
        public virtual bool Equals(ValueObject<TValueObject> other)
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
            //var other = (obj)T; // esta sentencia nos obliga a imponer una restricción en la que T ha de ser una clase

            if (obj == null)
            {
                return false;
            }

            Type t = GetType();
            Type otherType = obj.GetType();

            if (t != otherType)
            {
                return false;
            }

            foreach (FieldInfo field in this.GetFields(this))
            {
                object value1 = field.GetValue(obj);
                object value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                    {
                        return false;
                    }
                }
                else if (!value1.Equals(value2))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            // It's possible for two objects to return the same hash code based on
            // identically valued properties, even if they're of two different types,
            // so we include the object's type in the hash calculation
            int hashCode = GetType().GetHashCode();

            foreach (FieldInfo field in this.GetFields(this))
            {
                object value = field.GetValue(this);

                if (value != null) unchecked
                {                   
                    hashCode = hashCode * HASH_MULTIPLIER + value.GetHashCode();
                }
            }

            return hashCode;
        }

        private IEnumerable<FieldInfo> GetFields(object obj)
        {
            Type t = obj.GetType();
            var fields = new List<FieldInfo>();

            while (t != typeof(object))
            {
                FieldInfo[] tmp = t.GetFields(this.reflectingFlags);
                fields.AddRange(tmp);
                t = t.BaseType;
            }

            return fields;
        }
    }
}