using AutoMapper;
using CRUDDemo.DataAccessLayer.DbModels;
using CRUDDemoWebAPI.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using CRUDDemoWebAPI.AutoMapper;

namespace CRUDDemoWebAPI.Extensions
{
    public static class Application
    {
        public static void AddDependencyInjectionCustom(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            DependencyInjector.RegisterServices(services);
        }

        public static void AddDatabase(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            DependencyInjector.AddDbContext<UserDbContext>(configuration["AppSettings:ConnectionString"]);
        }

        public static void AddAutoMapper(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
        }

        public static void ConfigureSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dot Net Core Web API v1.0");
            });
        }

        public static void AddSwaggerUICustom(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

        }
    }
}
