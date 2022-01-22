using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriggerService.Application.Interfaces;
using TriggerService.Application.Models.Subjects;
using TriggerService.Domain.Enums;
using TriggerService.Domain.Models;

namespace TriggerService.Infrastructure.Persistence
{
    public class ProgramTriggerRepository : IProgramTriggerRepository
    {
        public async Task<List<ProgramTrigger>> GetPrograms(Guid ownerId, OwnerType type, string @event)
        {
            switch (type)
            {
                case OwnerType.Office:
                    switch (@event)
                    {
                        case "ForSale":
                            return new List<ProgramTrigger>()
                            {
                                new ProgramTrigger(
                                    new List<Owner>()
                                    {
                                        new Owner
                                        {
                                            Type = OwnerType.Office,
                                            Id = ownerId
                                        }
                                    },
                                    new PropertySubject("ForSale"),
                                    new List<Condition>()
                                    {
                                        new OfficeCondition(Rule.EqualToOneOf, "Active", new List<string>(){bool.TrueString})
                                    },
                                    Guid.NewGuid()),
                                new ProgramTrigger(
                                    new List<Owner>()
                                    {
                                        new Owner
                                        {
                                            Type = OwnerType.Office,
                                            Id = ownerId
                                        }
                                    },
                                    new PropertySubject("ForSale"),
                                    new List<Condition>()
                                    {
                                        new OfficeCondition(Rule.EqualToOneOf, "Active", new List<string>(){bool.TrueString}),
                                        new PropertyCondition(Rule.EqualToOneOf, "Sold", new List<string>(){bool.FalseString}),
                                        new PropertyCondition(Rule.LargerThan, "Value", new List<string>(){90.ToString()})
                                    },
                                    Guid.NewGuid())
                            };
                        case "Upcoming":
                            return new List<ProgramTrigger>()
                            {
                                new ProgramTrigger(
                                    new List<Owner>()
                                    {
                                        new Owner
                                        {
                                            Type = OwnerType.Office,
                                            Id = ownerId
                                        }
                                    },
                                    new PropertySubject("Upcoming"),
                                    new List<Condition>()
                                    {
                                        new OfficeCondition(Rule.EqualToOneOf, "Active", new List<string>(){bool.TrueString})
                                    },
                                    Guid.NewGuid())
                            };
                        case "Sold":
                            return new List<ProgramTrigger>()
                            {

                            };
                    }
                    break;
                case OwnerType.Hq:
                    switch (@event)
                    {
                        case "ForSale":
                            return new List<ProgramTrigger>()
                            {

                            };
                        case "Upcoming":
                            return new List<ProgramTrigger>()
                            {

                            };
                        case "Sold":
                            return new List<ProgramTrigger>()
                            {

                            };
                    }
                    break;
            }

            return new List<ProgramTrigger>();
        }
    }
}