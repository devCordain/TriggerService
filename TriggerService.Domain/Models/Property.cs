using System;

namespace TriggerService.Domain.Models
{
    public class Property
    {
        public int Value { get; set; }
        public bool Sold { get; set; }
        public Guid OfficeId { get; set; }
        public Guid HqId { get; set; }
    }
}