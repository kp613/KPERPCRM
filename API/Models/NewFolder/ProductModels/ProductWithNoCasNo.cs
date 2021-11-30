using System.ComponentModel.DataAnnotations;

namespace API.Models.ProductModels
{
    //用于没有CAS No的产品的记录，如提取物、新材料、复配的精细化学品等
    public class ProductWithNoCasNo
    {
        public int Id { get; set; }

        [Display(Name ="产品名称")]
        public string NameCh { get; set; }

        [Display(Name = "Product Name")]
        public string NameEn { get; set; }

        [Display(Name = "Commodity Code")]      //供应商所提供的通用商品代号
        public string CommodityCode { get; set; }

        public enum ProductClass            //产品类别
        {
            提取物=1,新材料=2,复配产品=3
        }
    }
}
