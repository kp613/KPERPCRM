using API.Models.CustomerModels;
using API.Models.ProductModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.BusinessModels
{
    public class QuoteForPurchase
    {
        public int Id { get; set; }
        public int InquiryId { get; set; }
        public int CompanyContacterId { get; set; }

        [Required]
        [Display(Name = "其他条款")]
        public string OtherTerms { get; set; }

        [ForeignKey("InquiryId")]
        public Inquiry Inquiry { get; set; }

        [ForeignKey("CompanyContacterId")]
        public CustomerContacter CompanyContacter { get; set; }

    }
}
