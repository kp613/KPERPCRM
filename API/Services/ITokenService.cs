using API.Models.IdentityModels;
using System.Threading.Tasks;


namespace API.Services
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}