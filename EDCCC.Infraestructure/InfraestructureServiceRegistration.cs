using EDCCC.Application.Contracts.Persistence;
using EDCCC.Infraestructure.Persistence;
using EDCCC.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EDCCC.Infraestructure
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EDCDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")), ServiceLifetime.Transient
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<EDCDbContextFeed>();

            var scope = services.BuildServiceProvider().CreateScope();
            var dBInitiation = scope.ServiceProvider.GetService<EDCDbContextFeed>();
            dBInitiation.FeedAsync().Wait();



            return services;
        }

        


    }
}
