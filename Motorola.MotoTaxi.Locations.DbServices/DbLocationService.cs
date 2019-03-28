using Motorola.MotoTaxi.Locations.DomainModels;
using Motorola.MotoTaxi.Locations.IServices;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Motorola.MotoTaxi.Locations.DbServices
{
    public class DbLocationService : ILocationService
    {
        
        public IEnumerable<Vehicle> Get(Location location)
        {
            List<Vehicle> vehiclelist;
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"))

            {
                IDatabase db = redis.GetDatabase();
                string key = "locations";

                var results = db.GeoRadius(key, location.Longitude, location.Latitude, 20, GeoUnit.Kilometers, 50, Order.Ascending, GeoRadiusOptions.WithCoordinates|GeoRadiusOptions.WithDistance);

                vehiclelist = results.Select(x => new Vehicle(x.Member, new Location { Latitude = x.Position.Value.Latitude, Longitude = x.Position.Value.Longitude })).ToList();
            }

            return vehiclelist;
        }

        public Location Get(string vehicleName)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"))
            {
                IDatabase db = redis.GetDatabase();
                string key = "locations";
                
                return new Location { Latitude = db.GeoPosition(key, vehicleName).Value.Latitude, Longitude = db.GeoPosition(key, vehicleName).Value.Longitude };
            }
        }

        public void Update(Vehicle vehicle)
        {

            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"))
            {
                IDatabase db = redis.GetDatabase();
                string key = "locations";

                db.GeoAdd(key, vehicle.location.Longitude, vehicle.location.Latitude, vehicle.Name);
            }
        }
    }
}
