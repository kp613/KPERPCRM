using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ProductModels
{
    public class ProductRelevantArray
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string RelevantArray { get; set; }
        public string Remark { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
