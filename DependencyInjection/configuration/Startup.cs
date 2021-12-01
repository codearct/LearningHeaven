using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace configuration
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "configuration", Version = "v1" });
            });
            services.Configure<MyApiOptions>(Configuration.GetSection("MyApi"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "configuration v1"));
            }

            //Console.WriteLine($"MyKey - {Configuration["MyKey"]}");
            app.Use(async (context, next) =>
            {
                Console.WriteLine($"MyKey - {Configuration["MyKey"]}");
                // var apiOptions = new MyApiOptions();
                // Configuration.GetSection("MyApi").Bind(apiOptions);
                var apiOptions = Configuration.GetSection("MyApi").Get<MyApiOptions>();
                // Console.WriteLine($"MyApi.Url Value - {Configuration["MyApi:Url"]}");
                // Console.WriteLine($"MyApi.ApiKey Value - {Configuration["MyApi:ApiKey"]}");
                Console.WriteLine($"MyApi.Url Value - {apiOptions.Url}");
                Console.WriteLine($"MyApi.ApiKey Value - {apiOptions.ApiKey}");

                Console.WriteLine($"MyNoKey {Configuration.GetValue<int>("MyNoKey", 10)}");

                await next();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
