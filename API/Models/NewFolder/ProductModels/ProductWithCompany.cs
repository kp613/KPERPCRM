using API.Models.ApplicationModels.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models.ProductModels
{
    public class ProductWithCompany
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public bool IsGoldForProduct { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UpdateTime { get; set; }

        [Display(Name = "收集人")]
        public string InputMan { get; set; }


        //public ICollection<Customer> Companies { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
