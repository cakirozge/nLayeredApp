using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    //extension metot static ile çalışır.
    //InMemoryDatabase: gerçek veri tabanı yok.-- entityframework.core.ınmemory dataaccess yüklendi
   public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(configuration.GetConnectionString("ETradeA")));
            //services.AddDbContext<BaseDbContext>(options => options.UseSq lServer(configuration.GetConnectionString("RentACar")));
            services.AddScoped<IProductDal, EfProductDal>();
            return services;
        }
    }
}
