using Core.Entities.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extentions
{
    public static class IdentityServiceExtentions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();
            services.AddAuthentication();
            return services;
        }
    }
}
