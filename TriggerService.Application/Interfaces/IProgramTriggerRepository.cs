using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriggerService.Domain.Enums;
using TriggerService.Domain.Models;

namespace TriggerService.Application.Interfaces
{
    public interface IProgramTriggerRepository
    {
        Task<List<ProgramTrigger>> GetPrograms(Guid ownerId, OwnerType type, string @event);
    }
}