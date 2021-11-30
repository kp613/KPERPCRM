using API.Controllers;
using API.Data;
using API.DTOs.AccountDtos;
using API.Models.AppIdentityModels;
using API.Models.IdentityModels;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.AccountControllers.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly AppIdentityDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(AppIdentityDbContext context,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService,IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoggedDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("该用户名已经使用");

            if (CheckEmailExistsAsync(registerDto.Email).Result.Value) return BadRequest("邮箱已经使用");

            if (await PhoneNumberExists(registerDto.PhoneNumber)) return BadRequest("手机号已经使用");


            var user = _mapper.Map<ApplicationUser>(registerDto);

            var staffId = _context.ApplicationUser.Max(p => p.StaffId);

            //user.UserName = registerDto.Username;
            user.StaffId = staffId + 1;       //员工工号自动编号


            var result = await _userManager.CreateAsync(user,registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);

            //await _context.SaveChangesAsync();

            return new LoggedDto
            {
                Username = user.UserName,
                Name = user.Name,
                KnownAs = user.KnownAs,
                StaffId = user.StaffId,
                Gender=user.Gender,
                ProfilePicture=user.ProfilePicture,
                Token = await _tokenService.CreateToken(user)
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
                Name = user.Name,
                KnownAs = user.KnownAs,
                StaffId=user.StaffId,
                Gender = user.Gender,
                ProfilePicture = user.ProfilePicture,
                Token = await _tokenService.CreateToken(user)
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

        [HttpGet("usernameExists")]
        private async Task<bool> UserExists(string username)
        {
            return await _context.ApplicationUser.AnyAsync(x => x.UserName == username.ToLower());
        }

        private async Task<bool> PhoneNumberExists(string phoneNumber)
        {
            return await _userManager.Users.AnyAsync(p=>p.PhoneNumber == phoneNumber);
        }

        [HttpGet("emailExists")]
        private async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
    }
}
