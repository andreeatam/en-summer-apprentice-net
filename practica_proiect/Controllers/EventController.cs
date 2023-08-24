using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using practica_proiect.Models.Dto;
using practica_proiect.Models;
using practica_proiect.Repositories;
using Microsoft.AspNetCore.Cors;
using practica_proiect.Models.Patch;

namespace TMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EventController(IEventRepository eventRepository, IMapper mapper, ILogger<EventController> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public ActionResult<List<Event>> GetAllEvents()
        {
            var events = _eventRepository.GetAll();
            if (events == null)
            {
                return NotFound();
            }

            var dtoEvents = _mapper.Map<List<EventDto>>(events);

            return Ok(dtoEvents);
        }


        [HttpGet]
        public async Task<ActionResult<Event>> GetEventsById(int id)
        {
            Event ev = await _eventRepository.GetById(id);
            var eventDto = _mapper.Map<EventDto>(ev);

            return Ok(eventDto);
        }


        [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> PatchEvent(EventPatchDto eventPatch)
        {
            var eventEntity = await _eventRepository.GetById(eventPatch.EventId);
            if (eventEntity == null)
            {
                return NotFound();
            }

            eventEntity.Name = eventPatch.EventName;
            eventEntity.EventId = eventPatch.EventId;
            eventEntity.Description = eventPatch.EventDescription;

            await _eventRepository.Update(eventEntity);

            //var dToEvent=_mapper.Map<EventDto>(eventEntity);
            //return Ok(eventEntity);

            return NoContent();
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            await _eventRepository.Delete(id);
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Event>> AddEvent(EventAddDto eventAddDTO)
        {
            var ev = _mapper.Map<Event>(eventAddDTO);

            await _eventRepository.Add(ev);

            return Ok(ev);
        }
    }
}