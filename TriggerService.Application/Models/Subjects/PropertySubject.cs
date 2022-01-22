using System.Collections.Generic;
using TriggerService.Domain.Enums;
using TriggerService.Domain.Models;

namespace TriggerService.Application.Models.Subjects
{
    public class PropertySubject : Subject{
        public override SubjectType Type => SubjectType.Property;
        public override string Event { get; }

        public override List<string> GetAvailableEvents => new List<string>()
        {
            "ForSale",
            "Upcoming",
            "Sold"
        };
    
        public PropertySubject(string @event)
        {
            Event = @event;
        }
    }
}