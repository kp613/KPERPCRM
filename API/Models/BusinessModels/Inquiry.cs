using API.Models.CustomerModels;
using API.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.BusinessModels
{
    public class Inquiry
    {
        public int Id { get; set; }
        //public int ProductId { get; set; }

        [Display(Name = "公司")]
        public int CompanyId { get; set; }

        [Display(Name = "联系人")]
        public int CompanyContacterId { get; set; }

        [Required]
        public string InquireContent { get; set; }      //客户询价的原始记录

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "录入日期")]
        public DateTime InquireTime { get; set; } = DateTime.Now;

        [Display(Name = "录入人")]
        public string TypeIn { get; set; }

        [ForeignKey("CompanyId")]
        public Customer Company { get; set; }

        [ForeignKey("CompanyContacterId")]
        public CustomerContacter CompanyContacter { get; set; }

        public ICollection<InquiriedProduct> InquiriedProducts { get; set; }
        
    }
}
