using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Dto;
using WebAPI.DTOs;
using WebAPI.Errors;
using WebAPI.Extentions;

namespace WebAPI.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private IOrderService orderService;
        private IMapper mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var address = mapper.Map<AddressDto, Address>(orderDto.ShipToAddress);
            var order = await orderService.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId, address);

            if (order == null)
                return BadRequest(new ApiResponse(400, "Problem with creating order"));

            return Ok(order);
        }

    }
}
