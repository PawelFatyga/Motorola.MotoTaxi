using Motorola.MotoTaxi.Locations.DomainModels;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.Locations.Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            while (true)
            {
                Task.Run(() => AddLocation());
                
                Thread.Sleep(500);
            }
        }


        private static async Task AddLocation()
        {
            var vehicleFaker = new VehicleFaker();
            var vehicle = vehicleFaker.Generate();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("Https://localhost:5001");

                var response = await client.PutAsJsonAsync<Vehicle>("api/location", vehicle);

                response.EnsureSuccessStatusCode();

                Console.WriteLine(vehicle + "Added/updated -> " + vehicle.Name);
            }
        }

    }
}
