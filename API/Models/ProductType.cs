using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameCN { get; set; }

        public int ProductTypeMainId { get; set; }

        public ProductTypeMain ProductTypeMain { get; set; }

        public ICollection<ProductListInType> ProductListInTypes { get; set; }
    }
}
