using Mmu.Rms.WebApi.Infrastructure.Settings.Models;

namespace Mmu.Rms.WebApi.Infrastructure.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings ProvideAppSettings();
    }
}