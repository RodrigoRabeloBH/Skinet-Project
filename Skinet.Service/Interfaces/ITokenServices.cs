using Skinet.Model.Identity;

namespace Skinet.Service.Interfaces
{
    public interface ITokenServices
    {
        string CreateToken(AppUser user);
    }
}