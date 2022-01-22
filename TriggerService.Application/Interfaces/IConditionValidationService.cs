using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriggerService.Domain.Models;

namespace TriggerService.Application.Interfaces
{
    public interface IConditionValidationService
    {
        Task<List<Guid>> GetValidProgramIds(Guid subjectId, List<ProgramTrigger> programTriggers, Owner owner);
    }
}