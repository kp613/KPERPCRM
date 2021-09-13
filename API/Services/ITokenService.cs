using API.Models.IdentityModels;
using System.Threading.Tasks;


namespace API.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(ApplicationUser user);
    }
}