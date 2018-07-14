using System.Collections.Generic;
using System.Security.Claims;

namespace Mmu.Rms.WebApi.Infrastructure.Security.Authorization.ClaimProvisioning.Implementation
{
    public class InMemoryClaimProvider : IClaimProvider
    {
        public IReadOnlyCollection<Claim> ProvideClaims(string userId) => new List<Claim>
        {
            new Claim(ClaimTypes.Name, userId),
            new Claim("TimeReportingClaim", string.Empty)
        };
    }
}