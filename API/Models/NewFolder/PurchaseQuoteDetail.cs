using API.Models.ApplicationModels.Products;
using API.Models.CustomerModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.BusinessModels
{
    public class PurchaseQuoteDetail
    {
        public int Id { get; set; }
        public int InquiryId { get; set; }
        public int InquiriedProductId { get; set; }
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public int CompanyContacterId { get; set; }
        public int PurchaseQuoteId { get; set; }

        [Required]
        [Display(Name = "数量")]
        public double Quantity { get; set; }

        public enum QuantityUnit
        {
            Kg, g, mg, MT, ml
        }

        [Required]
        [Display(Name = "单价"), DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C}")]
        [Column(TypeName = "money")]
        public double UnitPrice { get; set; }

        public enum CurrencyType
        {
            RMB, USD,
        }

        [Display(Name = "小计金额")]
        public double TotalPrice
        {
            get { return Math.Round(Quantity * UnitPrice, 2); }
        }


        [ForeignKey("InquiryId")]
        public Inquiry Inquiry { get; set; }

        [ForeignKey("InquiriedProductId")]
        public InquiriedProduct InquiriedProduct { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("CompanyId")]
        public Customer Company { get; set; }

        [ForeignKey("PurchaseQuoteId")]
        public QuoteForPurchase PurchaseQuote { get; set; }
    }
}
