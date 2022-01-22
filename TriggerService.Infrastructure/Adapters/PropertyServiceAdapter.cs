using System;
using System.Threading.Tasks;
using TriggerService.Application.Interfaces;
using TriggerService.Domain.Models;

namespace TriggerService.Infrastructure.Adapters
{
    public class PropertyServiceAdapter : IPropertyService
    {
        public async Task<Property> GetById(Guid propertyId) => new Property()
        {
            Value = 100,
            Sold = false,
            OfficeId = Guid.Empty,
            HqId = Guid.Empty
        };
    }
}