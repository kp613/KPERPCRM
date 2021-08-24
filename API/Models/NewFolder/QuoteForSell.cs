using API.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.BusinessModels
{
    public class QuoteForSell
    {
        public int Id { get; set; }
        public int InquiryId { get; set; }
        public int InquiriedProductId { get; set; }
        public int CompanyId { get; set; }
        public int CompanyContacterId { get; set; }

        [Required]
        [Display(Name = "其他条款")]
        public string OtherTerms { get; set; }

        [ForeignKey("InquiryId")]
        public Inquiry Inquiry { get; set; }

        [ForeignKey("InquiriedProductId")]
        public InquiriedProduct InquiriedProduct { get; set; }

        [ForeignKey("CompanyId")]
        public Customer Company { get; set; }

        [ForeignKey("CompanyContacterId")]
        public CustomerContacter CompanyContacter { get; set; }

        public ICollection<SellQuoteDetail> SellQuoteDetails { get; set; }
    }
}
