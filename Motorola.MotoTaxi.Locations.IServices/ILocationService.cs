
using Motorola.MotoTaxi.Locations.DomainModels;
using System;
using System.Collections.Generic;

namespace Motorola.MotoTaxi.Locations.IServices
{
    public interface ILocationService
    {
        void Update(Vehicle vehicle);
        IEnumerable<Vehicle> Get(Location location);
        Location Get(string vehicleName);

    }
}
