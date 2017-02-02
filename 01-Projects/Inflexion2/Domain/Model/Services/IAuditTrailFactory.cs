//----------------------------------------------------------------------------------------------
// <copyright file="PagedElements.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;

    /// <summary>
    /// Factory for auditable entities
    /// </summary>
    public interface IAuditTrailFactory
    {
        /// <summary>
        /// auditing a change
        /// </summary>
        /// <param name="changeSetUniqueId"></param>
        /// <param name="entityName"></param>
        /// <param name="entityUniqueId"></param>
        /// <param name="propertyName"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="updatedBy"></param>
        /// <param name="updatedAt"></param>
        /// <returns></returns>
        IEntityAuditTrail CreateAuditTrail(
            Guid changeSetUniqueId,
            string entityName,
            string entityUniqueId,
            string propertyName,
            object oldValue,
            object newValue,
            string updatedBy,
            DateTime updatedAt);

        /// <summary>
        /// asking for auditing success
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        bool IsEntityRegistered(string entityName);
    }
}