using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        // Dependency injection container
        public void ConfigureServices(IServiceCollection services)
        {
            // use MVC
            services.AddMvc(); // difference from AddMvcCore(): AddMvcCore() ∈ AddMvc()

            // services
            services.AddSingleton<IEmployeeRepo, MockEmployeeRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // handles exception, plug in as earlier as possible
            if (env.IsDevelopment())
            {
                // customize dev exception page
                DeveloperExceptionPageOptions devExOptions = new DeveloperExceptionPageOptions();
                devExOptions.SourceCodeLineCount = 10;
                app.UseDeveloperExceptionPage(devExOptions);
            }

            #region customize default html page method 1
            //// customize default html page
            //DefaultFilesOptions dfOptions = new DefaultFilesOptions();
            //dfOptions.DefaultFileNames.Clear();
            //dfOptions.DefaultFileNames.Add("fancy.html");

            //// order of these two 'use's is very important
            //// UseDefaultFiles() must present ahead of UseStaticFiles()
            //app.UseDefaultFiles(options);
            //app.UseStaticFiles();

            #endregion

            #region customize default html page method 2
            //FileServerOptions fsOptions = new FileServerOptions();
            //fsOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fsOptions.DefaultFilesOptions.DefaultFileNames.Add("fancy.html");
            //app.UseFileServer(fsOptions);
            #endregion

            //app.UseFileServer();

            // use MVC
            app.UseMvcWithDefaultRoute();

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("M1-req");
            //    await next();
            //    logger.LogInformation("M1-res");
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("M2-req");
            //    await next();
            //    logger.LogInformation("M2-res");
            //});

            // Terminal Middleware: Pipeline starts to reverse
            app.Run(async (context) =>
            {
                //await context.Response.WriteAsync(_config["xmj"]);
                //logger.LogInformation("M3-req");
                //await context.Response.WriteAsync("M3-req\n");
                //logger.LogInformation("M3-res");
                //await context.Response.WriteAsync("M3-res\n");
                throw new Exception("Lan lo");

            });
        }

    }
}
