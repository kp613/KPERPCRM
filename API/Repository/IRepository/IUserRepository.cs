using API.DTOs.UserDtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.AppIdentityModels;
using API.Helpers.Pagination;
using API.Helpers.Params;

namespace API.Repository.IRepository
{
    public interface IUserRepository
    {
        void Update(ApplicationUser user);
        void UploadImage(ApplicationUser user);

        Task<bool> SaveAllAsync();

        Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
        Task<MemberDto> GetMemberAsync(string username);

        Task<ICollection<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<ApplicationUser> GetUserByUsernameAsync(string username);



    }
}
