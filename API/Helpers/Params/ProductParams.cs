using API.Helpers.Pagination;

namespace API.Helpers.Params
{
    public class ProductParams : PageParams
    {
        public string CasNo { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameCN { get; set; }

        public string searchCasNo { get; set; }
        public string OrderBy { get; set; } = "updateDay";
    }
}

