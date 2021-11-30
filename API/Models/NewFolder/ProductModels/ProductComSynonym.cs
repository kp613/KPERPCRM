using API.Models.ApplicationModels.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ProductModels
{
    //产品的其他名称
    public class ProductComSynonym
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Synonyms")]
        public string SynonymsEn { get; set; }

        [Display(Name = "其他名称")]
        public string SynonymsCN { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
