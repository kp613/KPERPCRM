using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class ProductParams : PageParams
    {
        public string CasNo { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameCN { get; set; }
        public string OrderBy { get; set; } = "updateDay";
    }
}

