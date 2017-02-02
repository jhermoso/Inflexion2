namespace Inflexion2.Domain
{
    using System;

    /// <summary>
    /// value object event descriptor
    /// TODO: add inheritence from value object
    /// </summary>
    public class EventDescriptor
    {
        private const int HASH_MULTIPLIER = 31;
        private int? cachedHashcode;

        /// <summary>
        /// parameterless constructor for event descriptor
        /// </summary>
        protected EventDescriptor()
        {
        }

        /// <summary>
        /// pararmetrized event descriptor constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eventData"></param>
        /// <param name="version"></param>
        public EventDescriptor(Guid id, Event eventData, int version)
        {
            this.EventData = eventData;
            this.Version = version;
            this.Id = id;
        }

        /// <summary>
        /// realted data of the event
        /// </summary>
        public virtual Event EventData
        {
            get;
            protected set;
        }

        /// <summary>
        /// related Id
        /// </summary>
        public virtual Guid Id
        {
            get;
            protected set;
        }

        /// <summary>
        /// entity version
        /// </summary>
        public virtual int Version
        {
            get;
            protected set;
        }

        /// <summary>
        /// has code to get the value object identity
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // Once we have a hash code we'll never change it
            if (this.cachedHashcode.HasValue)
            {
                return this.cachedHashcode.Value;
            }

            unchecked
            {
                // It's possible for two objects to return the same hash code based on
                // identically valued properties, even if they're of two different types,
                // so we include the object's type in the hash calculation
                int hashCode = this.GetType().GetHashCode();
                this.cachedHashcode = (this.Version.GetHashCode() * hashCode * HASH_MULTIPLIER) ^ this.Id.GetHashCode();
            }

            return cachedHashcode.Value;
        }

        /// <summary>
        /// equals comparation for value objet identity
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as EventDescriptor;

            if (object.ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (compareTo == null || compareTo is EventDescriptor == false)
            {
                return false;
            }

            return this.Id.Equals(compareTo.Id) && this.Version.Equals(compareTo.Version);
        }
    }
}