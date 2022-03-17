
using MealOrdering.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Server.Services;
using Shared.FilterModels;
using Shared.ResponseModels;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService OrderService)
        {
            orderService = OrderService;
        }



        #region Order Methods

        [HttpGet("OrderById/{Id}")]
        public async Task<ServiceResponse<OrderDTO>> GetOrderById(Guid Id)
        {
            return new ServiceResponse<OrderDTO>()
            {
                Value = await orderService.GetOrderById(Id)
            };
        }

        [HttpGet("OrdersByDate")]
        public async Task<ServiceResponse<List<OrderDTO>>> GetOrder(DateTime OrderDate)
        {
            return new ServiceResponse<List<OrderDTO>>()
            {
                Value = await orderService.GetOrders(OrderDate)
            };
        }

        [HttpPost("OrdersByFilter")]
        public async Task<ServiceResponse<List<OrderDTO>>> GetOrdersByFilter([FromBody] OrderListFilterModel Filter)
        {
            return new ServiceResponse<List<OrderDTO>>()
            {
                Value = await orderService.GetOrdersByFilter(Filter)
            };
        }

        [HttpGet("TodaysOrder")]
        public async Task<ServiceResponse<List<OrderDTO>>> GetTodaysOrder()
        {
            return new ServiceResponse<List<OrderDTO>>()
            {
                Value = await orderService.GetOrders(DateTime.Now)
            };
        }

        [HttpPost("CreateOrder")]
        public async Task<ServiceResponse<OrderDTO>> CreateOrder(OrderDTO Order)
        {
            return new ServiceResponse<OrderDTO>()
            {
                Value = await orderService.CreateOrder(Order)
            };
        }

        [HttpPost("UpdateOrder")]
        public async Task<ServiceResponse<OrderDTO>> UpdateOrder(OrderDTO Order)
        {
            return new ServiceResponse<OrderDTO>()
            {
                Value = await orderService.UpdateOrder(Order)
            };
        }

        [HttpPost("DeleteOrder")]
        public async Task<BaseResponse> DeleteOrder([FromBody] Guid OrderId)
        {
            await orderService.DeleteOrder(OrderId);
            return new BaseResponse();
        }

        [HttpGet("DeleteOrder/{OrderId}")]
        public async Task<BaseResponse> DeleteOrderFromQueryString(Guid OrderId)
        {
            await orderService.DeleteOrder(OrderId);
            return new BaseResponse();
        }

        #endregion

        #region OrderItem Methods

        #region Get

        [HttpGet("OrderItemsById/{Id}")]
        public async Task<ServiceResponse<OrderItemDTO>> GetOrderItemsById(Guid Id)
        {
            return new ServiceResponse<OrderItemDTO>()
            {
                Value = await orderService.GetOrderItemsById(Id)
            };
        }

        #endregion


        [HttpPost("CreateOrderItem")]
        public async Task<ServiceResponse<OrderItemDTO>> CreateOrderItem(OrderItemDTO OrderItem)
        {
            return new ServiceResponse<OrderItemDTO>()
            {
                Value = await orderService.CreateOrderItem(OrderItem)
            };
        }

        [HttpPost("UpdateOrderItem")]
        public async Task<ServiceResponse<OrderItemDTO>> UpdateOrderItem(OrderItemDTO OrderItem)
        {
            return new ServiceResponse<OrderItemDTO>()
            {
                Value = await orderService.UpdateOrderItem(OrderItem)
            };
        }


        [HttpPost("DeleteOrderItem")]
        public async Task<BaseResponse> DeleteOrderItem([FromBody] Guid OrderItemId)
        {
            await orderService.DeleteOrderItem(OrderItemId);
            return new BaseResponse();
        }

        [HttpGet("OrderItems")]
        public async Task<ServiceResponse<List<OrderItemDTO>>> GetOrderItems(Guid OrderId)
        {
            return new ServiceResponse<List<OrderItemDTO>>()
            {
                Value = await orderService.GetOrderItems(OrderId)
            };
        }

        #endregion

    }
}