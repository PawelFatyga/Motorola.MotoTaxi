using Bogus;
using Motorola.MotoTaxi.Locations.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motorola.MotoTaxi.Locations.Driver
{
    public class VehicleFaker : Faker <Vehicle>
    {

        public string[] registers = { "KR13532", "SZA54354", "RZ5436", "WO543634", "WAR534534", "GD554363", "PO543634", "ZA654654", "KUB654645" };

        public VehicleFaker()
        {
            StrictMode(true);
            //var f = new Faker().Vehicle.Model();

            //RuleFor(p => p.Name, f => f.Random.Int(0, 12).ToString());
           RuleFor(p => p.Name, f => f.PickRandom<string>(registers));
           RuleFor(p => p.location, f =>
                new Location
                {
                    Latitude = f.Address.Latitude(50.0, 51),
                    Longitude = f.Address.Longitude(19.5, 20.4)
                }
            );
        }

    }
}
