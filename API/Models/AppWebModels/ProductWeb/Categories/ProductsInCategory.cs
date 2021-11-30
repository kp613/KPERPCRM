using API.Models.ApplicationModels.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.AppWebModels.ProductWeb.Categories
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
