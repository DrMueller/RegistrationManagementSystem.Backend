using System.Collections.Generic;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Rms.WebApi.Areas.Domain.Models
{
    public class Event : AggregateRoot
    {
        public Event(string id, string eventName, List<EventRegistration> registrations) : base(id)
        {
            Registrations = registrations;
            EventName = eventName;
        }

        public string EventName { get; }
        public IReadOnlyCollection<EventRegistration> Registrations { get; }
    }
}