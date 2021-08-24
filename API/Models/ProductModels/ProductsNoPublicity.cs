using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ProductModels
{
    //排除产品
    public class ProductsNoPublicity
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name ="受控类型")]
        public int TypeForControl { get; set; }
        public enum EControl { 
            毒品_不得经营 = 1010, 
            DEA管制化学品_不得经营 = 1013, 
            化学武器及前体_不得经营 = 1015, 
            剧毒化学品_不得经营 = 1020,
            麻醉药品和精神药品管制_谨慎经营=1031,
            易制爆产品_申报经营=1033,
            易制毒产品_申报经营=1035,
            兴奋剂_谨慎经营=1037,
            目录危化品=1041,
            非目录危化品_谨慎经营=1045,
            管控产品前体_谨慎经营=1047,
            暂时放弃_不想做_不合适=1050,
            客户保护或专利期产品=1060,
            没有能力开发或无货源=1070,
            过时产品_淘汰产品=1080,
            基础化工品=1090
        }
        //1043	目录危化品，有资质，可以凯美西操作

        [Display(Name = "例外")]      //如有资质的目录危化品或者客户保护或专利期内，我们还是想宣传的
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public bool? IsException { get; set; }

        public string Remark { get; set; }      //备注，如某精神类产品的前体，如：2019年开发失败等

        [Display(Name = "整理者")]
        public string SettleMan { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "更改时间")]
        public DateTime UpdateDay { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
