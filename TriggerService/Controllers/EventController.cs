using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriggerService.Application.Interfaces;
using TriggerService.Application.Models.Events.Property;
using TriggerService.Domain.Models;

namespace TriggerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController: Controller
    {
        private readonly IEventHandler<TriggerEvent> _eventHandler;

        public EventController(IEventHandler<TriggerEvent> eventHandler)
        {
            _eventHandler = eventHandler;
        }

        [HttpPost("property/for-sale")]
        public async Task<IActionResult> PropertyForSale([FromBody] PropertyEvent propertyEvent)
        {
            await _eventHandler.Handle(new PropertyForSaleEvent(propertyEvent.PropertyId, propertyEvent.OfficeId, propertyEvent.HqId));
            return Ok();
        }
        
        [HttpPost("property/upcoming")]
        public async Task<IActionResult> PropertyUpcoming([FromBody] PropertyEvent propertyEvent)
        {
            await _eventHandler.Handle(new PropertyUpcomingEvent(propertyEvent.PropertyId, propertyEvent.OfficeId, propertyEvent.HqId));
            return Ok();
        }
        
        [HttpPost("property/sold")]
        public async Task<IActionResult> PropertySold([FromBody] PropertyEvent propertyEvent)
        {
            await _eventHandler.Handle(new PropertySoldEvent(propertyEvent.PropertyId, propertyEvent.OfficeId, propertyEvent.HqId));
            return Ok();
        }
    }

    public class PropertyEvent
    {
        public Guid PropertyId { get; set; }
        public Guid OfficeId { get; set; }
        public Guid HqId { get; set; }
    }
}