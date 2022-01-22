using System;
using System.Collections.Generic;
using System.Linq;
using TriggerService.Domain.Enums;
using TriggerService.Domain.Models;

namespace TriggerService.Application.Models.Conditions
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