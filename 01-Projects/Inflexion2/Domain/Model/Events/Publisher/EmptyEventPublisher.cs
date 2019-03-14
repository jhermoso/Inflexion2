//----------------------------------------------------------------------------------------------
// <copyright file="EmptyEventPublisher.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using Inflexion2.Logging;

    /// <summary>
    /// Default Event Publisher
    /// </summary>
    public class EmptyEventPublisher : IEventPublisher
    {
        /// <summary>
        /// The logger
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyEventPublisher"/> class.
        /// </summary>
        public EmptyEventPublisher()
        {
            this.logger = LogManager.GetLogger(this.GetType());
        }

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event">The event.</param>
        public void Publish<T>(T @event) where T : class
        {
            logger.Debug("Publishing event of type: {0}", typeof(T).FullName);
        }
    }
}
