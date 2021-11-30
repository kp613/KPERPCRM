using API.Models.ApplicationModels.Settings;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.AppCoreModels
{

    public class ShareInvestment
    {
        //public ShareInvestment()
        //{
        //    ShareOption = 0;
        //    ShareConvert = 0;
        //    GiveShare = 0;
        //}

        public int Id { get; set; }

        [Display(Name = "公司名称")]
        [Range(1, int.MaxValue, ErrorMessage = "请选择一家您所投资的公司")]
        public int OurCompanyId { get; set; }

        [Display(Name = "股东姓名")]
        [Range(1, int.MaxValue, ErrorMessage = "请选择股东姓名")]
        public int ShareholderId { get; set; }

        [Display(Name = "登记日期")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        [Display(Name = "实缴金额")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public double PaidIn { get; set; }     //实缴金额

        [Column(TypeName = "decimal(18,0)")]
        [Display(Name = "折算股份")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public double ShareConvert { get; set; }       //实缴金额折算成股份数

        [Column(TypeName = "decimal(18,0)")]
        [Display(Name = "赠送虚拟股")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public double GiveShare { get; set; }      //赠送干股

        [Display(Name = "备注")]
        public string Comment { get; set; }

        [Display(Name = "登记人")]
        public string Registrant { get; set; }      //登记人

        [Display(Name = "股份审核时间")]
        public DateTime? LockoutEnd { get; set; }    //股份审核至有效期，设置当日 + 100，若null，则表示未经审核，若小于当前时间，表示已经退股

        [Column(TypeName = "money")]
        [Display(Name = "股份小计")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public double SubTotalShare
        {
            get
            {
                if (DateTime.Now > GetShareDate)
                {
                    return ShareConvert + GiveShare + ShareOption;
                }
                else
                {
                    return ShareConvert + GiveShare;
                }

            }
        }

        [Column(TypeName = "decimal(18,0)")]
        [Display(Name = "期权股数")]
        public double ShareOption { get; set; }

        [Display(Name = "行权日期")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? GetShareDate { get; set; }

        [ForeignKey("ShareholderId")]
        public Shareholder Shareholder { get; set; }

        [ForeignKey("OurCompanyId")]
        public OurCompany OurCompany { get; set; }
    }
}
