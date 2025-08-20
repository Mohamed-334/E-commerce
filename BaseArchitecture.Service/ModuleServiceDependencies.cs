using BaseArchitecture.Service.Service;
using BaseArchitecture.Service.ServiceInterfaces;
using EcommerceProject.Service.Service;
using EcommerceProject.Service.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BaseArchitecture.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            // Register service dependencies here
            // Example: services.AddScoped<IMyService, MyService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailsService, OrderDetailsService>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
