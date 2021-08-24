using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.IdentityModels
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

        //[ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int ApplicationUserId { get; set; }
    }
}