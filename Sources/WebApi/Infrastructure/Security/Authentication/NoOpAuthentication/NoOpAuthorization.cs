using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Mmu.Rms.WebApi.Infrastructure.Security.Authentication.NoOpAuthentication
{
    public class NoOpAuthorization : IAuthorizationService
    {
        private readonly DefaultAuthorizationService _defaultAuthorizationService;

        public NoOpAuthorization(DefaultAuthorizationService defaultAuthorizationService)
        {
            _defaultAuthorizationService = defaultAuthorizationService;
        }

        public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements) => _defaultAuthorizationService.AuthorizeAsync(user, resource, requirements);

        public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName) => _defaultAuthorizationService.AuthorizeAsync(user, resource, policyName);
    }
}