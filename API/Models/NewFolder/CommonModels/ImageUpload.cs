using API.Models.AppIdentityModels;
using API.Models.IdentityModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.CommonModels
{
    public class ImageUpload
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "图片标题")]
        public string Name { get; set; }

        public string ImageRoute { get; set; }

        [Display(Name = "上传作者")]
        public string Uploader { get; set; }
        [ForeignKey("Uploader")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name="上传时间")]
        public DateTime AddDate { get; set; }

    }
}
