using API.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ProductsDtos
{
    public class ProductCategoryFirstDto
    {
        public int Id { get; set; }

        public string NameCh { get; set; }

        public string NameEn { get; set; }

        public ICollection<ProductCategorySecondDto> ProductsGroupSecondDto { get; set; }
    }
}
