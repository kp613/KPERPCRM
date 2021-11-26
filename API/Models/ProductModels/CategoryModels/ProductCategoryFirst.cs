using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ProductModels
{
    public class ProductCategoryFirst
    {
         //原料药  生化化学品  天然产物 催化剂 合成砌块 对照品 功能化学品 材料化学品 杂类
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string NameCh { get; set; }

        [Required]
        public string NameEn { get; set; }

        public ICollection<ProductCategorySecond> ProductsGroupSeconds { get; set; }

    }
}
