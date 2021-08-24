using API.Models.BusinessModels;
using API.Models.CommonModels;
using API.Models.IdentityModels;
using API.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.CustomerModels
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name ="公司名称")]
        public string CustomerNameCh { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerNameEn { get; set; }

        [Display(Name = "已放弃")]
        public bool IsAbandoned { get; set; }


        [Display(Name ="区域")]
        [Required]
        public int AreaId { get; set; }

        [Display(Name = "网址")]
        public string CustomerWeb { get; set; }

        [Display(Name = "公司邮箱")]
        public string CustomerEmail { get; set; }

        [Display(Name = "公司电话")]
        public string CompanyTel { get; set; }

        [Display(Name = "公司QQ")]
        public string CompanyQQ { get; set; }

        [Display(Name = "微信公众号")]
        public string CompanyWeChat { get; set; }

        [Display(Name = "最新修改")]
        public string ModificateMan { get; set; }     //最近使用者

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "UpdateTime")]
        public DateTime UpdateDay { get; set; }

        public ICollection<Inquiry> Inquiries { get; set; }

        public ICollection<CustomerRelateAnother> CustomerRelateds { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public ICollection<CustomerContacter> CustomerContacters { get; set; }
        public ICollection<CustomerBank> CustomerBanks { get; set; }
        public ICollection<Warehouse> Warehouses { get; set; }
        public ICollection<ProductInAndOut> ProductInAndOuts { get; set; }

        [ForeignKey("AreaId")]
        public Area SysArea { get; set; }
    }
}
