using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAPI
{
    public class Startup
    {
        // to inject any service in this application 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }
        //To register middelware 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from Run");
            //});
            app.Use(async (Context, next) =>
            {
                await Context.Response.WriteAsync("Hello from Use-1 1 \n");
                await next();
                await Context.Response.WriteAsync("Hello from Use-1 2 \n");

            });
            app.Use(async (Context, next) =>
            {
                await Context.Response.WriteAsync("Hello from Use-2 1 \n");
                await next();
                await Context.Response.WriteAsync("Hello from Use-2 2 \n");

            });
            app.Use(async (Context, next) =>
            {
                await Context.Response.WriteAsync("Request Complete 1 \n");

            });
            //app.Run(async Context =>
            //{
            //    await Context.Response.WriteAsync("Hello from Run \n");
            //});
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //middleware
            }
            app.UseRouting();    //middleware
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();    //middleware
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello from new WebAPI app");
                //});
                //endpoints.MapGet("/test", async context =>
                //{
                //    await context.Response.WriteAsync("Hello from new WebAPI app Test");
                //});
            });
        }
    }
    
}
