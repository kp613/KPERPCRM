using API.Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.Params
{
    public class DesignRecordParams : PageParams
    {
        //public string searchCasNo { get; set; }
        //public string OrderBy { get; set; } = "updateDay";

        public int Draw { get; set; } = 1;       //page number
        public int Length { get; set; } = 5;     //page size
    }
}
