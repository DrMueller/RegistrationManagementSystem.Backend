using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Rms.WebApi.Areas.Domain.Models
{
    public class EventRegistration : Entity
    {
        public EventRegistration(string id, string individualId, string emailId) : base(id)
        {
            IndividualId = individualId;
            EmailId = emailId;
        }

        public string EmailId { get; }
        public string IndividualId { get; }
    }
}