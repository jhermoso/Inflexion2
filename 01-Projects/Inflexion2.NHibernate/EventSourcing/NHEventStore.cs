// -----------------------------------------------------------------------
// <copyright file="NHEventStore.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using NHibernate;

    /// <summary>
    /// nh event repository implementation
    /// </summary>
    public class NHibernateEventStore : BaseEventStore
    {
        private readonly IStatelessSession _session;

        /// <summary>
        /// initialization of repository using the session like UoW
        /// </summary>
        /// <param name="publisher"></param>
        /// <param name="session"></param>
        public NHibernateEventStore(
            IEventPublisher publisher,
            IStatelessSession session)
            : base(publisher)
        {
            _session = session;
        }

        /// <summary>
        /// gets the list of events for one aggregate
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <returns></returns>
        protected override IEnumerable<EventDescriptor> LoadEventDescriptorsForAggregate(Guid aggregateId)
        {
            var query = _session.GetNamedQuery("LoadEventDescriptors")
                        .SetGuid("aggregateId", aggregateId);
            return Transact(() => query.List<EventDescriptor>());
        }

        /// <summary>
        /// save the list of events for one descriptor
        /// </summary>
        /// <param name="newEventDescriptors"></param>
        /// <param name="aggregateId"></param>
        /// <param name="expectedVersion"></param>
        protected override void PersistEventDescriptors(
            IEnumerable<EventDescriptor> newEventDescriptors,
            Guid aggregateId, int expectedVersion)
        {
            // Don't bother to check expectedVersion. Since we can't delete
            // events, we won't skip a version. If we do have a true concurrency
            // violation, we'll get a PK violation exception.
            // SqlExceptionConverter will change it to a ConcurrencyViolation.
            Transact(() =>
            {
                foreach (var ed in newEventDescriptors)
                    _session.Insert(ed);
            });
        }

        /// <summary>
        /// apply a dynamic function in a transaction
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        protected virtual TResult Transact<TResult>(Func<TResult> func)
        {
            if (!_session.Transaction.IsActive)
            {
                // Wrap in transaction
                TResult result;
                using (var tx = _session.BeginTransaction())
                {
                    result = func.Invoke();
                    tx.Commit();
                }
                return result;
            }

            // Don't wrap;
            return func.Invoke();
        }

        /// <summary>
        /// aplies an action in a transaction 
        /// </summary>
        /// <param name="action"></param>
        protected virtual void Transact(Action action)
        {
            Transact<bool>(() =>
            {
                action.Invoke();
                return false;
            });
        }
    }
}