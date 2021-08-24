using API.Extensions;
using API.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.IdentityModel
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        public byte[] PasswordSalt { get; set; }

        [Display(Name="工号")]
        public int StaffId { get; set; }

        //[Required]
        [Display(Name = "身份证号")]
        public string NationalId { get; set; }   //身份证号

        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name="别名")]
        public string KnownAs { get; set; }

        [Display(Name = "性别")]
        public bool Gender { get; set; }

        //[Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }

        [Display(Name = "家庭住址")]
        public string Address { get; set; }

        [Display(Name = "市")]
        public string City { get; set; }

        [Display(Name = "省")]
        public string State { get; set; }

        [Display(Name = "国家")]
        public string Country { get; set; } = "中国";

        [Display(Name = "邮编")]
        public string PostalCode { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "休假")]
        public DateTime BeOnLeaveEnd { get; set; }      //休假中

        public byte[] ProfilePicture { get; set; }      //个人照片

        public string Resume { get; set; }              //个人简历

        public string Interests { get; set; }

        public string LookingFor { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime LastActive { get; set; } = DateTime.Now;

        //https://www.imooc.com/wiki/netcoreresful/c11l9.html
        //public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }
        //public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        //public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        //public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }

        //public ICollection<BusinessUserGroup> BusinessUserGroups { get; set; }

       // public ICollection<ApplicationUserRole> UserRoles { get; set; }
        public ICollection<Photo> Photos { get; set; }

        //public int GetAge()
        //{
        //    return Birthday.CalculateAge();
        //}

    }
}
