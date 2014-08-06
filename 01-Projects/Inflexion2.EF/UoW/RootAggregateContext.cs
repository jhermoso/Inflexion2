﻿//----------------------------------------------------------------------------------------------
// <copyright file="AuditableContext.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Linq.Expressions;

    using Inflexion2.Security;
    //using Inflexion2.Validation;

    public class RootAggregateContext : DbContext
    {
        public RootAggregateContext(string nameOrConnectionString)
        : base(nameOrConnectionString)
        {
        }

        public override int SaveChanges()
        {
            //this.AuditEntities();

            //this.ValidateEntities();

            return base.SaveChanges();
        }

        //protected void AuditEntities()
        //{
        //    string userUniqueId = string.Empty;

        //    var user = ApplicationContext.User;
        //    if (user != null)
        //    {
        //        var identity = ApplicationContext.User.Identity as ICoreIdentity;
        //        if (identity != null)
        //        {
        //            userUniqueId = identity.Id;
        //        }
        //    }

        //    DateTime now = DateTime.Now;

        //    foreach (DbEntityEntry<AuditInfo> entry in ChangeTracker.Entries<AuditInfo>())
        //    {
        //        if (entry.State == System.Data.Entity.EntityState.Added || entry.State == System.Data.Entity.EntityState.Modified)
        //        {
        //            entry.Entity.GetType().GetProperty("Version").SetValue(entry.Entity, DateTime.UtcNow.Ticks.ToString(), null);
        //        }

        //        if (entry.State == System.Data.Entity.EntityState.Added)
        //        {
        //            //entry.Entity.CreatedBy = userUniqueId; // CreatedBy
        //            //entry.Entity.UpdatedBy = userUniqueId;
        //            //entry.Entity.CreatedAt = now;
        //            //entry.Entity.UpdatedAt = now;
        //            entry.Entity =  AuditInfoFactory.Create(userUniqueId, userUniqueId, now, now);
        //        }
        //        else if (entry.State == System.Data.Entity.EntityState.Modified)
        //        {
        //            entry.Entity.UpdatedBy = userUniqueId;
        //            entry.Entity.UpdatedAt = now;

        //            var auditTrailFactory = ServiceLocator.TryGetInstance<IAuditTrailFactory>();
        //            if (auditTrailFactory != null && auditTrailFactory.IsEntityRegistered(entry.Entity.GetType().Name))
        //            {
        //                string tableName = entry.Entity.GetType().Name;
        //                IEnumerable<string> changedProperties = entry.CurrentValues.PropertyNames.Where(p => entry.Property(p).IsModified);

        //                Guid changeSetUniqueId = GuidExtensions.NewCombGuid();

        //                foreach (string property in changedProperties)
        //                {
        //                    string propertyName = property;
        //                    object oldValue = entry.OriginalValues[property];
        //                    object newValue = entry.CurrentValues[property];
        //                    IEntityAuditTrail auditTrail = auditTrailFactory.CreateAuditTrail(
        //                                                       changeSetUniqueId,
        //                                                       tableName,
        //                                                       this.GetEntityUniqueId(entry.Entity),
        //                                                       propertyName, oldValue, newValue,
        //                                                       userUniqueId,
        //                                                       now);

        //                    this.Set(auditTrail.GetType()).Add(auditTrail);
        //                }
        //            }
        //        }
        //    }
        //}

        //protected void ValidateEntities()
        //{
        //    foreach (DbEntityEntry<IValidatable> entry in ChangeTracker.Entries<IValidatable>())
        //    {
        //        entry.Entity.AssertValidation();
        //    }
        //}

        private string GetEntityUniqueId(object entity)
        {
            return string.Empty;
        }
    }
}