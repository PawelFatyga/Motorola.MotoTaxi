using Motorola.MotoTaxi.Locations.DomainModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.Locations.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            while (true)
            {
                Task.Run(() => GetVehicles());
                Thread.Sleep(2000);
            }
            

           // Console.ReadKey();
        }


        private static async Task GetVehicles()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001");

                var response = await client.GetAsync("api/location?latitude=50.5&longitude=19.9");

                if (response.IsSuccessStatusCode)
                {
                    //add package Microsoft.aspnet.WebApi.Client
                    var content = await response.Content.ReadAsAsync<IEnumerable<Vehicle>>();

                    Console.Clear();
                    foreach (var ent in content)
                    {
                        Console.WriteLine(ent.Name + " " + ent.location.Latitude + " " + ent.location.Longitude);
                    }
                    
                }
            }
        }
    }
}
