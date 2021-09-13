using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class MemberDto
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string PhotoUrl { get; set; }

        public int StaffId { get; set; }

        public string NationalId { get; set; }   //身份证号

        public string Name { get; set; }

        public string KnownAs { get; set; }         //别名（英文名）

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; } 

        public string PostalCode { get; set; }
        //public DateTime LockoutEnd { get; set; }        //大于现在为 不能登录，设置很大的值表示离职（+1000年)。可设置登录几次错误要暂停多少时间 https://www.yogihosting.com/aspnet-core-identity-user-lockout/

        public DateTime BeOnLeaveEnd { get; set; }      //大于现在为 休假中

        public string ProfilePicture { get; set; }      //个人照片

        public string Introduction { get; set; }              //个人简历

        public string Interests { get; set; }

        public string LookingFor { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        //public ICollection<PhotoDto> Photos { get; set; }

    }
}
