using System.Collections.Generic;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Rms.WebApi.Areas.Domain.Models
{
    public class Individual : AggregateRoot
    {
        public Individual(string id, string firstName, string lastName, List<EmailAddress> emailAddresses) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddresses = emailAddresses;
        }

        public IReadOnlyCollection<EmailAddress> EmailAddresses { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}