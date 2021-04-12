using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.FileExtensions;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using WebAPI.Models;


namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       // readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });
            //services.AddControllers()
            //    .AddNewtonsoftJson(options =>
            //    {
            //        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //    });
            ////services.AddMvc()
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //    .AddJsonOptions(options => {
            //        var resolver = options.SerializerSettings.ContractResolver;
            //        if (resolver != null)
            //            (resolver as DefaultContractResolver).NamingStrategy = null;
            //    });


            services.AddControllers();
            services.AddDbContext<PaymentDetailsContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddCors();
            

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(MyAllowSpecificOrigins,
            //    builder =>
            //    {
            //        builder.WithOrigins("http://localhost:4200/");
            //    });
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCors(MyAllowSpecificOrigins);

            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200/")
            .AllowAnyMethod()
            .AllowAnyHeader());

            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    
}
