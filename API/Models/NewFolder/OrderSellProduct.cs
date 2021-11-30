using API.Models.ApplicationModels.Products;
using API.Models.ProductModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.BusinessModels
{
    public class OrderSellProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [Required]
        [Display(Name ="数量")]
        public decimal Quantity { get; set; }

        public enum QuantityUnit
        {
            Kg,g,mg,MT,ml
        }

        [Required]
        [Display(Name = "单价"), DataType(DataType.Currency),DisplayFormat(DataFormatString = "{0:C}")]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public enum CurrencyType 
        { 
            RMB,USD
        }

        [Required]
        [Display(Name = "当天汇率")]
        public decimal ExchangeRate { get; set; }

        [Required]
        [Display(Name = "质量条款")]
        public string QualityTerms { get; set; }

        [Display(Name = "小计金额")]
        public decimal TotalPrice
        {
            get { return Math.Round(Quantity * UnitPrice,2); }
        }

        [Display(Name ="合计人民币"), DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalPriceRMB
        {
            get { return Quantity * UnitPrice * ExchangeRate; }
        }

        public int OrderSellId { get; set; }

        //[ForeignKey("OrderSellId")]
        //public OrderSell OrderSell { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
