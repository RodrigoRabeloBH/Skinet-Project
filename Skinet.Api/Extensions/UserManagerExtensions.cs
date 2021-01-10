using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Skinet.Model.Identity;

namespace Skinet.Api.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindByClaimsPrincipleWithAddress(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            return await input.Users
                .Include(u => u.Address)
                .SingleOrDefaultAsync(u => u.Email == email);
        }

        public static async Task<AppUser> FindUserFromClaimsPrinciple(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            return await input.Users.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}