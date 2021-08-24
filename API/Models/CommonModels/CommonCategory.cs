using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API.Models.CommonModels
{
    public class CommonCategory
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "类别")]
        [Required]
        public string Name { get; set; }
    }
}
