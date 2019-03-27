using Bogus;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Threading;

namespace Motorola.RedisDemo
{
    class Program
    {
        // add package StackExchange.Redis
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConnectionTest();

            AddGeoTest();
        }

        private static void AddGeoTest()
        {
            var location = new Location(50.05436, 19.54364);

            var key = "locations";

            //add package bogus
            var locationFaker = new Faker<Location>()
                .RuleFor(p => p.Latitude, f => f.Address.Latitude(50.5, 50.6))
                .RuleFor(p => p.Longitude, f => f.Address.Longitude(19.5, 19.7));

            var locations = locationFaker.GenerateLazy(100);

            var vehicleFaker = new Faker<Vehicle>()
                .RuleFor(p => p.Name, f => $"vehicle{f.IndexFaker}")
                .RuleFor(p => p.location, f => f.PickRandom(locations));

            var vehicles = vehicleFaker.Generate(10);

            GeoEntry[] geoEntries = vehicles.Select(v => new GeoEntry(v.location.Longitude, v.location.Latitude, v.Name)).ToArray();

            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"))
            {
                IDatabase db = redis.GetDatabase();

                db.KeyDelete(key, CommandFlags.FireAndForget);

                db.GeoAdd(key, location.Longitude, location.Latitude, "vehicle1");
                db.GeoAdd(key, location.Longitude+3, location.Latitude+2, "vehicle2");

                db.GeoAdd(key, geoEntries);

                double? distance = db.GeoDistance(key, "vehicle1", "vehicle2", GeoUnit.Kilometers);

                Console.WriteLine($"Distance: {distance} km");

                //redis-cli georadius locations 0 0 22000 km

                var results = db.GeoRadius(key, 0, 0, 22000, GeoUnit.Kilometers, 100, Order.Ascending, GeoRadiusOptions.WithDistance);
               
            }


             
        }

        private static void ConnectionTest()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

            //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("server1:6379, server2:6379");

            // docker run --name my-redis -d -p 6379:6379 redis

           // string key = "abcd";

            // select 
            //IDatabase db = redis.GetDatabase();
            //db.StringSet(key, "Foo", TimeSpan.FromSeconds(10));

            //TimeSpan? ttl = db.KeyTimeToLive(key);
            //Console.WriteLine(ttl);

            //Thread.Sleep(TimeSpan.FromSeconds(11));

            //string value = db.StringGet(key);
            //Console.WriteLine(value);
            //Console.ReadKey();
        }
    }
}
