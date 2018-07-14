using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Mmu.Rms.WebApi.Infrastructure.Security.Authorization.PolicyConfiguration.Implementation
{
    public class PolicyProviderResolver : IPolicyProviderResolver
    {
        private readonly IPolicyProvider[] _policyProviders;

        public PolicyProviderResolver(IPolicyProvider[] policyProviders)
        {
            _policyProviders = policyProviders;
        }

        public async Task ConfigurePoliciesAsync(AuthorizationOptions options)
        {
            var allTasks = _policyProviders.Select(f => f.ConfigurePoliciesAsync(options));
            await Task.WhenAll(allTasks);
        }
    }
}