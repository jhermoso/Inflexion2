//----------------------------------------------------------------------------------------------
// <copyright file="IEntityAuditTrail.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;

    /// <summary>
    /// TODO: update comments, auditing interface to add to root aggregates
    /// </summary>
    public interface IEntityAuditTrail
    {
        /// <summary>
        /// TODO: update comments
        /// </summary>
        Guid ChangeSetUniqueId
        {
            get;
            set;
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        string EntityUniqueId
        {
            get;
            set;
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        object NewValue
        {
            get;
            set;
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        object OldValue
        {
            get;
            set;
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        string PropertyName
        {
            get;
            set;
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        string UpdateBy
        {
            get;
            set;
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        DateTime UpdatedAt
        {
            get;
            set;
        }
    }
}