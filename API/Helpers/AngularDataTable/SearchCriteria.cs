using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.AngularDataTable
{
    public class SearchCriteria
    {
        public string Filter { get; set; }
        public bool IsPageLoad { get; set; } = true;
    }
}
