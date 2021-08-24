using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.BusinessModels
{
    public class MessageForQuote
    {
        public int Id { get; set; }
        public int InquiryId { get; set; }
        [Required]
        public string Message { get; set; }
        public bool ForSupplier { get; set; }
        public DateTime RecordDate { get; set; }
        public string Recorder { get; set; }
        public bool IsDeleted { get; set; }
    }
}
