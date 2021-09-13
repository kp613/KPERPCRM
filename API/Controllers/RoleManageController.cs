using API.Data;
using API.DTOs.AdminDtos;
using API.Models.IdentityModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class RoleManageController : BaseApiController
    {
        private readonly AppIdentityDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleManageController(AppIdentityDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<ApplicationRole>>> GetRoles()
        {
            var roles = await _roleManager.Roles
                .OrderByDescending(u => u.IdentityId)
                .AsNoTracking()
                .ToListAsync();

            return Ok(roles);
        }

        //[Authorize(Policy = "RequireAdminRole")]
        [HttpPost("addrole")]
        public async Task<ActionResult<ApplicationRole>> AddRole([FromBody] RoleDto roleDto)
        {
            if (await RoleExists(roleDto.Name)) return BadRequest("该角色已经使用");

            var identityIdMax = await _roleManager.Roles.MaxAsync(m => m.IdentityId);
            roleDto.IdentityId = identityIdMax + 1;

            var role = _mapper.Map<ApplicationRole>(roleDto);

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok(role);
        }

        [HttpPost("{roleId}")]
        public async Task<IActionResult> Edit(string roleId)
        {
            var role = await _context.ApplicationRole.FirstOrDefaultAsync(p => p.Id == roleId);
            // 获取角色的所有用户
            //var users = await _userManager.GetUsersInRoleAsync(model.Name);

            //ViewBag.Users = users;
            //return View(nameof(CreateAndEdit), new RoleManageViewModel
            //{
            //    UserId = model.Id,
            //    RoleName = model.Name,
            //    IdentityType = model.IdentityType,
            //    IdentityId = model.IdentityId,
            //    Statement = model.Statement,

            //    ApplicationRoles = await _context.ApplicationRole.ToListAsync(),
            //});
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRole(string id)
        {
            var role = await _context.ApplicationRole.FindAsync(id);

            if (role == null)
            {
                return BadRequest("没有这个角色");
            }

            _context.Remove(role);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("users-with-roles")]
        public async Task<ActionResult> GetUsersWithRoles()
        {
            var users = await _userManager.Users
                .Include(r => r.UserRoles)
                .ThenInclude(r => r.Role)
                .OrderBy(u => u.UserName)
                .Select(u => new
                {
                    u.Id,
                    Username = u.UserName,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                })
                .ToListAsync();

            return Ok(users);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("edit-roles/{username}")]
        public async Task<ActionResult> EditRoles(string username, [FromQuery] string roles)
        {
            var selectedRoles = roles.Split(",").ToArray();

            var user = await _userManager.FindByNameAsync(username);

            if (user == null) return NotFound("Could not find user");

            var userRoles = await _userManager.GetRolesAsync(user);

            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!result.Succeeded) return BadRequest("Failed to add to roles");

            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            if (!result.Succeeded) return BadRequest("Failed to remove from roles");

            return Ok(await _userManager.GetRolesAsync(user));
        }

        [Authorize(Policy = "ModeratePhotoRole")]
        [HttpGet("photos-to-moderate")]
        public ActionResult GetPhotosForModeration()
        {
            return Ok("Admins or moderators can see this");
        }

        private async Task<bool> RoleExists(string name)
        {
            return await _roleManager.Roles.AnyAsync(x => x.Name == name.ToLower());
        }
    }
}