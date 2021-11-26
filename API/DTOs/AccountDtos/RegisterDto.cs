using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.AccountDtos
{
    public class RegisterDto
    {
        //用于登录
        [Required] 
        public string Username { get; set; } //登录名或用户名，唯一

        [Required] 
        [EmailAddress]
        public string Email { get; set; }

        [Required] 
        public string PhoneNumber { get; set; }

        [Required] 
        public string Name { get; set; } //姓名

        [Required] 
        public string NationalId { get; set; }   //身份证号

        public string KnownAs { get; set; }  //昵称或英文名

        [Required] 
        public string Gender { get; set; }

        [Required] 
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; } //家庭住址

        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = "密码由至少一位大写字母，一位小写字母，一个数字和一个符号组成的6-10位字符")]   //This regular expression match can be used for validating strong password. It expects atleast 1 small-case letter, 1 Capital letter, 1 digit, 1 special character and the length should be between 6-10 characters. The sequence of the characters is not important. This expression follows the above 4 norms specified by microsoft for a strong password.  //Matches	1A2a$5 | 1234567Tt# | Tsd677% ;     // Non-Matches: Tt122 | 1tdfy34564646T*
        public string Password { get; set; }
    }
}