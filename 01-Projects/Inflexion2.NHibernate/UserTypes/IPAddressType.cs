//----------------------------------------------------------------------------------------------
// <copyright file="IPAddressType.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Data;
    using System.Net;

    using NHibernate;
    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;

    /// <summary>
    /// mapping for IP address
    /// </summary>
    public class IPAddressType : IUserType
    {
        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public bool IsMutable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public Type ReturnedType
        {
            get
            {
                return typeof(IPAddress);
            }
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public SqlType[] SqlTypes
        {
            get
            {
                return new[] { NHibernateUtil.String.SqlType };
            }
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public object DeepCopy(object value)
        {
            if (value == null)
            {
                return null;
            }

            return new IPAddress(((IPAddress)value).GetAddressBytes());
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
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        bool IUserType.Equals(object x, object y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// IUserType implemetation
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
                return IPAddress.Parse(rs[index].ToString());
            }
            catch (FormatException)
            {
                // The uri is malformed, maybe it is worth to doing something else.
                return null;
            }
        }

        /// <summary>
        /// IUserType implemetation
        /// </summary>
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null || value == DBNull.Value)
            {
                NHibernateUtil.String.NullSafeSet(cmd, null, index);
                return;
            }

            var obj = (IPAddress)value;
            NHibernateUtil.String.Set(cmd, obj.ToString(), index);
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