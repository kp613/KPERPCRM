using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ProductModels
{
    public enum UnitOfQuantity
    {
        kg,g,mt,mg,L,ml
    }

    //批号 入库
    public class Batch
    {
        public int Id { get; set; }

        public string BatchNumber { get; set; }

        [Display(Name="数量")]        //数量单位统一折算成公斤表示
        [Column(TypeName = "decimal(10,6)")]
        public decimal Quantity { get; set; }

        public string UnitOfQuantity { get; set; }

        public ICollection<Inventory> Inventories { get; set; }

    }
}
