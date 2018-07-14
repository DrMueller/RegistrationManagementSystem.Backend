using Microsoft.AspNetCore.Mvc.Filters;

namespace Mmu.Rms.WebApi.Infrastructure.Security.Authentication.NoOpAuthentication
{
    public class NoOpAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }
}