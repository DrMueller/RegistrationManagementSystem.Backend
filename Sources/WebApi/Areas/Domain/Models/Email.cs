using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Rms.WebApi.Areas.Domain.Models
{
    public class Email : AggregateRoot
    {
        public Email(string id, string subject) : base(id)
        {
            Guard.StringNotNullOrEmpty(() => subject);

            Subject = subject;
        }

        public string Subject { get; }
    }
}