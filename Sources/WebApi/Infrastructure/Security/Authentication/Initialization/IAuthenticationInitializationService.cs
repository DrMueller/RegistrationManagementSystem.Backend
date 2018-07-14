using Microsoft.Extensions.DependencyInjection;

namespace Mmu.Rms.WebApi.Infrastructure.Security.Authentication.Initialization
{
    public interface IAuthenticationInitializationService
    {
        void Initialize(IServiceCollection services);
    }
}