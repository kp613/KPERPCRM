using API.Models.CommonModels;
using API.Models.IdentityModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.AdminModels
{
    public class AuditAndAuthorization
    {
        public Guid Id { get; set; }
        public string RoleOrUserId { get; set; }

        [ForeignKey("RoleOrUserId")]
        public ApplicationRole ApplicationRole { get; set; }

        [ForeignKey("RoleOrUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public Guid ContentId { get; set; }

        [ForeignKey("ContentId")]
        public CommonContent Content { get; set; }

    }
}
