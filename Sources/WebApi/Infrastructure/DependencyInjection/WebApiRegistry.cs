using Microsoft.AspNetCore.Http;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using Mmu.Rms.WebApi.Infrastructure.Security.Authorization.ClaimProvisioning;
using Mmu.Rms.WebApi.Infrastructure.Security.Authorization.PolicyConfiguration;
using Mmu.Rms.WebApi.Infrastructure.Settings.Services.Implementation;
using StructureMap;

namespace Mmu.Rms.WebApi.Infrastructure.DependencyInjection
{
    public class WebApiRegistry : Registry
    {
        public WebApiRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<WebApiRegistry>();
                    scanner.AddAllTypesOf(typeof(IRepository<>));
                    scanner.AddAllTypesOf(typeof(IDataModelAdapter<,>));
                    scanner.AddAllTypesOf<IClaimProvider>();
                    scanner.AddAllTypesOf<IPolicyProvider>();
                    scanner.WithDefaultConventions();
                });

            For<IHttpContextAccessor>().Use<HttpContextAccessor>().Singleton();
            For<IDatabaseSettingsProvider>().Use<AppSettingsProvider>();
        }
    }
}