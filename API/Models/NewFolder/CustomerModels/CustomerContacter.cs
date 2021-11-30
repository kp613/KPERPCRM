using API.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.CustomerModels
{
    public class CustomerContacter
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Display(Name="姓名")]
        public string Name { get; set; }

        public enum Position 
        { 
            董事长,总经理,采购经理,销售经理,技术总监,技术部经理,采购,销售,研发员,教授,老师,研究生
        }

        [Display(Name = "手机")]
        public string Mobile { get; set; }

        public string QQ { get; set; }

        [Display(Name = "微信")]
        public string WeChat { get; set; }

        public string WhatsApp { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }

        [Display(Name = "备注")]
        public string Reference { get; set; }       //爱好、家庭成员、毕业学校等

        [Display(Name = "已离职")]
        public bool IsDimission { get; set; }

        [ForeignKey("CompanyId")]
        public Customer Customer { get; set; }

        public ICollection<Inquiry> Inquiries { get; set; }
    }
}
