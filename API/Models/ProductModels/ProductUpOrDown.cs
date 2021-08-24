using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ProductModels
{
    //用来记录这个产品的上游和下游相关产品信息
    public class ProductUpOrDown
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public bool UpOrDown { get; set; }

        public int UpOrDownId { get; set; }
        [ForeignKey("UpOrDownId")]
        public Product Product { get; set; }
    }
}
