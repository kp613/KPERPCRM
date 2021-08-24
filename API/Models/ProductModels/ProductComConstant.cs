using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ProductModels
{
    //产品常数
    public class ProductComConstant
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "分子式")]
        public string MolecularFormula { get; set; }

        [Display(Name = "分子量")]
        public string MolecularWeight { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
