using API.Models.CommonModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.CustomerModels
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public enum AddressType
        {
            办公地址, 发票地址, 送货地址, 生产地址, 其他地址
        }

        [Display(Name = "联系人")]
        [Required]
        public string ContacterName { get; set; }

        [Display(Name = "手机")]
        public string Mobile { get; set; }

        [Display(Name = "电话")]
        public string Telephone { get; set; }

        [Display(Name = "地址")]
        public string Address { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public Area CityOrDevZone { get; set; }

        [Display(Name = "邮编")]
        public string ZipCode { get; set; }

        [ForeignKey("CompanyId")]
        public Customer Customer { get; set; }


    }
}
