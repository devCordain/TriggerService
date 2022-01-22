using System.Threading.Tasks;
using TriggerService.Domain.Models;

namespace TriggerService.Application.Interfaces
{
    public interface IEventHandler<TriggerEvent>
    {
        public Task Handle(TriggerEvent triggerEvent);
    }
}