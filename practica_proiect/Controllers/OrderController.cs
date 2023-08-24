using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using practica_proiect.Models;
using practica_proiect.Models.Dto;
using practica_proiect.Models.Patch;
using practica_proiect.Repositories;

namespace practica_proiect.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
  

        public OrderController(IOrderRepository orderRepository, IMapper mapper, ITicketCategoryRepository ticketCategoryRepository)
        {
            _orderRepository= orderRepository;
            _mapper = mapper;
            _ticketCategoryRepository = ticketCategoryRepository;
        }



        [HttpGet]
        public ActionResult<List<Order>> GetAllOrders()
        {
            var orders = _orderRepository.GetAll();

            var dtoOrders = _mapper.Map<List<OrderDto>>(orders);
            return Ok(dtoOrders);
        }


        [HttpGet]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var ord = await _orderRepository.GetById(id);

            var dtoOrder = _mapper.Map<OrderDto>(ord);
            return Ok(dtoOrder);
        }


        [HttpPatch]
        public async Task<ActionResult> PatchOrder(OrderPatchDto orderPatch)
        {
            Order orderEntity = await _orderRepository.GetById(orderPatch.EventId);
           
            orderEntity.TicketCategory.EventId = orderPatch.EventId;
            orderEntity.TicketCategoryId = orderPatch.TicketCategoryId;
            orderEntity.NumberOfTickets = orderPatch.NumberOfTickets;
            
            await _orderRepository.Update(orderEntity);
          
            return Ok(orderEntity);
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);

            await _orderRepository.Delete(orderEntity);

            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<OrderAddDto>> AddOrder(OrderAddDto orderAddDto)
        {
            TicketCategory ticketCategory = await _ticketCategoryRepository.GetById(orderAddDto.ticketCategoryId);

            if(ticketCategory == null)
            {
                return NotFound();
            }

            float totalPrice = (float)(orderAddDto.numberOfTickets * ticketCategory.Price);

            if(totalPrice == null)
            {
                return NotFound();
            }
            
            var or = _mapper.Map<Order>(orderAddDto);
            or.TotalPrice= totalPrice;
            await _orderRepository.Add(or);

            return Ok(or);
        }
    }
}
