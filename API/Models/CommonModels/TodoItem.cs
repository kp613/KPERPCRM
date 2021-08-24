using API.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.CommonModels
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        [Display(Name ="完成")]
        public bool IsDone { get; set; }

        [Display(Name = "完成日期")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? IsDoneDate { get; set; }

        [Display(Name = "事项内容")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "执行日期")]
        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueAt { get; set; }

        [Display(Name = "执行人")]
        public string UserId { get; set; }

        [Display(Name = "事项安排人")]
        public string SubmitterId { get; set; }

        [Display(Name = "安排日期")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SubmitDate { get; set; }

        [Display(Name = "关联事项")]
        public Guid? TaskConnectedId { get; set; }

        public string TodoArea { get; set; }
        public string TodoController { get; set; }
        public string TodoAction { get; set; }


        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("SubmitterId")]
        public ApplicationUser ApplicationUserSubmitter { get; set; }

    }
}
