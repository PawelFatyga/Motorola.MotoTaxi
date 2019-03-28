using Motorola.MotoTaxi.Locations.DomainModels;
using Motorola.MotoTaxi.Orders.DomainModels;
using Motorola.MotoTaxi.Orders.FakeServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            //Task.Run(() => GetOrdersTest());
            Task.Run(() => AddOrderTest());
            

            Console.ReadKey();
        }

        private static async Task AddOrderTest()
        {
            //var order = new OrderFaker

            var orderFaker = new OrderFaker();

            var order = orderFaker.Generate();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("Https://localhost:5001");

                var response = await client.PostAsJsonAsync<Order>("api/orders", order);

                response.EnsureSuccessStatusCode();


            }
        }

        private static async Task GetOrdersTest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001");
                
                var response = await client.GetAsync("api/location?latitude=50.5&longitude=19.9");

                if(response.IsSuccessStatusCode)
                {
                    //add package Microsoft.aspnet.WebApi.Client
                    var content = response.Content.ReadAsAsync<IEnumerable<Vehicle>>().Result;

                    

                }
            }
        }
    }
}
