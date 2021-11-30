using API.Models.ApplicationModels.Settings;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.AppCoreModels
{
    public class ShareholderForCompany
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "所属公司")]
        public int OurCompanyId { get; set; }

        [Display(Name = "股东")]
        [Required]
        public int ShareholderId { get; set; }

        [Display(Name = "认缴金额(元)")]
        [DisplayFormat(DataFormatString ="{0:N0}")]
        public double SubscribedStock { get; set; }

        [Display(Name = "认缴日期")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SubscribedDate { get; set; }

        [Display(Name = "实缴金额(元)")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public double PaidTotal { get; set; }

        [ForeignKey("OurCompanyId")]
        public OurCompany OurCompany { get; set; }

        [ForeignKey("ShareholderId")]
        public Shareholder Shareholder { get; set; }
        
    }
}
