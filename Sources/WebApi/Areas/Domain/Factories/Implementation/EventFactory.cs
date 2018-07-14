using System.Collections.Generic;
using Mmu.Mlh.DataAccess.Areas.IdGeneration;
using Mmu.Rms.WebApi.Areas.Domain.Models;

namespace Mmu.Rms.WebApi.Areas.Domain.Factories.Implementation
{
    public class EventFactory : IEventFactory
    {
        private readonly IEntityIdFactory _entityIdFactory;

        public EventFactory(IEntityIdFactory entityIdFactory) => _entityIdFactory = entityIdFactory;

        public Event Create(string eventName, List<EventRegistration> registrations, string id = null) => new Event(id ?? _entityIdFactory.CreateEntityId(), eventName, registrations);
    }
}