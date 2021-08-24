using Microsoft.AspNetCore.Identity;

namespace API.Models.IdentityModels
{
    //[Keyless]
    public class ApplicationUserRole333
    {
        //public string UserId { get; set; }
        //[ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        //public string RoleId { get; set; }
        //[ForeignKey("RoleId")]
        public ApplicationRole Role { get; set; }
    }
}

