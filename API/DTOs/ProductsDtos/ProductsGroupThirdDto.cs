using API.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ProductsDtos
{
    public class ProductsGroupThirdDto
    {
        public int Id { get; set; }

        public int ProductsGroupSecondId { get; set; }


        public string NameCh { get; set; }

        public string NameEn { get; set; }

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


        public ICollection<ProductsGroupThirdProducts> ProductsGroupThirdProductsDto { get; set; }

    }
}
