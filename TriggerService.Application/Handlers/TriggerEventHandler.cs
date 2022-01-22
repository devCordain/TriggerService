using System.Linq;
using System.Threading.Tasks;
using TriggerService.Application.Interfaces;
using TriggerService.Domain.Enums;
using TriggerService.Domain.Models;

namespace TriggerService.Application.Handlers
{
    public class TriggerEventHandler : IEventHandler<TriggerEvent>
    {
        private IProgramTriggerRepository _programTriggerRepository;
        private IConditionValidationService _conditionValidationService;
        private IProgramService _programService;

        public TriggerEventHandler(
            IProgramTriggerRepository programTriggerRepository, 
            IConditionValidationService conditionValidationService, 
            IProgramService programService)
        {
            _programTriggerRepository = programTriggerRepository;
            _conditionValidationService = conditionValidationService;
            _programService = programService;
        }
        public async Task Handle(TriggerEvent triggerEvent)
        {
            var officeProgramTriggers = await _programTriggerRepository.GetPrograms(triggerEvent.OfficeId, OwnerType.Office, triggerEvent.Event);
            var validProgramIds = await _conditionValidationService.GetValidProgramIds(triggerEvent.SubjectId, officeProgramTriggers, officeProgramTriggers.First().Ownership.First());

            await _programService.TriggerPrograms(validProgramIds);
        }
    }
}