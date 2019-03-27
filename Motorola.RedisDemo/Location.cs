using System;
using System.Collections.Generic;
using System.Text;

namespace Motorola.RedisDemo
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location()
        {

        }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    public class Vehicle
    {
        public string Name { get; set; }
        public Location location { get; set; }

        public Vehicle()
        {

        }

        public Vehicle(string name, Location location)
            : this()
        {
            Name = name;
            this.location = location;
        }
    }
}
