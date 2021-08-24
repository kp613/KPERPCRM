using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.CommonModels
{
    public enum Grade
    {
        股东文件 = 1,
        董事会文件 = 2,
        总经办文件 = 3,
        文件 = 6,
        协议 = 7,

        公开信息 = 99
    }

    public class CommonSubCategory
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "次类别")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "类别")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CommonCategory Category { get; set; }

        public ICollection<CommonContent> CommonContent { get; set; }
    }
}
