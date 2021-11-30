using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.AdminModels
{
    public class OurDeliveryAddress
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="收件地址")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "收件人")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "联系电话")]
        public string Mobile { get; set; }

        [Display(Name = "备注")]
        public string Comment { get; set; }
    }
}
