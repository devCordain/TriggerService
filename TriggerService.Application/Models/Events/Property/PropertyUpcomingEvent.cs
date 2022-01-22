using System;
using TriggerService.Domain.Enums;
using TriggerService.Domain.Models;

namespace TriggerService.Application.Models.Events.Property
{
    public record PropertyUpcomingEvent(Guid PropertyId, Guid OfficeId, Guid HqId) : TriggerEvent(SubjectType.Property, "Upcoming", PropertyId, OfficeId, HqId);
}