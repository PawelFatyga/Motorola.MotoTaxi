using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Motorola.MotoTaxi.Orders.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(ConfigureConfiguration)
                .UseStartup<Startup>();

        private static void ConfigureConfiguration(WebHostBuilderContext context, IConfigurationBuilder configuration)
        {
            var env = context.HostingEnvironment;
            Trace.WriteLine(context.HostingEnvironment.EnvironmentName); //project -> properties -> debug -> environment mode


            configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //configuration.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            //configuration.AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true);
            //configuration.AddXmlFile($"appsettings.{env.EnvironmentName}.xml", optional: true, reloadOnChange: true);
        }
    }
}
