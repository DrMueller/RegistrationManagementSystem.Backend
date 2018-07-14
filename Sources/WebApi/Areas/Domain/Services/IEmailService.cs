using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Rms.WebApi.Areas.Domain.Models;

namespace Mmu.Rms.WebApi.Areas.Domain.Services
{
    public interface IEmailService
    {
        Task<IReadOnlyCollection<Email>> FetchIncomingEmailsAsync();
    }
}