using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.WebModels
{
    public class WebMessage
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "信息标题")]
        public string MsgName { get; set; }

        [Display(Name = "信息内容")]
        public string Description { get; set; }

        [Display(Name = "已发布内容")]
        public string ActiveDescription { get; set; }

        [Display(Name = "发布者")]
        public string PublisherId { get; set; }

        [Display(Name = "定稿人")]
        public string Finalizer { get; set; }

        [Display(Name = "审核者")]
        public string Auditor { get; set; }

        [Display(Name = "上级审核人")]
        public string AuditorId { get; set; }   //送审对象

        [Display(Name = "公开发布")]
        public bool IsActive { get; set; }

        [Display(Name = "删除")]
        public bool IsDeleted { get; set; }

        [Display(Name = "申请审批")]
        public bool ApplyingFor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "修改时间")]
        public DateTime Updatetime { get; set; }

        [Display(Name = "外网信息类别")]
        public int WebMessageCategoryId { get; set; }

        //[ForeignKey("WebMessageCategoryId")]
        public WebMessageCategory WebMessageCategory { get; set; }


        [ForeignKey("PublisherId")]
        public WebUser WebUserPublisher { get; set; }

        [ForeignKey("AuditorId")]
        public WebUser WebUserAuditor { get; set; }

        [ForeignKey("Finalizer")]
        public WebUser WebUserFinalizer { get; set; }
        

    }
}
