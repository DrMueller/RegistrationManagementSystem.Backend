using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Mmu.Rms.WebApi.Infrastructure.Security.Authorization.PolicyConfiguration.Implementation
{
    public class InMemoryPolicyProvider : IPolicyProvider
    {
        public Task ConfigurePoliciesAsync(AuthorizationOptions options)
        {
            options.AddPolicy(
                "GivenNamePolicy",
                config =>
                {
                    config.RequireClaim(ClaimTypes.GivenName);
                });

            options.AddPolicy(
                "NameMatthiasMuellerPolicy",
                config =>
                {
                    config.RequireClaim(ClaimTypes.Name, "m.mueller@novacapta.com");
                });

            options.AddPolicy(
                "NeverFullfilledPolicy",
                config =>
                {
                    config.RequireClaim(ClaimTypes.Uri, "hopefullynever");
                });

            return Task.CompletedTask;
        }
    }
}