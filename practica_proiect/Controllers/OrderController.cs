using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using practica_proiect.Models;
using practica_proiect.Models.Dto;
using practica_proiect.Repositories;

namespace practica_proiect.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository= orderRepository;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAll();

            /*var dtoOrders = orders.Select(e => new OrderDto()
            {
                OrderId = e.OrderId,
                eventName = e.TicketCategory?.Event?.EventName ?? string.Empty,
                OrderedAt = e.OrderedAt,
                NumberOfTickets = e.NumberOfTickets,
                TicketCategory = e.TicketCategory?.Description ?? string.Empty,
                TotalPrice = e.TotalPrice,
            });*/
            var dtoOrders = _mapper.Map<List<OrderDto>>(orders);
            return Ok(dtoOrders);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id)
        {
            Order order = await _orderRepository.GetById(id);

            /*OrderDto dtoOrder = new OrderDto()
            {
                OrderId = order.OrderId,
                eventName = order.TicketCategory?.Event?.EventName ?? string.Empty,
                OrderedAt = order.OrderedAt,
                NumberOfTickets = order.NumberOfTickets,
                TicketCategory = order.TicketCategory?.Description ?? string.Empty,
                TotalPrice = order.TotalPrice
            };*/
            var dtoOrder = _mapper.Map<OrderDto>(order);
            return Ok(dtoOrder);
        }


        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderId);
           
            orderEntity.TicketCategoryId = orderPatch.TicketCategoryId;
            orderEntity.NumberOfTickets = orderPatch.NumberOfTickets;
            orderEntity.TotalPrice = orderEntity.NumberOfTickets * orderEntity.TicketCategory.Price;
            
            _orderRepository.Update(orderEntity);
            var dtoOrder = _mapper.Map<OrderDto>(orderEntity);
            return Ok(dtoOrder);
        }


        [HttpDelete]
        public async Task<ActionResult<EventPatchDto>> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);

            _orderRepository.Delete(orderEntity);

            return NoContent();
        }
    }
}
