using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ProductsDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string CasNo { get; set; }

        public string ProductName { get; set; }

        public string ProductNameCN { get; set; }

        public string ProductCode { get; set; }
    }
}
