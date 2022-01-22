using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriggerService.Application.Interfaces;
using TriggerService.Domain.Enums;
using TriggerService.Domain.Models;

namespace TriggerService.Application.Services
{
    public class ConditionValidationService : IConditionValidationService
    {
        private IOfficeService _officeService;
        private IPropertyService _propertyService;
        
        public ConditionValidationService(
            IOfficeService officeService, 
            IPropertyService propertyService)
        {
            _officeService = officeService;
            _propertyService = propertyService;
        }
        public async Task<List<Guid>> GetValidProgramIds(Guid subjectId, List<ProgramTrigger> programTriggers, Owner owner)
        {
            var programIds = new List<Guid>();
            Guid hqId;

            Office? office = null;
            Property? property = null;

            var subjectType = programTriggers.First().Subject.Type;

            var hasOfficeConditions = programTriggers.Any(x => x.Conditions.Any(y => y.Parent == SubjectType.Office));
            var hasPropertyConditions = programTriggers.Any(x => x.Conditions.Any(y => y.Parent == SubjectType.Property));

            switch (subjectType)
            {
                case SubjectType.Property:
                    (office, property) = await GetDataBasedOnPropertyId(subjectId, hasOfficeConditions, hasPropertyConditions);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            foreach (var programTrigger in programTriggers)
            {
                if (programTrigger.IsValid(office, property))
                {
                    programIds.Add(programTrigger.ProgramId);
                }
            }

            return programIds;
        }

        private async Task<(Office? office, Property? property)> GetDataBasedOnPropertyId(Guid propertyId, bool hasOfficeConditions, bool hasPropertyConditions)
        {
            var property = hasOfficeConditions || hasPropertyConditions ? await _propertyService.GetById(propertyId) : null;
            var office = hasOfficeConditions ? await _officeService.GetById(property.OfficeId) : null;
            return (office, property);
        }
    }
}