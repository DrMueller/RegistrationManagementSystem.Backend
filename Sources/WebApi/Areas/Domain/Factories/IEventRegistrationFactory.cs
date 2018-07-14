using Mmu.Rms.WebApi.Areas.Domain.Models;

namespace Mmu.Rms.WebApi.Areas.Domain.Factories
{
    public interface IEventRegistrationFactory
    {
        EventRegistration Create(string individualId, string emailId, string id = null);
    }
}