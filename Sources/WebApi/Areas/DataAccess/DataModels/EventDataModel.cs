using System.Collections.Generic;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.Rms.WebApi.Areas.DataAccess.DataModels
{
    public class EventDataModel : DataModelBase
    {
        public string EventName { get; set; }
        public IReadOnlyCollection<EventRegistrationDataModel> Registrations { get; set; }
    }
}