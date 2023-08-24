using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using practica_proiect.Models.Dto;
using practica_proiect.Models;
using practica_proiect.Repositories;
using Microsoft.Extensions.Logging;

namespace practica_proiect.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class TicketCategoryController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public TicketCategoryController(IEventRepository eventRepository, ITicketCategoryRepository ticketCategoryRepository, IMapper mapper, ILogger<TicketCategoryController> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
            _ticketCategoryRepository = ticketCategoryRepository;
        }


        [HttpGet]
        public ActionResult<List<TicketCategory>> GetAllTicketCategories()
        {
            var tcs = _ticketCategoryRepository.GetAll();

            if (tcs == null)
            {
                return NotFound();
            }

            var dToTicketCateories = _mapper.Map<List<TicketCategoryDto>>(tcs);
            return Ok(dToTicketCateories);
        }

        [HttpPost]
        public async Task<ActionResult<TicketCategoryDto>> PostTicket(TicketCategoryPostDto ticketCategoryPostDto)
        {
            var eventId = await _eventRepository.GetEventIdByEventName(ticketCategoryPostDto.EventName);

            var ticketCategory = new TicketCategory()
            {
                EventId = eventId,
                Description = ticketCategoryPostDto.Description,
                Price = ticketCategoryPostDto.Price,

            };
            await _ticketCategoryRepository.AddTicketCategory(ticketCategory);

            var tk = _mapper.Map<TicketCategoryDto>(ticketCategory);

            return Ok(tk);
        }

    }
}
