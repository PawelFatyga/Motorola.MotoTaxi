using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Motorola.MotoTaxi.Locations.DomainModels;
using Motorola.MotoTaxi.Locations.IServices;

namespace Motorola.MotoTaxi.Locations.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }


        // GET api/location?latitude=50.5&longitude=19.9   -> ul pilsudskiego

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromQuery] Location location)
        {
            var list = locationService.Get(location); 

            return Ok(list);
        }

        // GET api/location/name
        [HttpGet("{name}")]
        public ActionResult<Location> Get(string name)
        {
            return Ok(locationService.Get(name));
        }

        // POST api/location
        [HttpPost]
        public void Post([FromBody] Vehicle car)
        {
            locationService.Update(car);
        }

        // PUT api/location/5
        [HttpPut]
        public void Put([FromBody] Vehicle vehicle)
        {
            locationService.Update(vehicle);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
