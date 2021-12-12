using API.Models.AppDevModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.AngularDataTable
{
    public class PagingResponse
    {
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }

        public DesignRecord[] DesignRecords { get; set; }
    }
}
