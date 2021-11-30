using API.Models.AppIdentityModels;
using API.Models.IdentityModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.AdminModels
{
    public class BusinessUserGroup
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public BusinessPorfolio BusinessPorfolio { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
