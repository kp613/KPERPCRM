using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ProductModels
{
    public class ProductsGroupThird
    {
        //三级类别原料药中的心脑血管药、艾滋病药等；砌块中的如：吡啶类、[1,5b-]等
        public int Id { get; set; }

        public int ProductsGroupSecondId { get; set; }

        [Display(Name = "类别名称")]
        [Required]
        public string NameCh { get; set; }

        [Display(Name = "Class Name")]
        public string NameEn { get; set; }

        [Display(Name = "自动生成")]
        public bool AutoGenerate { get; set; }

        public string Remark { get; set; }      //备注

        public string KeyElement { get; set; }      //关键元素，如Fe、Pt等
        public string KeyWordCN { get; set; }      //中文关键词

        //英文关键词，1-4是以and相连，1 and 2……
        public string KeyWordEn1 { get; set; }      
        public string KeyWordEn2 { get; set; }  
        public string KeyWordEn3 { get; set; }  
        public string KeyWordEn4 { get; set; }  

        //英文关键词，1-3之间是or关系，但和KeyWordEn1-4是And关系
        public string OrKeyWordEn1 { get; set; }      
        public string OrKeyWordEn2 { get; set; } 
        public string OrKeyWordEn3 { get; set; }

        public string OrKeyWordEn { get; set; }      //英文关键词，和KeyWordEn1-4是Or关系

        //英文关键词，排除关系，1-5之间是or关系，但和KeyWordEn1-4是And关系
        public string NoKeyWordEn1 { get; set; }
        public string NoKeyWordEn2 { get; set; } 
        public string NoKeyWordEn3 { get; set; }
        public string NoKeyWordEn4 { get; set; } 
        public string NoKeyWordEn5 { get; set; }

        //like KeyElement 
        //and like KeyWordCN 
        //and like (KeyWordEn1 and KeyWordEn2 and KeyWordEn3 and KeyWordEn4) 
        //and like (OrKeyWordEn1 or OrKeyWordEn2 or OrKeyWordEn3) 
        //or like OrKeyWordEn 
        //and not like (NoKeyWordEn1 or NoKeyWordEn2 or NoKeyWordEn3 or NoKeyWordEn4 or NoKeyWordEn5)

        public ICollection<ProductsGroupThirdProducts> ProductsGroupThirdProducts { get; set; }

        [ForeignKey("ProductsGroupSecondId")]
        public ProductsGroupSecond ProductsGroupSecond { get; set; }



    }
}
