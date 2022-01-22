using System;
using System.Collections.Generic;
using System.Linq;
using TriggerService.Domain.Enums;

namespace TriggerService.Domain.Models
{
    public abstract class Condition
    {
        public abstract SubjectType Parent { get; }
        public abstract Rule Rule { get; }
        public abstract string Attribute { get; }
        public abstract List<string> Values { get; }
        public bool IsValid(Office office) 
        {
            var actualValue = typeof(Office).GetProperty(Attribute)?.GetValue(office, null);
            return CommonIsValid(actualValue);
        }

        public bool IsValid(Property property)
        {
            var actualValue = typeof(Property).GetProperty(Attribute)?.GetValue(property, null);
            return CommonIsValid(actualValue);
        }
        
        private bool CommonIsValid(object actualValue) => Rule switch
        {
            Rule.EqualToOneOf => Values.Any(x => x == actualValue.ToString()),
            Rule.LargerThan => Values.All(x => (int)actualValue > int.Parse(x)),
            Rule.LessThan => Values.All(x => (int)actualValue < int.Parse(x)),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}