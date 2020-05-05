using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThrallBoard.Models;

namespace ThrallBoard
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            // DB
            services.AddDbContextPool<AppDBContext>((options) => { options.UseSqlServer(config.GetConnectionString("Main")); });

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // configure password options. Can also be achieved by services.Configure<IdentityOptions>()
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 4;
                options.Password.RequireNonAlphanumeric = false;
            }
            ).AddEntityFrameworkStores<AppDBContext>();

            // services
            //services.AddSingleton<IEmployeeRepo, MockEmployeeRepo>();
            services.AddScoped<IEmployeeRepo, SQLEmployeeRepo>();

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
            } else
            {
                app.UseExceptionHandler("/Error");
                // app.UseStatusCodePagesWithRedirects("/Error/{0}"); // Redirects to the error handling page. Changes address bar. Returns status 200 eventually to browser.
                app.UseStatusCodePagesWithReExecute("/Error/{0}"); // No redirects. Preserves original url (including query strings). Returns 404 eventually.
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
            app.UseAuthentication();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
