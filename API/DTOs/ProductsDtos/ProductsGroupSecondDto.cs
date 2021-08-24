using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ProductsDtos
{
    public class ProductsGroupSecondDto
    {
        public int Id { get; set; }

        public int ProductsGroupFirstId { get; set; }

        public string NameCh { get; set; }

        public string NameEn { get; set; }

        public ICollection<ProductsGroupThirdDto> ProductsGroupThirdDto { get; set; }
    }
}
