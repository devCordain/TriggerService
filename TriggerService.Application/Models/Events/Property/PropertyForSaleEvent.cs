using System;
using TriggerService.Domain.Enums;
using TriggerService.Domain.Models;

namespace TriggerService.Application.Models.Events.Property
{
    public record PropertyForSaleEvent(Guid PropertyId, Guid OfficeId, Guid HqId) : TriggerEvent(SubjectType.Property, "ForSale", PropertyId, OfficeId, HqId);
}