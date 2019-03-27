using Motorola.MotoTaxi.Locations.DomainModels;
using Motorola.MotoTaxi.Locations.IServices;
using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace Motorola.MotoTaxi.Locations.DbServices
{
    public class DbLocationService : ILocationService
    {
        private readonly ConnectionMultiplexer redis;

        public DbLocationService(ConnectionMultiplexer redis)
        {
            this.redis = redis;
        }

        public IEnumerable<Vehicle> Get(Location location)
        {
            throw new NotImplementedException();
        }

        public Location Get(string vehicleName)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
