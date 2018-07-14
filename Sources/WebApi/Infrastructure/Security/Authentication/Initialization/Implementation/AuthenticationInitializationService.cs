using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Rms.WebApi.Infrastructure.Security.Authentication.NoOpAuthentication;
using Mmu.Rms.WebApi.Infrastructure.Settings.Models.SubSettings;
using Mmu.Rms.WebApi.Infrastructure.Settings.Services;

namespace Mmu.Rms.WebApi.Infrastructure.Security.Authentication.Initialization.Implementation
{
    public class AuthenticationInitializationService : IAuthenticationInitializationService
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public AuthenticationInitializationService(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public void Initialize(IServiceCollection services)
        {
            var appSettings = _appSettingsProvider.ProvideAppSettings();
            if (!appSettings.ActivateSecurity)
            {
                InitializeNoOpSecurity(services);
            }
            else
            {
                InitializeAzureJwtSecurity(services, appSettings.AzureAdSettings);
            }
        }

        private static void InitializeAzureJwtSecurity(IServiceCollection services, AzureAdSettings azureAdSettings)
        {
            var authenticationBuidler = services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            );

            authenticationBuidler.AddJwtBearer(
                options =>
                {
                    options.IncludeErrorDetails = true;
                    options.Authority = $"{azureAdSettings.Instance}{azureAdSettings.TenantId}";
                    options.Audience = azureAdSettings.AudienceId;
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                });

        }

        private static void InitializeNoOpSecurity(IServiceCollection services)
        {
            services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = NoOpAuthHandler.NoOpSchema;
                    options.DefaultAuthenticateScheme = NoOpAuthHandler.NoOpSchema;
                    options.DefaultChallengeScheme = NoOpAuthHandler.NoOpSchema;
                    options.DefaultSignInScheme = NoOpAuthHandler.NoOpSchema;
                    options.DefaultSignOutScheme = NoOpAuthHandler.NoOpSchema;
                    options.DefaultForbidScheme = NoOpAuthHandler.NoOpSchema;
                }
            ).AddScheme<NoOpAuthOptions, NoOpAuthHandler>(
                NoOpAuthHandler.NoOpSchema,
                o =>
                {
                });
        }
    }
}