using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace employee
{

    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                logger.LogInformation("M1-req");
                await next();
                logger.LogInformation("M1-res");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("M2-req");
                await next();
                logger.LogInformation("M2-res");
            });

            // Terminal Middleware: Pipeline starts to reverse
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(_config["xmj"]);
                logger.LogInformation("M3-req");
                await context.Response.WriteAsync("M3-req\n");
                logger.LogInformation("M3-res");
                await context.Response.WriteAsync("M3-res\n");

            });
        }
    }
}
