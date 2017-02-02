namespace uNhAddIns.UserTypes
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;

    /// <summary>
    /// https://bitbucket.org/fabiomaulo/unhaddins
    /// http://stackoverflow.com/questions/6366956/mapping-an-iusertype-to-a-component-property-in-fluent-nhibernate/6416718
    /// base class to map componed entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId">The type of the id.</typeparam>
    [Serializable]
    public abstract class GenericWellKnownInstanceType<T, TId> : IUserType
        where T : class
    {
        private readonly Func<T, TId, bool> findPredicate;
        private readonly Func<T, TId> idGetter;
        private readonly IEnumerable<T> repository;

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        /// <param name="repository">The collection that represent a in-memory repository.</param>
        /// <param name="findPredicate">The predicate an instance by the persisted value.</param>
        /// <param name="idGetter">The getter of the persisted value.</param>
        protected GenericWellKnownInstanceType(
            IEnumerable<T> repository,
            Func<T,
            TId,
            bool> findPredicate,
            Func<T, TId> idGetter)
        {
            this.repository = repository;
            this.findPredicate = findPredicate;
            this.idGetter = idGetter;
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public bool IsMutable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public Type ReturnedType
        {
            get
            {
                return typeof(T);
            }
        }

        /// <summary>
        /// The SQL types for the columns mapped by this type.
        /// </summary>
        public abstract SqlType[] SqlTypes
        {
            get;
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        /// <summary>
        /// todo: update summary
        /// </summary>
        public object DeepCopy(object value)
        {
            return value;
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public object Disassemble(object value)
        {
            return value;
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public new bool Equals(object x, object y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(null, x) || ReferenceEquals(null, y))
            {
                return false;
            }

            return x.Equals(y);
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public int GetHashCode(object x)
        {
            return (x == null) ? 0 : x.GetHashCode();
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            int index0 = rs.GetOrdinal(names[0]);
            if (rs.IsDBNull(index0))
            {
                return null;
            }

            var value = (TId)rs.GetValue(index0);
            return this.repository.FirstOrDefault(x => this.findPredicate(x, value));
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                ((IDbDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
            }
            else
            {
                ((IDbDataParameter)cmd.Parameters[index]).Value = this.idGetter((T)value);
            }
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public object Replace(object original, object target, object owner)
        {
            return original;
        }
    }
}