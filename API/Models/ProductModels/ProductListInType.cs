using API.Models.ProductModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class ProductListInType
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }
    }
}
