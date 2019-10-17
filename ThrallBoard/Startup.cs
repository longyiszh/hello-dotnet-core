using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Thrallboard.Models;

namespace ThrallBoard
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            // services
            services.AddSingleton<IEmployeeRepo, MockEmployeeRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // customize dev exception page
                DeveloperExceptionPageOptions devExOptions = new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount = 10
                };
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


            app.UseFileServer();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
