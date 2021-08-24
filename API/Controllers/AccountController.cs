using API.Data;
using API.DTOs.AdminDtos;
using API.Models.IdentityModels;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly AppIdentityDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(AppIdentityDbContext context,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }




        [HttpPost("register")]
        public async Task<ActionResult<LoggedDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("该用户名已经使用");

            var staffId = _context.ApplicationUser.Max(p => p.StaffId);

            var user = new ApplicationUser
            {
                UserName = registerDto.Username,
                StaffId = staffId + 1,       //员工工号自动编号
            };

            await _userManager.CreateAsync(user,registerDto.Password);
            await _context.SaveChangesAsync();

            return new LoggedDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoggedDto>> Login(LoginDto loginDto)
        {
            var user = await _context.ApplicationUser.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null) return Unauthorized("非法用户");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("密码不对");

            return new LoggedDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }


        //private readonly ITokenService _tokenService;
        //private readonly IMapper _mapper;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService, IMapper mapper)
        //{
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //    _mapper = mapper;
        //    _tokenService = tokenService;
        //}

        //[HttpPost("register")]
        //public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        //{
        //    if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");

        //    var user = _mapper.Map<ApplicationUser>(registerDto);

        //    user.UserName = registerDto.Username.ToLower();

        //    var result = await _userManager.CreateAsync(user, registerDto.Password);

        //    if (!result.Succeeded) return BadRequest(result.Errors);

        //    var roleResult = await _userManager.AddToRoleAsync(user, "Member");

        //    if (!roleResult.Succeeded) return BadRequest(result.Errors);

        //    return new UserDto
        //    {
        //        Username = user.UserName,
        //        Token = await _tokenService.CreateToken(user),
        //        KnownAs = user.KnownAs,
        //        Gender = user.Gender
        //    };
        //}

        //[HttpPost("login")]
        //public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        //{
        //    var user = await _userManager.Users
        //        .Include(p => p.Photos)
        //        .SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

        //    if (user == null) return Unauthorized("Invalid username");

        //    var result = await _signInManager
        //        .CheckPasswordSignInAsync(user, loginDto.Password, false);

        //    if (!result.Succeeded) return Unauthorized();

        //    return new UserDto
        //    {
        //        Username = user.UserName,
        //        Token = await _tokenService.CreateToken(user),
        //        PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
        //        KnownAs = user.KnownAs,
        //        Gender = user.Gender
        //    };
        //}

        private async Task<bool> UserExists(string username)
        {
            return await _context.ApplicationUser.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
