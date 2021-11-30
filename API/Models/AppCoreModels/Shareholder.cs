using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.AppCoreModels
{
    public class Shareholder
    {
        public int Id { get; set; }

        [Display(Name="股东姓名")]
        public string Name { get; set; }

        [Display(Name = "股东识别号(身份证号)")]
        public string IDNumber { get; set; }

        [Display(Name = "股东备注")]
        public string Comment { get; set; }

        [Display(Name = "注销日期")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}")]
        public DateTime? LockoutEnd { get; set; }   //该股东名下把股份设为0后可以出局
    }
}
