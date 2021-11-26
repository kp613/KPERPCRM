using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.AccountDtos
{
    public class RegisterDto
    {
        //���ڵ�¼
        [Required] 
        public string Username { get; set; } //��¼�����û�����Ψһ

        [Required] 
        [EmailAddress]
        public string Email { get; set; }

        [Required] 
        public string PhoneNumber { get; set; }

        [Required] 
        public string Name { get; set; } //����

        [Required] 
        public string NationalId { get; set; }   //���֤��

        public string KnownAs { get; set; }  //�ǳƻ�Ӣ����

        [Required] 
        public string Gender { get; set; }

        [Required] 
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; } //��ͥסַ

        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = "����������һλ��д��ĸ��һλСд��ĸ��һ�����ֺ�һ��������ɵ�6-10λ�ַ�")]   //This regular expression match can be used for validating strong password. It expects atleast 1 small-case letter, 1 Capital letter, 1 digit, 1 special character and the length should be between 6-10 characters. The sequence of the characters is not important. This expression follows the above 4 norms specified by microsoft for a strong password.  //Matches	1A2a$5 | 1234567Tt# | Tsd677% ;     // Non-Matches: Tt122 | 1tdfy34564646T*
        public string Password { get; set; }
    }
}