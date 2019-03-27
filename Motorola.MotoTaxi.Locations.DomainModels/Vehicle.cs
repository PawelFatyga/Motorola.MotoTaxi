using System;
using System.Collections.Generic;
using System.Text;

namespace Motorola.MotoTaxi.Locations.DomainModels
{
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
