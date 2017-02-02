//----------------------------------------------------------------------------------------------
// <copyright file="ValidateEventListener.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using NHibernate.Cfg;
    using NHibernate.Event;

    using Validation;

    /// <summary>
    /// https://ayende.com/blog/3987/nhibernate-ipreupdateeventlistener-ipreinserteventlistener
    /// this class allow validation in presinsert and preupdate events
    /// </summary>
    public sealed class ValidateEventListener : IPreInsertEventListener, IPreUpdateEventListener, IInitializable
    {
        private bool isInitialized;

        /// <summary>
        /// nh IInitializable interface implementation 
        /// </summary>
        /// <param name="cfg"></param>
        public void Initialize(Configuration cfg)
        {
            if (!this.isInitialized && (cfg != null))
            {
                this.isInitialized = true;
            }
        }

        /// <summary>
        /// IPreInsertEventListener nh interface implementation
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public bool OnPreInsert(PreInsertEvent @event)
        {
            Validate(@event.Entity);
            return false;
        }

        /// <summary>
        /// IPreUpdateEventListener nh interface implementation
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            Validate(@event.Entity);
            return false;
        }

        private static void Validate(object entity)
        {
            IValidatable validatable = entity as IValidatable;
            if (validatable != null)
            {
                validatable.AssertValidation();
            }
        }
    }
}