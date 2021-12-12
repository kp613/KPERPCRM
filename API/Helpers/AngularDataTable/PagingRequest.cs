using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.AngularDataTable
{
    public class PagingRequest
    {
        public int Draw { get; set; }
        public IList<Column> Columns { get; set; }
        public IList<Order> Order { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public Search Search { get; set; }
        public SearchCriteria SearchCriteria { get; set; }

    }
}
