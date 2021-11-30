using API.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.AppIdentityModels
{
    public enum IdentityType
    {
        身份 = 0,
        职务 = 1,
        所属公司 = 2,
        部门 = 3,
        特例 = 9,
    }


    public class ApplicationRole : IdentityRole
    {
        [Display(Name = "授权层级")]
        public int IdentityType { get; set; }

        [Display(Name = "权限描述")]
        public string Statement { get; set; }

        [Display(Name = "序号")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdentityId { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
