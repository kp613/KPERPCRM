using API.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.BusinessModels
{
    public enum InquiryStatus
    {
        Pending,        //询单已认领
        Processing,     //询价中
        Completed,      //询价完成
        Cancelled,      //询价取消
    }

    public class InquiriedProduct
    {
        public int Id { get; set; }
        public int InquiryId { get; set; }
        public int ProductId { get; set; }
        //[Required]
        //public string ContentForProduct { get; set; }      //客户询价内容

        public InquiryStatus InquiryStatus { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;


        [ForeignKey("InquiryId")]
        public Inquiry Inquiry { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public ICollection<PriceFromSupplier> PriceFromSupplier { get; set; }
        public PriceForCustomer PriceForCustomer { get; set; }
    }
}
