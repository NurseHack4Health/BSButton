using BsButtonApi.Data;
using BsButtonApi.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BsButtonApi.Service.DependencyInjection
{
    public static class BsButtonApiMiddleware
    {
        public static IServiceCollection AddBsButtonServices(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<BsContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            serviceCollection.AddScoped<BsButtonService>();
            serviceCollection.AddScoped<BsButtonCommandRepository>();
            serviceCollection.AddScoped<BsButtonQueryRepository>();
            return serviceCollection;
        }
    }
}