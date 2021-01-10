using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Skinet.Model.Identity;

namespace Skinet.Data.Identity
{
    public class AppIdentityContextSeed
    {
        public static async Task SeedUser(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "John",
                    Email = "jhon@test.com",
                    UserName = "john@tets.com",
                    Address = new Address
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Street = "10 The Street",
                        City = "New York",
                        State = "NY",
                        ZipCode = "90210"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}