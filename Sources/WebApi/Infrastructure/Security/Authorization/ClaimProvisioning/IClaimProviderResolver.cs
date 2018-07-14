using System.Collections.Generic;
using System.Security.Claims;

namespace Mmu.Rms.WebApi.Infrastructure.Security.Authorization.ClaimProvisioning
{
    public interface IClaimProviderResolver
    {
        IReadOnlyCollection<Claim> ProvideClaims(string userId);
    }
}