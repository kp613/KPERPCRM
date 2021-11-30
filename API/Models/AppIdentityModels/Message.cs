using API.Models.IdentityModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.AppIdentityModels
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string SenderUsername { get; set; }        
        public string RecipientId { get; set; }
        public string RecipientUsername { get; set; }
        public string Content { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; } = DateTime.Now;
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }

        [ForeignKey("SenderId")]
        public ApplicationUser Sender { get; set; }

        [ForeignKey("RecipientId")]
        public ApplicationUser Recipient { get; set; }
    }
}
