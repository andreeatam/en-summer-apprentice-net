using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using practica_proiect.Models.Dto;
using practica_proiect.Models;
using practica_proiect.Repositories;


namespace TMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<EventDto>>> GetAll()
        {
            var events = await _eventRepository.GetAll();
            if (events == null)
            {
                return NotFound();
            }

            /*var dtoEvents = events.Select(e => new EventDto()
            {
                EventId = e.EventId,
                EventDescription = e.Description,
                EventName = e.Name,
                EventType = e.EventType?.Name ?? string.Empty,
                Venue = e.Venue?.Location ?? string.Empty
            });*/

           var dtoEvents = _mapper.Map<List<EventDto>>(events);

            return Ok(dtoEvents);
        }


        [HttpGet]
        public async Task<ActionResult<EventDto>> GetById(int id)
        {
            var @event = await _eventRepository.GetById(id);

            if (@event == null)
            {
                return NotFound();
            }

            var eventDto = _mapper.Map<EventDto>(@event);

            return Ok(eventDto);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatch)
        {
            var eventEntity = await _eventRepository.GetById(eventPatch.EventId);
            if (eventEntity == null)
            {
                return NotFound();
            }

            if (!eventPatch.EventName.IsNullOrEmpty()) 
                eventEntity.Name = eventPatch.EventName;
            if (!eventPatch.EventDescription.IsNullOrEmpty()) 
                eventEntity.Description = eventPatch.EventDescription;
            await _eventRepository.Update(eventEntity);
           
            var dToEvent=_mapper.Map<EventDto>(eventEntity);
            return Ok(eventEntity);
        }


        [HttpDelete]
        public async Task<ActionResult<EventPatchDto>> Delete(int id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            if (eventEntity == null)
            {
                return NotFound();
            }

            await _eventRepository.Delete(eventEntity);
            return NoContent();
        }
    }
}