using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FarmManager.Domain.Repositories;
using FarmManager.Infrastructure.Repositories;
using FarmManager.Infrastructure.Data;
using FarmManager.Core.Interfaces;
using FarmManager.Core.Services;

namespace FarmManager.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers();
            
            // Configure SQLite database
            var connectionString = _configuration.GetConnectionString("DefaultConnection") ?? "Data Source=FarmManager.db";
            services.AddFarmManagerDatabase(connectionString);

            // Register repositories
            services.AddScoped<IFieldRepository, FieldRepository>();
            services.AddScoped<ICropTypeRepository, CropTypeRepository>();

            // Register services
            services.AddScoped<IFieldService, FieldService>();

            // Configure Swagger/OpenAPI
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Farm Manager API",
                    Version = "v1",
                    Description = "API for managing farm fields and crop rotations",
                    Contact = new OpenApiContact
                    {
                        Name = "Farm Manager Team"
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options => 
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Farm Manager API v1");
                options.RoutePrefix = string.Empty; // Serve Swagger UI at root URL
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