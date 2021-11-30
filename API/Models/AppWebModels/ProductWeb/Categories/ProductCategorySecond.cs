using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.AppWebModels.ProductWeb.Categories
{
    public class ProductCategorySecond
    {
        //二级类别如产品类别中的原料药、砌块等；管控产品中的如：毒品、DEC、危化品等
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Key]
        public int Id { get; set; }

        public int ProductCategoryFirstId { get; set; }

        [Display(Name = "类别名称")]
        [Required]
        public string NameCh { get; set; }

        [Display(Name = "Class Name")]
        public string NameEn { get; set; }

        public ProductCategoryFirst ProductCategoryFirst { get; set; }
        public ICollection<ProductCategoryThird> ProductsGroupThirds { get; set; }

    }
}
