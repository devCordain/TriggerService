using System.Threading.Tasks;

namespace TriggerService.Application.Interfaces
{
    public interface IEventHandler<TriggerEvent>
    {
        public Task Handle(TriggerEvent triggerEvent);
    }
}