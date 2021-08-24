using API.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.BusinessModels
{
    public class SellQuoteDetail
    {
        public int Id { get; set; }
        public int InquiryId { get; set; }
        public int InquiriedProductId { get; set; }
        public int CompanyId { get; set; }
        public int CompanyContacterId { get; set; }
        public int SellQuoteId { get; set; }

        [Required]
        [Display(Name = "数量")]
        public decimal Quantity { get; set; }

        public enum QuantityUnit
        {
            Kg, g, mg, MT, ml
        }

        [Required]
        [Display(Name = "单价"), DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C}")]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public enum CurrencyType
        {
            RMB, USD
        }

        [Display(Name = "小计金额")]
        public decimal TotalPrice
        {
            get { return Math.Round(Quantity * UnitPrice, 2); }
        }


        [ForeignKey("InquiryId")]
        public Inquiry Inquiry { get; set; }

        [ForeignKey("InquiriedProductId")]
        public InquiriedProduct InquiriedProduct { get; set; }

        [ForeignKey("CompanyId")]
        public Customer Company { get; set; }

        [ForeignKey("SellQuoteId")]
        public QuoteForSell SellQuote { get; set; }
    }
}
