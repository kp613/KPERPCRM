using API.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.CommonModels
{
    public class Area
    {
        public enum AreaLevel
        {
            国家=1,省或州=2,市=3,区县或开发区=6
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name ="国家代码")]
        public int CountryCode { get; set; }

        public string AreaNameCh { get; set; }      //区域名称，如国家：中国，省：江苏或上海或California，市：南京，区县：鼓楼 或 高淳
        public string AreaNameEn { get; set; }

        [Display(Name ="代号")]
        public string AreaCode { get; set; }        //区域代号，如加州：CA，江苏：JS，南京：NJ

        public int ParentId { get; set; }           //上一级代码，假如中国=1，江苏=10，南京市=100，则父级代码：江苏为1，南京为10



        public ICollection<CustomerAddress> CustomerAddress { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
