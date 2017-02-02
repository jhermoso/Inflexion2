namespace Inflexion2.Domain
{
    using System;
    using System.Data;
    using Newtonsoft.Json;
    using NHibernate;
    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;

    /// <summary>
    /// map json
    /// </summary>
    [Serializable]
    public class JsonType : IUserType
    {
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
                return typeof(object);
            }
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public SqlType[] SqlTypes
        {
            get
            {
                return new[]
                    {
                        SqlTypeFactory.GetString(10000), // Type
                        SqlTypeFactory.GetStringClob(10000) // Data
                    };
            }
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public object Assemble(object cached, object owner)
        {
            var parts = cached as string[];
            return parts == null
                   ? null
                   : Deserialize(parts[1], parts[0]);
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public object DeepCopy(object value)
        {
            return value == null
                   ? null
                   : Deserialize(Serialize(value), GetType(value));
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object Disassemble(object value)
        {
            return (value == null)
                   ? null
                   : new string[]
                {
                    GetType(value),
                    Serialize(value)
                };
        }

        /// <summary>
        /// NH IUserType implemetation
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
        /// NH IUserType implemetation
        /// </summary>
        public int GetHashCode(object x)
        {
            return (x == null) ? 0 : x.GetHashCode();
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            int typeIndex = rs.GetOrdinal(names[0]);
            int dataIndex = rs.GetOrdinal(names[1]);
            if (rs.IsDBNull(typeIndex) || rs.IsDBNull(dataIndex))
            {
                return null;
            }

            var type = (string)rs.GetValue(typeIndex);
            var data = (string)rs.GetValue(dataIndex);
            return Deserialize(data, type);
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                NHibernateUtil.String.NullSafeSet(cmd, null, index);
                NHibernateUtil.String.NullSafeSet(cmd, null, index + 1);
                return;
            }

            var type = GetType(value);
            var data = Serialize(value);
            NHibernateUtil.String.NullSafeSet(cmd, type, index);
            NHibernateUtil.String.NullSafeSet(cmd, data, index + 1);
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
        private static object Deserialize(string data, string type)
        {
            return Deserialize(data, TypeNameHelper.GetType(type));
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        private static object Deserialize(string data, Type type)
        {
            return JsonConvert.DeserializeObject(data, type);
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        private static string GetType(object value)
        {
            return null == value
                   ? null
                   : TypeNameHelper.GetSimpleTypeName(value);
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        private static string Serialize(object value)
        {
            return null == value
                   ? null
                   : JsonConvert.SerializeObject(value);
        }
    }

    /// <summary>
    /// helper to get type json 
    /// </summary>
    public static class TypeNameHelper
    {
        /// <summary>
        /// get the type's name
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetSimpleTypeName(object obj)
        {
            return null == obj
                   ? null
                   : obj.GetType().AssemblyQualifiedName;
        }

        /// <summary>
        /// gets the type
        /// </summary>
        /// <param name="simpleTypeName"></param>
        /// <returns></returns>
        public static Type GetType(string simpleTypeName)
        {
            return Type.GetType(simpleTypeName);
        }
    }
}
