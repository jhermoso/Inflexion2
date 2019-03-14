//----------------------------------------------------------------------------------------------
// <copyright file="JSONExtensions.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2
{
    using System.Web.Script.Serialization; //asembly system.web.extensions

    /// <summary>
    /// JSON extension methods
    /// </summary>
    public static class JSONExtensions
    {
        /// <summary>
        /// Serializes an object to JSON.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>JSON string representation of the given object</returns>
        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }
    }
}