using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ProductModels
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "CAS No")]
        [RegularExpression(@"^[1-9][0-9]*-[0-9][0-9]-[0-9]")]
        public string CasNo { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "产品名称")]
        public string ProductNameCN { get; set; }

        [Display(Name = "产品代号")]
        public string ProductCode { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "更改时间")]
        public DateTime UpdateDay { get; set; }

        [Display(Name = "结构式")]
        public string StructureUrl { get; set; }



    }
}