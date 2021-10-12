using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CustomerDtos
{
    public class CustomersDto
    {
        public int Id { get; set; }
        public string CustomerNameCh { get; set; }
        public string CustomerNameEn { get; set; }
        public int AreaId { get; set; }

        [Display(Name = "网址")]
        [Required]
        public string CustomerWeb { get; set; }

        [Display(Name = "公司邮箱")]
        public string CustomerEmail { get; set; }

        [Display(Name = "公司电话")]
        public string CompanyTel { get; set; }

        [Display(Name = "公司QQ")]
        public string CompanyQQ { get; set; }

        [Display(Name = "微信公众号")]
        public string CompanyWeChat { get; set; }

    }
}
