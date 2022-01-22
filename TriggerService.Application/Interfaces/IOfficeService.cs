using System;
using System.Threading.Tasks;
using TriggerService.Domain.Models;

namespace TriggerService.Application.Interfaces
{
    public interface IOfficeService
    {
        public Task<Office> GetById(Guid officeId);
    }
}