using API.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.BusinessModels
{
    public class OrderSell_Backup
    {
        public int Id { get; set; }
        public int InquiryId { get; set; }
        public int InquiriedProductId { get; set; }
        public int CompanyId { get; set; }
        public int CompanyContacterId { get; set; }

        public string SalesMan { get; set; }

        [Display(Name="订单日期")]
        public DateTime OrderPlaced { get; set; }

        [Required]
        [Display(Name = "交货日期"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "合同条款")]
        public string ContractTerms { get; set; }

        public int MyCompanyId { get; set; }

        [Display(Name = "现金")]
        public bool IsCash { get; set; }

        public string AuditMan { get; set; }

        [Display(Name = "审核日期"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderAudited { get; set; }

        [Display(Name = "完成时间"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderFulfilled { get; set; }

        [ForeignKey("CompanyContacterId")]
        public CustomerContacter CompanyContacter { get; set; }

        [ForeignKey("InquiriedProductId")]
        public InquiriedProduct InquiriedProduct { get; set; }


        public ICollection<OrderSellProduct> OrderSellProducts { get; set; }
    }
}
