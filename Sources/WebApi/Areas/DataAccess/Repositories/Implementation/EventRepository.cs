using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DataAccess.Areas.Repositories;
using Mmu.Rms.WebApi.Areas.DataAccess.DataModels;
using Mmu.Rms.WebApi.Areas.Domain.Models;

namespace Mmu.Rms.WebApi.Areas.DataAccess.Repositories.Implementation
{
    public class EventRepository : RepositoryBase<Event, EventDataModel>, IEventRepository
    {
        public EventRepository(IDataModelRepository<EventDataModel> dataModelRepository, IDataModelAdapter<EventDataModel, Event> dataModelAdapter) : base(dataModelRepository, dataModelAdapter)
        {
        }
    }
}