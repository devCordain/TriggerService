using System;
using System.Collections.Generic;
using TriggerService.Application.Models.Conditions;

namespace TriggerService.Domain.Models
{
    public class ProgramTrigger
    {
        private Guid Id;
        public List<Owner> Ownership { get; set; }
        public Subject Subject { get; init; }
        public List<Condition> Conditions { get; set; }
        public DateTime? ArchivedAt { get; internal set; }
        public Guid ProgramId { get; set; }

        public ProgramTrigger(List<Owner> ownership, Subject subject, List<Condition> conditions, Guid programId)
        {
            Ownership = ownership;
            Subject = subject;
            Conditions = conditions;
            ProgramId = programId;
            ArchivedAt = null;
        }

        public bool IsValid(Office? office, Property? property)
        {
            foreach (var condition in Conditions)
            {
                if (condition is OfficeCondition && !condition.IsValid(office)) 
                    return false;

                if (condition is PropertyCondition && !condition.IsValid(property)) 
                    return false;
            }

            return true;
        }
    }
}