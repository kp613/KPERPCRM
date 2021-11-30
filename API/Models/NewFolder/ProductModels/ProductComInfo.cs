using API.Models.ApplicationModels.Products;
using System.ComponentModel.DataAnnotations;

namespace API.Models.ProductModels
{
    //产品的相关信息
    public class ProductComInfo
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "报价建议")]
        public string QuoteSuggest { get; set; }

        [Display(Name = "信息")]
        public string Remark { get; set; }

        public Product Product { get; set; }
    }
}
