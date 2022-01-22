using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TriggerService.Application.Interfaces
{
    public interface IProgramService
    {
        Task TriggerPrograms(List<Guid> programIds);
    }
}