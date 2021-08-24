using System.ComponentModel.DataAnnotations;

namespace API.Models.ProductModels
{
    public class ProductComInstruction
    {
        //产品说明书
        [Key]
        public int ProductId { get; set; }

        [Display(Name ="Product Instruction")]
        public string Instruction { get; set; }

        public Product Product { get; set; }
    }
}
