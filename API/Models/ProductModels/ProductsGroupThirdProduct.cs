using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ProductModels
{
    //各分类产品
    public class ProductsGroupThirdProducts
    {
        [Key]
        public int Id { get; set; }

        public bool IsVerified { get; set; } = false;     //true:经过确认过的分类

        public int ProductId { get; set; }
  
        public int ProductsGroupThirdId { get; set; }

        public Product Product { get; set; }
        public ProductsGroupThird ProductsGroupThird { get; set; }
    }
}
