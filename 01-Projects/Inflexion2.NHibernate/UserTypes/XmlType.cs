namespace Inflexion2.Domain
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Xml;

    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;

    /// <summary>
    ///helper class to map xml
    /// </summary>
    public class SqlXmlType : SqlType
    {
        /// <summary>
        /// constructor
        /// </summary>
        public SqlXmlType()
        : base(DbType.Xml)
        {
        }
    }

    /// <summary>
    ///  maps xml
    /// </summary>
    public class XmlType : IUserType
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
                return typeof(XmlDocument);
            }
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public SqlType[] SqlTypes
        {
            get
            {
                return new SqlType[] { new SqlXmlType() };
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
            var other = (XmlDocument)value;
            var xdoc = new XmlDocument();
            xdoc.LoadXml(other.OuterXml);
            return xdoc;
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
        public new bool Equals(object x, object y)
        {
            var xdoc_x = (XmlDocument)x;
            var xdoc_y = (XmlDocument)y;
            return xdoc_y.OuterXml == xdoc_x.OuterXml;
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
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            if (names.Length != 1)
            {
                throw new InvalidOperationException("names array has more than one element. can't handle this!");
            }

            var document = new XmlDocument();
            var val = rs[names[0]] as string;
            if (val != null)
            {
                document.LoadXml(val);
                return document;
            }

            return null;
        }

        /// <summary>
        /// NH IUserType implemetation
        /// </summary>
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var parameter = (DbParameter)cmd.Parameters[index];
            if (value == null)
            {
                parameter.Value = DBNull.Value;
                return;
            }

            parameter.Value = ((XmlDocument)value).OuterXml;
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