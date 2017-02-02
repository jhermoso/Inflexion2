namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// poc for CQRS implementation 
    /// main interface to save events
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// poc for CQRS implementation 
        /// store for the id of the entities afected
        /// important in this case the id type has to be a guid
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <returns></returns>
        List<Event> GetEventsForAggregate(Guid aggregateId);

        /// <summary>
        /// saving  events interface operation
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <param name="events"></param>
        /// <param name="expectedVersion"></param>
        void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);
    }
}