using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.CustomerModels
{
    public class CustomerBank
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }

        [Display(Name = "开户行")]
        [Required]
        public string BankName { get; set; }

        [Display(Name = "开户行地址")]
        [Required]
        public string BankAddress { get; set; }

        [Display(Name = "银行账号")]
        [Required]
        public string BankNumber { get; set; }

        [Display(Name = "Swift")]
        public string BankSwiftCode { get; set; }


        [Display(Name ="已作废")]
        public DateTime IsCanceled { get; set; }

        [ForeignKey("CompanyId")]
        public Customer Customer { get; set; }
    }
}
