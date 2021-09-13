using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.AdminDtos
{
    public class RoleDto
    {
        public string Name { get; set; }
        public int IdentityType { get; set; }
        public string Statement { get; set; }
        public int IdentityId { get; set; }
    }
}
