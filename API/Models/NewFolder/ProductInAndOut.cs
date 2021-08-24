using System.Collections.Generic;

namespace API.Models.ProductModels
{
    public class ProductInAndOut
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public float Quantity{ get; set; }

        public string Unit { get; set; }

        public bool InOrOut { get; set; } //true: 入库，false: 出库

        public string UserId { get; set; }


        public ICollection<Inventory> Inventories { get; set; }
    }
}
