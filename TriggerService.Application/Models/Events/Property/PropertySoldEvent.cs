using System;
using TriggerService.Domain.Enums;
using TriggerService.Domain.Models;

namespace TriggerService.Application.Models.Events.Property
{
    public record PropertySoldEvent(Guid PropertyId, Guid OfficeId, Guid HqId) : TriggerEvent(SubjectType.Property, "Sold", PropertyId, OfficeId, HqId);
}