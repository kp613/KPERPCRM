using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.CommonModels
{
    public class CommonContent
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name="信息标题")]
        public string Name { get; set; }

        [Display(Name = "信息内容")]
        public string Description { get; set; }

        [Display(Name = "发布者")]
        public string Publisher { get; set; }

        [Display(Name = "定稿人")]
        public string Finalizer { get; set; }

        [Display(Name = "上级审核人")]
        public string ToAuditor { get; set; }   //送审对象

        [Display(Name = "审核者")]
        public string Auditor { get; set; }

        [Display(Name = "公开发布")]
        public bool IsActive { get; set; }

        [Display(Name = "高管")]
        public bool ForGeneralManager { get; set; }

        [Display(Name = "部门经理")]
        public bool ForDepartmentManager { get; set; }

        [Display(Name = "班组长")]
        public bool ForGroupLeader { get; set; }

        [Display(Name = "不对试用期员工开放")]
        public bool NotForProbationStaff { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "修改时间")]
        public DateTime Updatetime { get; set; }

        [Display(Name = "类别")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CommonCategory CommonCategory { get; set; }

        [Display(Name = "次类别")]
        public int SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual CommonSubCategory CommonSubCategory { get; set; }

        //[ForeignKey("Id")]
        //public ICollection<AuditAndAuthorization> AuditAndAuthorizations { get; set; }


    }
}
