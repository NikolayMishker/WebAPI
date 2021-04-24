using Core.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Extentions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipaleWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);
            return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        }

        public static async Task<AppUser> FindByEmailFromClaimsPrincipale(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);
            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
