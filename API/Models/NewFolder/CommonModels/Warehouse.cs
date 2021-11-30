using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.CommonModels
{
    public class Warehouse
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="库房名称")]
        public string Name { get; set; }

        [Display(Name = "库房属地")]
        public string Department { get; set; }

        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "联系人")]
        public string Principal { get; set; }   //库房所有人，若为承租的库房，则为房东。如太和 李天赋

        [Display(Name = "联系电话")]
        public string Tel { get; set; }

        [Display(Name = "承租单价")]
        public double Price { get; set; }

        [Display(Name = "结算周期")]
        public PayPeriod? PayPeriod { get; set; }

    }

    public enum PayPeriod
    {
        年, 季, 月
    }
}
