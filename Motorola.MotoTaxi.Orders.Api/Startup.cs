using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Motorola.MotoTaxi.Orders.DbServices;
using Motorola.MotoTaxi.Orders.FakeServices;
using Motorola.MotoTaxi.Orders.IServices;

namespace Motorola.MotoTaxi.Orders.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IOrderService, FakeOrderService>();
            services.AddScoped<IOrderService, DbOrderService>();
            //services.AddSingleton<OrderFaker>();

            string connectionString = Configuration.GetConnectionString("OrdersConnection");

            var count = Configuration["OrdersCount"];
            var user = Configuration["User:Login"];

            // add package Microsoft.EntityFrameworkCore.SqlServer
            services.AddDbContext<OrdersContext>(options => options.UseSqlServer(connectionString));

            //add package Microsoft.Aspnetcore.mvc.formatters.xml 2.1.1
            services
                .AddMvc(options=>options.RespectBrowserAcceptHeader=true)
                .AddXmlSerializerFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
