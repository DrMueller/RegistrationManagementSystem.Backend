using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Mmu.Rms.WebApi.Infrastructure.Security.Authorization.ClaimProvisioning.Implementation
{
    public class ClaimProviderResolver : IClaimProviderResolver
    {
        private readonly IClaimProvider[] _claimProviders;

        public ClaimProviderResolver(IClaimProvider[] claimProviders)
        {
            _claimProviders = claimProviders;
        }

        public IReadOnlyCollection<Claim> ProvideClaims(string userId)
        {
            var allClaims = _claimProviders.SelectMany(f => f.ProvideClaims(userId)).ToList();
            return allClaims;
        }
    }
}