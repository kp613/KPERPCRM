using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.CustomerModels
{
    public class CustomerInvoiceInfo
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }


        [Display(Name = "财务联系人")]
        public string FinantialName { get; set; }

        [Display(Name = "Mobile")]
        public string FinantialMobile { get; set; }

        [Display(Name = "电话")]
        public string FinantialTel { get; set; }

        [Display(Name = "邮箱")]
        public string FinantialEmail { get; set; }


        [ForeignKey("CompanyId")]
        public Customer Customer { get; set; }
    }
}
