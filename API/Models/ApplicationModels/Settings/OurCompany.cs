using API.Models.AdminModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ApplicationModels.Settings
{
    public class OurCompany
    {
        [Display(Name = "公司代码")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage ="公司名称不能为空")]
        [Display(Name="公司名称 *")]
        public string CompanyName { get; set; }

        [Display(Name = "公司法人")]
        public string JuridicalPerson { get; set; }

        [Display(Name = "注册资本")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public double RegisteredCapital  { get; set; }

        [Display(Name = "实缴资本")]
        public double PaidInCapital { get; set; }

        [Display(Name = "总股份")]
        public double ShareTotal { get; set; }

        //用于业务员合同制作时正确选择公司，以区分帐内帐外，美金、人民币
        [Display(Name = "业务特征")]
        public string ServiceFeature { get; set; }

        [Display(Name = "公司简称")]
        public string Abbr { get; set; }

        [Display(Name = "公司官网")]
        public string Web { get; set; }

        [Display(Name = "公司邮箱")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "注册地址")]
        public string RegAddress { get; set; }

        [Display(Name = "注册电话")]
        public string RegTel { get; set; }

        [Display(Name = "税务登记号")]
        public string TaxNumber { get; set; }

        [Required]
        [Display(Name = "开户行 *")]
        public string BankName { get; set; }

        [Required]
        [Display(Name = "银行账号 *")]
        public string BankAccount { get; set; }

        [Display(Name = "银行地址")]
        public string BankAddress { get; set; }

        [Display(Name = "Swift Code")]
        public string SwiftCode { get; set; }

        
        [Display(Name = "其他信息")]
        public string OtherInf { get; set; }

        [Display(Name = "办公地址")]
        public string OfficeAddress { get; set; }

        [Display(Name = "公司章程")]
        public string Constitution { get; set; }

        [Display(Name = "股份说明")]
        public string StockComment { get; set; }
        public bool UsedAsBusiness { get; set; } //用于业务，比如业务员的公司选择
        public bool UsedAsShare { get; set; }   //用于股份管理，记录所有投入资金的公司

        //public ICollection<Shareholder> Shareholders { get; set; }
    }
}
