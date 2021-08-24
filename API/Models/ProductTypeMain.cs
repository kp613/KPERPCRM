using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class ProductTypeMain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameCN { get; set; }

        public ICollection<ProductType> ProductTypes { get; set; }
    }
}
