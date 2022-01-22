using System;
using TriggerService.Domain.Enums;

namespace TriggerService.Domain.Models
{
    public record TriggerEvent(SubjectType Subject, string Event, Guid SubjectId,  Guid OfficeId, Guid HqId);
}