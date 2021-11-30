using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.WebModels
{
    public class WebMessageCategory
    {
        public int Id { get; set; }

        [Display(Name="外网信息类别")]
        public string MsgCategoryName { get; set; }

        public ICollection<WebMessage> WebMessages { get; set; }
    }
}
