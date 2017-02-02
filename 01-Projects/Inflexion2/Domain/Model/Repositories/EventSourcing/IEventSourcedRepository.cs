namespace Inflexion2.Domain
{
    using System;
    /// <summary>
    ///  poc for CQRS implementation 
    ///  repository interface for Event Sourced Entities 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEventSourcedRepository<T>
        where T : EventSourcedEntity, new()
    {
        /// <summary>
        /// get the entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(Guid id);

        /// <summary>
        /// save a new version of a Event Sourced entity 
        /// </summary>
        /// <param name="aggregate"></param>
        /// <param name="expectedVersion"></param>
        void Save(EventSourcedEntity aggregate, int expectedVersion);
    }
}