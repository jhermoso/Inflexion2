namespace Inflexion2.Domain
{
    using System;
    using System.Data;

    using NHibernate;
    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;

    /// <summary>
    /// maps guids from string
    /// </summary>
    public class StringToGuid : IUserType
    {
        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public bool IsMutable
        {
            get
            {
                return true;
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
                return new[] { NHibernateUtil.Guid.SqlType };
            }
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object DeepCopy(object value)
        {
            if (value == null)
            {
                return null;
            }

            return value.ToString();
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object Disassemble(object value)
        {
            return value;
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
            return Equals(x, y);
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            int index = rs.GetOrdinal(names[0]);
            if (rs.IsDBNull(index))
            {
                return null;
            }

            try
            {
                return rs[index].ToString();
            }
            catch (FormatException)
            {
                return null;
            }
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null || value == DBNull.Value)
            {
                NHibernateUtil.String.NullSafeSet(cmd, null, index);
                return;
            }

            Guid obj = Guid.Parse(value.ToString());
            NHibernateUtil.String.Set(cmd, obj, index);
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object Replace(object original, object target, object owner)
        {
            return original;
        }
    }
}