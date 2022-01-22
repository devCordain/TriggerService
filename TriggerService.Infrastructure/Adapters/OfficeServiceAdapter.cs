using System;
using System.Threading.Tasks;
using TriggerService.Application.Interfaces;
using TriggerService.Domain.Models;

namespace TriggerService.Infrastructure.Adapters
{
    public class OfficeServiceAdapter : IOfficeService
    {
        public async Task<Office> GetById(Guid officeId) => new Office()
        {
            Active = true
        };
    }
}