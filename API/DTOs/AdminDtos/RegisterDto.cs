using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.AdminDtos
{
    public class RegisterDto
    {
        [Required] public string Username { get; set; }
        //[Required] public string KnownAs { get; set; }
        //[Required] public string Gender { get; set; }
        //[Required] public DateTime DateOfBirth { get; set; }
        //[Required] public string City { get; set; }
        //[Required] public string Country { get; set; }

        [Required]
        [MinLength(6,ErrorMessage ="密码不能少于6位")]
        public string Password { get; set; }
    }
}