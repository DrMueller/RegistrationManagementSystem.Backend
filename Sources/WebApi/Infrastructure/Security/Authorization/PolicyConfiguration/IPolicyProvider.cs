using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Mmu.Rms.WebApi.Infrastructure.Security.Authorization.PolicyConfiguration
{
    public interface IPolicyProvider
    {
        Task ConfigurePoliciesAsync(AuthorizationOptions options);
    }
}