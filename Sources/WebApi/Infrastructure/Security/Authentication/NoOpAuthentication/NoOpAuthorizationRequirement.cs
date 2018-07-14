using Microsoft.AspNetCore.Authorization;

namespace Mmu.Rms.WebApi.Infrastructure.Security.Authentication.NoOpAuthentication
{
    public class NoOpAuthorizationRequirement : IAuthorizationRequirement
    {
    }
}