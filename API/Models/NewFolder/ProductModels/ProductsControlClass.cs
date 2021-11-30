using API.Models.ApplicationModels.Products;
using API.Models.AppWebModels.ProductWeb.Categories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ProductModels
{
    //管控类产品和不想宣传的产品
    public class ProductsControlClass
    {
        public int Id { get; set; }
        public bool PermissionSell { get; set; }       //true:可以销售，比如获得许可的危化品

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ICollection<Product> Products { get; set; }

        public int ClassThirdId { get; set; }
        [ForeignKey("ClassThirdId")]
        public ICollection<ProductCategoryThird> ClassThirds { get; set; }


    }
}
