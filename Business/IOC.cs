using Business.Services;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Data;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class IOC
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Veritabanı bağlantısını sağlayalım.
            services.AddDbContext<StoreContext>(options => options.UseSqlServer(configuration.GetConnectionString("store_db")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IShelfService, ShelfService>();
            return services;
        }
    }
}
