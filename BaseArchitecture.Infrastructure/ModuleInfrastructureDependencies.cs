using BaseArchitecture.Infrastructure.Shared.BaseRepository;
using BaseArchitecture.Infrastructure.Shared.Interfaces;
using EcommerceProject.Infrastructure.Repository;
using EcommerceProject.Infrastructure.RepositoryInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BaseArchitecture.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection Services)
        {
            // Register service dependencies here
            // Example: services.AddScoped<IMyService, MyService>();
            Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            Services.AddScoped(typeof(IOrderDetailsRepository), typeof(OrderDetailsRepository));
            Services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            return Services;
        }
    }
}
