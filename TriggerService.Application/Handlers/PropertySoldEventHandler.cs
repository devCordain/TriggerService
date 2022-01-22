using System.Linq;
using System.Threading.Tasks;
using TriggerService.Application.Interfaces;
using TriggerService.Application.Models.Events.Property;
using TriggerService.Domain.Enums;

namespace TriggerService.Application.Handlers
{
    public class PropertySoldEventHandler : IEventHandler<PropertySoldEvent>
    {
        private readonly IProgramTriggerRepository _programTriggerRepository;
        private readonly IConditionValidationService _conditionValidationService;
        private readonly IProgramService _programService;
        
        public PropertySoldEventHandler(
            IProgramTriggerRepository programTriggerRepository,
            IConditionValidationService conditionValidationService, 
            IProgramService programService)
        {
            _programTriggerRepository = programTriggerRepository;
            _conditionValidationService = conditionValidationService;
            _programService = programService;
        }
        public async Task Handle(PropertySoldEvent triggerEvent)
        {
            var officeProgramTriggers = await _programTriggerRepository.GetPrograms(triggerEvent.OfficeId, OwnerType.Office, triggerEvent.Event);
            var validProgramIds = await _conditionValidationService.GetValidProgramIds(triggerEvent.SubjectId, officeProgramTriggers, officeProgramTriggers.First().Ownership.First());

            await _programService.TriggerPrograms(validProgramIds);
        }
    }
}