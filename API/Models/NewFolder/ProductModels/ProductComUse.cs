using API.Models.ApplicationModels.Products;
using System.ComponentModel.DataAnnotations;

namespace API.Models.ProductModels
{
    //产品用途
    public class ProductComUse
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name ="Use")]
        public string UseInEn { get; set; }

        [Display(Name = "用途")]
        public string UseInCh { get; set; }

        public Product Product { get; set; }
    }
}
