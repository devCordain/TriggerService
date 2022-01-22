using System.Collections.Generic;
using TriggerService.Domain.Enums;

namespace TriggerService.Domain.Models
{
    public class PropertyCondition : Condition
    {
        public override Rule Rule { get; }
        public override string Attribute { get; }
        public override List<string> Values { get; }
        public override SubjectType Parent => SubjectType.Property;
        
        public static List<string> AvailableAttributes => new List<string>()
        {
            "Sold",
            "Value"
        };
        
        public PropertyCondition(Rule rule, string attribute, List<string> values)
        {
            Rule = rule;
            Attribute = attribute;
            Values = values;
        }
    }
}