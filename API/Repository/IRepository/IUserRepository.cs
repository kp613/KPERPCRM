using API.DTOs;
using API.Models.IdentityModels;
using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.IRepository
{
    public interface IUserRepository
    {
        void Update(ApplicationUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<ApplicationUser> GetUserByUsernameAsync(string username);
        Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
        Task<MemberDto> GetMemberAsync(string username);
    }
}
