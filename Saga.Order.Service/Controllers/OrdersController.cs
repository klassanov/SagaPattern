using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Saga.Contracts;
using Saga.Order.Service.Models;

namespace Saga.Order.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> logger;
        private readonly IPublishEndpoint publishEndpoint;

        public OrdersController(ILogger<OrdersController> logger, IPublishEndpoint publishEndpoint)
        {
            this.logger = logger;
            this.publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder([FromBody] SubmitOrderRequest orderRequest)
        {
            var orderId = Guid.NewGuid();

            await publishEndpoint.Publish(new OrderSubmitted
            {
                OrderId = orderId,
                Email = orderRequest.Email,
                Total = orderRequest.Total,
            });

            //Simple solution for now
            return Ok(new { OrderId = orderId });

            //TODO Statuscheck endpoint to implement and return Accepted
            //return AcceptedAtAction("GetOrder", new {OrderId= orderId });
        }

        //Status endpoint to implement
        //[HttpGet("orderId")]
        //public IActionResult GetOrder(Guid orderId)
        //{
        //    return Ok("Hello");
        //}
    }
}
