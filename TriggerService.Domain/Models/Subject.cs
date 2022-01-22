using System.Collections.Generic;
using TriggerService.Domain.Enums;

namespace TriggerService.Domain.Models
{
    public abstract class Subject
    {
        public abstract SubjectType Type { get; }
        public abstract string Event { get; }
        public abstract List<string> GetAvailableEvents { get; }
    }
}