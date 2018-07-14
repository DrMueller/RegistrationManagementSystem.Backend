using Mmu.Mlh.DataAccess.Areas.IdGeneration;
using Mmu.Rms.WebApi.Areas.Domain.Models;

namespace Mmu.Rms.WebApi.Areas.Domain.Factories.Implementation
{
    public class EventRegistrationFactory : IEventRegistrationFactory
    {
        private readonly IEntityIdFactory _entityIdFactory;

        public EventRegistrationFactory(IEntityIdFactory entityIdFactory) => _entityIdFactory = entityIdFactory;

        public EventRegistration Create(string individualId, string emailId, string id = null) => new EventRegistration(
            id ?? _entityIdFactory.CreateEntityId(),
            individualId,
            emailId);
    }
}