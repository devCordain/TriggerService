using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriggerService.Application.Interfaces;

namespace TriggerService.Infrastructure.Adapters
{
    public class ProgramServiceAdapter : IProgramService
    {
        public async Task TriggerPrograms(List<Guid> programIds)
        {
            foreach (var id in programIds)
            {
                Console.WriteLine($"Sending {id} to ProgramService");
            }
        }
    }
}