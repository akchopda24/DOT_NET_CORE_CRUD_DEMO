using CRUDDemo.BusinessLogic.Interface;
using CRUDDemo.BusinessLogic.Services;
using CRUDDemo.DataAccessLayer.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CRUDDemoWebAPI.DependencyInjection
{
    public static class DependencyInjector
    {
        private static IServiceProvider _serviceProvider { get; set; }

        private static IServiceCollection _services { get; set; }

        public static void AddDbContext<T>(string connectionString) where T : DbContext
        {
            _services.AddDbContextPool<T>(options => options.UseSqlServer(connectionString));
        }

        public static T GetService<T>()
        {
            _services = _services ?? RegisterServices();
            _serviceProvider = _serviceProvider ?? _services.BuildServiceProvider();
            return _serviceProvider.GetService<T>();
        }
        public static IServiceCollection RegisterServices()
        {
            return RegisterServices(new ServiceCollection());
        }

        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            _services = services;
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IUsersService, UsersService>();
            return services;
        }

    }
}
