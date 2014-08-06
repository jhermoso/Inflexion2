// -----------------------------------------------------------------------
// <copyright file="EventDescriptorMap.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software . All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using FluentNHibernate.Mapping;

    /// <summary>
    /// EventDescriptor Map
    /// </summary>
    public class EventDescriptorMap : ClassMap<EventDescriptor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventDescriptorMap"/> class.
        /// </summary>
        public EventDescriptorMap()
        {
            this.Table("Events");

            this.CompositeId()
                .KeyProperty(c => c.Id)
                .KeyProperty(c => c.Version);

            this.Map(c => c.EventData)
                .CustomType<JsonType>()
                .Columns.Add("Type")
                .Columns.Add("Data");
        }
    }
}