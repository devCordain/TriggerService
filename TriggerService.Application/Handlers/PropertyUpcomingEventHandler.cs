using System.Threading.Tasks;
using TriggerService.Application.Interfaces;
using TriggerService.Application.Models.Events.Property;

namespace TriggerService.Application.Handlers
{
    public class PropertyUpcomingEventHandler : IEventHandler<PropertyUpcomingEvent>
    {
        public async Task Handle(PropertyUpcomingEvent triggerEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}