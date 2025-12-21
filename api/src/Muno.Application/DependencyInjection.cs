using Muno.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Muno.Application.Services;
using Muno.Application.Services.Interfaces;

namespace Muno.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IMenuItemService, MenuItemService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrentLanguage, CurrentLanguage>();
            services.AddScoped<ICurrentUser, CurrentUser>();

            services.AddAutoMapper(typeof(IMenuItemService).Assembly);
        
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllersWithViews()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();
        
            return services;
        }
    }
}
