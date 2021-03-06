using API.Data;
using API.DTOs.UserDtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repository.IRepository;
using API.Models.AppIdentityModels;
using API.Helpers.Pagination;
using API.Helpers.Params;

namespace API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppIdentityDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AppIdentityDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.ApplicationUser
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams)
        {
            //var query = _context.ApplicationUser
            //    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            //    .AsNoTracking();
            //return await PagedList<MemberDto>.CreateAsync(query, userParams.PageNumber, userParams.PageSize);
            var query = _context.ApplicationUser.AsQueryable();

            query = query.Where(u => u.UserName != userParams.CurrentUsername);
            query = query.Where(u => u.Gender == userParams.Gender);

            var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
            var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

            query = query.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);

            query = userParams.OrderBy switch
            {
                "created" => query.OrderByDescending(u => u.Created),
                //"lastActive" => query.OrderBy(u => u.LastActive),
                _ => query.OrderByDescending(u => u.LastActive)
            };

            return await PagedList<MemberDto>.CreateAsync(query.ProjectTo<MemberDto>(_mapper
                .ConfigurationProvider).AsNoTracking(),
                    userParams.PageNumber, userParams.PageSize);
        }


        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            return await _context.ApplicationUser.FindAsync(id);
        }

        public async Task<ApplicationUser> GetUserByUsernameAsync(string username)
        {
            return await _context.ApplicationUser
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<ICollection<ApplicationUser>> GetUsersAsync()
        {
            return await _context.ApplicationUser
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(ApplicationUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void UploadImage(ApplicationUser user)
        {
            _context.ApplicationUser.Update(user);
        }
    }
}