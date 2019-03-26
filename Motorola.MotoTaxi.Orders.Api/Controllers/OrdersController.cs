using Microsoft.AspNetCore.Mvc;
using Motorola.MotoTaxi.Orders.DomainModels;
using Motorola.MotoTaxi.Orders.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.Orders.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello Orders");
        }

        [HttpGet]
        [Route("{number}")]
        public IActionResult Get(string name)
        {
            return Ok($"Hello {name}");
        }

        // api/orders/100
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            Order order = orderService.Get(id);
            return Ok($"Hello {id}");
        }

        [HttpPost]
        public IActionResult Post(Order order)
        {
            orderService.Add(order);

            return Ok();
        }
    }
}
