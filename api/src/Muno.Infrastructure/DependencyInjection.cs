using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Muno.Application.Services;
using Muno.Application.Services.Interfaces;
using Muno.Domain.Interfaces.Repositories;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUserRepository, UserRepository>();
        
            return services;
        }
    }
}
