using Microsoft.AspNetCore.SignalR.Client;
using Motorola.MotoTaxi.Orders.DomainModels;
using System;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.ConsoleReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Task.Run(() => TestAsync());

            Console.ReadKey();
        }

        private static async Task TestAsync()
        {
            string url = "http://localhost:5000/hubs/orders";

            //added package Microsoft.AspNetCore.SignalR.Client

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            Console.WriteLine("Connecting...");

            await connection.StartAsync();

            Console.WriteLine("Connected.");

            connection.On<Order>("Added", order => Console.WriteLine($"Received {order.Id}"));
        }
    }
}
