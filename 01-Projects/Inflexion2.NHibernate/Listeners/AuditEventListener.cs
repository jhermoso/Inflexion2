﻿//----------------------------------------------------------------------------------------------
// <copyright file="AuditEventListener.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Hexa.Core;

    using NHibernate.Event;
    using NHibernate.Event.Default;
    using NHibernate.Persister.Entity;

    using Security;

    public class AuditEventListener<TIdentifier> : IPreUpdateEventListener, IPreInsertEventListener
        where TIdentifier : IEquatable<TIdentifier>, IComparable<TIdentifier>
    {
        public bool OnPreInsert(PreInsertEvent @event)
        {
            var auditable = @event.Entity as IAuditableEntity<TIdentifier>;
            if (auditable == null)
            {
                return false;
            }

            string userUniqueId = string.Empty;

            var user = ApplicationContext.User;
            if (user != null)
            {
                var identity = ApplicationContext.User.Identity as ICoreIdentity;
                if (identity != null)
                {
                    userUniqueId = identity.Id;
                }
            }

            DateTime createdAt = DateTime.Now;

            this._Set(@event.Persister, @event.State, "CreatedBy", userUniqueId);
            this._Set(@event.Persister, @event.State, "UpdatedBy", userUniqueId);
            this._Set(@event.Persister, @event.State, "CreatedAt", createdAt);
            this._Set(@event.Persister, @event.State, "UpdatedAt", createdAt);


            //TODO: coorregir esto por objetos valor inmutables
            //auditable.AuditInfo.CreatedBy = userUniqueId;
            //auditable.AuditInfo.CreatedTimestamp = createdAt;
            //auditable.AuditInfo.UpdatedTimestamp = createdAt;
            //auditable.AuditInfo.UpdatedBy = userUniqueId;
            return false;
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            var auditable = @event.Entity as IAuditableEntity<TIdentifier>;
            if (auditable == null)
            {
                return false;
            }

            string userUniqueId = string.Empty;

            var user = ApplicationContext.User;
            if (user != null)
            {
                var identity = ApplicationContext.User.Identity as ICoreIdentity;
                if (identity != null)
                {
                    userUniqueId = identity.Id;
                }
            }

            DateTime updatedAt = DateTime.Now;

            var auditTrailFactory = ServiceLocator.TryGetInstance<IAuditTrailFactory>();
            if (auditTrailFactory != null && auditTrailFactory.IsEntityRegistered(@event.Persister.EntityName))
            {
                string tableName = @event.Persister.EntityName;
                int[] changedPropertiesIdx = @event.Persister.FindDirty(
                                                 @event.State,
                                                 @event.OldState,
                                                 @event.Entity,
                                                 @event.Session.GetSessionImplementation());

                Guid changeSetUniqueId = GuidExtensions.NewCombGuid();

                foreach (int idx in changedPropertiesIdx)
                {
                    string propertyName = @event.Persister.PropertyNames[idx];
                    object oldValue = @event.OldState[idx];
                    object newValue = @event.State[idx];
                    IEntityAuditTrail auditTrail = auditTrailFactory.CreateAuditTrail(
                                                       changeSetUniqueId,
                                                       tableName,
                                                       @event.Id.ToString(),
                                                       propertyName, oldValue, newValue,
                                                       userUniqueId,
                                                       updatedAt);

                    @event.Session.Save(auditTrail);
                }
            }

            this._Set(@event.Persister, @event.State, "UpdatedBy", userUniqueId);
            this._Set(@event.Persister, @event.State, "UpdatedAt", updatedAt);

            //TODO: actualizar esto con una factoria de objetos valor
            //auditable.AuditInfo.UpdatedBy = userUniqueId;
            //auditable.AuditInfo.UpdatedAt = updatedAt;

            return false;
        }

        private void _Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            int index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
            {
                return;
            }

            state[index] = value;
        }
    }
}