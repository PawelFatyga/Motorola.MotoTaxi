using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motorola.MotoTaxi.Orders.DomainModels;
using Motorola.MotoTaxi.Orders.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        //[Authorize(Roles = "Boss")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            //string email = this.User.FindFirst(ClaimTypes.Email).Value;
            var list = orderService.Get();
            return Ok(list);


            //if (this.User.Identity.IsAuthenticated)
            //{
            //    string email = this.User.FindFirst(ClaimTypes.Email).Value;

            //    var list = orderService.Get();
            //    return Ok(list);

            //}
            //else
            //{
            //    return Unauthorized();
            //}
        }

        [HttpGet]
        [Route("{number}")]
        public IActionResult Get(string name)
        {
            var list = orderService.Get();
            return Ok(list);
            //return Ok($"Hello {name}");
        }

        // api/orders/100
        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous] //tutaj mozemy wylaczyc autentykacje
        public IActionResult Get(int id)
        {
            Order order = orderService.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
            //return Ok($"Hello {id}");
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            orderService.Add(order);

            return CreatedAtRoute( new { id = order.Id }, order);
        }
    }
}
