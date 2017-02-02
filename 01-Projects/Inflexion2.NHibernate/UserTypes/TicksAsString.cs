namespace Inflexion2.Domain
{
    using System;
    using System.Data;

    using NHibernate;
    using NHibernate.Engine;
    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;

    /// <summary >
    /// Implements a IUserVersionType based on TicksType, but returned as String instead of DateTime.
    /// </summary>
    public class TicksAsString : IUserVersionType
    {
        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public bool IsMutable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public Type ReturnedType
        {
            get
            {
                return typeof(string);
            }
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public SqlType[] SqlTypes
        {
            get
            {
                return new[] { new SqlType(DbType.Int64) };
            }
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object Assemble(object cached, object owner)
        {
            return this.DeepCopy(cached);
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public int Compare(object x, object y)
        {
            return ((IComparable)x).CompareTo(y);
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object DeepCopy(object value)
        {
            return value;
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object Disassemble(object value)
        {
            return this.DeepCopy(value);
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        bool IUserType.Equals(object x, object y)
        {
            return x == y;
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object Next(object current, ISessionImplementor session)
        {
            return this.Seed(session);
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            object ret = rs.GetValue(rs.GetOrdinal(names[0]));

            if (ret == null)
            {
                return null;
            }

            return ret.ToString();
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            NHibernateUtil.Int64.NullSafeSet(cmd, value, index);
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object Seed(ISessionImplementor session)
        {
            return DateTime.UtcNow.Ticks.ToString();
        }
    }
}