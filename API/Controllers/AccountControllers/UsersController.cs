using API.DTOs.UserDtos;
using API.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Repository.IRepository;
using API.Controllers;
using API.Helpers.Params;

namespace API.AccountControllers.Controllers
{

    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery]UserParams userParams)
        {
            //var users = await _userRepository.GetMembersAsync(userParams);

            //Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            //var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);

            //return Ok(usersToReturn);
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
            if (user != null)
            {
                userParams.CurrentUsername = user.UserName;
            }

            if (string.IsNullOrEmpty(userParams.Gender))
                userParams.Gender = user.Gender == "male" ? "female" : "male";

            var users = await _userRepository.GetMembersAsync(userParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }

        //[Authorize]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<MemberDto>> GetUserById(string id)
        //{
        //    var user= await _userRepository.GetUserByIdAsync(id);
        //    return _mapper.Map<MemberDto>(user);
        //}

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            ////var user= await _userRepository.GetUserByUsernameAsync(username);
            ////return _mapper.Map<MemberDto>(user);
            ///

            return await _userRepository.GetMemberAsync(username);

        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery] UserParams userParams)
        //{
        //    var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
        //    userParams.CurrentUsername = user.UserName;

        //    if (string.IsNullOrEmpty(userParams.Gender))
        //        userParams.Gender = user.Gender == "male" ? "female" : "male";

        //    var users = await _userRepository.GetMembersAsync(userParams);

        //    Response.AddPaginationHeader(users.CurrentPage, users.PageSize,
        //        users.TotalCount, users.TotalPages);

        //    return Ok(users);
        //}

        //[HttpGet("{username}", Name = "GetUser")]
        //public async Task<ActionResult<MemberDto>> GetUser(string username)
        //{
        //    return await _userRepository.GetMemberAsync(username);
        //}

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            //var username = User.FindFirst(ClaimTypes.NameIdentifier)?. Value;
            //var user = await _userRepository.GetUserByUsernameAsync(username);

            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            _mapper.Map(memberUpdateDto, user);

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }

        [HttpPatch("{username}")]
        public async Task<ActionResult> UploadImage(string username, [FromBody] MemberUpdateDto memberUpdateDto)
        {
            //var username = User.FindFirst(ClaimTypes.NameIdentifier)?. Value;
            //var user = await _userRepository.GetUserByUsernameAsync(username);

            var user = await _userRepository.GetUserByUsernameAsync(username);

            user.ProfilePicture = memberUpdateDto.ProfilePicture;

            _userRepository.UploadImage(user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }

    }
}