using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ProductModels
{
    public class ProductsGroupSecond
    {
        //二级类别如产品类别中的原料药、砌块等；管控产品中的如：毒品、DEC、危化品等
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        public int ProductsGroupFirstId { get; set; }

        [Display(Name = "类别名称")]
        [Required]
        public string NameCh { get; set; }

        [Display(Name = "Class Name")]
        [Required]
        public string NameEn { get; set; }

        public ProductsGroupFirst ProductsGroupFirst { get; set; }
        public ICollection<ProductsGroupThird> ProductsGroupThirds { get; set; }

    }
}
