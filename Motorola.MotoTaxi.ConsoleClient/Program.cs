using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Task.Run(() => GetOrdersTest());

            Console.ReadKey();
        }

        private static async Task GetOrdersTest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5000");
                var response = await client.GetAsync("api/orders");

                if(response.IsSuccessStatusCode)
                {
                    

                }
            }
        }
    }
}
