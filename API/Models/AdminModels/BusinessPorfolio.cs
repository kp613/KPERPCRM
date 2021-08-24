using API.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.AdminModels
{
    public class BusinessPorfolio
    {
        public int Id { get; set; }

        [Display(Name = "业务名称")]
        public string Name { get; set; }

        public ICollection<BusinessUserGroup> BusinessUserGroups { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
