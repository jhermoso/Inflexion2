//----------------------------------------------------------------------------------------------
// <copyright file="DbProvider.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Data
{
    using System.Runtime.Serialization;

    /// <summary>
    /// enum  of Database providers
    /// </summary>
    public enum DbProvider
    {
        /// <summary>
        /// MySqlProvider
        /// </summary>
        [EnumMember(Value = "MySql.Data.MySQLClient")] MySqlProvider,

        /// <summary>
        /// SQLiteProvider
        /// </summary>
        [EnumMember(Value = "System.Data.SQLite")] SQLiteProvider,

        /// <summary>
        /// MsSqlProvider
        /// </summary>
        [EnumMember(Value = "System.Data.SqlClient")] MSSqlProvider,

        /// <summary>
        /// OracleDataProvider
        /// </summary>
        [EnumMember(Value = "Oracle.DataAccess.Client")] OracleDataProvider,

        /// <summary>
        /// PostgreSQLProvider
        /// </summary>
        [EnumMember(Value = "Npgsql")] PostgreSqlProvider,

        /// <summary>
        /// SqlCe
        /// </summary>
        [EnumMember(Value = "System.Data.SqlServerCe.3.5")] SqlCe,

        /// <summary>
        /// Firebird
        /// </summary>
        [EnumMember(Value = "FirebirdSql.Data.FirebirdClient")] Firebird
    }
}