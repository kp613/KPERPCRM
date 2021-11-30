using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.WebModels
{
    public class WebUser
    {
        public string Id { get; set; }

        [Display(Name="姓名")]
        public string Name { get; set; }
    }
}
