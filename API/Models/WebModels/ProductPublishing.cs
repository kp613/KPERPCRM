using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API.Models.WebModels
{
    public class ProductPublishing
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "CAS No")]
        [RegularExpression(@"^[1-9][0-9]*-[0-9][0-9]-[0-9]")]
        public string CASNo { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "产品名称")]
        public string ProductNameCN { get; set; }

    }
}
