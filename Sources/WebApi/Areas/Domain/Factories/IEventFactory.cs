using System.Collections.Generic;
using Mmu.Rms.WebApi.Areas.Domain.Models;

namespace Mmu.Rms.WebApi.Areas.Domain.Factories
{
    public interface IEventFactory
    {
        Event Create(string eventName, List<EventRegistration> registrations, string id = null);
    }
}