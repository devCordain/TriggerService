using System;
using System.Threading.Tasks;
using TriggerService.Domain.Models;

namespace TriggerService.Application.Interfaces
{
    public interface IPropertyService
    {
        public Task<Property> GetById(Guid propertyId);
    }
}