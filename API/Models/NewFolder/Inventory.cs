using API.Models.ApplicationModels.Products;
using API.Models.CommonModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ProductModels
{
    public class Inventory
    {
        public int Id{ get; set; }
        public int ProductId{ get; set; }

        [Display(Name = "批号")]
        public int BatchId { get; set; }

        [Display(Name ="同批序号")]
        public int Lable { get; set; }

        public int PackageId { get; set; }

        [ForeignKey("PackageId")]
        public Package Package { get; set; }

        public int WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
