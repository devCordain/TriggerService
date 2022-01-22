using System.Threading.Tasks;
using TriggerService.Application.Interfaces;
using TriggerService.Application.Models.Events.Property;

namespace TriggerService.Application.Handlers
{
    public class PropertyForSaleEventHandler : IEventHandler<PropertyForSaleEvent>
    {
        public async Task Handle(PropertyForSaleEvent triggerEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}