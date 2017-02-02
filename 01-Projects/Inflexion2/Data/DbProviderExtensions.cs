//----------------------------------------------------------------------------------------------
// <copyright file="DbProviderExtensions.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Data
{
    using System.Data.Common;

    /// <summary>
    /// extension for net provider data bases
    /// </summary>
    public static class DbProviderExtensions
    {
        /// <summary>
        /// Execute sql procedures whose are not querys
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="connectionString"></param>
        /// <param name="command"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static void ExecuteNonQuery(this DbProviderFactory provider, string connectionString, string command)
        {
            // Connect & Execute cmd..
            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = command;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// execute an escalar function in a db which returns a value
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="connectionString"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static object ExecuteScalar(this DbProviderFactory provider, string connectionString, string command)
        {
            // Connect & Execute cmd..
            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = command;
                    object ret = cmd.ExecuteScalar();
                    return ret;
                }
            }
        }
    }
}