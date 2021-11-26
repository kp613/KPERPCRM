using API.Models.ProductModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ProductModels
{
    public class ProductsInCategory
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
