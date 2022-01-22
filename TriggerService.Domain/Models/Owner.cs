using System;
using TriggerService.Domain.Enums;

namespace TriggerService.Domain.Models
{
    public class Owner
    {
        public OwnerType Type { get; set; }
        public Guid Id { get; set; }
    }
}