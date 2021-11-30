using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.CustomerModels
{
    public class CustomerRelateAnother
    {
        [Key]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [Display(Name ="关联公司")]
        public int CustomerRelateId { get; set; }
        

    }
}
